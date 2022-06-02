using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Debugging;
using TetraPak.Configuration;
using TetraPak.Logging;
using HttpMethod=Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Supports configuration for an individual backend service, and a collection of service endpoints. 
    /// </summary>
    /// <typeparam name="TEndpoints">
    ///   The <see cref="Type"/> of service endpoints.
    /// </typeparam>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class BackendService<TEndpoints> : IBackendService, IAccessTokenProvider
    where TEndpoints : ServiceEndpoints
    {
        readonly string? _serviceName;
        HttpClientOptions? _defaultClientOptions;
        
        const string TimerGet = "out-get";
        const string TimerPost = "out-post";
        const string TimerPut = "out-put";
        const string TimerPatch = "out-patch";
        const string TimerDelete = "out-delete";

        /// <inheritdoc />
        public string ServiceName => _serviceName ?? Endpoints.SectionIdentifier;

        /// <summary>
        ///   Gets the endpoint configuration.
        /// </summary>
        public TEndpoints Endpoints { get; }

        /// <summary>
        ///   Gets logging provider.  
        /// </summary>
        protected ILogger? Logger => Endpoints.Logger;

        /// <inheritdoc />
        public AmbientData AmbientData => Endpoints.AmbientData;

        /// <inheritdoc />
        public IServiceAuthConfig ParentConfig => Config;

        /// <inheritdoc />
        public bool IsAuthIdentifier(string identifier) => TetraPakConfig.CheckIsAuthIdentifier(identifier);
        
        /// <summary>
        ///   Gets the Tetra Pak configuration.
        /// </summary>
        protected TetraPakConfig Config => Endpoints.Config;

        /// <inheritdoc />
        public IConfiguration Configuration => Config.Configuration;

        /// <inheritdoc />
        public ConfigPath? ConfigPath => Config.ConfigPath;
        
        /// <inheritdoc />
        [StateDump]
        public GrantType GrantType => Endpoints.GrantType;

        /// <summary>
        ///   Gets a client identity to be submitted when requesting authorization.
        /// </summary>
        [StateDump]
        public string? ClientId => Endpoints.ClientId;

        /// <summary>
        ///   Gets a client secret to be submitted when requesting authorization.
        /// </summary>
        [StateDump, RestrictedValue(DisclosureLogLevel = LogLevel.Debug)]
        public string? ClientSecret => Endpoints.ClientSecret;

        /// <summary>
        ///   Gets a scope to be requested for authorization.
        /// </summary>
        [StateDump]
        public MultiStringValue Scope => Endpoints.Scope;

        /// <inheritdoc />
        public string GetConfiguredValue(string key, params string[] fallbackKeys) => Endpoints.GetConfiguredValue(key);

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientIdAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken = null) => Endpoints.GetClientIdAsync(authContext, cancellationToken);

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientSecretAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken = null) => Endpoints.GetClientSecretAsync(authContext, cancellationToken);

        /// <summary>
        ///   Gets a scope to be requested for authorization while, optionally, specifying a default scope.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows canceling ot the operation.
        /// </param>
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken = null) => Endpoints.GetScopeAsync(authContext, null, 
            cancellationToken);

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext, 
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null)
            => Endpoints.GetScopeAsync(authContext, useDefault, cancellationToken);
        
        /// <inheritdoc />
        public Task<Outcome<ActorToken>> GetAccessTokenAsync(bool forceStandardHeader = false)
            => Endpoints.GetAccessTokenAsync(forceStandardHeader);
        
        /// <summary>
        ///   Gets or sets a default <see cref="HttpClientOptions"/>, used when sending HTTP requests
        ///   without passing client options.    
        /// </summary>
        public HttpClientOptions DefaultClientOptions
        {
            get => _defaultClientOptions ?? Endpoints.ClientOptions;
            set => _defaultClientOptions = value;
        }
        
        /// <inheritdoc />
        public ServiceEndpoint GetEndpoint(string name) => Endpoints[name];

        /// <summary>
        ///   Returns all service endpoints as a collection of key-value pairs, each
        ///   with the endpoint name as its 'key' element and the actual <see cref="ServiceEndpoint"/> as the value. 
        /// </summary>
        /// <returns>
        ///   A collection of <see cref="KeyValuePair{TKey,TValue}"/> items.
        /// </returns>
        public IEnumerable<KeyValuePair<string,ServiceEndpoint>> GetEndpoints() => Endpoints;

        internal void DiagnosticsStartTimer(string? timerKey)
        {
            if (timerKey is { })
            {
                Endpoints.DiagnosticsStartTimer(timerKey);
            }
        }

        internal long? DiagnosticsEndTimer(string? timerKey)
        {
            if (timerKey is { })
            {
                return Endpoints.DiagnosticsStopTimer(timerKey);
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<Outcome<ActorToken>> AuthorizeAsync(
            HttpClientOptions clientOptions, 
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var accessTokenOutcome  = await GetAccessTokenAsync();
            if (accessTokenOutcome)
            {
                clientOptions.ActorToken = new BearerToken(accessTokenOutcome.Value!.Identity);
            }
            clientOptions.AuthConfig = this;
            return await OnAuthorizeAsync(clientOptions, ct);
        }

        /// <summary>
        ///   Sends a HTTP request and returns the outcome. 
        /// </summary>
        /// <param name="request">
        ///   The HTTP request to be sent.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        ///   Specifies options for creating a client.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows cancelling the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        public Task<HttpOutcome<HttpResponseMessage>> SendAsync(
            HttpRequestMessage request, 
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null) 
        => OnSendAsync(request, resolveDiagnosticsTimer(request), clientOptions, cancellationToken);

        protected virtual async Task<HttpOutcome<HttpResponseMessage>> OnSendAsync(
            HttpRequestMessage requestMessage, 
            string? timer,
            HttpClientOptions? clientOptions,
            CancellationToken? cancellationToken)
        {
            var messageId = AmbientData.GetMessageId(true)!;
            if (!Endpoints.IsValid)
                return OnServiceConfigurationError(requestMessage, Endpoints.GetIssues()!, messageId);
            
            cancellationToken ??= Endpoints.ContextCancellationToken ?? CancellationToken.None;
            if (cancellationToken.IsRequestCancelled())
                return HttpOutcome<HttpResponseMessage>.Fail(
                    HttpMethod.Post,
                    new HttpRequestCancelledException());
            
            var ct = cancellationToken ?? CancellationToken.None;

            var httpMethod = requestMessage.Method.Method.ToHttpMethod();
            var accessTokenOutcome = await GetAccessTokenAsync();
            var grantType = clientOptions?.AuthConfig?.GrantType ?? DefaultClientOptions.AuthConfig?.GrantType ?? GrantType.None;
            if (!accessTokenOutcome && grantType != GrantType.None)
                return HttpOutcome<HttpResponseMessage>.Fail(
                    httpMethod,
                    new Exception("Could not initialize a HTTP client. No access token available", 
                        accessTokenOutcome.Exception));

            var forceAuthorization = false;
            clientOptions ??= accessTokenOutcome
                ? DefaultClientOptions.WithAuthorization(accessTokenOutcome.Value!, Endpoints.AuthorizationService)
                : DefaultClientOptions;

            retry:
            
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, ct);
            if (!clientOutcome)
                return HttpOutcome<HttpResponseMessage>.Fail(
                    httpMethod,
                    HttpServerException.InternalServerError(
                        "Could not initialize a HTTP client (see inner exception)",
                        clientOutcome.Exception));
            
            var client = clientOutcome.Value!;

            try
            {
                var sb = Logger?.IsEnabled(LogLevel.Trace) ?? false
                    ? await (await requestMessage.ToGenericHttpRequestAsync()).ToStringBuilderAsync(
                        new StringBuilder(), 
                        () => TraceHttpRequestOptions
                        .Default(messageId)
                        .WithDirection(HttpDirection.Out, ApiRequestInitiators.SdkBackendService(this))
                        .WithBaseAddress(client.BaseAddress!)
                        .WithDefaultHeaders(client.DefaultRequestHeaders))
                    : null;
                DiagnosticsStartTimer(timer);
                var response = await client.SendAsync(requestMessage, ct);
                var roundTripMs = DiagnosticsEndTimer(timer);
                if (sb is { })
                {
                    sb.AppendLine();
                    var genericResponse = await response.ToGenericHttpResponseAsync(); 
                    await genericResponse.ToStringBuilderAsync(
                        sb,
                        roundTripMs.HasValue
                            ? () => TraceHttpResponseOptions.Default(messageId).WithDetail($"{roundTripMs}ms")
                            : null);
                    Logger.Trace(sb.ToString(), messageId);
                }

                if (response.IsSuccessStatusCode)
                    return HttpOutcome<HttpResponseMessage>.Success(httpMethod, response);

                if (response.StatusCode == HttpStatusCode.Unauthorized && !forceAuthorization)
                {
                    // this deals with a situation where caching has produces an invalid (cached) authorization;
                    // try re-authorizing the client once ...
                    forceAuthorization = true;
                    clientOptions.RequestForcedAuthorization();
                    requestMessage = await requestMessage.CloneAsync();
                    requestMessage.Headers.Remove(HeaderNames.Authorization);
                    goto retry;
                }

                return HttpOutcome<HttpResponseMessage>.Fail(httpMethod, new HttpServerException(response));
            }
            catch (Exception ex)
            {
                return requestErrorOutcome(ex, requestMessage, AmbientData.GetMessageId(true));
            }
        }

        static string? resolveDiagnosticsTimer(HttpRequestMessage request)
        {
            return request.Method.Method switch
            {
                "POST" => TimerPost,
                "GET" => TimerGet,
                "PUT" => TimerPut,
                "PATCH" => TimerPatch,
                "DELETE" => TimerDelete,
                _ => null
            };
        }

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> PostRawAsync(string path,
            HttpContent content,
            RequestOptions? options = null) 
        =>
            OnSendAsync(
                OnMakeRequestMessage(HttpMethod.Post, path, content), 
                TimerPost, 
                options?.ClientOptions,
                options?.CancellationToken);

        /// <summary>
        ///   Invoked to construct a <see cref="HttpRequestMessage"/> from a path,
        ///   HTTP method and <see cref="HttpContent"/> object.
        /// </summary>
        /// <param name="method">
        ///   The HTTP method.
        /// </param>
        /// <param name="path">
        ///   A resource path.
        /// </param>
        /// <param name="content">
        ///   The HTTP content (and headers).
        /// </param>
        /// <returns>
        ///   A <see cref="HttpRequestMessage"/> object.
        /// </returns>
        protected virtual HttpRequestMessage OnMakeRequestMessage(HttpMethod method, string path, HttpContent content)
        {
            var message = new HttpRequestMessage(
                new System.Net.Http.HttpMethod(method.ToString()),
                OnConstructPath(path.Trim('/'))) 
            {
                Content = content
            };
            return message;

            // if (!content.Headers.Any())
            //     return message;
            //
            // message.TryAddHeadersFrom(content);
            //     
            // var headers = message.Headers.ToDictionary(i => i.Key);
            // if (!headers.Any())
            // {
            //     foreach (var (key, value) in content.Headers)
            //     {
            //         message.Headers.TryAddWithoutValidation(key, value);
            //     }
            //
            //     return message;
            // }
            //
            // foreach (var header in content.Headers)
            // {
            //     if (!headers.ContainsKey(header.Key))
            //     {
            //         message.Headers.Add(header.Key, header.Value);
            //         continue;
            //     }
            //
            //     var values = message.Headers.GetValues(header.Key).ToList();
            //     var append = header.Value.Where(i => !values.Contains(i));
            //     foreach (var value in append)
            //     {
            //         message.Headers.TryAddWithoutValidation(header.Key, value);
            //     }
            // }
            // content.Headers.Clear();
            // message.Content = content;
            //
            // return message;
        }

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> PutRawAsync(
            string path, 
            HttpContent content, 
            RequestOptions? options = null) 
        =>
            OnSendAsync(
                OnMakeRequestMessage(HttpMethod.Put, path, content),
                TimerPut,
                options?.ClientOptions,
                options?.CancellationToken);

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> PatchRawAsync(
            string path, 
            HttpContent content,RequestOptions? options = null)
        => 
            OnSendAsync(
                OnMakeRequestMessage(HttpMethod.Patch, path, content),
                TimerPatch,
                options?.ClientOptions,
                options?.CancellationToken);

        
        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> GetRawAsync(
            string path,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        {
            var useQuery = !queryParameters.IsEmpty();
            var usePath = $"{OnConstructPath(path)}{(useQuery ? queryParameters!.ToString(true) : "")}";
            var get = new System.Net.Http.HttpMethod(HttpVerbs.Get); 
            var request = new HttpRequestMessage(get, usePath.TrimStart('/'));
            return OnSendAsync(request, TimerGet, options?.ClientOptions, options?.CancellationToken);
        }

        /// <inheritdoc />
        public async Task<HttpEnumOutcome<T>> GetCollectionAsync<T>(
            string path, 
            HttpQuery? queryParameters = null, 
            RequestOptions? options = null)
        {
            try
            {
                DiagnosticsStartTimer(TimerGet);
                var outcome = await GetRawAsync(path, queryParameters, options);
                DiagnosticsEndTimer(TimerGet);
                if (!outcome)
                    return HttpEnumOutcome<T>.Fail(HttpMethod.Get, outcome.Exception);

                var stream = await outcome.Value!.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<T>(stream);
                return HttpEnumOutcome<T>.Success(HttpMethod.Get, result!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> DeleteRawAsync(
            string path, 
            HttpQuery? queryParameters = null, 
            RequestOptions? options = null)
        {
            var useQuery = !queryParameters.IsEmpty();
            var usePath = $"{OnConstructPath(path)}{(useQuery ? queryParameters!.ToString(true) : "")}";
            var delete = new System.Net.Http.HttpMethod(HttpVerbs.Delete); 
            var request = new HttpRequestMessage(delete, usePath.TrimStart('/'));
            return OnSendAsync(request, TimerDelete, options?.ClientOptions, options?.CancellationToken);
        }

        /// <summary>
        ///   (virtual method)<br/>
        ///   Resolves the effective path to be used.
        ///   Default implementation resolved a default path ('/') as a concatenation of
        ///   <see cref="ServiceEndpoints.Host"/> and <see cref="ServiceEndpoints.BasePath"/>
        ///   and just returns all other paths as-is. 
        /// </summary>
        /// <param name="path">
        ///   The path to be resolved.
        /// </param>
        /// <returns>
        ///   A URL to be used in the request.
        /// </returns>
        protected virtual string OnConstructPath(string path)
        {
            return path != ServiceEndpoints.DefaultPath 
                ? path 
                : $"{Endpoints.Host!.EnsurePostfix("/")}{Endpoints.BasePath!.TrimStart('/')}";
        }
        
        /// <summary>
        ///   Called by an internal method when it discovers a configuration issue,
        ///   allowing for a consistent response to all such issues.
        /// </summary>
        /// <param name="request">
        ///   The ongoing request.  
        /// </param>
        /// <param name="issues">
        ///   A collection of issues found.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpEnumOutcome{T}"/> to indicate success/failure and, on success, also carry
        ///   one or more <see cref="HttpResponseMessage"/>s or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual HttpOutcome<HttpResponseMessage> OnServiceConfigurationError(
            HttpRequestMessage request,
            IEnumerable<Exception> issues,
            string? messageId)
        {
            return ServiceConfigHelper.GetServiceConfigurationErrorResponse(
                request.Method.Method,
                request.RequestUri!.ToString(),
                request.RequestUri.Query,
                issues,
                messageId,
                Logger);
        }
        
        HttpOutcome<HttpResponseMessage> requestErrorOutcome(Exception exception, HttpRequestMessage request, string? messageId)
        {
            Logger.Error(
                new Exception($"Error while performing request: {request.Method} {request.RequestUri}: {exception.Message}", exception)
                ,messageId:messageId);
            var httpMethod = request.Method.Method.ToHttpMethod();
            return HttpOutcome<HttpResponseMessage>.Fail(httpMethod, exception);
        }

        /// <summary>
        ///   (virtual method)<br/>
        ///   Invoked after initial preparation by <see cref="AuthorizeAsync"/>.
        /// </summary>
        /// <param name="clientOptions">
        ///   Specifies options for the client to be used during the authorization.
        /// </param>
        /// <param name="cancellationToken">
        ///   Allows canceling the authorization process.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <remarks>
        ///   The default implementation simply calls <see cref="Endpoints"/>'
        ///   internal <see cref="IAuthorizationService"/>
        /// </remarks>
        protected virtual async Task<Outcome<ActorToken>> OnAuthorizeAsync(
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken) 
        =>
            await Endpoints.AuthorizeAsync(clientOptions, cancellationToken);

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
            var clientOutcome = await Endpoints.GetHttpClientAsync(clientOptions, cancellationToken);
            if (!clientOutcome)
                return Outcome<HttpClient>.Fail(clientOutcome.Exception);

            var client = clientOutcome.Value!;
            if (client.BaseAddress is {})
                return clientOutcome;

            if (string.IsNullOrWhiteSpace(Endpoints.BasePath))
            {
                client.BaseAddress = new Uri(Endpoints.Host!.EnsurePostfix("/"));
                return clientOutcome;
            }
            
            client.BaseAddress = new Uri($"{Endpoints.Host!.EnsurePostfix("/")}{Endpoints.BasePath.TrimStart('/').EnsurePostfix("/")}");
            return clientOutcome;
        }

        /// <summary>
        ///   Initializes the <see cref="BackendService{TEndpoints}"/>
        /// </summary>
        /// <param name="endpoints">
        ///   The service's supported endpoint.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="endpoints"/> was <c>null</c>.
        /// </exception>
        public BackendService(TEndpoints endpoints)
        {
            _serviceName = endpoints.SectionIdentifier;
            Endpoints = endpoints ?? throw new ArgumentNullException(nameof(endpoints));
            Endpoints.SetBackendService(this);
        }
    }
}