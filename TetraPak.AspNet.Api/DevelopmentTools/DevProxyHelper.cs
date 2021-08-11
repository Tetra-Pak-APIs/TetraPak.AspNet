using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.DevelopmentTools
{
    public static class DevProxyHelper
    {
        /// <summary>
        ///   Enables the behavior of a local "development proxy" (a.k.a. "sidecar").
        ///   Please note that the proxy will only be enabled when the host
        ///   is running in a "Development" runtime environment. 
        /// </summary>
        /// <param name="app">
        ///   The application builder instance.
        /// </param>
        /// <param name="env">
        ///   The wwb host environment.
        /// </param>
        /// <param name="proxyUrl">
        ///   The URL for the (actual) proxy to be emulated locally.
        /// </param>
        /// <returns>
        ///   The <paramref name="app"/> instance.
        /// </returns>
        public static IApplicationBuilder UseLocalDevProxy(this IApplicationBuilder app, 
            IWebHostEnvironment env,
            string proxyUrl)
        {
            if (!env.IsDevelopment())
                return app;

            var logger = app.ApplicationServices.GetService<ILogger<LocalDevProxyMiddleware>>();

            var ambientData = app.ApplicationServices.GetService<AmbientData>();
            if (ambientData is null)
            {
                logger.Warning($"Cannot inject a local development proxy. {nameof(AmbientData)} service is not set up");
                return app;
            }

            var proxyMiddleware = new LocalDevProxyMiddleware(ambientData, proxyUrl);
            app.Use(async (context, next) =>
            {
                var isSuccessful = await proxyMiddleware.InvokeAsync(context);
                if (!isSuccessful)
                {
                    logger.Warning("Local development proxy failed to produce a JWT Bearer");
                    return;
                }
                await next();
            });
            logger.Warning("Local development proxy middleware was injected");            
            return app;
        }
    }
}