using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Convenient methods to help consuming service endpoints.  
    /// </summary>
    public static class ServiceEndpointExtensions
    {
        internal static void SetBackendService(this ServiceEndpoint self, IBackendService service)
        {
            if (self.Service is null)
                self.Service = service;
        }

        internal static void ClearBackendService(this ServiceEndpoints self)
        {
            self.BackendService = null;
            foreach (var (_, endpoint) in self)
            {
                endpoint.Service = null;
            }
        }

        internal static IBackendService GetBackendService(this ServiceEndpoint self)
        {
            return self.Service 
                   ?? throw new ArgumentOutOfRangeException($"Cannot acquire service for backend URL: {self}");
        }

        public static Task<Outcome<ActorToken>> AuthorizeAsync(
            this ServiceEndpoint serviceEndpoint,
            HttpMethod httpMethod,
            CancellationToken? cancellationToken = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return Task.FromResult(invalidUrl.GetInvalidEndpointAuthorization());
            
            var clientOptions = serviceEndpoint.ClientOptions;
            var service = serviceEndpoint.Service
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return service.AuthorizeAsync(clientOptions, cancellationToken);
        }

        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="queryParameters">
        ///     (optional)
        ///     Query parameters.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        /// </param>
        /// <param name="clientOptions">
        ///     (optional)
        ///     Options for the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<HttpResponseMessage>> GetAsync(this ServiceEndpoint serviceEndpoint,
            HttpQueryParameters? queryParameters = null,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Get, invalidUrl!, null);
            
            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return await service.GetAsync(
                serviceEndpoint!,
                queryParameters,
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(
                        (await serviceEndpoint.GetAccessTokenAsync()).Value, 
                        serviceEndpoint.AuthorizationService),
                cancellationToken);
        }

        
        // /// <summary>
        // ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/> obsolete
        // /// </summary>
        // /// <param name="serviceEndpoint">
        // ///     The <see cref="ServiceEndpoint"/>.
        // /// </param>
        // /// <param name="queryParameters">
        // ///     (optional)
        // ///     Query parameters.
        // /// </param>
        // /// <param name="cancellationToken">
        // ///     (optional)<br/>
        // /// </param>
        // /// <param name="clientOptions">
        // ///     (optional)
        // ///     Options for the operation.
        // /// </param>
        // /// <returns>
        // ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        // ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        // /// </returns>
        // /// <exception cref="InvalidOperationException">
        // ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        // /// </exception>
        // public static async Task<Outcome<HttpResponseMessage>> GetAsync(this ServiceEndpoint serviceEndpoint,
        //     HttpQueryParameters? queryParameters = null,
        //     CancellationToken? cancellationToken = null,
        //     HttpClientOptions? clientOptions = null)
        // {
        //     if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
        //         return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Get, invalidUrl!, null);
        //
        //     var service = serviceEndpoint.Service 
        //                   ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
        //     return await service.GetAsync(
        //         serviceEndpoint!, 
        //         queryParameters, 
        //         clientOptions 
        //             ?? serviceEndpoint.ClientOptions.WithAuthorization((await serviceEndpoint.GetAccessTokenAsync()).Value),
        //         cancellationToken);
        // }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///     The content (body) to be posted.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        ///     Allows operation cancellation.
        /// </param>
        /// <param name="clientOptions">
        ///     (optional)
        ///     Options for the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<Outcome<HttpResponseMessage>> PostAsync(this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidEndpoint)
                return invalidEndpoint.GetInvalidEndpointResponse(HttpMethod.Post, invalidEndpoint!, null);

            var service = serviceEndpoint.Service 
                        ?? throw new InvalidOperationException(
                        $"Endpoint Url {serviceEndpoint} was not assigned to a service");

            return await service.PostAsync(
                serviceEndpoint!, 
                content, 
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(
                    (await serviceEndpoint.GetAccessTokenAsync()).Value,
                    serviceEndpoint.AuthorizationService),
                cancellationToken);
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///     The content (body) to be posted.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        ///     Allows operation cancellation.
        /// </param>
        /// <param name="clientOptions">
        ///     (optional)
        ///     Options for the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<Outcome<HttpResponseMessage>> PostAsync(this ServiceEndpoint serviceEndpoint,
            object? data,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            var content = data is null
                ? new StringContent("{}")
                : new StringContent(JsonSerializer.Serialize(data));
            return serviceEndpoint.PostAsync(content, cancellationToken, clientOptions);
        }

        /// <summary>
        ///   Sends an HTTP PUT message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The content (body) to be put.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows operation cancellation.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional)
        ///   Options for the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<Outcome<HttpResponseMessage>> PutAsync(this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Post, invalidUrl!, null);

            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return await service.PostAsync(
                serviceEndpoint!, 
                content, 
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(
                    (await serviceEndpoint.GetAccessTokenAsync()).Value,
                    serviceEndpoint.AuthorizationService),
                cancellationToken);
        }

        /// <summary>
        ///   Sends an HTTP PUT message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///     The content (body) to be posted.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        ///     Allows operation cancellation.
        /// </param>
        /// <param name="clientOptions">
        ///     (optional)
        ///     Options for the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<Outcome<HttpResponseMessage>> PutAsync(this ServiceEndpoint serviceEndpoint,
            object? data,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            var content = data is null
                ? new StringContent("{}")
                : new StringContent(JsonSerializer.Serialize(data));
            return serviceEndpoint.PutAsync(content, cancellationToken, clientOptions);
        }
        
        /// <summary>
        ///   Sends an HTTP PATCH message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The content (body) to be put.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows operation cancellation.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional)
        ///   Options for the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<Outcome<HttpResponseMessage>> PatchAsync(this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Post, invalidUrl!, null);

            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return await service.PatchAsync(
                serviceEndpoint!, 
                content, 
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(
                    (await serviceEndpoint.GetAccessTokenAsync()).Value,
                    serviceEndpoint.AuthorizationService),
                cancellationToken);
        }   

        /// <summary>
        ///   Sends an HTTP PATCH message to the specified <see cref="ServiceEndpoint"/>
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///   The content (body) to be posted.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows operation cancellation.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional)
        ///   Options for the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<Outcome<HttpResponseMessage>> PatchAsync(this ServiceEndpoint serviceEndpoint,
            object? data,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            var content = data is null
                ? new StringContent("{}")
                : new StringContent(JsonSerializer.Serialize(data));
            return serviceEndpoint.PutAsync(content, cancellationToken, clientOptions);
        }
    }
}