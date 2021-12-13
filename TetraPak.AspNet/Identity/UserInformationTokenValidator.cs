using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Identity
{
    /// <summary>
    ///   To be inherited and used for custom token validation purposes by a <see cref="UserInformationProvider"/>.
    /// </summary>
    public abstract class UserInformationTokenValidator
    {
        /// <summary>
        ///   Gets a log provider.
        /// </summary>
        protected ILogger? Logger => Config?.Logger;

        /// <summary>
        ///   Gets the auth configuration.
        /// </summary>
        public TetraPakConfig? Config { get; private set; }

        internal void Initialize(TetraPakConfig config) => Config = config;

        /// <summary>
        ///   Called by the <see cref="UserInformationProvider"/> for custom access token validation/processing.
        ///   One good example could be performing automatic token exchange for accessing user information services. 
        /// </summary>
        /// <param name="accessToken">
        ///   The access token to be validated/processed.
        /// </param>
        /// <param name="isCached">
        ///   Specifies whether the access token was cached by the <see cref="UserInformationProvider"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> value to indicate successful validation/processing,
        ///   and to carry the access token to be used.
        /// </returns>
        public abstract Task<Outcome<string>> ValidateAccessTokenAsync(string accessToken, bool isCached);
    }
}