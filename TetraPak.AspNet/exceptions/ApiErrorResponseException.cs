using System;

namespace TetraPak.AspNet
{
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