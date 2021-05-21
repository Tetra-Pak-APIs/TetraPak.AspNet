using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api.Auth
{
    public static class TetraPakAuth
    {
        internal static string Host { get; private set; }
        
        /// <summary>
        ///   Configures the app service for Tetra Pak Sidecar Jwt Bearer Authentication.
        /// </summary>
        /// <param name="c">
        ///   A <see cref="IServiceCollection"/>, to be configured for the requested auth flow.
        /// </param>
        /// <param name="options">
        ///   Options governing how/what to validate in the sidecar issued JWT bearer tokens. 
        /// </param>
        /// <returns>
        ///   The <see cref="IServiceCollection"/> instance.
        /// </returns>
        public static IServiceCollection AddSidecarJwtAuthentication(
            this IServiceCollection c,
            SidecarJwBearerAssertionOptions options = null)
        {
            c.AddSingleton<HostProvider>();
            c.AddSingleton<TetraPakAuthConfig>();
            c.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>(
                p => new ConfigureJwtBearerOptions(p, 
                    p.GetService<HostProvider>(), 
                    p.GetService<IWebHostEnvironment>(),
                    options));
            c.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, null);
            return c;
        }

        
        /// <summary>
        ///   Installs sidecar JWT authentication middleware. 
        /// </summary>
        /// <param name="app">
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <returns>
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        public static IApplicationBuilder UseSidecarJwtAuthentication(this IApplicationBuilder app)
        {
            app.Use((context, func) =>
            {
                Host ??= $"{context.Request.Scheme}://{context.Request.Host.Value}";
                return func();
            });
            app.UseAuthentication();
            
            return app;
        }
    }

    public class HostProvider
    {
        internal string GetHost() => TetraPakAuth.Host;
    }
    
    
    /// <summary>
    ///   Used for configuring Sidecar JWT Bearer Assertion.
    /// </summary>
    public class SidecarJwBearerAssertionOptions
    {
        public TetraPakAuthConfig AuthConfig { get; }

        public SidecarJwBearerAssertionOptions(TetraPakAuthConfig authConfig)
        {
            AuthConfig = authConfig;
        }
    }
}