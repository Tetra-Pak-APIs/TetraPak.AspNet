using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        protected IHttpClientProvider HttpClientProvider { get; }

        /// <summary>
        ///   Gets logging provider.  
        /// </summary>
        protected ILogger Logger { get; }
        // ReSharper restore MemberCanBePrivate.Global

        public async Task<Outcome<HttpResponseMessage>> SendAsync(
            HttpRequestMessage request, 
            CancellationToken? cancellationToken = null)
        {
            var useCancellationToken = cancellationToken ?? CancellationToken.None;
            var clientOptions = new HttpClientOptions
            {
                Authentication = request.Headers.Authorization
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
            var useCancellationToken = cancellationToken ?? CancellationToken.None;
            var clientOutcome = await OnGetHttpClientAsync(clientOptions, cancellationToken); 
            if (!clientOutcome)
                return Outcome<HttpResponseMessage>.Fail(
                    new Exception("Could not initialize a HTTP client (see inner exception)", 
                        clientOutcome.Exception));
            
            var client = clientOutcome.Value;
#if DEBUG || LOG_DEBUG            
            Logger.Debug($"Sending request URI: {path}");
            Logger.Debug($"Sending request HEADERS: {client.DefaultRequestHeaders.Concat()}");
     #if NET5_0_OR_GREATER
            var contentString = await content.ReadAsStringAsync(useCancellationToken);
     #else
            var contentString = await content.ReadAsStringAsync();
     #endif
            Logger.Debug($"Sending request CONTENT: {contentString}");
#endif
            var response = await client.PostAsync(path.TrimStart('/'), content, useCancellationToken);
            return response.IsSuccessStatusCode
                ? Outcome<HttpResponseMessage>.Success(response)
                : Outcome<HttpResponseMessage>.Fail(response);
        }

        protected virtual async Task<Outcome<HttpClient>> OnGetHttpClientAsync(HttpClientOptions clientOptions, CancellationToken? cancellationToken)
        {
            var clientOutcome = await HttpClientProvider.GetHttpClientAsync(clientOptions, cancellationToken, Logger);
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

        public BackendService(TEndpoints endpoints, IHttpClientProvider httpClientProvider, ILogger logger)
        {
            HttpClientProvider = httpClientProvider;
            Endpoints = endpoints;
            Endpoints.SetBackendService(this);
            Logger = logger;
        }
    }
}