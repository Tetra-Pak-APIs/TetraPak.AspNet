using System;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   <para>
        ///   Produces a <see cref="ServerException"/> to indicate that the server requires the request to be conditional.
        ///   </para>
        ///   <para>
        ///   Typically, this means that a required precondition header, such as <c>If-Match</c>, is missing.
        ///   </para>
        ///   <para>
        ///   When a precondition header is not matching the server side state,
        ///   the response should be <c>412 Precondition Failed</c>. 
        ///   </para>
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
        public static ServerException PreconditionRequired(
            string? message = null, 
            Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Precondition Required", 
                HttpStatusCode.PreconditionRequired, 
                innerException);
        }
    }
}