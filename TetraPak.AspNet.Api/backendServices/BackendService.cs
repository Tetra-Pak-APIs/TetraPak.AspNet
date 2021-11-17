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
using HttpMethod=Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

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
    public class BackendService<TEndpoints> : IBackendService, IAccessTokenProvider
    where TEndpoints : ServiceEndpoints
    {
        const string TimerGet = "out-get";
        const string TimerPost = "out-post";
        const string TimerPut = "out-put";
        const string TimerPatch = "out-patch";
        const string TimerDelete = "out-delete";

        /// <inheritdoc />
        public string ServiceName { get; }

        /// <summary>
        ///   Gets the endpoint configuration.
        /// </summary>
        // ReSharper disable MemberCanBePrivate.Global
        public TEndpoints Endpoints { get; }

        // /// <summary>
        // ///   Gets a delegate used to provide a <see cref="HttpClient"/>,
        // ///   used to consumer the backend service.
        // /// </summary>
        // protected IHttpServiceProvider HttpServiceProvider => Endpoints.HttpServiceProvider; obsolete

        // /// <summary>
        // ///   Gets a delegate used to provide a <see cref="HttpClient"/>,
        // ///   used to consumer the backend service.
        // /// </summary>
        // protected IHttpClientProvider HttpClientProvider => Endpoints.HttpClientProvider;

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
        [StateDump]
        public string? ClientSecret => Endpoints.ClientSecret;

        /// <summary>
        ///   Gets a scope to be requested for authorization.
        /// </summary>
        [StateDump]
        public MultiStringValue Scope => Endpoints.Scope;

        /// <inheritdoc />
        public string GetConfiguredValue(string key) => Endpoints.GetConfiguredValue(key);

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
        
        /// <inheritdoc />
        public HttpClientOptions DefaultClientOptions => Endpoints.ClientOptions;
        
        /// <inheritdoc />
        public ServiceEndpoint GetEndpoint(string name) => Endpoints[name];

        internal void DiagnosticsStartTimer(string? timerKey)
        {
            if (timerKey is { })
            {
                Endpoints.DiagnosticsStartTimer(timerKey);
            }
        }

        internal void DiagnosticsEndTimer(string? timerKey)
        {
            if (timerKey is { })
            {
                Endpoints.DiagnosticsEndTimer(timerKey);
            }
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
        {
            return sendAsync(request, resolveDiagnosticsTimer(request), clientOptions, cancellationToken);
        }

        async Task<HttpOutcome<HttpResponseMessage>> sendAsync(
            HttpRequestMessage request, 
            string? timer,
            HttpClientOptions? clientOptions,
            CancellationToken? cancellationToken)
        {
            if (!Endpoints.IsValid)
                return OnServiceConfigurationError(request, Endpoints.GetIssues()!, AmbientData.GetMessageId(true));
            
            cancellationToken ??= Endpoints.ContextCancellationToken ?? CancellationToken.None;
            if (cancellationToken.IsRequestCancelled())
                return HttpOutcome<HttpResponseMessage>.Fail(
                    HttpMethod.Post,
                    new HttpRequestCancelledException());
            
            var ct = cancellationToken ?? CancellationToken.None;

            var httpMethod = request.Method.Method.ToHttpMethod();
            var accessTokenOutcome = await GetAccessTokenAsync();
            var grantType = clientOptions?.AuthConfig?.GrantType ?? DefaultClientOptions.AuthConfig?.GrantType ?? GrantType.None;
            if (!accessTokenOutcome && grantType != GrantType.None)
                return HttpOutcome<HttpResponseMessage>.Fail(
                    httpMethod,
                    new Exception("Could not initialize a HTTP client. No access token available", 
                        accessTokenOutcome.Exception));

            clientOptions ??= accessTokenOutcome
                ? DefaultClientOptions.WithAuthorization(accessTokenOutcome.Value!, Endpoints.AuthorizationService)
                : DefaultClientOptions;
            
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, ct);
            if (!clientOutcome)
                return HttpOutcome<HttpResponseMessage>.Fail(
                    httpMethod,
                    new Exception("Could not initialize a HTTP client (see inner exception)", 
                        clientOutcome.Exception));
            
            var client = clientOutcome.Value!;

            try
            {
                DiagnosticsStartTimer(timer);
                var response = await client.SendAsync(request, ct);
                DiagnosticsEndTimer(timer);
                return response.IsSuccessStatusCode
                    ? HttpOutcome<HttpResponseMessage>.Success(httpMethod, response)
                    : HttpOutcome<HttpResponseMessage>.Fail(httpMethod, response);
            }
            catch (Exception ex)
            {
                return requestErrorOutcome(ex, request, AmbientData.GetMessageId(true));
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
        public Task<HttpOutcome<HttpResponseMessage>> PostAsync(
            string path,
            HttpContent content,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            var post = new System.Net.Http.HttpMethod(HttpVerbs.Post); 
            var request = new HttpRequestMessage(post, path.TrimStart('/'));
            request.Content = content;
            return sendAsync(request, TimerPost, clientOptions, cancellationToken);
            
            
//             var ct = cancellationToken ?? CancellationToken.None; obsolete
//             clientOptions ??= DefaultClientOptions.WithAuthorization(await HttpServiceProvider.GetAccessTokenAsync());
//             var clientOutcome = await OnGetHttpClientAsync(clientOptions ?? DefaultClientOptions, ct); 
//             if (!clientOutcome)
//                 return Outcome<HttpResponseMessage>.Fail(clientOutcome.Exception);
//             
//             var client = clientOutcome.Value!;
//             Logger.Trace($"Sending request URI: {path}");
//             Logger.Trace($"Sending request HEADERS: {client.DefaultRequestHeaders.Concat()}");
//             
// #if NET5_0_OR_GREATER
//             var contentString = await content.ReadAsStringAsync(ct);
// #else
//             var contentString = await content.ReadAsStringAsync();
// #endif
//             Logger.Debug($"POST - Sending request CONTENT: {contentString}");
//             DiagnosticsStartTimer(TimerPost);
//             var response = await client.PostAsync(path.TrimStart('/'), content, ct);
//             DiagnosticsEndTimer(TimerPost);
//             return response.IsSuccessStatusCode
//                 ? Outcome<HttpResponseMessage>.Success(response)
//                 : Outcome<HttpResponseMessage>.Fail(response);
        }

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> PutAsync(
            string path, 
            HttpContent content, 
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            var put = new System.Net.Http.HttpMethod(HttpVerbs.Put); 
            var request = new HttpRequestMessage(put, path.TrimStart('/'));
            request.Content = content;
            return sendAsync(request, TimerPost, clientOptions, cancellationToken);
            
//             var ct = cancellationToken ?? CancellationToken.None; obsolete
//             clientOptions ??= DefaultClientOptions.WithAuthorization(await HttpServiceProvider.GetAccessTokenAsync());
//             var clientOutcome = await OnGetHttpClientAsync(clientOptions ?? DefaultClientOptions, ct); 
//             if (!clientOutcome)
//                 return Outcome<HttpResponseMessage>.Fail(clientOutcome.Exception);
//             
//             var client = clientOutcome.Value!;
//             Logger.Trace($"Sending request PUT {path}");
//             Logger.Trace($"Sending request HEADERS: {client.DefaultRequestHeaders.Concat()}");
//             
// #if NET5_0_OR_GREATER
//             var contentString = await content.ReadAsStringAsync(ct);
// #else
//             var contentString = await content.ReadAsStringAsync();
// #endif
//             Logger.Debug($"PUT - Sending request CONTENT: {contentString}");
//             DiagnosticsStartTimer(TimerPost);
//             var response = await client.PutAsync(path.TrimStart('/'), content, ct);
//             DiagnosticsEndTimer(TimerPost);
//             return response.IsSuccessStatusCode
//                 ? Outcome<HttpResponseMessage>.Success(response)
//                 : Outcome<HttpResponseMessage>.Fail(response);
        }

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> PatchAsync(
            string path, 
            HttpContent content,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> PatchAsync(
            string path, 
            object?  data, 
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }
        
        // /// <inheritdoc />
        // public async Task<HttpEnumOutcome<T>> GetAsync<T>(
        //     string path, 
        //     HttpQueryParameters queryParameters, 
        //     HttpClientOptions? clientOptions = null,
        //     CancellationToken? cancellationToken = null, 
        //     string? messageId = null)
        // {
        //     try
        //     {
        //         var outcome = await GetAsync(path, queryParameters, clientOptions, cancellationToken, messageId);
        //         if (!outcome)
        //             return HttpEnumOutcome<T>.Fail(HttpMethod.Get, outcome.Exception);
        //
        //         var stream = await outcome.Value!.Content.ReadAsStreamAsync();
        //         var result = await JsonSerializer.DeserializeAsync<T>(stream);
        //         return HttpEnumOutcome<T>.Success(HttpMethod.Get, result!);
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex);
        //         throw;
        //     }
        // }

        /// <inheritdoc />
        public Task<HttpOutcome<HttpResponseMessage>> GetAsync(
            string path,
            HttpQuery? queryParameters = null,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null,
            string? messageId = null)
        {
            var useQuery = !queryParameters.IsEmpty();
            var usePath = $"{OnConstructPath(path)}{(useQuery ? queryParameters!.ToString(true) : "")}";
            var get = new System.Net.Http.HttpMethod(HttpVerbs.Get); 
            var request = new HttpRequestMessage(get, usePath.TrimStart('/'));
            return sendAsync(request, TimerGet, clientOptions, cancellationToken);
        }

        protected virtual string OnConstructPath(string path)
        {
            return path != ServiceEndpoints.DefaultPath 
                ? path 
                : $"{Endpoints.Host}{Endpoints.BasePath}";
        }

        /// <inheritdoc />
        public async Task<HttpEnumOutcome<T>> GetAsync<T>(
            string path, 
            HttpQuery? queryParameters = null, 
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

        // /// <inheritdoc />
        // public Task<HttpOutcome<HttpResponseMessage>> GetAsync(
        //     string path,
        //     HttpQueryParameters? queryParameters = null,
        //     HttpClientOptions? clientOptions = null,
        //     CancellationToken? cancellationToken = null, 
        //     string? messageId = null)
        // {
        //     return GetAsync(
        //         path,
        //         queryParameters?.ToString(true),
        //         clientOptions,
        //         cancellationToken,
        //         messageId);
        // }

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
        {
            return await Endpoints.AuthorizeAsync(clientOptions, cancellationToken);
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
            ServiceName = endpoints.SectionIdentifier;
            Endpoints = endpoints ?? throw new ArgumentNullException(nameof(endpoints));
            Endpoints.SetBackendService(this);
        }
    }
}