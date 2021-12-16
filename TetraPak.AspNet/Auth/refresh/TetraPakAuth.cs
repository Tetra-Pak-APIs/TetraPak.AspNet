using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    partial class TetraPakAuth // refresh token flow 
    {
        static readonly object s_syncRoot = new();
        static bool s_isRefreshTokenGrantAdded;
        
        // /// <summary>
        // ///   OBSOLETE!
        // ///   This method will be removed in future versions.
        // ///   Please use <see cref="UseTetraPakClientAuthentication"/> instead.
        // /// </summary>
        // [Obsolete("This method will be removed in future versions. Please use UseTetraPakClientAuthentication instead")]
        // public static void UseTetraPakAuthentication(this IApplicationBuilder app, IWebHostEnvironment env)
        // {
        //     app.UseTetraPakClientAuthentication(env);
        // }
        
        /// <summary>
        ///   Configures Tetra Pak specific auth behavior.
        /// </summary>
        /// <param name="app">
        ///   The application builder object.
        /// </param>
        /// <param name="env">
        ///   Provides information about the hosting environment. 
        /// </param>
        public static void UseTetraPakClientAuthentication(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var config = app.ApplicationServices.GetRequiredService<TetraPakConfig>();
            if (config.IsMessageIdEnabled)
            {
                app.UseTetraPakMessageId();
            }
        }

        /// <summary>
        ///   Adds Tetra Pak support for the OAuth2 Refresh Token Grant flow.
        /// </summary>
        /// <param name="services">
        ///   The service collection.
        /// </param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddTetraPakRefreshTokenGrant(this IServiceCollection services)
        {
            lock (s_syncRoot)
            {
                if (s_isRefreshTokenGrantAdded)
                    return services;

                try
                {
                    services.AddTetraPakHttpClientProvider();
                    services.AddSingleton<IRefreshTokenGrantService>(p
                        => new TetraPakRefreshTokenGrantService(
                            p.GetRequiredService<TetraPakConfig>(),
                            p.GetRequiredService<IHttpClientProvider>(),
                            p.GetService<IHttpContextAccessor>(),
                            p.GetService<ILogger<TetraPakRefreshTokenGrantService>>()));
                    s_isRefreshTokenGrantAdded = true;
                }
                catch (Exception ex)
                {
                    var p = services.BuildServiceProvider();
                    var logger = p.GetService<ILogger<TetraPakRefreshTokenGrantService>>();
                    logger.Error(ex, $"Failed to register Tetra Pak Refresh Token Grant ({typeof(TetraPakRefreshTokenGrantService)}) with service collection");
                }
            }

            return services;
        }
    }
}