using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    public class BackendService<TEndpoints> : IBackendService
    where TEndpoints : EndpointsConfig
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
        // ReSharper restore MemberCanBePrivate.Global
        
        public GrantType GrantType => Endpoints.GrantType;

        public string ClientId => Endpoints.ClientId;

        public string ClientSecret => Endpoints.ClientSecret;

        public MultiStringValue Scope => Endpoints.Scope;

        public HttpClientOptions DefaultClientOptions => Endpoints.ClientOptions;

        public async Task<Outcome<HttpResponseMessage>> SendAsync(
            HttpRequestMessage request, 
            CancellationToken? cancellationToken = null)
        {
            var useCancellationToken = cancellationToken ?? CancellationToken.None;
            var clientOptions = new HttpClientOptions
            {
                Authentication = request.Headers.Authorization,
                AuthConfig = this
            };
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, cancellationToken);
            if (clientOutcome)
                return Outcome<HttpResponseMessage>.Fail(
                    new Exception("Could not initialize a HTTP client (see inner exception)", 
                        clientOutcome.Exception));
            
            var client = clientOutcome.Value;
            var response = await client.SendAsync(request, useCancellationToken);
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
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, cancellationToken); 
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
            IDictionary<string, string> queryParameters = null,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            var ct = cancellationToken ?? CancellationToken.None;
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, cancellationToken); 
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
                    : Outcome<HttpResponseMessage>.Fail(response);
            }
            catch (Exception ex)
            {
                return requestErrorOutcome(ex, HttpMethod.Get, url);
            }

            string pathWithQueryParameters()
            {
                if (!(queryParameters?.Any() ?? false))
                    return path;

                var sb = new StringBuilder(path);
                sb.Append('?');
                var pairs = queryParameters.ToArray();
                var pair = pairs[0];
                sb.Append(pair.Key);
                sb.Append('=');
                sb.Append(pair.Value);
                for (var i = 1; i < pairs.Length; i++)
                {
                    sb.Append('&');
                    pair = pairs[i];
                    sb.Append(pair.Key);
                    sb.Append('=');
                    sb.Append(pair.Value);
                }

                return sb.ToString();
            }
        }

        Outcome<HttpResponseMessage> requestErrorOutcome(Exception exception, HttpMethod method, string url)
        {
            Logger.Error(new Exception($"Error while performing request: {method} {url}: {exception.Message}", exception));
            return Outcome<HttpResponseMessage>.Fail(exception);
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