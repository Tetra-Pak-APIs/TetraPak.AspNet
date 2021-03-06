using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TetraPak.AspNet.Auth;

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

        Task<Outcome<ActorToken>> AuthenticateAsync(
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null);

        ServiceEndpoint GetEndpoint(string name);

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
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<HttpResponseMessage>> PostAsync(
            string path,
            HttpContent content,
            HttpClientOptions clientOptions = null,
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
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetAsync(string,string,TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync{T}(string,System.Collections.Generic.IDictionary{string,string},TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync{T}(string,string,TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            IDictionary<string, string> queryParameters,
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null,
            string messageId = null);

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
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <typeparam name="T">Specifies the type of object to be retrieved.</typeparam>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetAsync(string,System.Collections.Generic.IDictionary{string,string},TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync(string,string,TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync{T}(string,string,TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        Task<Outcome<T>> GetAsync<T>(
            string path,
            IDictionary<string, string> queryParameters,
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null,
            string messageId = null);

        
        /// <summary>
        ///   Sends a GET request to the backend service to retrieve a <see cref="HttpResponseMessage"/>.
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
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetAsync(string,System.Collections.Generic.IDictionary{string,string},TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync{T}(string,string,TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync{T}(string,System.Collections.Generic.IDictionary{string,string},TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            string queryParameters = null,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null,
            string messageId = null);

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
        ///   A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <typeparam name="T">Specifies the type of object to be retrieved.</typeparam>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <seealso cref="GetAsync(string,System.Collections.Generic.IDictionary{string,string},TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync(string,string,TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        /// <seealso cref="GetAsync{T}(string,System.Collections.Generic.IDictionary{string,string},TetraPak.AspNet.Api.HttpClientOptions,System.Nullable{System.Threading.CancellationToken},string)"/>
        Task<Outcome<T>> GetAsync<T>(
            string path,
            string queryParameters = null,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null,
            string messageId = null);

    }
}