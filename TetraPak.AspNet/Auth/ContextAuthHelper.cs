using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    public static class ContextAuthHelper
    {
        public static bool TryReadAuthorization(
            this MessageReceivedContext context,
            OpenIdConnectOptions options,
            TetraPakConfig config,
            ILogger logger, 
            out string authorization)
        {
            authorization = context.Request.Headers[config.AuthorizationHeader];
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
                logger.Debug($"Environment: {config.Environment}");
                logger.Debug($"Discovery document URL: {options.MetadataAddress}");
                return true;
            }
            
            logger.Debug($"Received token: \n{authorization}");
            return true;
        }

        public static bool IsClientSecretRequired(this GrantType grantType)
        {
            return grantType is GrantType.CC or GrantType.TX;
        }
    }
}