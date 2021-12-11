using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LoggerExtensions=TetraPak.Logging.LoggerExtensions;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Provides convenient extension methods to be used for debugging/diagnostics purposes.
    /// </summary>
    public static class DebugHelper
    {
        static AssemblyDebuggingMiddleware? s_assemblyDebuggingMiddleware;

        /// <summary>
        ///   Injects middleware that logs all assemblies currently linked to the app domain. 
        /// </summary>
        /// <param name="app">
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <param name="logLevel">
        ///   (optional; default=<see cref="LogLevel.Debug"/>)<br/>
        ///   Specifies the log level used when sending the information to the log provider.
        /// </param>
        /// <returns>
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        public static IApplicationBuilder UseAssembliesUsedDebugging(
            this IApplicationBuilder app, 
            LogLevel logLevel = LogLevel.Debug)
        {
            var logger = app.ApplicationServices.GetService<ILogger<AssemblyDebuggingMiddleware>>();
            s_assemblyDebuggingMiddleware = new AssemblyDebuggingMiddleware(true, logger);
            
            app.Use(async (_, next) =>
            {
                await s_assemblyDebuggingMiddleware.InvokeAsync();
                await next();
            });

            return app;
        }
        
        /// <summary>
        ///   Adds route debugging information to all configured channels
        ///   (such as the console and/or the logging framework).
        /// </summary>
        /// <param name="app">
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <param name="optionsFactory">
        ///   (optional)<br/>
        ///   A delegate to customize <see cref="RouteDebuggingOptions"/> used for debugging routing.
        /// </param>
        /// <returns>
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        /// <seealso cref="RouteDebuggingOptions"/>
        public static IApplicationBuilder UseRoutingDebugging(
            this IApplicationBuilder app,
            Action<RouteDebuggingOptions>? optionsFactory = null)
        {
            var options = new RouteDebuggingOptions();
            optionsFactory?.Invoke(options);

            app.Use((context, next) =>
            {
                var endpoint = context.GetEndpoint();
                if (options.OnRouteDebug is { })
                {
                    var args = new RouteDebugArgs(context, options);
                    options.OnRouteDebug(args);
                    if (args.IsHandled)
                        return next();
                }

                if ((options.Channels & RouteDebuggingChannels.Console) == RouteDebuggingChannels.Console)
                {
                    Console.WriteLine($"Route found: {context.GetEndpoint()?.DisplayName}");
                }

                if ((options.Channels & RouteDebuggingChannels.Logger) != RouteDebuggingChannels.Logger) 
                    return next();
                
                var logger = context.RequestServices.GetService<ILogger<RouteDebugArgs>>();
                var message = LoggerExtensions.Format($"Route: {endpoint?.DisplayName ?? "(none)"}");
                // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
                logger.Log(options.LogLevel, message);

                return next();
            });

            return app;
        }
    }
}