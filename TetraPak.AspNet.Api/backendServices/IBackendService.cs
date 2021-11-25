using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TetraPak.AspNet.Auth;

#nullable enable

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Classes implementing this contract can be used to consume a backend service. 
    /// </summary>
    public interface IBackendService : IServiceAuthConfig
    {
        /// <summary>
        ///   Gets the identity of the service. This identity should be unique with the runtime context. 
        /// </summary>
        string ServiceName { get; }
        
        /// <summary>
        ///   Gets default options for the creating clients for the backend service. 
        /// </summary>
        HttpClientOptions DefaultClientOptions { get; }

        /// <summary>
        ///   Obtains authorization to consume the service. 
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
        Task<Outcome<ActorToken>> AuthorizeAsync(
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null);

        /// <summary>
        ///   Gets a named service endpoint.
        /// </summary>
        /// <param name="name">
        ///   The name of the requested endpoint.
        /// </param>
        /// <returns>
        ///   
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="name"/> was unassigned (<c>null</c> or just whitespace).
        /// </exception>
        ServiceEndpoint GetEndpoint(string name);

        /// <summary>
        ///   Gets a collection of <see cref="KeyValuePair{TKey,TValue}"/> with all endpoint names (key)
        ///   and the corresponding <see cref="ServiceEndpoint"/> (value).
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string,ServiceEndpoint>> GetEndpoints();

        /// <summary>
        ///   Sends a POST request to the backend service.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="content">
        ///   The content to be posted.
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
        Task<HttpOutcome<HttpResponseMessage>> PostAsync(
            string path,
            HttpContent content,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null);
        
        /// <summary>
        ///   Sends a PUT request to the backend service.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="content">
        ///   The content to be put.
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
        Task<HttpOutcome<HttpResponseMessage>> PutAsync(
            string path,
            HttpContent content,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null);

        /// <summary>
        ///   Sends a PATCH request to the backend service.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="content">
        ///   The content to be patched.
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
        Task<HttpOutcome<HttpResponseMessage>> PatchAsync(
            string path,
            HttpContent content,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null);

        /// <summary>
        ///   Sends a PATCH request to the backend service.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="data">
        ///   The content to be patched.
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
        Task<HttpOutcome<HttpResponseMessage>> PatchAsync(
            string path,
            object? data,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null);

        /// <summary>
        ///   Sends a GEt request to the backend service to retrieve a <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)
        ///   Query parameters.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        ///   Specifies options for creating a client.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows cancelling the operation.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetAsync{T}(string,HttpQuery,HttpClientOptions,Nullable{CancellationToken},string)"/>
        Task<HttpOutcome<HttpResponseMessage>> GetAsync(
            string path,
            HttpQuery? queryParameters = null,
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null,
            string? messageId = null);

        /// <summary>
        ///   Sends a GET request to the backend service to retrieve an object of a specified type.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="queryParameters">
        ///   (optional)
        ///   Query parameters.
        /// </param>
        /// <param name="clientOptions">
        ///   (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        ///   Specifies options for creating a client.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Allows cancelling the operation.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <typeparam name="T">Specifies the type of object to be retrieved.</typeparam>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetAsync(string,HttpQuery,HttpClientOptions,Nullable{CancellationToken},string)"/>
        Task<HttpEnumOutcome<T>> GetAsync<T>(
            string path,
            HttpQuery? queryParameters = null, 
            HttpClientOptions? clientOptions = null,
            CancellationToken? cancellationToken = null,
            string? messageId = null);

        // /// <summary>
        // ///   Sends a GET request to the backend service to retrieve a <see cref="HttpResponseMessage"/>. obsolete
        // /// </summary>
        // /// <param name="path">
        // ///   The path to the requested resource. 
        // /// </param>
        // /// <param name="queryParameters">
        // ///   (optional)
        // ///   Query parameters.
        // /// </param>
        // /// <param name="clientOptions">
        // ///   (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        // ///   Specifies options for creating a client.
        // /// </param>
        // /// <param name="cancellationToken">
        // ///   (optional)<br/>
        // ///   Allows cancelling the operation.
        // /// </param>
        // /// <param name="messageId">
        // ///   (optional)<bt/>
        // ///   A unique string value to be used for referencing/diagnostics purposes.
        // /// </param>
        // /// <returns>
        // ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        // ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        // /// </returns>
        // /// <seealso cref="GetAsync(string,HttpQueryParameters,HttpClientOptions,Nullable{CancellationToken},string)"/>
        // /// <seealso cref="GetAsync{T}(string,string,HttpClientOptions,Nullable{CancellationToken},string)"/>
        // /// <seealso cref="GetAsync{T}(string,HttpQueryParameters,HttpClientOptions,Nullable{CancellationToken},string)"/>
        // Task<HttpOutcome<HttpResponseMessage>> GetAsync(
        //     string path,
        //     string? queryParameters = null,
        //     HttpClientOptions? clientOptions = null,
        //     CancellationToken? cancellationToken = null,
        //     string? messageId = null);

        // /// <summary>
        // ///   Sends a GET request to the backend service to retrieve an object of a specified type.
        // /// </summary>
        // /// <param name="path">
        // ///   The path to the requested resource. 
        // /// </param>
        // /// <param name="queryParameters">
        // ///   (optional)
        // ///   Query parameters.
        // /// </param>
        // /// <param name="clientOptions">
        // ///   (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        // ///   Specifies options for creating a client.
        // /// </param>
        // /// <param name="cancellationToken">
        // ///   (optional)<br/>
        // ///   Allows cancelling the operation.
        // /// </param>
        // /// <param name="messageId">
        // ///   (optional)<bt/>
        // ///   A unique string value to be used for referencing/diagnostics purposes.
        // /// </param>
        // /// <typeparam name="T">Specifies the type of object to be retrieved.</typeparam>
        // /// <returns>
        // ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        // ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        // /// </returns>
        // /// <seealso cref="GetAsync(string,HttpQueryParameters,HttpClientOptions,Nullable{CancellationToken},string)"/>
        // /// <seealso cref="GetAsync(string,string,HttpClientOptions,Nullable{CancellationToken},string)"/>
        // /// <seealso cref="GetAsync{T}(string,HttpQueryParameters,HttpClientOptions,Nullable{CancellationToken},string)"/>
        // Task<HttpEnumOutcome<T>> GetAsync<T>(
        //     string path,
        //     string? queryParameters = null,
        //     HttpClientOptions? clientOptions = null,
        //     CancellationToken? cancellationToken = null,
        //     string? messageId = null);

    }
}