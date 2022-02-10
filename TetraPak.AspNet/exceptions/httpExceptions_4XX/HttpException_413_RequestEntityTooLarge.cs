﻿using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

namespace TetraPak.AspNet
{
    partial class HttpServerException
    {
        /// <summary>
        ///   Produces a <see cref="HttpServerException"/> to indicate that the request entity is larger than limits
        ///   defined by server; the server might close the connection or return a <c>Retry-After</c> header field.
        /// </summary>
        /// <param name="closeConnection">
        ///   Specifies whether to also send back a <c>Connection: close</c> header to client.
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
        ///   A <see cref="HttpServerException"/>.
        /// </returns>
        /// <seealso cref="RequestEntityTooLarge(TimeSpan,string?,Exception?)"/>
        /// <seealso cref="RequestEntityTooLarge(DateTime,string?,Exception?)"/>
        public static HttpServerException RequestEntityTooLarge(
            bool closeConnection,
            string? message = null, 
            Exception? innerException = null)
        {
            if (!closeConnection)
                return new HttpServerException(
                    message ?? "Request Entity Too Large", 
                    HttpStatusCode.RequestEntityTooLarge,
                    innerException);
                
            var response = new HttpResponseMessage(HttpStatusCode.RequestEntityTooLarge);
            response.Headers.Add(HeaderNames.Connection, "close");
            return new HttpServerException(makeResponseMessage(closeConnection));
        }

        /// <summary>
        ///   Produces a <see cref="HttpServerException"/> to indicate that the request entity is larger than limits
        ///   defined by server; the server might close the connection or return a <c>Retry-After</c> header field.
        /// </summary>
        /// <param name="retryAfter">
        ///   Specifies a timespan to be sent back with the <c>Retry-After</c> header.
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
        ///   A <see cref="HttpServerException"/>.
        /// </returns>        
        /// <seealso cref="RequestEntityTooLarge(bool,string?,Exception?)"/>
        /// <seealso cref="RequestEntityTooLarge(DateTime,string?,Exception?)"/>
        public static HttpServerException RequestEntityTooLarge(
            TimeSpan retryAfter,
            string? message = null, 
            Exception? innerException = null)
        {
            var response = makeResponseMessage(false);
            response.Headers.Add(
                HeaderNames.RetryAfter,  
                Math.Truncate(retryAfter.TotalSeconds).ToString(CultureInfo.InvariantCulture));
            return new HttpServerException(response, message, innerException);
        }

        /// <summary>
        ///   Produces a <see cref="HttpServerException"/> to indicate that the request entity is larger than limits
        ///   defined by server; the server might close the connection or return a <c>Retry-After</c> header field.
        /// </summary>
        /// <param name="retryAfter">
        ///   Specifies a date/time to be sent back with the <c>Retry-After</c> header.
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
        ///   A <see cref="HttpServerException"/>.
        /// </returns>        
        /// <seealso cref="RequestEntityTooLarge(bool,string?,Exception?)"/>
        /// <seealso cref="RequestEntityTooLarge(TimeSpan,string?,Exception?)"/>
        public static HttpServerException RequestEntityTooLarge(
            DateTime retryAfter,
            string? message = null, 
            Exception? innerException = null)
        {
            var response = makeResponseMessage(false);
            response.Headers.Add(
                HeaderNames.RetryAfter,  
                    retryAfter.ToUniversalTime().ToString("R"));
            return new HttpServerException(response, message, innerException);
        }

        static HttpResponseMessage makeResponseMessage(bool closeConnection)
        {
            var response = new HttpResponseMessage(HttpStatusCode.RequestEntityTooLarge);
            if (closeConnection)
            {
                response.Headers.Add(HeaderNames.Connection, "close");
            }
            return response;
        }
    }
}