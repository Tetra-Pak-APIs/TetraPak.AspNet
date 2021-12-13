using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to indicate that the expectation
        ///   given in the request's <c>Expect</c> header could not be met.
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
        public static ServerException ExpectationFailed(string? message = null, Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Expectation Failed", 
                HttpStatusCode.ExpectationFailed, 
                innerException);
        }
    }
}