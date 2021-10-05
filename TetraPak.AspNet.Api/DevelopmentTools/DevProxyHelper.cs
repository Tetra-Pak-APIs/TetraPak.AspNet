using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api.DevelopmentTools
{
    /// <summary>
    ///   Provides helper methods for using a local (desktop) development proxy (sidecar).
    /// </summary>
    public static class DevProxyHelper
    {
        static readonly object s_syncRoot = new object();
        static bool s_isDevProxyAllowed = true;
        static bool s_isDevProxyConfigured;

        /// <summary>
        ///   Enables the behavior of a local "development proxy" (a.k.a. "sidecar").
        ///   Please note that the proxy will only be enabled when the host
        ///   is running in a "Development" runtime environment. 
        /// </summary>
        /// <param name="app">
        ///     The application builder instance.
        /// </param>
        /// <param name="env">
        ///     The wwb host environment.
        /// </param>
        /// <param name="proxyUrl">
        ///     The URL for the (actual) proxy to be emulated locally.
        /// </param>
        /// <param name="isMutedWhen">
        ///   (optional)<br/>
        ///   Specified a <see cref="HttpComparison"/> criteria that, when <c>true</c>, mutes the
        ///   DevProxy, allowing the request to just pass through to the API.
        /// </param>
        /// <returns>
        ///   The <paramref name="app"/> instance.
        /// </returns>
        public static IApplicationBuilder UseLocalDevProxy(this IApplicationBuilder app,
            IWebHostEnvironment env,
            string proxyUrl, 
            HttpComparison? isMutedWhen = null)
        {
            lock (s_syncRoot)
            {
                if (s_isDevProxyConfigured || !s_isDevProxyAllowed)
                    return app;

                var logger = app.ApplicationServices.GetService<ILogger<DevProxyMiddleware>>();
                s_isDevProxyAllowed = env.IsLocalHost();
                if (!s_isDevProxyAllowed)
                {
                    logger.Debug("Local development proxy middleware was NOT injected (not a local host)");
                    return app;
                }

                var authConfig = app.ApplicationServices.GetService<TetraPakAuthConfig>();
                if (authConfig is null)
                {
                    logger.Warning($"Cannot inject a local development proxy. {nameof(TetraPakAuthConfig)} service is not configured");
                    s_isDevProxyConfigured = true;
                    return app;
                }

                var proxyMiddleware = new DevProxyMiddleware(authConfig, proxyUrl, isMutedWhen);
                app.Use(async (context, next) =>
                {
                    await proxyMiddleware.InvokeAsync(context);
                    await next();
                });
                logger.Warning("Local development proxy middleware WAS injected");
                s_isDevProxyConfigured = true;
                return app;
            }
        }
    }
}