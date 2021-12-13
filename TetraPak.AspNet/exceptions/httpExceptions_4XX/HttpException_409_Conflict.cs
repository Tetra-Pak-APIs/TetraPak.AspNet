using System;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to indicate a request conflict with
        ///   current state of the target resource.
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
        public static ServerException Conflict(
            string? message = null, 
            Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Conflict", 
                HttpStatusCode.Conflict, 
                innerException);
        }
    }
}