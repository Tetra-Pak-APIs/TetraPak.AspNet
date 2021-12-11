using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Used to configure route debugging.
    /// </summary>
    /// <seealso cref="DebugHelper.UseRoutingDebugging"/>
    public class RouteDebuggingOptions
    {
        /// <summary>
        ///   Specifies which channel(s) to be used for logging routing debugging information.
        /// </summary>
        public RouteDebuggingChannels Channels { get; set; } = RouteDebuggingChannels.Logger;

        /// <summary>
        ///   Specifies the <see cref="LogLevel"/> to be used when sending routing debug
        ///   information to a <see cref="ILogger"/>.
        /// </summary>
        /// <seealso cref="RouteDebuggingChannels.Logger"/>
        public LogLevel LogLevel { get; set; } = LogLevel.Debug;

        /// <summary>
        ///   Optional callback handler for custom routing debugging.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public RouteDebugHandler? OnRouteDebug { get; set; }
    }
}