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
            TetraPakApiAuthConfig config,
            ILogger logger, 
            out ActorToken token)
        {
            using (logger?.BeginScope($"Looking for authorization in header: {config.AuthorizationHeader}"))
            {
                if (!config.IsCustomAuthorizationHeader)
                {
                    logger.Debug("Default authorization header is in use");
                    token = null;
                    return false;
                }
            
                string authorization = context.Request.Headers[config.AuthorizationHeader];
                var isTokenAvailable = !string.IsNullOrWhiteSpace(authorization);
                if (!ActorToken.TryParse(authorization, out token))
                    return false;
                
                var isJwtToken = authorization.TryParseToJwtSecurityToken(out var jwt);

                if (!logger?.IsEnabled(LogLevel.Debug) ?? false)
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
                    logger.Debug($"Environment: {config.Environment}");
                    logger.Debug($"Discovery document URL: {options.MetadataAddress}");
                    return true;
                }
            
                logger.Debug($"Received token: \n{authorization}");
                return true;
            }
        }
    }
}