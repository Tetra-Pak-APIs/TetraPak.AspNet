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
        readonly TetraPakAuthConfig _authConfig;

        public ILogger Logger => _authConfig.Logger;

        public async Task<Outcome<UserInformation>> GetUserInformationAsync(string accessToken)
        {
            var loader = new UserInformationProvider(_authConfig);
            try
            {
                var userInformation = await loader.GetUserInformationAsync(accessToken);
                return Outcome<UserInformation>.Success(userInformation);
            }
            catch (Exception ex)
            {
                return Outcome<UserInformation>.Fail(ex);
            }
        }
        
        public TetraPakUserInformation(TetraPakAuthConfig authConfig)
        {
            _authConfig = authConfig;
        }
    }
}