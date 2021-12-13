using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to indicate that the server, while acting as a gateway or proxy,
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
        ///   A <see cref="ServerException"/>.
        /// </returns>
        public static ServerException BadGateway(string? message = null, Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Bad Gateway", 
                HttpStatusCode.BadGateway, 
                innerException);
        }
    }
}