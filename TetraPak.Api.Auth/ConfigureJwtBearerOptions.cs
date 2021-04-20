using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;
using TetraPak.Serialization;

namespace TetraPak.Api.Auth
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        const string SelfReferenceIdentifier = "(me)";
        
        readonly SidecarJwBearerAssertionOptions _options;
        readonly HostProvider _hostProvider;
        readonly IWebHostEnvironment _hostEnvironment;

        bool IsDevelopment => _hostEnvironment.IsDevelopment();
        
        public TetraPakAuthConfig AuthConfig => _options.AuthConfig;

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
#if UNSECURE__
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
                    OnMessageReceived = context =>
                    {
                        if (!Logger.IsEnabled(LogLevel.Debug))
                            return Task.CompletedTask;
                        
                        var jwt = getJwtBearer(context);
                        Logger.Debug($"Received message: {context.Request.Path.Value}");
                        Logger.Debug(jwt is null
                            ? "No JWT Bearer was supplied"
                            : $"Received JWT Bearer: {tokenLogString(jwt)}");
                        Logger.Debug($"Environment: {AuthConfig.Environment}");
                        Logger.Debug($"Discovery document URL: {options.MetadataAddress}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Logger.Debug("Token is valid");
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (!Logger.IsEnabled(LogLevel.Debug))
                        {
                            var message = context.Exception is { }
                                ? $"JWT Bearer Assertion failed: {context.Exception.Message}"
                                : "JWT Bearer Assertion failed";
                            Logger.Debug(message);
                        }

                        // terminates the request (todo: Consider option to allow other authentication schemes)
                        context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                        var response = IsDevelopment
                            ? new ApiErrorResponse(context.Exception.Message)
                            {
                                Description = context.Exception.StackTrace
                            }
                            : new ApiErrorResponse("JWT authentication failed");
                        context.Response.WriteAsync(response.ToJson(IsDevelopment, JsonIgnoreCondition.WhenWritingNull));
                        return Task.FromResult(0);
                    },
                    // OnForbidden = context =>
                    // {
                    //     return Task.CompletedTask;
                    // },
                    // OnChallenge = context =>
                    // {
                    //     return Task.CompletedTask;
                    // }
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

        static JwtSecurityToken getJwtBearer(MessageReceivedContext context)
        {
            const string BearerQualifier = "Bearer ";
            
            var s = context.Request.Headers["Authorization"].FirstOrDefault();
            if (s is null)
                return null;

            if (!s.StartsWith(BearerQualifier, StringComparison.InvariantCultureIgnoreCase))
                return null;

            try
            {
                var sJwt = s.Substring(BearerQualifier.Length).Trim();
                var handler = new JwtSecurityTokenHandler();
                return handler.ReadJwtToken(sJwt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static string tokenLogString(JwtSecurityToken jwt)
        {
            var sb = new StringBuilder();
            foreach (var claim in jwt.Claims)
            {
                
                sb.AppendLine($"{claim.Type}: {claim.Value}");
            }

            return sb.ToString();
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