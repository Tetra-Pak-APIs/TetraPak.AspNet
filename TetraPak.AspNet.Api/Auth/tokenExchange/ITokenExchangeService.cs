using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Implementors of this interface can be used for exchanging access tokens.  
    /// </summary>
    public interface ITokenExchangeService
    {
        /// <summary>
        ///   Exchanges a specified access token for a new, to be used for consuming a service.
        /// </summary>
        /// <param name="credentials">
        ///   Specifies the credentials used for the token exchange
        ///   (typically <see cref="BasicAuthCredentials"/> carrying client id and client secret).
        /// </param>
        /// <param name="accessToken">
        ///   The access token to be exchanged.
        /// </param>
        /// <param name="cancellationToken">
        ///   A cancellation token.
        /// </param>
        /// <returns>
        ///   A <see cref="Outcome{T}"/> value indicating success/failure and.
        ///   On success the value also carries the requested result; otherwise a <see cref="Exception"/> might
        ///   be carried instead.
        /// </returns>
        Task<Outcome<TokenExchangeResponse>> ExchangeAccessTokenAsync(
            Credentials credentials,
            ActorToken accessToken, 
            CancellationToken cancellationToken);

        /// <summary>
        ///   Creates a <see cref="AuthenticationHeaderValue"/> from a <see cref="TokenExchangeResponse"/>. 
        /// </summary>
        /// <param name="tokenExchangeResponse">
        ///   A response from a token exchange.  
        /// </param>
        AuthenticationHeaderValue OnGetAuthorizationFrom(TokenExchangeResponse tokenExchangeResponse);
    }
}