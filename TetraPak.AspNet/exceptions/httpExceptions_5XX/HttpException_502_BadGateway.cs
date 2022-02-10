using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class HttpServerException
    {
        /// <summary>
        ///   Produces a <see cref="HttpServerException"/> to indicate that the server, while acting as a gateway or proxy,
        ///   received an invalid response from the upstream server.
        /// </summary>
        /// <param name="message">
        ///   (optional)<br/>
        ///   Describes the problem.
        /// </param>
        /// <param name="innerException">
        ///   (optional)<br/>
        ///   The exception that is the cause of the current exception.
        /// </param>
        /// <returns>
        ///   A <see cref="HttpServerException"/>.
        /// </returns>
        public static HttpServerException BadGateway(string? message = null, Exception? innerException = null)
        {
            return new HttpServerException(
                message ?? "Bad Gateway", 
                HttpStatusCode.BadGateway, 
                innerException);
        }
    }
}