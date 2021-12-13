using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to indicate that the server is not able to produce a response.
        ///   This can be sent by a server that is not configured to produce responses for the combination of scheme
        ///   and authority that are included in the request URI.
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
        public static ServerException MisdirectedRequest(string? message = null, Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Misdirected Request", 
                HttpStatusCode.MisdirectedRequest, 
                innerException);
        }
    }
}