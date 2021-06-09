using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LoggerExtensions=TetraPak.Logging.LoggerExtensions;

namespace TetraPak.AspNet.Debugging
{
    public static class DebugHelper
    {
        /// <summary>
        ///   Adds route debugging information to all configured channels
        ///   (such as the console and/or the logging framework).
        /// </summary>
        /// <param name="app">
        ///   An <see cref="IApplicationBuilder"/> instance.
        /// </param>
        /// <param name="onSetOptions">
        ///   (optional)<br/>
        ///   A delegate to customize <see cref="RouteDebuggingOptions"/> used for debugging routing.
        /// </param>
        /// <returns>
        ///   The <see cref="IApplicationBuilder"/> instance.
        /// </returns>
        /// <seealso cref="RouteDebuggingOptions"/>
        public static IApplicationBuilder UseRoutingDebugging(
            this IApplicationBuilder app,
            Action<RouteDebuggingOptions> onSetOptions = null)
        {
            var options = new RouteDebuggingOptions();
            onSetOptions?.Invoke(options);

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

                if ((options.Logging & RouteDebuggingLogging.Console) == RouteDebuggingLogging.Console)
                {
                    Console.WriteLine($"Route found: {context.GetEndpoint()?.DisplayName}");
                }

                if ((options.Logging & RouteDebuggingLogging.Logger) != RouteDebuggingLogging.Logger) 
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

    public class RouteDebugArgs
    {
        public Endpoint Endpoint { get; }

        /// <summary>
        ///   
        /// </summary>
        public LogLevel? LogLevel { get; }

        /// <summary>
        ///   Gets or sets a value that specifies that operation is complete
        ///   and that no further actions are to be taken. 
        /// </summary>
        public bool IsHandled { get; set; }

        internal RouteDebugArgs(HttpContext context, RouteDebuggingOptions options)
        {
            Endpoint = context.GetEndpoint();
            LogLevel = (options.Logging & RouteDebuggingLogging.Logger) == RouteDebuggingLogging.Logger
                ? options.LogLevel
                : null;
        }
    }

    /// <summary>
    ///   Used to specify which channels to write route debugging to.
    /// </summary>
    /// <seealso cref="RouteDebuggingOptions.Logging"/>
    [Flags]
    public enum RouteDebuggingLogging
    {
        /// <summary>
        ///   Route debugging will not be written to any channel.
        /// </summary>
        None = 0,
        
        /// <summary>
        ///   Route debugging will be written to the console.
        /// </summary>
        Console = 1,
        
        /// <summary>
        ///   Route debugging will be written to the configured logging framework.
        /// </summary>
        Logger = 2,
        
        /// <summary>
        ///   Route debugging will be written to all supported channels.
        /// </summary>
        All = Console | Logger
    }

    public delegate void RouteDebugHandler(RouteDebugArgs args);
    
    /// <summary>
    ///   Used to configure route debugging.
    /// </summary>
    /// <seealso cref="DebugHelper.UseRoutingDebugging"/>
    public class RouteDebuggingOptions
    {
        public RouteDebuggingLogging Logging { get; set; } = RouteDebuggingLogging.Logger;

        public LogLevel LogLevel { get; set; } = LogLevel.Debug;

        public RouteDebugHandler OnRouteDebug { get; set; }
    }
}