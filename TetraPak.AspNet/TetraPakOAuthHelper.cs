using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Configuration;
using TetraPak.Logging;

namespace TetraPak.AspNet
{
    // https://mauridb.medium.com/using-oauth2-middleware-with-asp-net-core-2-0-b31ffef58cd0
    public static class TetraPakOAuthHelper
    {
        // todo Consider adding support for claims-based user info (see URL above class declaration)
        public static async Task AddTetraPakAuthentication(
            this IServiceCollection services, 
            MultiStringValue scope = null)
        {
            services.AddSingleton<OAuthOptions, TetraPakOauthOptions>();
            services.AddSingleton<TetraPakAuthConfig>();
            services.AddAuthentication().AddOAuth("TetraPak-LoginAPI", async options =>
            {
                var tetraPakOptions = (TetraPakOauthOptions) options;
                options.AuthorizationEndpoint = await tetraPakOptions.AuthConfig.GetAuthorityUrlAsync();
                options.TokenEndpoint = await tetraPakOptions.AuthConfig.GetTokenIssuerUrlAsync();
                options.UserInformationEndpoint = await tetraPakOptions.AuthConfig.GetUserInformationUrlAsync();
                options.ClientId = tetraPakOptions.ClientId;
                options.ClientSecret = tetraPakOptions.ClientSecret;
                options.CallbackPath = tetraPakOptions.CallbackPath;
                foreach (var scopeItem in tetraPakOptions.Scope)
                {
                    options.Scope.Add(scopeItem);
                }
                
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "UserId");
                options.ClaimActions.MapJsonKey(ClaimTypes.Email, "EmailAddress", ClaimValueTypes.Email);
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "Name");

                options.Events = new OAuthEvents
                {
                    OnRemoteFailure = context =>
                    {
                        tetraPakOptions.Logger?.Error(context.Failure,"OAuth authentication error!");
                        context.HandleResponse();
                        return Task.FromResult(0);
                    }
                };

            });
        }
    }

    public class TetraPakOauthOptions : OAuthOptions
    {
        public ILogger Logger { get; }

        public TetraPakAuthConfig AuthConfig { get; }

        public TetraPakOauthOptions(ILogger<TetraPakOauthOptions> logger, TetraPakAuthConfig authConfig)
        {
            Logger = logger;
            AuthConfig = authConfig;
        }
    }
}