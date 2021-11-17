using System;
using System.Net;

#nullable enable

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to indicate that the server understands the content type of the
        ///   request entity, and the syntax of the request entity is correct,
        ///   but it was unable to process the contained instructions. 
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
        public static ServerException UnprocessableEntity(string? message = null, Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Unprocessable Entity", 
                HttpStatusCode.UnprocessableEntity, 
                innerException);
        }
    }
}