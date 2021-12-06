﻿using System;
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

        /// <summary>
        ///   Obtains authorization for consuming the endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///   The extended service endpoint.
        /// </param>
        /// <param name="httpMethod">
        ///   The HTTP method intended for consuming the endpoint. 
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables cancellation of the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
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
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/> to receive a
        ///   <see cref="HttpResponseMessage"/> back (see remarks).
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
        /// <remarks>
        ///   Use this method when you need more control over how to manage the response.
        ///   For more standard responses, please see
        ///   <see cref="GetAsync{T}(ServiceEndpoint,IEnumerable{string},HttpQuery?,RequestOptions?,HttpClientOptions?)"/>
        /// </remarks>
        /// <seealso cref="GetHttpResponseAsync(TetraPak.AspNet.Api.ServiceEndpoint,TetraPak.AspNet.HttpQuery?,System.Nullable{System.Threading.CancellationToken},TetraPak.AspNet.HttpClientOptions?)"/>
        /// <seealso cref="GetAsync{T}(ServiceEndpoint,IEnumerable{string},HttpQuery?,RequestOptions?,HttpClientOptions?)"/>
        public static async Task<HttpOutcome<HttpResponseMessage>> GetHttpResponseAsync(
            this ServiceEndpoint serviceEndpoint,
            HttpQuery? queryParameters = null,
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

        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/> and expects
        ///   untyped data in a successful response
        ///   (see <see cref="GetAsync{T}(ServiceEndpoint,IEnumerable{string},HttpQuery,RequestOptions,HttpClientOptions)"/>
        ///   for retrieving a typed response).
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="dynamicPathElements"></param>
        /// <param name="subPath">
        ///     One or more key elements to be added to the endpoint path.
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
        /// <seealso cref="GetAsync{T}(ServiceEndpoint,IEnumerable{string},HttpQuery,RequestOptions,HttpClientOptions)"/>
        /// <seealso cref="GetAsync{T}(ServiceEndpoint,HttpQuery,RequestOptions,HttpClientOptions)"/>
        public static async Task<HttpOutcome<HttpResponseMessage>> GetHttpResponseAsync(
            this ServiceEndpoint serviceEndpoint,
            object? dynamicPathElements,
            DynamicPath subPath,
            HttpQuery? queryParameters = null,
            CancellationToken? cancellationToken = null,
            HttpClientOptions? clientOptions = null)
        {
            if (serviceEndpoint is ServiceInvalidEndpoint invalidUrl)
                return invalidUrl.GetInvalidEndpointResponse(HttpMethod.Get, invalidUrl!, null);
            
            var service = serviceEndpoint.Service 
                          ?? throw new InvalidOperationException($"Endpoint Url {serviceEndpoint} was not assigned to a service");
            return await service.GetAsync(
                serviceEndpoint.Path(dynamicPathElements, subPath),
                queryParameters,
                clientOptions ?? serviceEndpoint.ClientOptions.WithAuthorization(
                    (await serviceEndpoint.GetAccessTokenAsync()).Value, 
                    serviceEndpoint.AuthorizationService),
                cancellationToken);
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
        /// <param name="clientOptions">
        ///   (optional)<br/>
        ///   Options for the client to be used for the operation.
        /// </param>
        /// <param name="requestOptions">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies how multiple requests are made.
        ///   This option affect response times or possible service quota.    
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<HttpOutcome<ApiDataResponse<T>>> GetAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            HttpQuery? queryParameters = null,
            RequestOptions? requestOptions = null,
            HttpClientOptions? clientOptions = null)
        => 
            serviceEndpoint.GetAsync<T>(null!, queryParameters, requestOptions, clientOptions);


        /// <summary>
        ///   Sends an HTTP GET message to the specified <see cref="ServiceEndpoint"/> while specifying one or
        ///   more resource keys.
        ///   The response is automatically deserialized into a <see cref="ApiDataResponse{T}"/>
        ///   carrying the expected (typed) resources.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="keys">
        ///   A collection of resource keys (for obtaining multiple resources).
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)<br/>
        ///   Query parameters.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional)<br/>
        ///   Options for the client to be used for the operation.
        /// </param>
        /// <param name="requestOptions">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies how multiple requests are made.
        ///   This option affect response times or possible service quota.    
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static Task<HttpOutcome<ApiDataResponse<T>>> GetAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            IEnumerable<string>? keys,
            HttpQuery? queryParameters = null,
            RequestOptions? requestOptions = null,
            HttpClientOptions? clientOptions = null)
        => 
            serviceEndpoint.GetAsync<T>(keys, null, queryParameters, requestOptions, clientOptions);

        /// <summary>
        ///   Sends an HTTP GET message, passing a collection of resource <paramref name="keys"/> requesting the
        ///   corresponding resources, to the specified <see cref="ServiceEndpoint"/>.
        ///   The response is automatically deserialized into a <see cref="ApiDataResponse{T}"/>
        ///   carrying the expected (typed) resources.
        /// </summary>
        /// <param name="serviceEndpoint">
        ///     The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="dynamicPathElements">
        ///   An object used to resolve dynamic elements of the endpoint path. 
        /// </param>
        /// <param name="keys">
        ///   One or more keys, to identity the requested resources.
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)<br/>
        ///   Query parameters.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional)<br/>
        ///   Options for the client to be used for the operation.
        /// </param>
        /// <param name="requestOptions">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies how multiple requests are made.
        ///   This option affect response times or possible service quota.    
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   The <paramref name="serviceEndpoint"/> was not assigned to a registered service.
        /// </exception>
        public static async Task<HttpOutcome<ApiDataResponse<T>>> GetAsync<T>(
            this ServiceEndpoint serviceEndpoint,
            object? dynamicPathElements = null,
            IEnumerable<string>? keys = null,
            HttpQuery? queryParameters = null,
            RequestOptions? requestOptions = null,
            HttpClientOptions? clientOptions = null)
        {
            requestOptions ??= RequestOptions.Default;
            var data = new List<T>();

            var keyArray = keys?.ToArray();
            if ((!keyArray?.Any() ?? true) || keyArray?.Length == 1)
                return await getAsync(null);
            
            switch (requestOptions.Distribution)
            {
                case RequestDistribution.Sequential:
                    foreach (var key in keyArray!)
                    {
                        if (requestOptions.CancellationToken.IsCancellationRequested)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Get,
                                new ServerException("Request was cancelled", HttpStatusCode.InternalServerError));
                            
                        var outcome = await getAsync(key);
                        if (outcome)
                        {
                            data.AddRange(outcome.Value!.Data);
                            continue;
                        }
                            
                        if (!requestOptions.IsFailureTolerant)
                            return HttpOutcome<ApiDataResponse<T>>.Fail(
                                HttpMethod.Get,
                                outcome.Exception);
                    }
                    return HttpOutcome<ApiDataResponse<T>>.Success(
                        HttpMethod.Get, 
                        new ApiDataResponse<T>(data));
                
                case RequestDistribution.Parallel:
                    var requests = keyArray!.Select(getAsync).ToArray();
                    await Task.WhenAll(requests);
                    foreach (var outcome in requests.Select(r => r.Result))
                    {
                        if (!outcome && !requestOptions.IsFailureTolerant)
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
                        $"Unsupported: {requestOptions.Distribution}");
            }
            
            async Task<HttpOutcome<ApiDataResponse<T>>> getAsync(string? key)
            {
                var httpOutcome = await serviceEndpoint.GetHttpResponseAsync(
                    dynamicPathElements,
                    key, 
                    queryParameters, 
                    requestOptions.CancellationToken, 
                    clientOptions);
                if (!httpOutcome)
                    return HttpOutcome<ApiDataResponse<T>>.Fail(httpOutcome.Method, httpOutcome.Exception);

                return await httpOutcome.Value!.TryParseApiDataResponseAsync<T>(HttpMethod.Get);
            }
        }

        public static async Task<HttpOutcome<HttpResponseMessage>> GetRawAsync(
            this ServiceEndpoint serviceEndpoint,
            object? dynamicPathElements = null,
            string? key = null,
            HttpQuery? queryParameters = null,
            RequestOptions? requestOptions = null,
            HttpClientOptions? clientOptions = null)
        {
            requestOptions ??= RequestOptions.Default;
            return await serviceEndpoint.GetHttpResponseAsync(
                dynamicPathElements,
                key, 
                queryParameters, 
                requestOptions.CancellationToken, 
                clientOptions);
        }

        public static async Task<HttpOutcome<Stream>> GetStreamAsync(
            this ServiceEndpoint serviceEndpoint,
            object? dynamicPathElements = null,
            string? key = null,
            HttpQuery? queryParameters = null,
            RequestOptions? requestOptions = null,
            HttpClientOptions? clientOptions = null)
        {
            var rawOutcome = await serviceEndpoint.GetRawAsync(
                dynamicPathElements, 
                key,
                queryParameters,
                requestOptions, clientOptions);

            return rawOutcome
                ? HttpOutcome<Stream>.Success(HttpMethod.Get, await rawOutcome.Value!.Content.ReadAsStreamAsync())
                : HttpOutcome<Stream>.Fail(HttpMethod.Get, rawOutcome.Exception); 
        }

        static async Task<HttpOutcome<ApiDataResponse<T>>> TryParseApiDataResponseAsync<T>(
            this HttpResponseMessage httpResponseMessage, 
            HttpMethod httpMethod)
        {
            var json = (await httpResponseMessage.Content.ReadAsStringAsync()).Trim();
            
            // todo Consider parsing HTTP result in background thread when result exceeds a threshold size
            // todo Add logging to TryParseResultAsync<T>

            return parseResult();
            
            HttpOutcome<ApiDataResponse<T>> parseResult()
            {
                if (string.IsNullOrWhiteSpace(json))
                    return HttpOutcome<ApiDataResponse<T>>.Fail(httpMethod, new ServerException(HttpStatusCode.NoContent));
                
                // first try parsing Tetra Pak Api Data Response format ...
                if (json.IsJsonApiDataResponse(out _))
                {
                    try
                    {
                        var apiDataResponse = JsonSerializer.Deserialize<ApiDataResponse<T>>(json);
                        return apiDataResponse is { }
                            ? HttpOutcome<ApiDataResponse<T>>.Success(httpMethod, apiDataResponse)
                            : unexpectedJsonFormatFailure();
                    }
                    catch
                    {
                        // fall back to other parsing strategies
                    }
                }

                if (json.IsJsonObject())
                {
                    try
                    {
                        var obj = JsonSerializer.Deserialize<T>(json);
                        return HttpOutcome<ApiDataResponse<T>>.Success(httpMethod, new ApiDataResponse<T>(new[] { obj }));
                    }
                    catch
                    {
                        return unexpectedJsonFormatFailure();
                    }
                }
                
                if (!json.IsJsonList())
                    return unexpectedJsonFormatFailure();

                try
                {
                    var items = JsonSerializer.Deserialize<IEnumerable<T>>(json);
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

        static readonly char[] s_jsonApiDataResponseQualifier = $"{{\"meta\":{{\"{ApiMetadata.FormatKey}\":\"".ToCharArray();
        
        static bool IsJsonApiDataResponse(this string json, out string? version)
        {
            var ca = json.ToCharArray();
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

        static bool IsJsonList(this string json)
        {
            var ca = json.Trim().ToCharArray();
            return ca.Length > 0 && ca[0] == '[';
        }

        static bool IsJsonObject(this string json)
        {
            var ca = json.Trim().ToCharArray();
            return ca.Length > 0 && ca[0] == '{';
        }

        /// <summary>
        ///   Returns the endpoint path as a <see cref="string"/>.
        /// </summary>
        /// <param name="endpoint">
        ///   The service endpoint.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        ///   The <see cref="ServiceEndpoint"/> is implicitly always cast to a <see cref="string"/>
        ///   so calling this method is not really necessary but might improve code readability. 
        /// </remarks>
        /// <seealso cref="Path(ServiceEndpoint,DynamicPath)"/>
        public static string Path(this ServiceEndpoint endpoint) => endpoint.StringValue;

        /// <summary>
        ///   Adds one or more key elements to the endpoint path and returns the result as a <see cref="string"/>.
        /// </summary>
        /// <param name="endpoint">
        ///   The extended <see cref="ServiceEndpoint"/>.
        /// </param>
        /// <param name="subPath">
        ///   One or more key elements to be added to the endpoint path.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> value.
        /// </returns>
        /// <remarks>
        ///   The <see cref="ServiceEndpoint"/> is implicitly always cast to a <see cref="string"/>
        ///   so calling this method is not really necessary but might improve code readability. 
        /// </remarks>
        /// <seealso cref="Path(ServiceEndpoint)"/>
        public static string Path(this ServiceEndpoint endpoint, DynamicPath subPath) 
            => subPath.IsEmpty()
                ? endpoint.StringValue 
                : subPath.Insert(endpoint.StringValue).StringValue;
        
        public static string Path(this ServiceEndpoint endpoint, object? dynamicPathElements, DynamicPath subPath)
        {
            if (dynamicPathElements is null)
                return endpoint.Path(subPath);

            var pathElements = ((DynamicPath) endpoint.StringValue).Substitute(dynamicPathElements, true);
            return subPath.IsEmpty()
                ? pathElements.StringValue
                : subPath.Insert(pathElements.StringValue).StringValue;
        }

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
        public static async Task<Outcome<HttpResponseMessage>> PostAsync(
            this ServiceEndpoint serviceEndpoint,
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
        public static Task<Outcome<HttpResponseMessage>> PostAsync(
            this ServiceEndpoint serviceEndpoint,
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
        public static async Task<Outcome<HttpResponseMessage>> PutAsync(
            this ServiceEndpoint serviceEndpoint,
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
        public static Task<Outcome<HttpResponseMessage>> PutAsync(
            this ServiceEndpoint serviceEndpoint,
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
        public static async Task<Outcome<HttpResponseMessage>> PatchAsync(
            this ServiceEndpoint serviceEndpoint,
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
        public static Task<Outcome<HttpResponseMessage>> PatchAsync(
            this ServiceEndpoint serviceEndpoint,
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