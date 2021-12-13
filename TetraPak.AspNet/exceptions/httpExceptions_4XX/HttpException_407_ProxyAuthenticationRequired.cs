using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to reflect a situation where
        ///   the server cannot or is unwilling to produce a response matching the request's list of acceptable
        ///   values, as defined in the content negotiation headers (Accept, Accept-Encoding, Accept-Language).
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
        public static ServerException ProxyAuthenticationRequired(
            string? message = null, 
            Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Proxy Authentication Required", 
                HttpStatusCode.ProxyAuthenticationRequired, 
                innerException);
        }
    }
}