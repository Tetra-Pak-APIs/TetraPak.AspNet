using System;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Implementors of this class are capable of providing an access token from a request context. 
    /// </summary>
    public interface IAccessTokenProvider
    {
        /// <summary>
        ///   Gets an access token from the request context.
        /// </summary>
        /// <param name="forceStandardHeader">
        ///   (optional; default=<c>false</c>)<br/>
        ///   When set the configured (see <see cref="TetraPakAuthConfig.AuthorizationHeader"/>) authorization
        ///   header is ignored in favour of the HTTP standard <see cref="HeaderNames.Authorization"/> header. 
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<ActorToken>> GetAccessTokenAsync(bool forceStandardHeader = false);
    }
}