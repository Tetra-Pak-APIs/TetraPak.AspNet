using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.DevelopmentTools
{
    public static class DevSidecarHelper
    {
        /// <summary>
        ///   Enables the behavior of a local "development sidecar" (reversed proxy).
        ///   Please note that the sidecar will only be enabled when the host
        ///   is running in a "Development" runtime environment. 
        /// </summary>
        /// <param name="app">
        ///     The application builder instance.
        /// </param>
        /// <param name="env">
        ///     The wwb host environment.
        /// </param>
        /// <param name="sidecarUrl"></param>
        /// <returns>
        ///   The <paramref name="app"/> instance.
        /// </returns>
        public static IApplicationBuilder UseDevSidecar(this IApplicationBuilder app, 
            IWebHostEnvironment env,
            string sidecarUrl)
        {
            if (!env.IsDevelopment())
                return app;

            var logger = app.ApplicationServices.GetService<ILogger<SidecarEmulatingMiddleware>>();
            var config = app.ApplicationServices.GetService<TetraPakAuthConfig>();
            if (config is null)
            {
                logger.Warning($"Cannot inject a local sidecar. {nameof(TetraPakAuthConfig)} service is not set up");
                return app;
            }

            var ambientData = app.ApplicationServices.GetService<AmbientData>();
            if (ambientData is null)
            {
                logger.Warning($"Cannot inject a local sidecar. {nameof(AmbientData)} service is not set up");
                return app;
            }

            var sidecar = new SidecarEmulatingMiddleware(config, sidecarUrl);
            app.Use(async (context, next) =>
            {
                var isSuccessful = await sidecar.InvokeAsync(context);
                if (!isSuccessful)
                {
                    logger.Warning("Dev Sidecar failed to produce a Sidecar JWT Bearer");
                    return;
                }
                await next();
            });
            logger.Warning("Local development sidecar middleware was injected");            
            return app;
        }
    }
}