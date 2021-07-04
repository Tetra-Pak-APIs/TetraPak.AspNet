using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    public class BackendService<TEndpoints> : IBackendService
    where TEndpoints : ServiceEndpoints
    {
        /// <summary>
        ///   Gets the endpoint configuration.
        /// </summary>
        // ReSharper disable MemberCanBePrivate.Global
        public TEndpoints Endpoints { get; }

        /// <summary>
        ///   Gets a delegate used to provide a <see cref="HttpClient"/>,
        ///   used to consumer the backend service.
        /// </summary>
        protected IHttpServiceProvider HttpServiceProvider { get; }

        /// <summary>
        ///   Gets logging provider.  
        /// </summary>
        protected ILogger Logger => Endpoints.Logger;

        /// <summary>
        ///   Gets the Tetra Pak configuration.
        /// </summary>
        protected TetraPakAuthConfig AuthConfig => Endpoints.AuthConfig;
        
        public GrantType GrantType => Endpoints.GrantType;

        public string ClientId => Endpoints.ClientId;

        public string ClientSecret => Endpoints.ClientSecret;

        public MultiStringValue Scope => Endpoints.Scope;

        public HttpClientOptions DefaultClientOptions => Endpoints.ClientOptions;

        public async Task<Outcome<ActorToken>> AuthenticateAsync(
            HttpClientOptions clientOptions, 
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var accessTokenOutcome  = await HttpServiceProvider.GetAccessTokenAsync(AuthConfig);
            if (accessTokenOutcome)
            {
                clientOptions.Authentication =
                    new AuthenticationHeaderValue("Bearer", accessTokenOutcome.Value.Identity);
            }
            clientOptions.AuthConfig = this;
            return await OnAuthenticateAsync(clientOptions, ct);
        }

        public async Task<Outcome<HttpResponseMessage>> SendAsync(
            HttpRequestMessage request, 
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var clientOptions = new HttpClientOptions
            {
                Authentication = request.Headers.Authorization,
                AuthConfig = this
            };
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
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, ct); 
            if (!clientOutcome)
                return Outcome<HttpResponseMessage>.Fail(
                    new Exception("Could not initialize a HTTP client (see inner exception)", 
                        clientOutcome.Exception));
            
            var client = clientOutcome.Value;
            Logger.Trace($"Sending request URI: {path}");
            Logger.Trace($"Sending request HEADERS: {client.DefaultRequestHeaders.Concat()}");
            
#if NET5_0_OR_GREATER
            var contentString = await content.ReadAsStringAsync(ct);
#else
            var contentString = await content.ReadAsStringAsync();
#endif
            Logger.Debug($"Sending request CONTENT: {contentString}");
            var response = await client.PostAsync(path.TrimStart('/'), content, ct);
            return response.IsSuccessStatusCode
                ? Outcome<HttpResponseMessage>.Success(response)
                : Outcome<HttpResponseMessage>.Fail(response);
        }

        public async Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            string queryParameters = null,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null,
            string messageId = null)
        {
            if (!Endpoints.IsValid)
                return OnServiceConfigurationError(HttpMethod.Get, path, queryParameters, Endpoints.GetIssues(), messageId);
                
            var ct = cancellationToken ?? CancellationToken.None;
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, ct); 
            if (!clientOutcome)
                return Outcome<HttpResponseMessage>.Fail(
                    new Exception("Could not initialize a HTTP client (see inner exception)", 
                        clientOutcome.Exception));

            var client = clientOutcome.Value;
            path = pathWithQueryParameters();
            var url = $"{client.BaseAddress}{path.TrimStart('/')}";
            
            Logger.Trace($"Sending request URI: {url}");
            Logger.Trace($"Sending request HEADERS: {client.DefaultRequestHeaders.Concat()}");

            try
            {
                var response = await client.GetAsync(path.TrimStart('/'), ct);
                return response.IsSuccessStatusCode
                    ? Outcome<HttpResponseMessage>.Success(response)
                    : Outcome<HttpResponseMessage>.Fail(new HttpException(response));
            }
            catch (Exception ex)
            {
                return requestErrorOutcome(ex, HttpMethod.Get, url);
            }


            string pathWithQueryParameters()
            {
                return string.IsNullOrWhiteSpace(queryParameters) 
                    ? path
                    : $"{path}{queryParameters.Trim().EnsurePrefix("?")}";
            }
        }


        public Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            IDictionary<string, string> queryParameters,
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null, 
            string messageId = null)
        {
            return GetAsync(
                path,
                queryParameters.ToUrlQueryParameters(true),
                clientOptions,
                cancellationToken,
                messageId);
        }

        protected virtual Outcome<HttpResponseMessage> OnServiceConfigurationError(
            HttpMethod method,
            string path, 
            string queryParameters, 
            IEnumerable<Exception> issues,
            string messageId)
        {
            return ServiceConfigHelper.GetServiceConfigurationErrorResponse(
                method,
                path,
                queryParameters,
                issues,
                messageId,
                Logger);
        }
        
        Outcome<HttpResponseMessage> requestErrorOutcome(Exception exception, HttpMethod method, string url)
        {
            Logger.Error(new Exception($"Error while performing request: {method} {url}: {exception.Message}", exception));
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

        protected virtual async Task<Outcome<HttpClient>> OnGetHttpClientAsync(
            HttpClientOptions clientOptions, 
            CancellationToken? cancellationToken)
        {
            var clientOutcome = await HttpServiceProvider.GetClientAsync(clientOptions, cancellationToken, Logger);
            if (!clientOutcome)
                return Outcome<HttpClient>.Fail(new Exception("Could not initialize a HTTP client (see inner exception)", clientOutcome.Exception));

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

        public BackendService(TEndpoints endpoints, IHttpServiceProvider httpServiceProvider)
        {
            Endpoints = endpoints ?? throw new ArgumentNullException(nameof(endpoints));
            HttpServiceProvider = httpServiceProvider ?? throw new ArgumentNullException(nameof(httpServiceProvider));
            Endpoints.SetBackendService(this);
        }
    }
}