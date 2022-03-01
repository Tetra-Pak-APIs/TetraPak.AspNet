﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   An exception that codifies the issue using a standard HTTP status code.
    ///   Very suitable for many server related exceptions.
    ///   (see: <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status">list of HTTP status codes</a>).
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public partial class HttpServerException : Exception
    {
        readonly HttpStatusCode? _statusCode;
        
        /// <summary>
        ///   Gets the HTTP status code
        ///   (see: <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status">list of HTTP status codes</a>).
        /// </summary>
        public HttpStatusCode StatusCode => _statusCode ?? Response!.StatusCode;
        
        /// <summary>
        ///   A <see cref="HttpResponseMessage"/>. This value might not have been assigned.
        /// </summary>
        public HttpResponseMessage? Response { get; }

        /// <inheritdoc />
        public override string ToString() => $"{((int)StatusCode).ToString()} ({StatusCode}) {base.ToString()}";

        /// <summary>
        ///   Initializes the <see cref="HttpServerException"/> with a <see cref="HttpStatusCode"/>.
        /// </summary>
        /// <param name="statusCode">
        ///   The <see cref="HttpStatusCode"/> to be assigned.
        /// </param>
        /// <param name="message">
        ///   (optional)<br/>
        ///   An error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        ///   (optional)<br/>
        ///   The exception that is the cause of the current exception.
        /// </param>
        internal HttpServerException(string message, HttpStatusCode statusCode, Exception? innerException = null)
            : base(message, innerException)
        {
            _statusCode = statusCode;
        }

        /// <summary>
        ///   Initializes the <see cref="HttpServerException"/> with a <see cref="HttpStatusCode"/>.
        /// </summary>
        /// <param name="statusCode">
        ///   The <see cref="HttpStatusCode"/> to be assigned.
        /// </param>
        /// <param name="innerException">
        ///   (optional)<br/>
        ///   The exception that is the cause of the current exception.
        /// </param>
        internal HttpServerException(HttpStatusCode statusCode, Exception? innerException = null)
        : base(null, innerException)
        {
            _statusCode = statusCode;
        }
        
        /// <summary>
        ///   Initializes the <see cref="HttpServerException"/> with a <see cref="HttpResponseMessage"/>.
        ///   Please note that this also assigns the <see cref="StatusCode"/>.
        /// </summary>
        /// <param name="response">
        ///   The <see cref="HttpResponseMessage"/> to be assigned. 
        /// </param>
        /// <param name="message">
        ///   (optional)<br/>
        ///   An error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        ///   (optional)<br/>
        ///   The exception that is the cause of the current exception.
        /// </param>
        public HttpServerException(
            HttpResponseMessage response, 
            string? message = null,
            Exception? innerException = null)
        : base(string.IsNullOrEmpty(message) ? response.ReasonPhrase : message, innerException)
        {
            Response = response;
        }
    }
}