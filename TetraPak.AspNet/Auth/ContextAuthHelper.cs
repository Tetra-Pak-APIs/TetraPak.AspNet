using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    static class ContextAuthHelper
    {
        internal static bool TryReadAuthorization(
            this MessageReceivedContext context,
            OpenIdConnectOptions oidcOptions,
            TetraPakConfig config,
            ILogger logger, 
            [NotNullWhen(true)] out string authorization)
        {
            authorization = context.Request.Headers[config.AuthorizationHeader];
            var isTokenAvailable = !string.IsNullOrWhiteSpace(authorization);
            var isJwtToken = authorization.TryParseToJwtSecurityToken(out var jwt);

            if (!logger.IsEnabled(LogLevel.Debug))
                return isTokenAvailable;

            var messageId = config.AmbientData.GetMessageId();
            logger.Debug($"Received message: {context.Request.Path.Value}", messageId);
            if (!isTokenAvailable)
            {
                logger.Debug($"No authorization found");
                return false;
            }

            if (isJwtToken)
            {
                logger.Debug($"Received JWT: \n{jwt.ToDebugString()}", messageId);
                logger.Debug($"Environment: {config.Environment}", messageId);
                logger.Debug($"Discovery document URL: {oidcOptions.MetadataAddress}", messageId);
                return true;
            }
            
            logger.Debug($"Received token: \n{authorization}", messageId);
            return true;
        }

        internal static bool IsClientSecretRequired(this GrantType grantType)
        {
            return grantType is GrantType.CC or GrantType.TX;
        }

        internal static ClientCredentials GetClientCredentials(this IServiceAuthConfig config)
        {
            return new ClientCredentials(config);
        }

    }
}