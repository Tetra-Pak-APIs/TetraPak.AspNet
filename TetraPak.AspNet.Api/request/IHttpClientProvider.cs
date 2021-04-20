using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Provides a <see cref="HttpClient"/>, either as a singleton or a transient instance.   
    /// </summary>
    public interface IHttpClientProvider
    {
        /// <summary>
        ///   Returns a (configured) 
        /// </summary>
        /// <param name="options">
        ///   (optional)<br/>
        ///   A (customizable) set of options to describe the requested <see cref="HttpClient"/>.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   A <see cref="CancellationToken"/>
        /// </param>
        /// <param name="logger">
        ///   (optional)<br/>
        ///   An <see cref="ILogger"/> instance.
        /// </param>
        /// <returns>
        ///   A <see cref="Outcome{T}"/> value indicating success/failure and, on success, carrying
        ///   the requested client as its <see cref="Outcome{T}.Value"/>; otherwise an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<HttpClient>> GetHttpClientAsync(
            HttpClientOptions options = null, 
            CancellationToken? cancellationToken = null, 
            ILogger logger = null);
    }

    public interface IApiLoggerProvider
    {
        ILogger GetLogger();

        void SetLogger(ILogger logger);
    }
}