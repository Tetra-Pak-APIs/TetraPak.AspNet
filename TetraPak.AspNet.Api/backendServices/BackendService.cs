using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Supports configuration for an individual backend service, and a collection of service endpoints. 
    /// </summary>
    /// <typeparam name="TEndpoints">
    ///   The <see cref="Type"/> of service endpoints.
    /// </typeparam>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class BackendService<TEndpoints> : IBackendService
    where TEndpoints : ServiceEndpointCollection
    {
        const string TimerGet = "out-get";
        const string TimerPost = "out-post";
        
        /// <inheritdoc />
        public string ServiceName { get; set; }
        
        /// <summary>
        ///   Gets the endpoint configuration.
        /// </summary>
        // ReSharper disable MemberCanBePrivate.Global
        public TEndpoints Endpoints { get; private set; }

        /// <summary>
        ///   Gets a delegate used to provide a <see cref="HttpClient"/>,
        ///   used to consumer the backend service.
        /// </summary>
        protected IHttpServiceProvider HttpServiceProvider { get; private set; }

        /// <summary>
        ///   Gets logging provider.  
        /// </summary>
        protected ILogger? Logger => Endpoints?.Logger;

        /// <inheritdoc />
        public AmbientData AmbientData => Endpoints!.AmbientData;

        public IServiceAuthConfig ParentConfig => AuthConfig;

        /// <summary>
        ///   Gets the Tetra Pak configuration.
        /// </summary>
        protected TetraPakAuthConfig AuthConfig => Endpoints!.AuthConfig;

        /// <inheritdoc />
        public IConfiguration Configuration => AuthConfig.Configuration;

        /// <inheritdoc />
        public ConfigPath? ConfigPath => AuthConfig.ConfigPath;
        
        /// <inheritdoc />
        [StateDump]
        public GrantType GrantType => Endpoints!.GrantType;

        [StateDump]
        public string? ClientId => Endpoints?.ClientId;

        [StateDump]
        public string? ClientSecret => Endpoints?.ClientSecret;

        [StateDump]
        public MultiStringValue? Scope => Endpoints?.Scope;

        /// <inheritdoc />
        public string GetConfiguredValue(string key) => Endpoints!.GetConfiguredValue(key);

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientIdAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken = null) => Endpoints!.GetClientIdAsync(authContext, cancellationToken);

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientSecretAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken = null) => Endpoints!.GetClientSecretAsync(authContext, cancellationToken);

        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken = null) => Endpoints!.GetScopeAsync(authContext, null, cancellationToken);

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext, 
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null)
            => Endpoints!.GetScopeAsync(authContext, useDefault, cancellationToken);
        
        
        /// <inheritdoc />
        public HttpClientOptions DefaultClientOptions => Endpoints!.ClientOptions;
        
        /// <inheritdoc />
        public ServiceEndpoint GetEndpoint(string name) => Endpoints![name];

        internal void DiagnosticsStartTimer(string timerKey)
        {
            (HttpServiceProvider as ITetraPakDiagnosticsProvider)?.DiagnosticsStartTimer(timerKey);
        }

        internal void DiagnosticsEndTimer(string timerKey)
        {
            (HttpServiceProvider as ITetraPakDiagnosticsProvider)?.DiagnosticsEndTimer(timerKey);
        }

        public async Task<Outcome<ActorToken>> AuthenticateAsync(
            HttpClientOptions clientOptions, 
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var accessTokenOutcome  = await HttpServiceProvider.GetAccessTokenAsync(AuthConfig);
            if (accessTokenOutcome)
            {
                clientOptions.Authorization = new BearerToken(accessTokenOutcome.Value.Identity);
            }
            clientOptions.AuthConfig = this;
            return await OnAuthenticateAsync(clientOptions, ct);
        }

        public async Task<Outcome<HttpResponseMessage>> SendAsync(
            HttpRequestMessage request, 
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            clientOptions ??= DefaultClientOptions.WithAuthorization(await HttpServiceProvider.GetAccessTokenAsync());
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, ct);
            if (clientOutcome)
                return Outcome<HttpResponseMessage>.Fail(
                    new Exception("Could not initialize a HTTP client (see inner exception)", 
                        clientOutcome.Exception));
            
            var client = clientOutcome.Value;
            var response = await client.SendAsync(request, ct);
            return response.IsSuccessStatusCode
                ? Outcome<HttpResponseMessage>.Success(response)
                : Outcome<HttpResponseMessage>.Fail(response);
        }

        public async Task<Outcome<HttpResponseMessage>> PostAsync(
            string path,
            HttpContent content,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            clientOptions ??= DefaultClientOptions.WithAuthorization(await HttpServiceProvider.GetAccessTokenAsync());
            var clientOutcome = await OnGetHttpClientAsync(clientOptions ?? DefaultClientOptions, ct); 
            if (!clientOutcome)
                return Outcome<HttpResponseMessage>.Fail(clientOutcome.Exception);
            
            var client = clientOutcome.Value;
            Logger.Trace($"Sending request URI: {path}");
            Logger.Trace($"Sending request HEADERS: {client.DefaultRequestHeaders.Concat()}");
            
#if NET5_0_OR_GREATER
            var contentString = await content.ReadAsStringAsync(ct);
#else
            var contentString = await content.ReadAsStringAsync();
#endif
            Logger.Debug($"Sending request CONTENT: {contentString}");
            DiagnosticsStartTimer(TimerPost);
            var response = await client.PostAsync(path.TrimStart('/'), content, ct);
            DiagnosticsEndTimer(TimerPost);
            return response.IsSuccessStatusCode
                ? Outcome<HttpResponseMessage>.Success(response)
                : Outcome<HttpResponseMessage>.Fail(response);
        }

        /// <inheritdoc />
        public async Task<Outcome<T>> GetAsync<T>(
            string path, 
            IDictionary<string, string> queryParameters, 
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null, 
            string? messageId = null)
        {
            try
            {
                var outcome = await GetAsync(path, queryParameters, clientOptions, cancellationToken, messageId);
                if (!outcome)
                    return Outcome<T>.Fail(outcome.Exception);

                var stream = await outcome.Value.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<T>(stream);
                return Outcome<T>.Success(result!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            string? queryParameters = null,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null,
            string? messageId = null)
        {
            if (!Endpoints!.IsValid)
                return OnServiceConfigurationError(HttpMethod.Get, path, queryParameters, Endpoints.GetIssues()!, messageId);

            var ct = cancellationToken ?? CancellationToken.None;
            clientOptions ??= DefaultClientOptions.WithAuthorization(await HttpServiceProvider.GetAccessTokenAsync());
            var clientOutcome = await OnGetHttpClientAsync(clientOptions ?? DefaultClientOptions, ct); 
            if (!clientOutcome)
                return Outcome<HttpResponseMessage>.Fail(clientOutcome.Exception);

            var client = clientOutcome.Value;
            path = pathWithQueryParameters();
            var url = $"{client.BaseAddress}{path.TrimStart('/')}";
            
            Logger.Trace($"Sending request URI: {url}");
            Logger.Trace($"Sending request HEADERS: {client.DefaultRequestHeaders.Concat()}");

            try
            {
                DiagnosticsStartTimer(TimerGet);
                var response = await client.GetAsync(path.TrimStart('/'), ct);
                DiagnosticsEndTimer(TimerGet);
                return response.IsSuccessStatusCode
                    ? Outcome<HttpResponseMessage>.Success(response)
                    : Outcome<HttpResponseMessage>.Fail(new HttpException(response));
            }
            catch (Exception ex)
            {
                return requestErrorOutcome(ex, HttpMethod.Get, url, messageId);
            }

            string pathWithQueryParameters()
            {
                return string.IsNullOrWhiteSpace(queryParameters) 
                    ? path
                    : $"{path}{queryParameters.Trim().EnsurePrefix("?")}";
            }
        }

        /// <inheritdoc />
        public async Task<Outcome<T>> GetAsync<T>(
            string path, 
            string? queryParameters = null, 
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null, 
            string? messageId = null)
        {
            try
            {
                DiagnosticsStartTimer(TimerGet);
                var outcome = await GetAsync(path, queryParameters, clientOptions, cancellationToken, messageId);
                DiagnosticsEndTimer(TimerGet);
                if (!outcome)
                    return Outcome<T>.Fail(outcome.Exception);

                var stream = await outcome.Value.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<T>(stream);
                return Outcome<T>.Success(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <inheritdoc />
        public Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            IDictionary<string, string> queryParameters,
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null, 
            string? messageId = null)
        {
            return GetAsync(
                path,
                queryParameters.ToUrlQueryParameters(true),
                clientOptions,
                cancellationToken,
                messageId);
        }

        /// <summary>
        ///   Called by an internal method when it discovers a configuration issue,
        ///   allowing for a consistent response to all such issues.
        /// </summary>
        /// <param name="method">
        ///   The request HTTP method.
        /// </param>
        /// <param name="path">
        ///   The request path.
        /// </param>
        /// <param name="queryParameters">
        ///   Any request query parameters.
        /// </param>
        /// <param name="issues">
        ///   A collection of issues found.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <returns></returns>
        protected virtual Outcome<HttpResponseMessage> OnServiceConfigurationError(
            HttpMethod method,
            string path, 
            string? queryParameters, 
            IEnumerable<Exception> issues,
            string? messageId)
        {
            return ServiceConfigHelper.GetServiceConfigurationErrorResponse(
                method,
                path,
                queryParameters,
                issues,
                messageId,
                Logger);
        }
        
        Outcome<HttpResponseMessage> requestErrorOutcome(Exception exception, HttpMethod method, string url, string? messageId)
        {
            Logger.Error(new Exception($"Error while performing request: {method} {url}: {exception.Message}", exception)
                ,messageId:messageId);
            return Outcome<HttpResponseMessage>.Fail(exception);
        }

        protected virtual Task<Outcome<ActorToken>> OnAuthenticateAsync(
            HttpClientOptions options,
            CancellationToken? cancellationToken)
        {
            return HttpServiceProvider.AuthenticateAsync(
                options,
                cancellationToken,
                Logger);
        }

        /// <summary>
        ///   This method gets invoked when the class needs a <see cref="HttpClient"/> instance.
        ///   The calling code expects the returned client to be fully configured according to the
        ///   options specified in <paramref name="clientOptions"/>.
        /// </summary>
        /// <param name="clientOptions">
        ///   Specifies how to configure/authorize the requested client.
        /// </param>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/> to be used for cancelling the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpClient"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual async Task<Outcome<HttpClient>> OnGetHttpClientAsync(
            HttpClientOptions clientOptions, 
            CancellationToken? cancellationToken)
        {
            var clientOutcome = await HttpServiceProvider.GetClientAsync(clientOptions, cancellationToken, Logger);
            if (!clientOutcome)
                return Outcome<HttpClient>.Fail(clientOutcome.Exception);

            var client = clientOutcome.Value;
            if (client.BaseAddress is {})
                return clientOutcome;

            if (string.IsNullOrWhiteSpace(Endpoints.BasePath))
            {
                client.BaseAddress = new Uri(Endpoints.Host.EnsurePostfix("/"));
                return clientOutcome;
            }
            
            client.BaseAddress = new Uri($"{Endpoints.Host.EnsurePostfix("/")}{Endpoints.BasePath.TrimStart('/').EnsurePostfix("/")}");
            return clientOutcome;
        }

        // ReSharper disable once UnusedMember.Global
        internal Outcome<ServiceEndpointCollection> IsInitialized() => Endpoints is { } 
            ? Outcome<ServiceEndpointCollection>.Success(Endpoints) 
            : Outcome<ServiceEndpointCollection>.Fail(new Exception("Not initialized"));

        // internal void Initialize(TEndpoints endpoints, IHttpServiceProvider httpServiceProvider) obsolete
        // {
        //     Endpoints = endpoints ?? throw new ArgumentNullException(nameof(endpoints));
        //     HttpServiceProvider = httpServiceProvider ?? throw new ArgumentNullException(nameof(httpServiceProvider)); 
        //     Endpoints.SetBackendService(this);
        // }

        // public BackendService() obsolete?
        // {
        // }

        public BackendService(TEndpoints endpointCollection, IHttpServiceProvider httpServiceProvider)
        {
            ServiceName = endpointCollection.SectionIdentifier;
            Endpoints = endpointCollection ?? throw new ArgumentNullException(nameof(endpointCollection));
            HttpServiceProvider = httpServiceProvider ?? throw new ArgumentNullException(nameof(httpServiceProvider)); 
            Endpoints.SetBackendService(this);
            // Initialize(endpoints, httpServiceProvider);
        }
    }
}