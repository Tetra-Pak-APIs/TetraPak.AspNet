using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TetraPak.AspNet.Api.DevelopmentTools;
using TetraPak.Caching;

namespace TetraPak.AspNet.Api.Auth
{
    partial class TetraPakApiAuth // JWT Bearer validation 
    {
        /// <summary>
        ///   Configures the app service for Jwt Bearer Authentication.
        /// </summary>
        /// <param name="c">
        ///   A <see cref="IServiceCollection"/>, to be configured for the requested auth flow.
        /// </param>
        /// <param name="options">
        ///   Options governing how/what to validate JWT bearer tokens. 
        /// </param>
        /// <returns>
        ///   The <see cref="IServiceCollection"/> instance.
        /// </returns>
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection c,
            JwBearerAssertionOptions options = null)
        {
            return c.AddJwtAuthentication<SimpleCache>(options);
        }

        /// <summary>
        ///   Configures the app service for Jwt Bearer Authentication while specifying a cache implementation.
        /// </summary>
        /// <param name="c">
        ///   A <see cref="IServiceCollection"/>, to be configured for the requested auth flow.
        /// </param>
        /// <param name="options">
        ///   Options governing how/what to validate JWT bearer tokens. 
        /// </param>
        /// <typeparam name="TCache">
        ///   Specifies a class for implementing caching (must implement <see cref="ITimeLimitedRepositories"/>).
        /// </typeparam>
        /// <returns>
        ///   The <see cref="IServiceCollection"/> instance.
        /// </returns>
        public static IServiceCollection AddJwtAuthentication<TCache>(
            this IServiceCollection c,
            JwBearerAssertionOptions options = null)
        where TCache : class, ITimeLimitedRepositories
        {
            c.TryAddSingleton<HostProvider>();
            c.TryAddSingleton<TetraPakApiAuthConfig>();            
            c.TryAddSingleton<TetraPakAuthConfig, TetraPakApiAuthConfig>();

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
        ///   Installs JWT authentication middleware
        ///   (and, optionally, a built-in local "development proxy"). Please see remarks. 
        /// </summary>
        /// <param name="app">
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <param name="env"></param>
        /// <param name="enableTetraPakMessageId">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to also enforce the Tetra Pak message id functionality.
        ///   This is akin to calling <see cref="TetraPakApiHelper.UseTetraPakMessageId"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        /// <remarks>
        ///   <para>
        ///   Enabling this mechanism is a flexible way to protect your secure endpoints. When enabled
        ///   client must call your protected endpoints through a reversed proxy acting as your API's "sidecar".
        ///   The sidecar will handle client authentication and, when successful, replace the client's
        ///   access token with a short lived JWT Bearer token, to be exchanged only between the service and its sidecar.
        ///   This JWT Bearer will automatically be validated for every request by the middleware installed by this method.
        ///   </para>
        ///   <para>
        ///   While securing your traffic the flipside to this approach is that your service cannot function
        ///   without a sidecar. When there is no internal JWT Bearer to validate the request will automatically
        ///   fail and return an "Unauthorized" response (<see cref="HttpStatusCode.Unauthorized"/>).
        ///   This makes it impossible to host your service locally for debugging during development.
        ///   </para>
        ///   <para>
        ///   To deal with this you might have to introduce conditional validation and even remove authentication
        ///   completely when debugging your service locally. This is a very bad idea as it would mean you would
        ///   effectively be debugging code that is different from the one deployed to its hosting environments. 
        ///   </para>
        ///   <para>
        ///   A better solution is using a local development proxy (sidecar) that acts as the real thing.
        ///   You can do this by simply adding a <c>DevProxy</c> flag to the <c>ValidateJwtBearer</c> sub section
        ///   in your json configuration in appsettings.json or (better yet)
        ///   appsettings.Development.json, like so:
        ///   </para>
        ///   <code>
        ///    "TetraPak": {
        ///       "ClientId": "abcd1234",
        ///       "ValidateJwtBearer": {
        ///            "Audience": "demo-api",
        ///            "DevProxy": "demo-api-proxy"
        ///       }
        ///   }
        ///   </code>
        ///   The value for the <c>DevProxy</c> key should be the Apigee proxy name (you probably need to ask for it),
        ///   or the full proxy URL. Please note that the local development proxy will ONLY be enabled when
        ///   your service is running in the "Development" runtime environment, regardless of the your configuration.
        ///   This is to ensure you cannot accidentally deploy it to any other environment.
        /// </remarks>
        public static IApplicationBuilder UseJwtAuthentication(
            this IApplicationBuilder app, 
            IWebHostEnvironment env,
            bool enableTetraPakMessageId = true)
        {
            var config = app.ApplicationServices.GetService<TetraPakAuthConfig>();
            var proxyUrl = config?.JwtBearerValidation.DevProxy;
            if (enableTetraPakMessageId)
            {
                app.UseTetraPakMessageId();
            }
            if (!string.IsNullOrEmpty(proxyUrl))
            {
                app.UseLocalDevProxy(env, proxyUrl);
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