﻿using System;
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
    public static partial class TetraPakAuth
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
                        OnValidatePrincipal = async context =>
                        {
                            if (!await context.RefreshTokenIfExpiredAsync(authConfig, logger))
                                return;
                            
                            // transfer access and id token to HttpContext ...
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
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateActor = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidateTokenReplay = true
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
                            authConfig.Logger?.Debug("Token received");
                            context.Properties.IsPersistent = true;
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
    
    static class CookieValidatePrincipalContextExtensions
    {
        public static async Task<bool> RefreshTokenIfExpiredAsync(
            this CookieValidatePrincipalContext context,
            TetraPakAuthConfig auth,
            ILogger logger)
        {
            if (!isExpired())
                return true;

            var refreshToken = context.Properties.GetTokenValue(AmbientData.Keys.RefreshToken);
            if (refreshToken is null)
                return true;

            var outcome = await auth.RefreshTokenAsync(refreshToken, logger);
            if (!outcome)
                return await fail();
            
            context.Properties.UpdateTokenValue(AmbientData.Keys.AccessToken, outcome.Value.AccessToken);
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
                var refreshThresholdTimeSpan = TimeSpan.FromSeconds(auth.RefreshThreshold);
                var result = remainingTimeSpan < refreshThresholdTimeSpan;
                
                logger.Trace(
                    $">======< TOKEN TTL >======<\n"+
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