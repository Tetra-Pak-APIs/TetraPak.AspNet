using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TetraPak.AspNet.Debugging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        const string SelfReferenceIdentifier = "(me)";
        
        readonly SidecarJwBearerAssertionOptions _options;
        readonly HostProvider _hostProvider;
        readonly IWebHostEnvironment _hostEnvironment;

        bool IsDevelopment => _hostEnvironment.IsDevelopment();
        
        public TetraPakApiAuthConfig AuthConfig => _options.AuthConfig;

        public ILogger Logger { get; }
        
        public void Configure(JwtBearerOptions options)
        {
            using (Logger?.BeginScope("Configures JWT Bearer Assertion"))
            {
                options.MetadataAddress = AuthConfig.DiscoveryDocumentUrl;
                options.Authority = AuthConfig.AuthorityUrl;
                if (options.Authority is null)
                {
                    const string DiagnosticsMessage =
                        "Failed to acquire an authority resource locator. Please investigate configuration and assert correct environment";
                    Logger?.Error(new Exception(DiagnosticsMessage));
                    var message = IsDevelopment
                        ? DiagnosticsMessage
                        : "Server is inoperable";
                    alwaysFail(options, message);
                    return;
                }
                options.TokenValidationParameters = new TokenValidationParameters
                {
#if UNSECURE
                    ValidateLifetime = false,
                    ValidateAudience = false
                    ValidateLifetime = false,
#else
                    ValidateAudience = true,
                    ValidateIssuer = !string.IsNullOrWhiteSpace(AuthConfig.JwtBearerValidation.Issuer),
                    ValidateLifetime = AuthConfig.JwtBearerValidation.ValidateLifetime
#endif
                };

                if (options.TokenValidationParameters.ValidateAudience)
                {
                    options.TokenValidationParameters.ValidAudience = resolveAudience(AuthConfig.JwtBearerValidation.Audience);
                    Logger?.Information($"Audience={options.TokenValidationParameters.ValidAudience}");
                }

                if (options.TokenValidationParameters.ValidateIssuer)
                {
                    options.TokenValidationParameters.ValidIssuer = AuthConfig.JwtBearerValidation.Issuer;
                    Logger?.Information($"Issuer={options.TokenValidationParameters.ValidIssuer}");
                }
                
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = async context =>
                    {
                        Logger.DebugAssembliesInUse();
                        await Logger.Debug(context.Request);
                        if (context.TryReadCustomAuthorization(options, AuthConfig, Logger, out var token))
                        {
                            context.Token = token;
                        }   
                    },
                    OnTokenValidated = _ =>
                    {
                        Logger.Debug("JWT Bearer is valid");
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (Logger.IsEnabled(LogLevel.Debug))
                        {
                            var message = context.Exception is { }
                                ? $"JWT Bearer assertion failed: {context.Exception.Message}"
                                : "JWT Bearer assertion failed";
                            Logger.Debug(message, context.HttpContext.Request.GetRequestReferenceId(AuthConfig));
                        }

                        // terminates the request (todo: Consider option to allow other authentication schemes)
                        context.Response.OnStarting(async () =>
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                            var response = IsDevelopment
                                ? new ApiErrorResponse(context.Exception.Message, context.HttpContext, AuthConfig)
                                {
                                    Description = context.Exception.StackTrace
                                }
                                : new ApiErrorResponse("JWT authentication failed", context.HttpContext, AuthConfig);
                            await context.Response.WriteAsync(response.ToJson(IsDevelopment));
                            
                        });
                        return Task.CompletedTask;
                    },
                    OnForbidden = _ =>
                    {
                        return Task.CompletedTask;
                    },
                    OnChallenge = _ =>
                    {
                        return Task.CompletedTask;
                    }
                };
            }
        }

        static void alwaysFail(JwtBearerOptions options, string message)
        {
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.WriteAsync(message);
                    return Task.FromResult(0);
                }
            };
        }

        string resolveAudience(string audience)
        {
            return string.IsNullOrWhiteSpace(audience) || SelfReferenceIdentifier.Equals(audience, StringComparison.InvariantCultureIgnoreCase)
                ? _hostProvider.GetHost()
                : audience;
        }
        
        public void Configure(string name, JwtBearerOptions options)
        {
            if (name == JwtBearerDefaults.AuthenticationScheme)
            {
                Configure(options);
            }
        }

        public ConfigureJwtBearerOptions(
            IServiceProvider provider, 
            HostProvider hostProvider,
            IWebHostEnvironment hostEnvironment,
            SidecarJwBearerAssertionOptions options = null)
        {
            _options = options ?? ActivatorUtilities.CreateInstance<SidecarJwBearerAssertionOptions>(provider);
            _hostProvider = hostProvider;
            _hostEnvironment = hostEnvironment;
            Logger = provider.GetService<ILogger<ConfigureJwtBearerOptions>>();
        }
    }
}