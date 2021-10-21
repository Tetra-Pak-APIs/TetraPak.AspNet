using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Provides a <see cref="HttpClient"/>, either as a singleton or a transient instance.   
    /// </summary>
    public interface IHttpServiceProvider : IApiLoggerProvider, IMessageIdProvider, IAccessTokenProvider
    {
        Task<Outcome<ActorToken>> GetAccessTokenAsync(TetraPakConfig config);
        
        /// <summary>
        ///   Creates and returns a (configured) <see cref="HttpClient"/> for use with a specific service. 
        /// </summary>
        /// <param name="options">
        ///     (optional)<br/>
        ///     A (customizable) set of options to describe the requested <see cref="HttpClient"/>.
        /// </param>
        /// <param name="cancellationToken">
        ///     (optional)<br/>
        ///     A <see cref="CancellationToken"/>
        /// </param>
        /// <param name="logger">
        ///     (optional)<br/>
        ///     An <see cref="ILogger"/> instance.
        /// </param>
        /// <param name="authenticate">
        ///     (optional; default=<c>true</c>)<br/>
        ///     Specifies whether the created client should automatically be configured.
        ///     Set to false to avoid implicitly invoking the <see cref="AuthorizeAsync"/> method. 
        /// </param>
        /// <returns>
        ///   A <see cref="Outcome{T}"/> value indicating success/failure and, on success, carrying
        ///   the requested client as its <see cref="Outcome{T}.Value"/>; otherwise an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<HttpClient>> GetClientAsync(
            HttpClientOptions options = null,
            CancellationToken? cancellationToken = null,
            ILogger logger = null,
            bool authenticate = true);


        /// <summary>
        ///   Authenticates a specific service. 
        /// </summary>
        /// <param name="options">
        ///   Options for obtaining a client.
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
        ///   the requested token as its <see cref="Outcome{T}.Value"/>; otherwise an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<ActorToken>> AuthorizeAsync(
            HttpClientOptions options,
            CancellationToken? cancellationToken = null, 
            ILogger logger = null);

        /// <summary>
        ///   Acquires a token exchange service.
        /// </summary>
        /// <returns></returns>
        Task<ITokenExchangeService> GetTokenExchangeService();
    }

    /// <summary>
    ///   Classes implementing this contract can be used to acquire a logging provider.
    /// </summary>
    public interface IApiLoggerProvider
    {
        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        /// <returns>
        ///   A <see cref="ILogger"/> instance.
        /// </returns>
        ILogger GetLogger();

        // /// <summary>
        // ///   Sets a specific logging provider. obsolete
        // /// </summary>
        // /// <param name="logger">
        // ///   A logging provider to be used.
        // /// </param>
        // void SetLogger(ILogger logger);
    }
}