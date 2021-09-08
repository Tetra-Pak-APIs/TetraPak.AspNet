using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace TetraPak.AspNet
{
    [DebuggerDisplay("{ToString()}")]
    public class HttpException : Exception
    {
        readonly HttpStatusCode? _statusCode;
        
        public HttpStatusCode StatusCode => _statusCode ?? Response.StatusCode;
        
        public HttpResponseMessage Response { get; }

        public override string ToString() => $"{((int)StatusCode).ToString()} ({StatusCode}) {base.ToString()}";

        public HttpException(HttpStatusCode statusCode, string message = null, Exception innerException = null)
        : base(message, innerException)
        {
            _statusCode = statusCode;
        }
        
        public HttpException(
            HttpResponseMessage response, 
            string message = null,
            Exception innerException = null)
        : base(string.IsNullOrEmpty(message) ? response.ReasonPhrase : message, innerException)
        {
            Response = response;
        }
    }
    
    public class ApiErrorResponseException : Exception 
    {
        public ApiErrorResponse ErrorResponse { get; }
        
        public string Title => ErrorResponse.Title;

        public string MessageId => ErrorResponse.MessageId;

        public string Status => ErrorResponse.Status;

        public int StatusCode => ErrorResponse.StatusCode;
    
        public ApiErrorResponseException(ApiErrorResponse apiErrorResponse)
        {
            ErrorResponse = apiErrorResponse;
        }
    }
}