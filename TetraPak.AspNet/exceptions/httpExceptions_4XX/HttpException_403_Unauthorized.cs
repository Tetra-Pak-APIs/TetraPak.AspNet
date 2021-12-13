using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to reflect that
        ///   the actor does not have access to the requested resource(s).
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
        public static ServerException Forbidden(string? message = null, Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Forbidden",
                HttpStatusCode.Forbidden, 
                innerException);
        }
    }
}