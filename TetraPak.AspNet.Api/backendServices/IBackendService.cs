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
        /// <returns>
        ///   A collection of key value pairs with the names of endpoints as keys. 
        /// </returns>
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
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<HttpOutcome<HttpResponseMessage>> PostRawAsync(
            string path,
            HttpContent content,
            RequestOptions? options = null);
        
        /// <summary>
        ///   Sends a PUT request to the backend service.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="content">
        ///   The content to be put.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<HttpOutcome<HttpResponseMessage>> PutRawAsync(
            string path,
            HttpContent content,
            RequestOptions? options = null);

        /// <summary>
        ///   Sends a PATCH request to the backend service.
        /// </summary>
        /// <param name="path">
        ///   The path to the requested resource. 
        /// </param>
        /// <param name="content">
        ///   The content to be patched.
        /// </param>
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<HttpOutcome<HttpResponseMessage>> PatchRawAsync(
            string path,
            HttpContent content,
            RequestOptions? options = null);

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
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetCollectionAsync{T}"/>
        Task<HttpOutcome<HttpResponseMessage>> GetRawAsync(
            string path,
            HttpQuery? queryParameters = null,
            RequestOptions? options = null);

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
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <typeparam name="T">Specifies the type of object to be retrieved.</typeparam>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetRawAsync"/>
        Task<HttpEnumOutcome<T>> GetCollectionAsync<T>(
            string path,
            HttpQuery? queryParameters = null, 
            RequestOptions? options = null);
        
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
        /// <param name="options">
        ///   (optional; default=<see cref="RequestOptions.Default"/>)<br/>
        ///   Specifies options for the request.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetRawAsync"/>
        Task<HttpOutcome<HttpResponseMessage>> DeleteRawAsync(
            string path,
            HttpQuery? queryParameters = null, 
            RequestOptions? options = null);
    }
}