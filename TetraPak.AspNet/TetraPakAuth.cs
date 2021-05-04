using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet
{
    // https://mauridb.medium.com/using-oauth2-middleware-with-asp-net-core-2-0-b31ffef58cd0
    public static class TetraPakAuth
    {
        const string TetraPakScheme = "TetraPak-LoginAPI";

        public static void AddTetraPakWebClientAuthentication(this IServiceCollection services)
        {
            services.TryAddSingleton<TetraPakAuthConfig>();
            services.AddTetraPakClaimsTransformation();
            
            var provider = services.BuildServiceProvider();
            var authConfig = provider.GetService<TetraPakAuthConfig>();
            var logger = authConfig?.Logger ?? provider.GetService<ILogger<OAuthOptions>>();
            if (authConfig is null)
            {
                logger?.Error(new Exception($"Cannot resolve service: {typeof(TetraPakAuthConfig)}"));
                return; // todo log this failure!
            }

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
                    //         OnValidatePrincipal = context =>
                    //         {
                    //             return Task.CompletedTask;
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
                            authConfig.Logger?.Error(context.Failure,"OIDC authentication error!");
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnTicketReceived = context =>
                        {
                            authConfig.Logger?.Debug("OAuth token received");
                            return Task.CompletedTask;
                        },
                        OnAccessDenied = context =>
                        {
                            authConfig.Logger?.Information($"Access denied: {context.AccessDeniedPath}");
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnCreatingTicket = context =>
                        {
                            TetraPakClaimsTransformation.TokenResponse = context.TokenResponse;
                            var userInfoEndpoint = authConfig.UserInformationUrl;
                            return Task.CompletedTask;
                        },
                        // OnRedirectToAuthorizationEndpoint = context => obsolete
                        // {
                        //     return Task.CompletedTask;
                        // }
                    };
            });
        }
        
        // todo Consider adding support for claims-based user info (see URL above class declaration)
        public static void AddTetraPakOidcAuthentication(this IServiceCollection services)
        {
            services.AddSingleton<TetraPakAuthConfig>();
            services.AddTetraPakClaimsTransformation();
            services.AddTetraPakUserInformation();
            
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
            var provider = services.BuildServiceProvider();
            var authConfig = provider.GetService<TetraPakAuthConfig>();
            var logger = authConfig?.Logger ?? provider.GetService<ILogger<OAuthOptions>>();
            if (authConfig is null)
            {
                logger?.Error(new Exception($"Cannot resolve service: {typeof(TetraPakAuthConfig)}"));
                return; // todo log this failure!
            }

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
                        OnValidatePrincipal = context =>
                        {
                            trySetToken(AmbientData.Keys.AccessToken);
                            trySetToken(AmbientData.Keys.IdToken);
                            return Task.CompletedTask;
                            
                            void trySetToken(string key)
                            {
                                var itemsKey = $".Token.{key}";
                                if (!context.Properties.Items.ContainsKey(itemsKey)) 
                                    return;
                                
                                context.HttpContext.Items[key] = context.Properties.Items[itemsKey];
                            }
                        }
                    };
                })
                .AddOpenIdConnect(TetraPakScheme, options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    //options.ResponseType = "code id_token"; // <- first get code, then get token from standard token endpoint
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    //options.RequireHttpsMetadata = true;
                    options.MetadataAddress = authConfig.DiscoveryDocumentUrl;
                    options.ClientId = authConfig.ClientId;
                    options.ClientSecret = authConfig.ClientSecret;
                    options.UseTokenLifetime = true;
                    options.CorrelationCookie.SameSite = SameSiteMode.Lax;
                    options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.ProtocolValidator.RequireNonce = false; // nonstandard
                    // options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;
                    options.CallbackPath = authConfig.CallbackPath is { } 
                        ? new PathString(authConfig.CallbackPath) 
                        : null;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    
                    foreach (var scopeItem in authConfig.Scope)
                    {
                        options.Scope.Add(scopeItem);
                    }

                    if (options.Scope.All(s => s != "openid"))
                    {
                        options.Scope.Add("openid");
                    }

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateActor = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidateTokenReplay = false
                    };
                
                    // options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "UserId");
                    // options.ClaimActions.MapJsonKey(ClaimTypes.Email, "EmailAddress", ClaimValueTypes.Email);
                    // options.ClaimActions.MapJsonKey(ClaimTypes.Name, "Name");

                    options.Events = new OpenIdConnectEvents
                    {
                        OnRemoteFailure = context =>
                        {
                            authConfig.Logger?.Error(context.Failure,"OIDC authentication error!");
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnTicketReceived = context =>
                        {
                            authConfig.Logger?.Debug("OAuth token received");
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            authConfig.Logger?.Warning($"OIDC authentication failed! {context.Exception.Message}");
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnAccessDenied = context =>
                        {
                            authConfig.Logger?.Information($"Access denied: {context.AccessDeniedPath}");
                            context.HandleResponse();
                            return Task.FromResult(0);
                        },
                        OnMessageReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        // OnAuthorizationCodeReceived = context => obsolete
                        // {
                        //     var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{authConfig.ClientId}:{authConfig.ClientSecret}"));
                        //     context.Backchannel.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                        //     return Task.CompletedTask;
                        // },
                        OnTokenValidated = context =>
                        {
                            var handler = new JwtSecurityTokenHandler();
                            context.HttpContext.Items.Add(AmbientData.Keys.AccessToken, handler.WriteToken(context.SecurityToken));
                            return Task.CompletedTask;
                        },
                        OnTokenResponseReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnRedirectToIdentityProvider = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnRemoteSignOut = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnUserInformationReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnSignedOutCallbackRedirect = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnRedirectToIdentityProviderForSignOut = context =>
                        {
                            return Task.CompletedTask;
                        }
                    };
            });
        }
    }
}