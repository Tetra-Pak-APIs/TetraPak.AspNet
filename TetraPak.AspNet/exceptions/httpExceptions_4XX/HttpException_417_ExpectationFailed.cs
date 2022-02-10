﻿using System;
using System.Net;

namespace TetraPak.AspNet
{
    partial class HttpServerException
    {
        /// <summary>
        ///   Produces a <see cref="HttpServerException"/> to indicate that the expectation
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
        ///   A <see cref="HttpServerException"/>.
        /// </returns>
        public static HttpServerException ExpectationFailed(string? message = null, Exception? innerException = null)
        {
            return new HttpServerException(
                message ?? "Expectation Failed", 
                HttpStatusCode.ExpectationFailed, 
                innerException);
        }
    }
}