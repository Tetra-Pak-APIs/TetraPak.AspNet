using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using TetraPak.AspNet.Debugging;
using TetraPak.Caching;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Auth
{
    // https://mauridb.medium.com/using-oauth2-middleware-with-asp-net-core-2-0-b31ffef58cd0
    /// <summary>
    ///   Provides convenience- and extension methods to help with integrating an ASP.NET Core/5+
    ///   web application with the Tetra Pak Auth Services.
    /// </summary>
    public static partial class TetraPakAuth
    {
        const string TetraPakScheme = "TetraPak-LoginAPI";

        /// <summary>
        ///   Adds the necessary middleware to integrate with Tetra Pak Auth Services using the
        ///   Open Id Connection (OIDC) auth flow.
        /// </summary>
        /// <param name="services">
        ///   An object implementing <see cref="IServiceCollection"/> (can be unassigned). 
        /// </param>
        public static void AddTetraPakOidcAuthentication(this IServiceCollection services)
        {
            services.AddTetraPakOidcAuthentication<SimpleCache>();
        }
        
        // todo Consider adding support for claims-based user info (see URL above class declaration)
        /// <summary>
        ///   Adds and configures middleware to integrate with Tetra Pak Auth Services using the
        ///   Open Id Connection (OIDC) auth flow.
        /// </summary>
        /// <param name="services">
        ///   An object implementing <see cref="IServiceCollection"/> (can be unassigned). 
        /// </param>
        /// <typeparam name="TCache">
        ///   Specifies class to be used for OIDC related caching purposes. 
        /// </typeparam>
        public static void AddTetraPakOidcAuthentication<TCache>(this IServiceCollection services)
        where TCache : class, ITimeLimitedRepositories
        {
            // todo This method is HUGE. Consider refactoring to break it down!
            services.AddAmbientData();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTetraPakConfiguration();
            
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
            var provider = services.BuildServiceProvider();
            var tetraPakConfig = provider.GetService<TetraPakConfig>();

            addCachingIfAllowed();

            var logger = tetraPakConfig?.Logger ?? provider.GetService<ILogger<OAuthOptions>>();
            if (tetraPakConfig is null)
            {
                logger.Error(new ServerConfigurationException($"Cannot resolve service: {typeof(TetraPakConfig)}"));
                return;
            }

            services.AddTetraPakClaimsTransformation();
            services.AddTetraPakUserInformation();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = TetraPakScheme;
                })
                .AddCookie(options =>
                {
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = async context =>
                        {
                            if (!await context.RefreshTokenIfExpiredAsync(tetraPakConfig, logger))
                                return;
                            
                            // transfer access and id token to HttpContext, making them available as ambient values ...
                            trySetToken(AmbientData.Keys.AccessToken);
                            trySetToken(AmbientData.Keys.IdToken);

                            void trySetToken(string key)
                            {
                                var token = context.Properties.GetTokenValue(key);
                                if (string.IsNullOrWhiteSpace(token))
                                    return;
                                
                                context.HttpContext.Items[key] = token;
                            }
                        },
                    };
                })
                .AddOpenIdConnect(TetraPakScheme, options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    //options.ResponseType = "code id_token"; // <- first get code, then get token from standard token endpoint
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    //options.RequireHttpsMetadata = true;
                    options.MetadataAddress = tetraPakConfig.DiscoveryDocumentUrl;
                    options.ClientId = tetraPakConfig.ClientId;
                    options.ClientSecret = tetraPakConfig.ClientSecret;
                    options.UseTokenLifetime = true;
                    options.CorrelationCookie.SameSite = SameSiteMode.Lax;
                    options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.ProtocolValidator.RequireNonce = false; // nonstandard
                    //options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;
                    options.CallbackPath = tetraPakConfig.CallbackPath is { } 
                        ? new PathString(tetraPakConfig.CallbackPath) 
                        : null;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    
                    foreach (var scopeItem in tetraPakConfig.Scope)
                    {
                        options.Scope.Add(scopeItem);
                    }

                    if (options.Scope.All(s => s != "openid"))
                    {
                        options.Scope.Add("openid");
                    }

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateActor = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidateTokenReplay = true
                    };

                    options.Events = new OpenIdConnectEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.TryReadAuthorization(options, tetraPakConfig, logger, out var token))
                            {
                                context.Token = token;
                                traceOidc(() => $"Token received: {token}");
                            }          
                            return Task.CompletedTask;
                        },
                        OnRemoteFailure = context =>
                        {
                            var messageId = context.Request.GetMessageId(null);
                            tetraPakConfig.Logger.Error(context.Failure!,"<OIDC> authentication error!", messageId);
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnTicketReceived = context =>
                        {
                            context.Properties.IsPersistent = true;
                            traceOidc(() => "Ticket received");
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            var messageId = context.Request.GetMessageId(null);
                            tetraPakConfig.Logger.Warning($"<OIDC> Authentication failed! {context.Exception.Message}", messageId);
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnAccessDenied = context =>
                        {
                            var messageId = context.Request.GetMessageId(null);
                            tetraPakConfig.Logger.Information($"<IODC> Access denied: {context.AccessDeniedPath}", messageId);
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnTokenValidated = context =>
                        {
                            var handler = new JwtSecurityTokenHandler();
                            context.HttpContext.Items.Add(AmbientData.Keys.AccessToken, handler.WriteToken(context.SecurityToken));
                            traceOidc(() => $"Token validated: {context.SecurityToken}");
                            return Task.CompletedTask;
                        },
                        OnTokenResponseReceived = async context =>
                        {
                            traceOidc(() 
                                => $"Token response received:{oidcConnectMessageAsync(context.TokenEndpointResponse)}");
                            await logger.TraceAsync(context.Response, true);
                        },
                        OnRedirectToIdentityProvider = _ =>
                        {
                            traceOidc(() => "Redirects to identity provider");
                            return Task.CompletedTask;
                        },
                        OnRemoteSignOut = _ =>
                        {
                            traceOidc(() => "Remote sign-out");
                            return Task.CompletedTask;
                        },
                        OnUserInformationReceived = context =>
                        {
                            if (!(logger?.IsEnabled(LogLevel.Trace) ?? false)) 
                                return Task.CompletedTask;
                            
                            var claims = context.Principal?.Claims.ConcatCollection(callback: o => o.ToString()!);
                            traceOidc(() => $"User information received: {claims}");
                            return Task.CompletedTask;
                        },
                        OnSignedOutCallbackRedirect = _ =>
                        {
                            return Task.CompletedTask;
                        },
                        OnRedirectToIdentityProviderForSignOut = _ =>
                        {
                            traceOidc(() => "Redirects to identity provider for sign-out");
                            return Task.CompletedTask;
                        }
                    };

                });
            
            void traceOidc(Func<string> message)
            {
                if (!logger?.IsEnabled(LogLevel.Trace) ?? true)
                    return;
                
                var messageId = tetraPakConfig?.AmbientData.GetMessageId(true);
                logger.Trace($"<IODC> {message()}", messageId);
            }

            async Task<string> oidcConnectMessageAsync(OpenIdConnectMessage oidcMessage)
            {
                var dump = new StateDump("OIDC Message", logger);
                await dump.AddAsync(oidcMessage, "");

                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine(await dump.BuildAsStringAsync());
                return sb.ToString();
            }

            void addCachingIfAllowed()
            {
                if (tetraPakConfig is { IsCachingAllowed: true })
                {
                    services.AddTetraPakCaching();
                }
            }
        }

        static void AddTetraPakWebClientAuthentication(this IServiceCollection services) // todo Make available when needed -JR 2021-09-01
        {
            services.AddTetraPakConfiguration();
            services.AddTetraPakClaimsTransformation();
            
            var provider = services.BuildServiceProvider();
            var authConfig = provider.GetService<TetraPakConfig>() 
                             ?? throw new ServerConfigurationException($"Service location failed: {typeof(TetraPakConfig)}");
            var logger = authConfig.Logger ?? provider.GetService<ILogger<OAuthOptions>>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = TetraPakScheme;
                })
                .AddCookie(
                    // options =>
                    // {
                    //     options.Events = new CookieAuthenticationEvents
                    //     {
                    //         OnValidatePrincipal = async context =>
                    //         {
                    //             
                    //         }
                    //     };
                    // }
                )
                .AddOAuth(TetraPakScheme, options =>
                {
                    options.AuthorizationEndpoint = authConfig.AuthorityUrl;
                    options.TokenEndpoint = authConfig.TokenIssuerUrl;
                    options.UserInformationEndpoint = authConfig.UserInformationUrl;
                    options.CallbackPath = authConfig.CallbackPath is { } 
                        ? new PathString(authConfig.CallbackPath) 
                        : null;
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.ClientId = authConfig.ClientId;
                    options.ClientSecret = authConfig.ClientSecret;
                    options.UsePkce = true;
                    options.SaveTokens = true;

                    foreach (var scopeItem in authConfig.Scope)
                    {
                        options.Scope.Add(scopeItem);
                    }

                    // always request 'openid' scope, for later 'userinfo' requirements
                    if (options.Scope.All(i => i != "openid"))
                    {
                        options.Scope.Add("openid");
                    }
                
                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "UserId");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "EmailAddress", ClaimValueTypes.Email);
                    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "Name");
                    
                    options.Events = new OAuthEvents
                    {
                        OnRemoteFailure = context =>
                        {
                            authConfig.Logger.Error(context.Failure!,"OIDC authentication error!");
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnTicketReceived = context =>
                        {
                            traceOAuth(() => $"OAuth token received ({context.ReturnUri})");
                            return Task.CompletedTask;
                        },
                        OnAccessDenied = context =>
                        {
                            logger.Information($"Access denied: {context.AccessDeniedPath}");
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnCreatingTicket = context =>
                        {
                            TetraPakJwtClaimsTransformation.TokenResponse = context.TokenResponse;
                            traceOAuth(() => $"Ticket created: {context.TokenResponse.AccessToken}");
                            return Task.CompletedTask;
                        },
                        OnRedirectToAuthorizationEndpoint = context => 
                        {
                            traceOAuth(() => $"Redirecting to authorization endpoint: {context.RedirectUri}");
                            return Task.CompletedTask;
                        }
                    };
                    
            });
            
            void traceOAuth(Func<string> message)
            {
                if (!logger?.IsEnabled(LogLevel.Trace) ?? true)
                    return;
                
                var messageId = authConfig!.AmbientData.GetMessageId(true);
                logger.Trace($"<OAUTH> {message()}", messageId);
            }
        }
    }
    
    static class CookieValidatePrincipalContextExtensions
    {
        public static async Task<bool> RefreshTokenIfExpiredAsync(
            this CookieValidatePrincipalContext context,
            TetraPakConfig config,
            ILogger? logger)
        {
            if (!isExpired())
                return true;

            var refreshToken = context.Properties.GetTokenValue(AmbientData.Keys.RefreshToken);
            if (refreshToken is null)
                return true;

            var outcome = await config.RefreshTokenAsync(refreshToken, logger);
            if (!outcome)
                return await fail();
            
            context.Properties.UpdateTokenValue(AmbientData.Keys.AccessToken, outcome.Value!.AccessToken);
            var expiresAt = outcome.Value.ExpiresInSeconds.HasValue
                ? DateTimeOffset.UtcNow.AddSeconds(outcome.Value.ExpiresInSeconds.Value)
                : DateTimeOffset.Now;
            context.Properties.UpdateTokenValue(AmbientData.Keys.ExpiresAt, expiresAt.ToString());
            if (outcome.Value.RefreshToken is { })
            {
                context.Properties.UpdateTokenValue(AmbientData.Keys.RefreshToken, outcome.Value.RefreshToken);
            }

            if (outcome.Value.IdToken is { })
            {
                context.Properties.UpdateTokenValue(AmbientData.Keys.RefreshToken, outcome.Value.IdToken);
            }

            context.ShouldRenew = true;
            return true;
  
            bool isExpired()
            {
                var expiresAtString = context.Properties.GetTokenValue(AmbientData.Keys.ExpiresAt);
                if (expiresAtString is null)
                    return false;

                var now = DateTimeOffset.UtcNow;
                expiresAt = DateTimeOffset.Parse(expiresAtString);
                var remainingTimeSpan = expiresAt.Subtract(now);
                var refreshThresholdTimeSpan = TimeSpan.FromSeconds(config.RefreshThreshold);
                var result = remainingTimeSpan < refreshThresholdTimeSpan;
                
                logger.Trace(
                    "\n>======< TOKEN TTL >======<\n"+
                    $"  time (UTC): {now}\n"+
                    $"  expires   : {expiresAt}\n"+
                    $"  TTL       : {remainingTimeSpan}\n"+
                    $"  threshold : {refreshThresholdTimeSpan}\n"+
                    $"  expired   : {result}\n"+
                    ">=========================<");
                
                return result;
            }
            
            async Task<bool> fail()
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync();
                return false;
            }
        }
    }
}