using System;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to indicate hat access to the target resource has been denied.
        ///   This happens with conditional requests on methods other than <c>GET</c> or <c>HEAD</c> when the condition
        ///   defined by the <c>If-Unmodified-Since</c> or <c>If-None-Match headers</c> is not fulfilled.
        ///   In that case, the request, usually an upload or a modification of a resource,
        ///   cannot be made and this error response is sent back. 
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
        public static ServerException PreconditionFailed(
            string? message = null, 
            Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Precondition Failed",
                HttpStatusCode.PreconditionFailed, 
                innerException);
        }
    }
}