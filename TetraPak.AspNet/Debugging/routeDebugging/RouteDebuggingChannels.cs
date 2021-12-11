using System;

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Used to specify which channels to write route debugging to.
    /// </summary>
    /// <seealso cref="RouteDebuggingOptions.Channels"/>
    [Flags]
    public enum RouteDebuggingChannels
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
}