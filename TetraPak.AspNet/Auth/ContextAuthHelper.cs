using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    public static class ContextHelper
    {
        public static bool TryReadAuthorization(
            this MessageReceivedContext context,
            OpenIdConnectOptions options,
            TetraPakAuthConfig authConfig,
            ILogger logger, 
            out string authorization)
        {
            authorization = context.Request.Headers[authConfig.AuthorizationHeader];
            var isTokenAvailable = !string.IsNullOrWhiteSpace(authorization);
            var isJwtToken = authorization.TryParseToJwtSecurityToken(out var jwt);

            if (!logger.IsEnabled(LogLevel.Debug))
                return isTokenAvailable;
            
            logger.Debug($"Received message: {context.Request.Path.Value}");
            if (!isTokenAvailable)
            {
                logger.Debug($"No authorization found");
                return false;
            }

            if (isJwtToken)
            {
                logger.Debug($"Received JWT: \n{jwt.ToDebugString()}");
                logger.Debug($"Environment: {authConfig.Environment}");
                logger.Debug($"Discovery document URL: {options.MetadataAddress}");
                return true;
            }
            
            logger.Debug($"Received token: \n{authorization}");
            return true;
        }
    }
}