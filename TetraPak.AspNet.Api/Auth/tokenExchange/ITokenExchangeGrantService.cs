using System;
using System.Threading;
using System.Threading.Tasks;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Documentations;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Implementors of this interface can be used for exchanging access tokens.  
    /// </summary>
    public interface ITokenExchangeGrantService 
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
        /// <remarks>
        ///   <para>
        ///   Please note that (as of 2021-11-01) Tetra Pak auth services does not allow Token Exchange for
        ///   non-human identities (a.k.a. "system identities").
        ///   </para>
        ///   <para>
        ///   What this means is that if you pass an <paramref name="accessToken"/>
        ///   that was ultimately issued from a Client Credentials Grant the token exchange will fail
        ///   with a <c>400 Bad Request</c>.
        ///   You can examine the <paramref name="accessToken"/> using the
        ///   extension method <see cref="JwtHelper.IsSystemIdentityToken(ActorToken)"/>.
        ///   </para>
        ///   <para>
        ///   For more details please see article using the link found in this constant:
        ///   <see cref="Docs.DevPortal.TokenExchangeSubjectTokenTypes"/>  
        ///   </para>
        /// </remarks>
        Task<Outcome<TokenExchangeResponse>> ExchangeAccessTokenAsync(
            Credentials credentials,
            ActorToken accessToken, 
            CancellationToken cancellationToken);
    }
}