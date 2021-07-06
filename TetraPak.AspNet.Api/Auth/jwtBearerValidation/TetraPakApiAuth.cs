using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TetraPak.AspNet.Api.DevelopmentTools;
using TetraPak.AspNet.Auth;
using TetraPak.Caching;

namespace TetraPak.AspNet.Api.Auth
{
    partial class TetraPakApiAuth // JWT Bearer validation 
    {
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
            return c.AddSidecarJwtAuthentication<SimpleCache>(options);
        }

        /// <summary>
        ///   Configures the app service for Tetra Pak Sidecar Jwt Bearer Authentication while
        ///   specifying a cache implementation.
        /// </summary>
        /// <param name="c">
        ///   A <see cref="IServiceCollection"/>, to be configured for the requested auth flow.
        /// </param>
        /// <param name="options">
        ///   Options governing how/what to validate in the sidecar issued JWT bearer tokens. 
        /// </param>
        /// <typeparam name="TCache">
        ///   Specifies a class for implementing caching (must implement <see cref="ITimeLimitedRepositories"/>).
        /// </typeparam>
        /// <returns>
        ///   The <see cref="IServiceCollection"/> instance.
        /// </returns>
        public static IServiceCollection AddSidecarJwtAuthentication<TCache>(
            this IServiceCollection c,
            SidecarJwBearerAssertionOptions options = null)
        where TCache : class, ITimeLimitedRepositories
        {
            c.AddSingleton<HostProvider>();
            c.AddSingleton<TetraPakAuthApiConfig>();            
            c.AddSingleton<TetraPakAuthConfig, TetraPakAuthApiConfig>();

            addCachingIfAllowed();
            
            c.AddTetraPakWebApiClaimsTransformation();
            c.AddTetraPakUserInformation();
            
            c.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>(
                p => new ConfigureJwtBearerOptions(p, 
                    p.GetService<HostProvider>(), 
                    p.GetService<IWebHostEnvironment>(),
                    options));
            c.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, null);
            return c;
            
            void addCachingIfAllowed()
            {
                var provider = c.BuildServiceProvider();
                var authConfig = provider.GetService<TetraPakAuthConfig>();
                if (authConfig is null || !authConfig.IsCachingAllowed)
                    return;

                if (!typeof(TCache).IsAssignableFrom(typeof(SimpleCache)))
                {
                    c.AddSingleton<ITimeLimitedRepositories, TCache>();
                    return;
                }
                
                c.AddSingleton<ITimeLimitedRepositories,SimpleCache>(p =>
                {
                    var cacheLogger = p.GetService<ILogger<SimpleCache>>();
                    var cache = new SimpleCache(cacheLogger)
                    {
                        DefaultLifeSpan = authConfig.DefaultCachingLifetime
                    };
                    var cacheConfig = authConfig.Caching.WithCache(cache);
                    return cache.WithConfiguration(cacheConfig);
                });
            }
        }

        /// <summary>
        ///   Installs sidecar JWT authentication middleware
        ///   (and, optionally, a built-in "development sidecar"). Please see remarks. 
        /// </summary>
        /// <param name="app">
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <param name="env"></param>
        /// <returns>
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        /// <remarks>
        ///   <para>
        ///   Enabling this mechanism is a flexible way to protect your secure endpoints. When enabled
        ///   client must call your protected endpoints through a reversed proxy acting as your API's "sidecar".
        ///   The sidecar will handle client authentication and, when successful, replace the client's
        ///   access token with a short-lived, internal, JWT Bearer token. This JWT Bearer will automatically
        ///   be validated for every request by the middleware installed by this method.
        ///   </para>
        ///   <para>
        ///   While securing your traffic the downside with this approach is that your service cannot function
        ///   without a sidecar. When there is no internal JWT Bearer to validate the request will automatically
        ///   fail and return an "Unauthorized" response (<see cref="HttpStatusCode.Unauthorized"/>).
        ///   This makes it impossible to host your service locally for debugging during development.
        ///   </para>
        ///   <para>
        ///   To deal with this you might have to introduce conditional validation and even remove authentication
        ///   completely when debugging your service locally. This is a bad idea as it would mean you'd be debugging
        ///   code that will then function differently when deployed to its TEST or PRODUCTION hosting environment. 
        ///   </para>
        ///   <para>
        ///   A better solution is using a local development sidecar that acts as the real thing. You can do this
        ///   by simply adding a <c>UseDevSidecar</c> flag to the <c>ValidateJwtBearer</c> sub section
        ///   in your json configuration in appsettings.json or (better yet)
        ///   appsettings.Development.json, like so:
        ///   </para>
        ///   <code>
        ///    "TetraPak": {
        ///       "ClientId": "abcd1234",
        ///       "ValidateJwtBearer": {
        ///            "Audience": "demo-api",
        ///            "UseDevSidecar": true
        ///       }
        ///   }
        ///   </code>
        ///   Please note that the "development sidecar" will ONLY be enabled when your service is running
        ///   in the "Development" runtime environment, regardless of the your configuration.
        /// </remarks>
        public static IApplicationBuilder UseSidecarJwtAuthentication(
            this IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            var config = app.ApplicationServices.GetService<TetraPakAuthConfig>();
            var sidecarUrl = config?.JwtBearerValidation.DevSidecar;
            if (!string.IsNullOrEmpty(sidecarUrl))
            {
                app.UseDevSidecar(env, sidecarUrl);
            }
            app.Use((context, func) =>
            {
                Host ??= $"{context.Request.Scheme}://{context.Request.Host.Value}";
                return func();
            });
            app.UseAuthentication();
            
            return app;
        }
    }
}