using System;
using System.Net;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Thrown to reflect configuration issues.
    /// </summary>
    public class ServerConfigurationException : ServerException
    {
        /// <summary>
        ///   (static property)<br/>
        ///   Gets or sets a default error message to be used when no message is specified.
        /// </summary>
        public static string DefaultErrorMessage { get; set; } = "Internal server error (probably configuration)";
        
        /// <summary>
        ///   Initializes the <see cref="ServerConfigurationException"/>.
        /// </summary>
        /// <param name="message">
        ///   (optional; default=<see cref="DefaultErrorMessage"/>)<br/>
        ///   A message describing the server configuration issue.
        /// </param>
        /// <param name="innerException">
        ///   (optional)<br/>
        ///   The exception that is the cause of the current exception.
        /// </param>
        public ServerConfigurationException(string? message = null, Exception? innerException = null)
        : base(message ?? "Internal server error (probably configuration)", HttpStatusCode.InternalServerError, innerException)
        {
        }
    }
}