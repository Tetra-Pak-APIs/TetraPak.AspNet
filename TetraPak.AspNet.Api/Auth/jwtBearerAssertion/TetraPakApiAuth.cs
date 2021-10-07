using System;
using System.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TetraPak.AspNet.Api.DevelopmentTools;
using TetraPak.AspNet.Auth;
using TetraPak.Caching;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Provides convenience- and extension methods for Tetra Pak auth purposes.
    /// </summary>
    partial class TetraPakApiAuth // JWT Bearer validation 
    {
        /// <summary>
        ///   Configures the app service for Jwt Bearer Authentication.
        /// </summary>
        /// <param name="c">
        ///   A <see cref="IServiceCollection"/>, to be configured for the requested auth flow.
        /// </param>
        /// <param name="defaultScheme">
        ///   (optional; default="Bearer")<br/>
        ///   Specifies the default authentication scheme.  
        /// </param>
        /// <param name="options">
        ///   Options governing how/what to validate JWT bearer tokens. 
        /// </param>
        /// <returns>
        ///   The <see cref="IServiceCollection"/> instance.
        /// </returns>
        public static AuthenticationBuilder AddTetraPakJwtBearerAssertion(
            this IServiceCollection c,
            string? defaultScheme = null, 
            JwBearerAssertionOptions? options = null)
        {
            return c.AddTetraPakJwtBearerAssertion<SimpleCache>(defaultScheme, options);
        }
        
        /// <summary>
        ///   Configures the app service for Jwt Bearer Authentication while specifying a cache implementation.
        /// </summary>
        /// <param name="c">
        ///   A <see cref="IServiceCollection"/>, to be configured for the requested auth flow.
        /// </param>
        /// <param name="defaultScheme">
        ///   (optional; default="Bearer")<br/>
        ///   Specifies the default authentication scheme.  
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
        /// <seealso cref="UseTetraPakApiAuthentication"/>
        public static AuthenticationBuilder AddTetraPakJwtBearerAssertion<TCache>(
            this IServiceCollection c,
            string? defaultScheme = null, 
            JwBearerAssertionOptions? options = null)
            where TCache : class, ITimeLimitedRepositories
        {
            defaultScheme ??= JwtBearerDefaults.AuthenticationScheme;
            return c.AddAuthentication(defaultScheme)
                    .AddTetraPakJwtBearerAssertion<TCache>(options);
        }

        public static AuthenticationBuilder AddTetraPakJwtBearerAssertion(
            this AuthenticationBuilder a,
            JwBearerAssertionOptions? options = null)
        {
            return a.AddTetraPakJwtBearerAssertion<SimpleCache>(options);
        }

        public static AuthenticationBuilder AddTetraPakJwtBearerAssertion<TCache>(
            this AuthenticationBuilder a,
            JwBearerAssertionOptions? options = null)
            where TCache : class, ITimeLimitedRepositories
        {
            var c = a.Services;
            c.TryAddSingleton<HostProvider>();
            c.TryAddSingleton<TetraPakApiConfig>();            
            c.TryAddSingleton<TetraPakConfig, TetraPakApiConfig>();

            addCachingIfAllowed();
            
            c.AddTetraPakApiClaimsTransformation();
            
            c.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>(
                p => new ConfigureJwtBearerOptions(p, 
                    p.GetRequiredService<HostProvider>(), 
                    p.GetRequiredService<IWebHostEnvironment>(),
                    options));
            return a.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, _ => {});
            
            void addCachingIfAllowed()
            {
                var provider = c.BuildServiceProvider();
                var authConfig = provider.GetService<TetraPakConfig>();
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
        ///   <para>
        ///   <b>DEPRECATED!</b>
        ///   </para>
        ///   <para>
        ///   This method was deprecated in SDK v1.1 and is scheduled for removal in future versions.
        ///   Please use <see cref="UseTetraPakApiAuthentication"/> instead.
        ///   </para> 
        /// </summary>
        /// <seealso cref="AddTetraPakJwtBearerAssertion"/>
        [Obsolete("This method is obsolete. Please call UseTetraPakAuthentication instead")] // obsolete method (replaced)
        public static IApplicationBuilder UseTetraPakJwtAuthentication(
            this IApplicationBuilder app, 
            IWebHostEnvironment env)
        => app.UseTetraPakApiAuthentication(env);

        /// <summary>
        ///   Installs JWT authentication middleware
        ///   (and, optionally, a built-in local "development proxy"). Please see remarks. 
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
        ///   <para>
        ///   The value for the <c>DevProxy</c> key should be the Apigee proxy name (you probably need to ask for it),
        ///   or the full proxy URL. Please note that the local development proxy will ONLY be enabled when
        ///   your service is running in the "Development" runtime environment, regardless of the your configuration.
        ///   This is to ensure you cannot accidentally deploy it to any other environment.
        ///   </para>
        /// </remarks>
        /// <seealso cref="AddTetraPakJwtBearerAssertion"/>
        public static IApplicationBuilder UseTetraPakApiAuthentication(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            app.UseTetraPakAuthentication(env);
            
            var config = app.ApplicationServices.GetRequiredService<TetraPakConfig>();
            var proxyUrl = config.JwtBearerAssertion.DevProxy;
            var mutedWhen = config.JwtBearerAssertion.DevProxyIsMutedWhen;
            if (!string.IsNullOrEmpty(proxyUrl))
            {
                app.UseLocalDevProxy(env, proxyUrl, mutedWhen);
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