using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TetraPak.DynamicEntities;
using HttpMethod=Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

#nullable enable

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Convenient methods to help consuming service endpoints.  
    /// </summary>
    public static class ServiceEndpointHelper
    {
        internal static void SetBackendService(this ServiceEndpoint self, IBackendService service)
        {
            self.Service ??= service;
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

        /// <summary>
        ///   Obtains authorization for consuming the endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The extended service endpoint.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables cancellation of the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="serviceEndpoint"/> was unassigned.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<Outcome<ActorToken>> AuthorizeAsync(
            this ServiceEndpoint serviceEndpoint,
            CancellationToken? cancellationToken = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return Task.FromResult(invalidUrl.GetInvalidEndpointAuthorization());
            
            var clientOptions = serviceEndpoint.ClientOptions;
            var service = serviceEndpoint.Service
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return service.AuthorizeAsync(clientOptions, cancellationToken);
        }

        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/> to receive a ("raw")
        ///   <see cref="HttpResponseMessage"/> in response, allowing for customized response formatting or logics.
        ///   (see <see cref="GetAsync{T}(ServiceEndpoint,HttpQuery?,RequestOptions?)"/>
        ///   for retrieving a typed response).
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="queryParameters">
        ///     (optional)
        ///     Query parameters.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="serviceEndpoint"/> was unassigned.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        /// <seealso cref="GetRawAsync(TetraPak.AspNet.Api.ServiceEndpoint,TetraPak.AspNet.HttpQuery?,TetraPak.AspNet.Api.RequestOptions?)"/>
        /// <seealso cref="GetAsync{T}(ServiceEndpoint,IEnumerable{string},HttpQuery?,RequestOptions?)"/>
        public static async Task<HttpOutcome<HttpResponseMessage>> GetRawAsync(
            this ServiceEndpoint serviceEndpoint,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Get, invalidUrl!, null);
            
            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            options ??= RequestOptions.Default;
            options.ClientOptions ??= serviceEndpoint.ClientOptions.WithAuthorization(
                (await serviceEndpoint.GetAccessTokenAsync()).Value, 
                serviceEndpoint.AuthorizationService);
            return await service.GetRawAsync(serviceEndpoint!, queryParameters,options);
        }

        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/> to receive a ("raw")
        ///   <see cref="HttpResponseMessage"/> in response, allowing for customized response formatting or logics.
        ///   (see <see cref="GetAsync{T}(ServiceEndpoint,IEnumerable{string}?,HttpQuery?,RequestOptions?)"/>
        ///   for retrieving a typed response).
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="subPath">
        ///   One or more key elements to be added to the endpoint path.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)
        ///   Query parameters.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Options for the request.   
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="serviceEndpoint"/> was unassigned.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<HttpResponseMessage>> GetRawAsync(
            this ServiceEndpoint serviceEndpoint,
            DynamicPath subPath,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Get, invalidUrl!, null);
            
            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            options ??= RequestOptions.Default;
            options.ClientOptions ??= serviceEndpoint.ClientOptions.WithAuthorization(
                (await serviceEndpoint.GetAccessTokenAsync()).Value, 
                serviceEndpoint.AuthorizationService);
            return await service.GetRawAsync(
                serviceEndpoint.Path(options.DynamicPathValues, subPath),
                queryParameters, options);
        }

        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/>.
        ///   The response is automatically deserialized into a <see cref="ApiDataResponse{T}"/>
        ///   carrying the expected (typed) resources.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)<br/>
        ///   Query parameters.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Options for the request.   
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="ApiDataResponse{T}"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="serviceEndpoint"/> was unassigned.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<HttpOutcome<ApiDataResponse<T>>> GetAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        => 
            serviceEndpoint.GetAsync<T>(null!, queryParameters, options);


        /// <summary>
        ///   Sends an HTTP GET message, passing a collection of resource <paramref name="keys"/> requesting the
        ///   corresponding resources, to the specified <see cref="ServiceEndpoint"/>.
        ///   The response is automatically deserialized into a <see cref="ApiDataResponse{T}"/>
        ///   carrying the expected (typed) resources.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="keys">
        ///   One or more keys, to identity the requested resources.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)<br/>
        ///   Query parameters.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Options for the request.    
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="ApiDataResponse{T}"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> GetAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            IEnumerable<string>? keys = null,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse<T>(HttpMethod.Get, invalidUrl!, null);

            options ??= RequestOptions.Default;
            var data = new List<T>();

            var keyArray = keys?.ToArray();
            if (keyArray is null || keyArray.Length < 2)
                return await getAsync(keyArray?.FirstOrDefault());
            
            switch (options.Distribution)
            {
                case RequestDistribution.Sequential:
                    foreach (var key in keyArray)
                    {
                        if (options.CancellationToken.IsCancellationRequested)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Get,
                                new ServerException("Request was cancelled", HttpStatusCode.InternalServerError));
                            
                        var outcome = await getAsync(key);
                        if (outcome)
                        {
                            data.AddRange(outcome.Value!.Data);
                            continue;
                        }
                            
                        if (!options.IsFailureTolerant)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Get,
                                outcome.Exception);
                    }
                    return HttpOutcome<ApiDataResponse<T>>.Success(
                        HttpMethod.Get, 
                        new ApiDataResponse<T>(data));
                
                case RequestDistribution.Parallel:
                    var requests = keyArray.Select(getAsync).ToArray();
                    await Task.WhenAll(requests);
                    foreach (var outcome in requests.Select(r => r.Result))
                    {
                        if (!outcome && !options.IsFailureTolerant)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Get,
                                outcome.Exception);
                        
                        data.AddRange(outcome.Value!.Data);
                    }
                    return HttpOutcome<ApiDataResponse<T>>.Success(
                        HttpMethod.Get, 
                        new ApiDataResponse<T>(data));
                
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(RequestOptions.Distribution),
                        $"Unsupported: {options.Distribution}");
            }
            
            async Task<HttpOutcome<ApiDataResponse<T>>> getAsync(string? key)
            {
                var httpOutcome = await serviceEndpoint.GetRawAsync(
                    key, 
                    queryParameters, 
                    options);
                if (!httpOutcome)
                    return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);

                return await httpOutcome.Value!.tryParseApiDataResponseAsync<T>(HttpMethod.Get);
            }
        }

        /// <summary>
        ///   Sends an HTTP GET message to consume a specified resource as a <see cref="Stream"/>.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="key">
        ///   (optional)<br/>
        ///   A key, used to identity a requested resource.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)<br/>
        ///   Query parameters.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Options for the request.    
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   the requested <see cref="Stream"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        public static async Task<HttpOutcome<Stream>> GetStreamAsync(
            this ServiceEndpoint serviceEndpoint,
            string? key = null,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        {
            var httpOutcome = await serviceEndpoint.GetRawAsync(
                key,
                queryParameters,
                options);

            return httpOutcome
                ? HttpOutcome<Stream>.Success(httpOutcome.Method, await httpOutcome.Value!.Content.ReadAsStreamAsync())
                : HttpOutcome<Stream>.Fail(httpOutcome.Method, httpOutcome.Exception); 
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/> for a standardized
        ///   <see cref="ApiDataResponse{T}"/>.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> PostAsync<T>(this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            RequestOptions? options = null)
        {
            var httpOutcome = await serviceEndpoint.PostRawAsync(content, options);
            if (!httpOutcome)
                return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);
            
            return await httpOutcome.Value!.tryParseApiDataResponseAsync<T>(httpOutcome.Method);
        }
        
        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/> for a standardized
        ///   <see cref="ApiDataResponse{T}"/>.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> PostAsync<T>(this ServiceEndpoint serviceEndpoint,
            object? data,
            RequestOptions? options = null)
        {
            var httpOutcome = await serviceEndpoint.PostRawAsync(data, options);
            if (!httpOutcome)
                return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);
            
            return await httpOutcome.Value!.tryParseApiDataResponseAsync<T>(httpOutcome.Method);
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/> to receive a ("raw")
        ///   <see cref="HttpResponseMessage"/> in response, allowing for customized response formatting or logics.
        ///   (see <see cref="PostAsync{T}(ServiceEndpoint,HttpContent,RequestOptions?)"/>
        ///   for retrieving a typed response).
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<HttpResponseMessage>> PostRawAsync(
            this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidEndpoint)
                return invalidEndpoint.GetInvalidEndpointResponse(HttpMethod.Post, invalidEndpoint!, null);

            var service = serviceEndpoint.Service 
                        ?? throw new InvalidOperationException(
                        $"Endpoint Url {serviceEndpoint} was not assigned to a service");

            options ??= RequestOptions.Default;
            options.ClientOptions ??= serviceEndpoint.ClientOptions.WithAuthorization(
                (await serviceEndpoint.GetAccessTokenAsync()).Value,
                serviceEndpoint.AuthorizationService);
            return await service.PostRawAsync(serviceEndpoint.StringValue, content, options);
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/> for a "raw"
        ///   <see cref="HttpResponseMessage"/> response, allowing for customized response formatting or logics.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<HttpOutcome<HttpResponseMessage>> PostRawAsync(
            this ServiceEndpoint serviceEndpoint,
            object? data,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return Task.FromResult(invalidUrl.GetInvalidEndpointResponse(
                    HttpMethod.Post, 
                    invalidUrl!, 
                    null));

            var content = data is null
                ? new StringContent("{}")
                : new StringContent(JsonSerializer.Serialize(data));
            return serviceEndpoint.PostRawAsync(content, options);
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/> for a standardized
        ///   <see cref="ApiDataResponse{T}"/>.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> PutAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            RequestOptions? options = null)
        {
            var httpOutcome = await serviceEndpoint.PutRawAsync(content, options);
            if (!httpOutcome)
                return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);

            return await httpOutcome.Value!.tryParseApiDataResponseAsync<T>(httpOutcome.Method);
        }

        /// <summary>
        ///   Sends an HTTP POST message to the specified <see cref="ServiceEndpoint"/> for a standardized
        ///   <see cref="ApiDataResponse{T}"/>.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> PutAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            object? data,
            RequestOptions? options = null)
        {
            var httpOutcome = await serviceEndpoint.PutRawAsync(data, options);
            if (!httpOutcome)
                return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);

            return await httpOutcome.Value!.tryParseApiDataResponseAsync<T>(httpOutcome.Method);
        }

        /// <summary>
        ///   Sends an HTTP PUT message to the specified <see cref="ServiceEndpoint"/> for a "raw"
        ///   <see cref="HttpResponseMessage"/> response, allowing for customized response formatting or logics.
        ///   (see <see cref="PutAsync{T}(ServiceEndpoint,HttpContent,RequestOptions?)"/>
        ///   for retrieving a typed response).
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<HttpResponseMessage>> PutRawAsync(
            this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Put, invalidUrl!, null);

            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            options ??= RequestOptions.Default;
            options.ClientOptions ??= serviceEndpoint.ClientOptions.WithAuthorization(
                (await serviceEndpoint.GetAccessTokenAsync()).Value,
                serviceEndpoint.AuthorizationService);
            return await service.PutRawAsync(serviceEndpoint!, content, options);
        }

        /// <summary>
        ///   Sends an HTTP PUT message to the specified <see cref="ServiceEndpoint"/> for a "raw"
        ///   <see cref="HttpResponseMessage"/> response, allowing for customized response formatting or logics.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<HttpOutcome<HttpResponseMessage>> PutRawAsync(
            this ServiceEndpoint serviceEndpoint,
            object? data,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return Task.FromResult(invalidUrl.GetInvalidEndpointResponse(
                    HttpMethod.Put, 
                    invalidUrl!, 
                    null)); 

            var content = data is null
                ? new StringContent("{}")
                : new StringContent(JsonSerializer.Serialize(data));
            return serviceEndpoint.PutRawAsync(content, options);
        }
        
        /// <summary>
        ///   Sends an HTTP PATCH message to the specified <see cref="ServiceEndpoint"/> for a standardized
        ///   <see cref="ApiDataResponse{T}"/>.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> PatchAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            RequestOptions? options = null)
        {
            var httpOutcome = await serviceEndpoint.PutRawAsync(content, options);
            if (!httpOutcome)
                return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);

            return await httpOutcome.Value!.tryParseApiDataResponseAsync<T>(httpOutcome.Method);
        }
        
        /// <summary>
        ///   Sends an HTTP PATCH message to the specified <see cref="ServiceEndpoint"/> for a "raw"
        ///   <see cref="HttpResponseMessage"/> response, allowing for customized response formatting or logics.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="content">
        ///   The patched resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<HttpResponseMessage>> PatchRawAsync(
            this ServiceEndpoint serviceEndpoint,
            HttpContent content,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Patch, invalidUrl!, null);

            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            options ??= RequestOptions.Default;
            options.ClientOptions ??= serviceEndpoint.ClientOptions.WithAuthorization(
                (await serviceEndpoint.GetAccessTokenAsync()).Value,
                serviceEndpoint.AuthorizationService);
            return await service.PatchRawAsync(serviceEndpoint!, content, options);
        }   

        /// <summary>
        ///   Sends an HTTP PATCH message to the specified <see cref="ServiceEndpoint"/> for a "raw"
        ///   <see cref="HttpResponseMessage"/> response, allowing for customized response formatting or logics.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="data">
        ///   The patched resourced to be submitted.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<HttpOutcome<HttpResponseMessage>> PatchRawAsync(
            this ServiceEndpoint serviceEndpoint,
            object? data,
            RequestOptions? options = null)
        {
            var content = data is null
                ? new StringContent("{}")
                : new StringContent(JsonSerializer.Serialize(data));
            return serviceEndpoint.PatchRawAsync(content, options);
        }
        
        /// <summary>
        ///   Sends an HTTP DELETE message, passing a collection of resource <paramref name="keys"/>,
        ///   requesting removal of the corresponding resources, to the specified <see cref="ServiceEndpoint"/>.
        ///   The response is automatically deserialized into a <see cref="ApiDataResponse{T}"/>
        ///   carrying the expected (typed) resources.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="keys">
        ///   One or more keys, to identity the resources to be removed.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)<br/>
        ///   Query parameters.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Options for the request.    
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="ApiDataResponse{T}"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> DeleteAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            IEnumerable<string>? keys,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse<T>(HttpMethod.Delete, invalidUrl!, null);

            options ??= RequestOptions.Default;
            var data = new List<T>();

            var keyArray = keys?.ToArray();
            if (keyArray is null || keyArray.Length < 2)
                return await deleteAsync(keyArray?.FirstOrDefault());
            
            switch (options.Distribution)
            {
                case RequestDistribution.Sequential:
                    foreach (var key in keyArray)
                    {
                        if (options.CancellationToken.IsCancellationRequested)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Delete,
                                new ServerException("Request was cancelled", HttpStatusCode.InternalServerError));
                            
                        var outcome = await deleteAsync(key);
                        if (outcome)
                        {
                            data.AddRange(outcome.Value!.Data);
                            continue;
                        }
                            
                        if (!options.IsFailureTolerant)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Get,
                                outcome.Exception);
                    }
                    return HttpOutcome<ApiDataResponse<T>>.Success(
                        HttpMethod.Get, 
                        new ApiDataResponse<T>(data));
                
                case RequestDistribution.Parallel:
                    var requests = keyArray.Select(deleteAsync).ToArray();
                    await Task.WhenAll(requests);
                    foreach (var outcome in requests.Select(r => r.Result))
                    {
                        if (!outcome && !options.IsFailureTolerant)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Get,
                                outcome.Exception);
                        
                        data.AddRange(outcome.Value!.Data);
                    }
                    return HttpOutcome<ApiDataResponse<T>>.Success(
                        HttpMethod.Get, 
                        new ApiDataResponse<T>(data));
                
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(RequestOptions.Distribution),
                        $"Unsupported: {options.Distribution}");
            }
            
            async Task<HttpOutcome<ApiDataResponse<T>>> deleteAsync(string? key)
            {
                var httpOutcome = await serviceEndpoint.DeleteRawAsync(
                    (DynamicPath) key, 
                    queryParameters, 
                    options);
                if (!httpOutcome)
                    return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);

                return await httpOutcome.Value!.tryParseApiDataResponseAsync<T>(HttpMethod.Get);
            }
        }

        /// <summary>
        ///   Sends an HTTP DELETE message to the specified <see cref="ServiceEndpoint"/> and expects
        ///   untyped data in a successful response
        ///   (see <see cref="DeleteAsync{T}(ServiceEndpoint,IEnumerable{string}?,HttpQuery?,RequestOptions?)"/>
        ///   for retrieving a typed response).
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="subPath">
        ///   One or more key elements to be added to the endpoint path.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)
        ///   Query parameters.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Options for the request.   
        /// </param>
        /// <returns>
        ///   An <see cref="HttpOutcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="serviceEndpoint"/> was unassigned.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<HttpResponseMessage>> DeleteRawAsync(
            this ServiceEndpoint serviceEndpoint,
            DynamicPath subPath,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null)
        {
            if (serviceEndpoint is null) throw new ArgumentNullException(nameof(serviceEndpoint));
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Delete, invalidUrl!, null);
            
            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            options ??= RequestOptions.Default;
            options.ClientOptions ??= serviceEndpoint.ClientOptions.WithAuthorization(
                (await serviceEndpoint.GetAccessTokenAsync()).Value, 
                serviceEndpoint.AuthorizationService);
            return await service.DeleteRawAsync(
                serviceEndpoint.Path(options.DynamicPathValues, subPath),
                queryParameters, options);
        }
        
        /// <summary>
        ///   Adds one or more key elements to the endpoint path and returns the result as a <see cref="string"/>.
        /// </summary>
        /// <param name="endpoint">
        ///   The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="subPath">
        ///   (optional)<br/>
        ///   One or more key elements to be added to the endpoint path.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> value.
        /// </returns>
        /// <remarks>
        ///   The <see cref="ServiceEndpoint"/> is implicitly always cast to a <see cref="string"/>
        ///   so calling this method is not really necessary but might improve code readability. 
        /// </remarks>
        /// <seealso cref="Path(ServiceEndpoint,object?,DynamicPath)"/>
        public static string Path(this ServiceEndpoint endpoint, DynamicPath? subPath = null) 
            => subPath?.IsEmpty() ?? true
                ? endpoint.StringValue 
                : subPath.Insert(endpoint.StringValue).StringValue;
        
        /// <summary>
        ///   Returns the resolved endpoint path from a combination of dynamic path elements and a sub path. 
        /// </summary>
        /// <param name="endpoint">
        ///   The service endpoint to resolve the path for.
        /// </param>
        /// <param name="dynamicPathValues">
        ///   An object holding the values to be used when resolving variable elements of the path
        ///   (see <see cref="DynamicPathHelper.Substitute"/>).
        /// </param>
        /// <param name="subPath">
        ///   A path to be appended to the resolved service endpoint base path.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> representing the service endpoint path.
        /// </returns>
        public static string Path(this ServiceEndpoint endpoint, object? dynamicPathValues, DynamicPath subPath)
        {
            if (dynamicPathValues is null)
                return endpoint.Path(subPath);

            var pathElements = ((DynamicPath) endpoint.StringValue).Substitute(dynamicPathValues);
            return subPath.IsEmpty()
                ? pathElements.StringValue
                : subPath.Insert(pathElements.StringValue).StringValue;
        }
        
        static readonly char[] s_jsonApiDataResponseQualifier = $"{{\"meta\":{{\"{ApiMetadata.FormatKey}\":\"".ToCharArray();
        
        /// <summary>
        ///   Examines a (presumably downloaded) <see cref="string"/> and resolves whether it is standardized
        ///   Tetra Pak JSON response format and, if so, what version.
        /// </summary>
        /// <param name="data">
        ///   The <see cref="string"/> to be examined.
        /// </param>
        /// <param name="version">
        ///   Passes back the format version expressed by the JSON data when successful;
        ///   otherwise passes back <c>null</c>.  
        /// </param>
        /// <returns>
        ///   <c>true</c> if <paramref name="data"/> was found to contain standardized Tetra Pak JSON response
        ///   format (<see cref="ApiDataResponse"/>); otherwise <c>false</c>.
        /// </returns>
        public static bool IsJsonApiDataResponse(this string data, out string? version)
        {
            var ca = data.ToCharArray();
            var i = 0;
            for (var q = 0; q < s_jsonApiDataResponseQualifier.Length; q++)
            {
                var c = ca[i++];
                if (char.IsWhiteSpace(c))
                    continue;

                if (c == s_jsonApiDataResponseQualifier[q])
                    continue;

                version = null;
                return false;
            }

            version = null;
            var sbVersion = new StringBuilder();
            for (; i < ca.Length; i++)
            {
                var c = ca[i];
                if (c != '\"')
                {
                    sbVersion.Append(c);
                    continue;
                }
                version = sbVersion.ToString();
                break;
            }
            return true;
        }

        static bool isJsonList(this string json)
        {
            var ca = json.Trim().ToCharArray();
            return ca.Length > 0 && ca[0] == '[';
        }

        static bool isJsonObject(this string json)
        {
            var ca = json.Trim().ToCharArray();
            return ca.Length > 0 && ca[0] == '{';
        }
        
        static async Task<HttpOutcome<ApiDataResponse<T>>> tryParseApiDataResponseAsync<T>(
            this HttpResponseMessage httpResponseMessage, 
            HttpMethod httpMethod)
        {
            var data = (await httpResponseMessage.Content.ReadAsStringAsync()).Trim();
            
            // todo Consider parsing HTTP result in background thread when result exceeds a threshold size
            // todo Add logging to TryParseResultAsync<T>

            return parseResult();
            
            HttpOutcome<ApiDataResponse<T>> parseResult()
            {
                if (string.IsNullOrWhiteSpace(data))
                    return HttpOutcome<ApiDataResponse<T>>.Fail(httpMethod, new ServerException(HttpStatusCode.NoContent));
                
                // first try parsing Tetra Pak Api Data Response format ...
                if (data.IsJsonApiDataResponse(out _))
                {
                    try
                    {
                        var apiDataResponse = JsonSerializer.Deserialize<ApiDataResponse<T>>(data);
                        return apiDataResponse is { }
                            ? HttpOutcome<ApiDataResponse<T>>.Success(httpMethod, apiDataResponse)
                            : unexpectedJsonFormatFailure();
                    }
                    catch
                    {
                        // fall back to other parsing strategies
                    }
                }

                if (data.isJsonObject())
                {
                    try
                    {
                        var obj = JsonSerializer.Deserialize<T>(data);
                        return HttpOutcome<ApiDataResponse<T>>.Success(
                            httpMethod, 
                            new ApiDataResponse<T>(obj is {} ? new[] { obj } : null));
                    }
                    catch
                    {
                        return unexpectedJsonFormatFailure();
                    }
                }
                
                if (!data.isJsonList())
                    return unexpectedJsonFormatFailure();

                try
                {
                    var items = JsonSerializer.Deserialize<IEnumerable<T>>(data);
                    return HttpOutcome<ApiDataResponse<T>>.Success(httpMethod, new ApiDataResponse<T>(items));
                }
                catch
                {
                    return unexpectedJsonFormatFailure();
                }
            }
            
            HttpOutcome<ApiDataResponse<T>> unexpectedJsonFormatFailure() 
                =>
                HttpOutcome<ApiDataResponse<T>>.Fail(
                    httpMethod,
                    new ServerException("Unexpected JSON response format", HttpStatusCode.InternalServerError));
                
        }
    }
}