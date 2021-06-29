using System;
using System.Net;
using System.Net.Http;

namespace TetraPak.AspNet
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode => Response.StatusCode;
        
        public HttpResponseMessage Response { get; }
        
        public HttpException(
            HttpResponseMessage response, 
            string message = null,
            Exception innerException = null)
        : base(string.IsNullOrEmpty(message) ? response.ReasonPhrase : message, innerException)
        {
            Response = response;
        }
    }
}