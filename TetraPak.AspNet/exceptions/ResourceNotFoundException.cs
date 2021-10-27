#nullable enable
using System;
using System.Net;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Represents an issue where a requested resource was not found.
    /// </summary>
    public class ResourceNotFoundException : HttpException
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ResourceNotFoundException"/> class with a specified
        ///   error message and (optionally) a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">
        ///   The error message that explains the reason for the exception.
        /// </param>
        /// <param name="inner">
        ///   (optional)<br/>
        ///   The exception that is the cause of the current exception.
        /// </param>
        public ResourceNotFoundException(string message, Exception? inner = null) 
        : base(HttpStatusCode.NotFound, message, inner)
        {
        }
    }
}