using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Api
{
    public static class ServiceEndpointExtensions
    {
        internal static void SetBackendService(this ServiceEndpoint self, IBackendService service)
        {
            switch (compareEndpointService(self, service))
            {
                case ServiceEndpointService.None:
                    self.Service = service;
                    break;

                case ServiceEndpointService.Same:
                    break;
                
                case ServiceEndpointService.Other:
                    throw new ArgumentException($"Endpoint {self} is already assigned to service {self.Service}", nameof(service));

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        static ServiceEndpointService compareEndpointService(ServiceEndpoint endpoint, IBackendService service)
        {
            if (endpoint.Service is null)
                return ServiceEndpointService.None;
            
            return endpoint.Service.ServiceName == service.ServiceName 
                ? ServiceEndpointService.Same
                : ServiceEndpointService.Other;
        }

        enum ServiceEndpointService
        {
            None,
            
            Same,
            
            Other
        }

        internal static IBackendService GetBackendService(this ServiceEndpoint self)
        {
            return self.Service 
                   ?? throw new ArgumentOutOfRangeException($"Cannot acquire service for backend URL: {self}");
        }

        public static Task<Outcome<ActorToken>> AuthenticateAsync(
            this ServiceEndpoint serviceEndpoint,
            CancellationToken? cancellationToken = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return Task.FromResult(invalidUrl.GetInvalidEndpointAuthorization());
            
            var clientOptions = serviceEndpoint.ClientOptions;
            var service = serviceEndpoint.Service
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return service.AuthenticateAsync(clientOptions, cancellationToken);
        }

        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
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
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<Outcome<HttpResponseMessage>> GetAsync(
            this ServiceEndpoint serviceEndpoint,  
            IDictionary<string,string> queryParameters,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Get, invalidUrl, null);
            
            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return await service.GetAsync(
                serviceEndpoint,
                queryParameters,
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(await serviceEndpoint.GetAccessTokenAsync()),
                cancellationToken);
        }

        public static async Task<Outcome<HttpResponseMessage>> GetAsync(
            this ServiceEndpoint serviceEndpoint,  
            string queryParameters = null,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Get, invalidUrl, null);

            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return await service.GetAsync(
                serviceEndpoint, 
                queryParameters, 
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(await serviceEndpoint.GetAccessTokenAsync()), 
                cancellationToken);
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
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
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<Outcome<HttpResponseMessage>> PostAsync(
            this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Post, invalidUrl, null);

            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return await service.PostAsync(
                serviceEndpoint, 
                content, 
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(await serviceEndpoint.GetAccessTokenAsync()), 
                cancellationToken);
        }
    }
}