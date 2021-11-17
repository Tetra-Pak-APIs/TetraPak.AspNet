using System;
using System.Net;

#nullable enable

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to reflect a situation where resource(s) was not found.
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
        public static ServerException NotFound(string? message = null, Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Not Found", 
                HttpStatusCode.NotFound, 
                innerException);
        }
    }
}