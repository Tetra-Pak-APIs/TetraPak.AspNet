using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

#nullable enable

namespace TetraPak.AspNet
{
    partial class ServerException
    {
        /// <summary>
        ///   Produces a <see cref="ServerException"/> to reflect a situation where
        ///   the request method is known by the server but is not supported by the target resource.
        /// </summary>
        /// <param name="allowedMethods">
        ///   A list of allowed HTTP methods.
        /// </param>
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
        public static ServerException MethodNotAllowed(
            IEnumerable<string> allowedMethods, 
            string? message = null, 
            Exception? innerException = null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            response.Headers.Add(HeaderNames.Allow, allowedMethods);
            return new ServerException(response, message ?? "Method not allowed", innerException);
        }
    }
}