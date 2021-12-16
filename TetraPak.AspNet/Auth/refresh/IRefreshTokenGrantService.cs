using System;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Classes implementing this interface are able to perform the OAuth2 Refresh Token Grant flow. 
    /// </summary>
    public interface IRefreshTokenGrantService
    {
        /// <summary>
        ///   Submits a refresh token to acquire a new access token.
        /// </summary>
        /// <param name="refreshToken">
        ///   The refresh token to be submitted for a new access token.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables cancellation of the operation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="RefreshTokenResponse"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<RefreshTokenResponse>> RefreshTokenAsync(ActorToken refreshToken, CancellationToken? cancellationToken = null);
    }
}