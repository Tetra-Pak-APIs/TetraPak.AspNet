using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    public static class ContextHelper
    {
        public static bool TryReadCustomAuthorization(
            this MessageReceivedContext context,
            JwtBearerOptions options,
            TetraPakAuthConfig authConfig,
            ILogger logger, 
            out string authorization)
        {
            using (logger?.BeginScope($"Looking for authorization in header: {authConfig.AuthorizationHeader}"))
            {
                if (!authConfig.IsCustomAuthorizationHeader)
                {
                    logger.Debug("Default authorization header is in use");
                    authorization = null;
                    return false;
                }
            
                authorization = context.Request.Headers[authConfig.AuthorizationHeader];
                var isTokenAvailable = !string.IsNullOrWhiteSpace(authorization);
                var isJwtToken = authorization.TryParseToJwtSecurityToken(out var jwt);

                if (!logger.IsEnabled(LogLevel.Debug))
                    return isTokenAvailable;
            
                logger.Debug($"Received message: {context.Request.Path.Value}");
                if (!isTokenAvailable)
                {
                    logger.Debug("No authorization found");
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
}