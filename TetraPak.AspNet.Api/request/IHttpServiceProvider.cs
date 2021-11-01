// using TetraPak.AspNet.Auth;
//
// #nullable enable
//
// namespace TetraPak.AspNet.Api
// {
//     /// <summary>
//     ///   Just a convenient code interface for a collection of services, required by APIs.   
//     /// </summary>
//     public interface IHttpServiceProvider : 
//         IHttpClientProvider, 
//         // IApiLoggerProvider, obsolete
//         IMessageIdProvider, 
//         IAccessTokenProvider
//         // IAuthorizationService obsolete
//     {
//         // /// <summary>
//         // ///   Obtains the access token for the current request/response context. obsolete
//         // /// </summary>
//         // /// <param name="config">
//         // ///   The Tetra Pak integration configuration.
//         // /// </param>
//         // /// <returns>
//         // ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
//         // ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
//         // /// </returns>
//         // Task<Outcome<ActorToken>> GetAccessTokenAsync(TetraPakConfig config);
//         
//         // /// <summary>
//         // ///   Authenticates a specific service.  obsolete
//         // /// </summary>
//         // /// <param name="options">
//         // ///   Options for obtaining a client.
//         // /// </param>
//         // /// <param name="cancellationToken">
//         // ///   (optional)<br/>
//         // ///   A <see cref="CancellationToken"/>
//         // /// </param>
//         // /// <returns>
//         // ///   A <see cref="Outcome{T}"/> value indicating success/failure and, on success, carrying
//         // ///   the requested token as its <see cref="Outcome{T}.Value"/>; otherwise an <see cref="Exception"/>.
//         // /// </returns>
//         // Task<Outcome<ActorToken>> AuthorizeAsync(
//         //     HttpClientOptions options,
//         //     CancellationToken? cancellationToken = null);
//
//         // /// <summary>
//         // ///   Acquires a token exchange service. obsolete
//         // /// </summary>
//         // /// <returns>
//         // ///   A <see cref="ITokenExchangeService"/>.
//         // /// </returns>
//         // Task<ITokenExchangeService> GetTokenExchangeService();
//     }
//
//     // /// <summary>
//     // ///   Classes implementing this contract can be used to acquire a logging provider.
//     // /// </summary>
//     // public interface IApiLoggerProvider
//     // {
//     //     /// <summary>
//     //     ///   Gets a logging provider.
//     //     /// </summary>
//     //     /// <returns>
//     //     ///   A <see cref="ILogger"/> instance.
//     //     /// </returns>
//     //     ILogger GetLogger();
//     //
//     //     // /// <summary>
//     //     // ///   Sets a specific logging provider. obsolete
//     //     // /// </summary>
//     //     // /// <param name="logger">
//     //     // ///   A logging provider to be used.
//     //     // /// </param>
//     //     // void SetLogger(ILogger logger);
//     // }
// }