using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Api
{
    public static class EndpointUrlExtensions
    {
        static readonly Dictionary<ServiceEndpointUrl,IBackendService> s_endpoints = new();
        
        internal static void SetBackendService(this ServiceEndpointUrl self, IBackendService backendService)
        {
            lock (s_endpoints)
            {
                if (s_endpoints.TryGetValue(self, out var existingService))
                    throw new ArgumentException($"Endpoint {self} is already assigned to service {existingService}", nameof(backendService));
                
                s_endpoints.Add(self, backendService);
            }
        }

        internal static IBackendService GetBackendService(this ServiceEndpointUrl self)
        {
            lock (s_endpoints)
            {
                return s_endpoints.TryGetValue(self, out var service)
                    ? service
                    : throw new ArgumentOutOfRangeException($"Cannot acquire service for backend URL: {self}");
            }
        }

        public static Task<Outcome<ActorToken>> AuthenticateAsync(
            this ServiceEndpointUrl serviceUrl,
            CancellationToken? cancellationToken = null)
        {
            if (serviceUrl is ServiceInvalidEndpointUrl invalidUrl)
                return Task.FromResult(invalidUrl.GetInvalidEndpointUrlAuthorization());
            
            lock (s_endpoints)
            {
                if (!s_endpoints.TryGetValue(serviceUrl, out var service))
                    throw new InvalidOperationException($"Endpoint Url {serviceUrl} was not assigned to a service");

                var clientOptions = serviceUrl.GetBackendService().DefaultClientOptions;
                return service.AuthenticateAsync(clientOptions, cancellationToken);
            }
        }

        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpointUrl"/>
        /// </summary>
        /// <param name="serviceUrl">
        ///   The <see cref="ServiceEndpointUrl"/>.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)
        ///   Query parameters.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional)
        ///   Options for the operation.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceUrl"/> was not assigned to a registered service.
        /// </exception>
        public static Task<Outcome<HttpResponseMessage>> GetAsync(
            this ServiceEndpointUrl serviceUrl,  
            IDictionary<string,string> queryParameters,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            if (serviceUrl is ServiceInvalidEndpointUrl invalidUrl)
                return Task.FromResult(
                    invalidUrl.GetInvalidEndpointUrlResponse(HttpMethod.Get, invalidUrl, null));
            
            lock (s_endpoints)
            {
                if (!s_endpoints.TryGetValue(serviceUrl, out var service))
                    throw new InvalidOperationException($"Endpoint Url {serviceUrl} was not assigned to a service");

                clientOptions ??= serviceUrl.GetBackendService().DefaultClientOptions;
                return service.GetAsync(serviceUrl, queryParameters, clientOptions, cancellationToken);
            }
        }

        public static Task<Outcome<HttpResponseMessage>> GetAsync(
            this ServiceEndpointUrl serviceUrl,  
            string queryParameters = null,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            if (serviceUrl is ServiceInvalidEndpointUrl invalidUrl)
                return Task.FromResult(
                    invalidUrl.GetInvalidEndpointUrlResponse(HttpMethod.Get, invalidUrl, null));

            lock (s_endpoints)
            {
                if (!s_endpoints.TryGetValue(serviceUrl, out var service))
                    throw new InvalidOperationException($"Endpoint Url {serviceUrl} was not assigned to a service");

                clientOptions ??= serviceUrl.GetBackendService().DefaultClientOptions;
                return service.GetAsync(serviceUrl, queryParameters, clientOptions, cancellationToken);
            }
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpointUrl"/>
        /// </summary>
        /// <param name="serviceUrl">
        ///   The <see cref="ServiceEndpointUrl"/>.
        /// </param>
        /// <param name="content">
        ///   The content (body) to be posted.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional)
        ///   Options for the operation.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceUrl"/> was not assigned to a registered service.
        /// </exception>
        public static Task<Outcome<HttpResponseMessage>> PostAsync(
            this ServiceEndpointUrl serviceUrl,
            HttpContent content,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            if (serviceUrl is ServiceInvalidEndpointUrl invalidUrl)
                return Task.FromResult(
                    invalidUrl.GetInvalidEndpointUrlResponse(HttpMethod.Post, invalidUrl, null));

            lock (s_endpoints)
            {
                if (!s_endpoints.TryGetValue(serviceUrl, out var service))
                    throw new InvalidOperationException($"Endpoint Url {serviceUrl} was not assigned to a service");

                clientOptions ??= serviceUrl.GetBackendService().DefaultClientOptions;
                return service.PostAsync(serviceUrl, content, clientOptions, cancellationToken);
            }
        }
    }
}