using System;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

#nullable enable

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   <para>
        ///   Produces a <see cref="ServerException"/> to indicate that the server refuses to accept the request
        ///   without a defined <c>Content-Length</c> header.
        ///   </para>
        ///   <para>
        ///   If you don't know whether this condition is temporary or permanent,
        ///   a 404 status code should be used instead.
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
        public static ServerException LengthRequired(
            string? message = null, 
            Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Length Required", 
                HttpStatusCode.LengthRequired, 
                innerException);
        }
    }
}