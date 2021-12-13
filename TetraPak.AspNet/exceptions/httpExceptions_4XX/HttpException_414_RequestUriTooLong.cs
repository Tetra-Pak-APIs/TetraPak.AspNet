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
        ///   Produces a <see cref="ServerException"/> to indicate that the URI requested by the client is longer than
        ///   the server is willing to interpret.
        ///   </para>
        ///   <para>
        ///   There are a few rare conditions when this might occur:
        ///   </para>
        ///   <list type="bullet">
        ///     <item>
        ///     <description>
        ///     when a client has improperly converted a POST request to a GET request with long query information,
        ///     </description>
        ///     </item>
        ///     <item>
        ///     <description>
        ///     when the client has descended into a loop of redirection (for example, a redirected URI prefix that points to a suffix of itself),
        ///     </description>
        ///     </item>
        ///     <item>
        ///     <description>
        ///     or when the server is under attack by a client attempting to exploit potential security holes.
        ///     </description>
        ///     </item>
        ///   </list>
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
        public static ServerException RequestUriTooLong(
            string? message = null, 
            Exception? innerException = null)
        {
            return new ServerException(
                message ?? "Request Uri too Long", 
                HttpStatusCode.RequestUriTooLong, 
                innerException);
        }
    }
}