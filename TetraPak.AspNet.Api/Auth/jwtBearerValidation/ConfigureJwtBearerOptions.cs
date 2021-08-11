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
using TetraPak.AspNet.diagnostics;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        const string SelfReferenceIdentifier = "(me)";
        
        readonly JwBearerAssertionOptions _options;
        readonly HostProvider _hostProvider;
        readonly IWebHostEnvironment _hostEnvironment;

        bool IsDevelopment => _hostEnvironment.IsDevelopment();
        
        public TetraPakApiAuthConfig Config => _options.Config;

        public ILogger Logger { get; }
        
        public void Configure(JwtBearerOptions options)
        {
            using (Logger?.BeginScope("Configures JWT Bearer Assertion"))
            {
                options.MetadataAddress = Config.DiscoveryDocumentUrl;
                options.Authority = Config.AuthorityUrl;
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
                    ValidateIssuer = !string.IsNullOrWhiteSpace(Config.JwtBearerValidation.Issuer),
                    ValidateLifetime = Config.JwtBearerValidation.ValidateLifetime
#endif
                };

                if (options.TokenValidationParameters.ValidateAudience)
                {
                    options.TokenValidationParameters.ValidAudience = resolveAudience(Config.JwtBearerValidation.Audience);
                    Logger?.Information($"Audience={options.TokenValidationParameters.ValidAudience}");
                }

                if (options.TokenValidationParameters.ValidateIssuer)
                {
                    options.TokenValidationParameters.ValidIssuer = Config.JwtBearerValidation.Issuer;
                    Logger?.Information($"Issuer={options.TokenValidationParameters.ValidIssuer}");
                }

                const string TimerName = "in-auth-jwt";
                
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = async context =>
                    {
                        context.HttpContext.StartDiagnosticsTime(TimerName);
                        Logger.DebugAssembliesInUse();
                        await Logger.Debug(context.Request);
                        if (context.TryReadCustomAuthorization(options, Config, Logger, out var token))
                        {
                            context.Token = token.Identity;
                        }   
                    },
                    OnTokenValidated = context =>
                    {
                        context.HttpContext.EndDiagnosticsTime(TimerName);
                        Logger.Debug("JWT Bearer is valid");
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.HttpContext.EndDiagnosticsTime(TimerName);
                        if (Logger.IsEnabled(LogLevel.Debug))
                        {
                            var message = context.Exception is { }
                                ? $"JWT Bearer assertion failed: {context.Exception.Message}"
                                : "JWT Bearer assertion failed";
                            Logger.Debug(message, context.HttpContext.Request.GetMessageId(Config));
                        }

                        // terminates the request (todo: Consider option to allow other authentication schemes)
                        context.Response.OnStarting(async () =>
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                            var messageId = context.Request.GetMessageId(Config);
                            var response = IsDevelopment
                                ? new ApiErrorResponse(context.Exception.Message, messageId)
                                {
                                    Description = context.Exception.StackTrace
                                }
                                : new ApiErrorResponse("JWT authentication failed", messageId);
                            await context.Response.WriteAsync(response.ToJson(IsDevelopment));
                            
                        });
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        context.HttpContext.EndDiagnosticsTime(TimerName);
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
            JwBearerAssertionOptions options = null)
        {
            _options = options ?? ActivatorUtilities.CreateInstance<JwBearerAssertionOptions>(provider);
            _hostProvider = hostProvider;
            _hostEnvironment = hostEnvironment;
            Logger = provider.GetService<ILogger<ConfigureJwtBearerOptions>>();
        }
    }
}