using System;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Reflects a <see cref="ApiErrorResponse"/> as an exception.
    /// </summary>
    public class ApiErrorResponseException : Exception 
    {
        /// <summary>
        ///   The error response containing the <see cref="ApiErrorResponse"/>.
        /// </summary>
        ApiErrorResponse ErrorResponse { get; }
        
        /// <inheritdoc cref="ApiErrorResponse.Title"/>
        public string Title => ErrorResponse.Title;

        /// <inheritdoc cref="ApiErrorResponse.MessageId"/>
        public string? MessageId => ErrorResponse.MessageId;

        /// <inheritdoc cref="ApiErrorResponse.Status"/>
        public string Status => ErrorResponse.Status;

        /// <inheritdoc cref="ApiErrorResponse.StatusCode"/>
        public int StatusCode => ErrorResponse.StatusCode;
    
        internal ApiErrorResponseException(ApiErrorResponse apiErrorResponse)
        {
            ErrorResponse = apiErrorResponse;
        }
    }
}