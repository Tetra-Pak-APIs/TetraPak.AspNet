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
        ///   Produces a <see cref="ServerException"/> to indicate that the server refuses to accept the request because
        ///   the payload format is in an unsupported format.
        ///   </para>
        ///   <para>
        ///   The format problem might be due to the request's indicated <c>Content-Type</c> or <c>Content-Encoding</c>,
        ///   or as a result of inspecting the data directly. 
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
        public static ServerException UnsupportedMediaType(
            string? message = null, 
            Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Unsupported Media Type", 
                HttpStatusCode.UnsupportedMediaType, 
                innerException);
        }
    }
}