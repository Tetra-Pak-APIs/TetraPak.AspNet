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
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Debugging;
using TetraPak.AspNet.diagnostics;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   This code API can be used to access/manipulate the JWT Bearer authentication configuration,
    ///   represented by the configuration sub section identified by
    ///   <see cref="JwtBearerAssertionConfig.SectionIdentifier"/>. 
    /// </summary>
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        const string SelfReferenceIdentifier = "(me)";
        
        readonly JwBearerAssertionOptions _options;
        readonly HostProvider _hostProvider;
        readonly IWebHostEnvironment _hostEnvironment;

        bool IsDevelopment => _hostEnvironment.IsDevelopment();
        
        /// <summary>
        ///   Provides access to the Tetra Pak configuration.
        /// </summary>
        public TetraPakApiConfig TetraPakConfig => _options.Config;

        /// <summary>
        ///   Gets a logger provider. 
        /// </summary>
        public ILogger? Logger { get; }

        /// <inheritdoc />
        public void Configure(JwtBearerOptions options)
        {
            using (Logger?.BeginScope("Configures JWT Bearer Assertion"))
            {
                options.MetadataAddress = TetraPakConfig.DiscoveryDocumentUrl;
                options.Authority = TetraPakConfig.AuthorityUrl;
                if (string.IsNullOrWhiteSpace(options.Authority))
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
                    ValidateIssuer = !string.IsNullOrWhiteSpace(TetraPakConfig.JwtBearerAssertion.Issuer),
                    ValidateLifetime = TetraPakConfig.JwtBearerAssertion.ValidateLifetime
#endif
                };

                if (options.TokenValidationParameters.ValidateAudience)
                {
                    options.TokenValidationParameters.ValidAudience = resolveAudience(TetraPakConfig.JwtBearerAssertion.Audience);
                    Logger?.Information($"Audience={options.TokenValidationParameters.ValidAudience}");
                }

                if (options.TokenValidationParameters.ValidateIssuer)
                {
                    options.TokenValidationParameters.ValidIssuer = TetraPakConfig.JwtBearerAssertion.Issuer;
                    Logger?.Information($"Issuer={options.TokenValidationParameters.ValidIssuer}");
                }

                const string TimerName = "in-auth-jwt";
                
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.HttpContext.StartDiagnosticsTime(TimerName);
                        Logger.DebugAssembliesInUse(); // todo Consider moving log-dumping assemblies-in-use to middleware  
                        //await Logger.TraceHttpRequestAsync(context.Request); obsolete (this is now done by middleware)
                        if (context.TryReadCustomAuthorization(options, TetraPakConfig, Logger, out var token))
                        {
                            context.Token = token.Identity;
                        }   
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        context.HttpContext.EndDiagnosticsTime(TimerName);
                        Logger.Debug("JWT Bearer is valid", context.Request.GetMessageId(TetraPakConfig));
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.HttpContext.EndDiagnosticsTime(TimerName);
                        if (Logger?.IsEnabled(LogLevel.Debug) ?? false)
                        {
                            var message = context.Exception is { }
                                ? $"JWT Bearer assertion failed: {context.Exception.Message}"
                                : "JWT Bearer assertion failed";
                            Logger.Debug(message, context.Request.GetMessageId(TetraPakConfig));
                        }

                        // terminates the request (todo: Consider option to allow other authentication schemes)
                        context.Response.OnStarting(async () =>
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                            var messageId = context.Request.GetMessageId(TetraPakConfig);
                            var response = IsDevelopment
                                ? new ApiErrorResponse(context.Exception!.Message, messageId)
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

        string resolveAudience(string? audience)
        {
            return string.IsNullOrWhiteSpace(audience) || SelfReferenceIdentifier.Equals(audience, StringComparison.InvariantCultureIgnoreCase)
                ? _hostProvider.GetHost()
                : audience;
        }

        /// <inheritdoc />
        public void Configure(string name, JwtBearerOptions options)
        {
            if (name == JwtBearerDefaults.AuthenticationScheme)
            {
                Configure(options);
            }
        }

        /// <summary>
        ///   Initializes the <see cref="ConfigureJwtBearerOptions"/>.
        /// </summary>
        /// <param name="provider">
        ///   A service locator.
        /// </param>
        /// <param name="hostProvider">
        ///   Provides access to the host name.
        /// </param>
        /// <param name="hostEnvironment">
        ///   The host environment information.
        /// </param>
        /// <param name="options">
        ///   (optional; default=service located instance)<br/>
        ///   JWT Bearer Assertion options.
        /// </param>
        public ConfigureJwtBearerOptions(
            IServiceProvider provider, 
            HostProvider hostProvider,
            IWebHostEnvironment hostEnvironment,
            JwBearerAssertionOptions? options = null)
        {
            _options = options ?? ActivatorUtilities.CreateInstance<JwBearerAssertionOptions>(provider);
            _hostProvider = hostProvider;
            _hostEnvironment = hostEnvironment;
            Logger = provider.GetService<ILogger<ConfigureJwtBearerOptions>>();
        }
    }
}