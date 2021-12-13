using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    static class ContextHelper
    {
        internal static bool TryReadCustomAuthorization(
            this MessageReceivedContext context,
            JwtBearerOptions options,
            TetraPakApiConfig config,
            ILogger? logger, 
            [NotNullWhen(true)] out ActorToken? token)
        {
            using (logger?.BeginScope($"Looking for authorization in header: {config.AuthorizationHeader}"))
            {  
                var messageId = context.Request.GetMessageId(config);
                if (!config.IsCustomAuthorizationHeader)
                {
                    logger.Debug("Default authorization header is in use", messageId);
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
            
                logger.Debug($"Received message: {context.Request.Path.Value}", messageId);
                if (!isTokenAvailable)
                {
                    logger.Debug("No authorization found", messageId);
                    return false;
                }

                if (isJwtToken)
                {
                    logger.Debug($"Received JWT: \n{jwt!.ToDebugString()}", messageId);
                    logger.Debug($"Environment: {config.Environment}", messageId);
                    logger.Debug($"Discovery document URL: {options.MetadataAddress}", messageId);
                    return true;
                }
            
                logger.Debug($"Received token: \n{authorization}", messageId);
                return true;
            }
        }
    }
}