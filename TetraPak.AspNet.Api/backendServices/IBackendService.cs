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
        ///   Gets default options for the creating clients for the backend service. 
        /// </summary>
        HttpClientOptions DefaultClientOptions { get; }

        Task<Outcome<ActorToken>> AuthenticateAsync(
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null);

        /// <summary>
        ///   Sends a POST request to the backend service.
        /// </summary>
        /// <param name="path">
        ///     The path to the requested resource. 
        /// </param>
        /// <param name="content">
        ///     The content to be posted.
        /// </param>
        /// <param name="clientOptions">
        ///     (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        ///     Specifies options for creating a client.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        ///     A <see cref="CancellationToken"/>.
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
        ///   Sends a POST request to the backend service.
        /// </summary>
        /// <param name="path">
        ///     The path to the requested resource. 
        /// </param>
        /// <param name="queryParameters">
        ///     (optional)
        ///     Query parameters.
        /// </param>
        /// <param name="clientOptions">
        ///     (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        ///     Specifies options for creating a client.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        ///     A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            IDictionary<string, string> queryParameters,
            HttpClientOptions clientOptions,
            CancellationToken? cancellationToken = null,
            string messageId = null);

        /// <summary>
        ///   Sends a POST request to the backend service.
        /// </summary>
        /// <param name="path">
        ///     The path to the requested resource. 
        /// </param>
        /// <param name="queryParameters">
        ///     (optional)
        ///     Query parameters.
        /// </param>
        /// <param name="clientOptions">
        ///     (optional; default=<see cref="DefaultClientOptions"/>)<br/>
        ///     Specifies options for creating a client.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        ///     A <see cref="CancellationToken"/>.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<HttpResponseMessage>> GetAsync(
            string path,
            string queryParameters = null,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null,
            string messageId = null);
    }
}