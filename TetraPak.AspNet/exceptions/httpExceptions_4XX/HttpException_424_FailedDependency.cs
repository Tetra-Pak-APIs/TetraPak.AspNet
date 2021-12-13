using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to indicate that the request failed
        ///   due to failure of a previous request.
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
        public static ServerException FailedDependency(string? message = null, Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Failed Dependency", 
                HttpStatusCode.FailedDependency, 
                innerException);
        }
    }
}