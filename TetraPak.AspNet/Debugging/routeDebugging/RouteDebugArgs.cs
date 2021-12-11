using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Arguments used when invoking a custom routing debugger handler (<see cref="RouteDebugHandler"/>).
    /// </summary>
    public class RouteDebugArgs
    {
        /// <summary>
        ///   Rets the resolved routing <see cref="Endpoint"/>.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Endpoint? Endpoint { get; }

        /// <summary>
        ///   Specifies the <see cref="LogLevel"/> used for logging routing information.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public LogLevel LogLevel { get; }

        /// <summary>
        ///   Gets or sets a value that specifies that operation is complete
        ///   and that no further actions are to be taken. 
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public bool IsHandled { get; set; }

        internal RouteDebugArgs(HttpContext context, RouteDebuggingOptions options)
        {
            Endpoint = context.GetEndpoint();
            LogLevel = (options.Channels & RouteDebuggingChannels.Logger) == RouteDebuggingChannels.Logger
                ? options.LogLevel
                : LogLevel.Debug;
        }
    }
}