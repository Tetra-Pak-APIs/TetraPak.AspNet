using System;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Implementors of this class are capable of providing a identity token from a request context.
    /// </summary>
    public interface IIdentityTokenProvider
    {
        /// <summary>
        ///   Gets an identity token from the request context.
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<ActorToken>> GetIdTokenAsync();
    }
}