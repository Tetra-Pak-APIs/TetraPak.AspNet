using System;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Auth
{
    public interface IAccessTokenProvider
    {
        /// <summary>
        ///   Gets an access token from the request context.
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<ActorToken>> GetAccessTokenAsync();
    }
}