using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Identity
{
    /// <summary>
    ///   Provides easy access to Tetra Pak's user information services. 
    /// </summary>
    public class TetraPakUserInformation
    {
        readonly TetraPakConfig _config;

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        public ILogger Logger => AmbientData.Logger;

        /// <summary>
        ///   Gets the ambient data object.
        /// </summary>
        public AmbientData AmbientData => _config.AmbientData;

        /// <summary>
        ///   Obtains and returns user information from the Tetra Pak Auth Services. 
        /// </summary>
        /// <param name="accessToken">
        ///   The request access token.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="UserInformation"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        public async Task<Outcome<UserInformation>> GetUserInformationAsync(ActorToken accessToken)
        {
            var loader = new UserInformationProvider(AmbientData);
            try
            {
                // there's no point in calling the remote service for system identities (it will fail) ...
                if (accessToken.Identity.IsSystemIdentityToken())
                    return Outcome<UserInformation>.Fail(ServerException.BadRequest("Cannot obtain user information for system identity"));
                
                var userInformation = await loader.GetUserInformationAsync(accessToken);
                return Outcome<UserInformation>.Success(userInformation);
            }
            catch (Exception ex)
            {
                return Outcome<UserInformation>.Fail(ex);
            }
        }

        /// <summary>
        ///   Initializes the <see cref="TetraPakUserInformation"/> object.
        /// </summary>
        /// <param name="config">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="config"/> was unassigned.
        /// </exception>
        public TetraPakUserInformation(TetraPakConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
    }
}
  