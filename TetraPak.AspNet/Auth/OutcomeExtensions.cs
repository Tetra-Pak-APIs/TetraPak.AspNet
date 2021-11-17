using System.Net;

namespace TetraPak.AspNet.Auth
{
    public static class OutcomeExtensions
    {
        public static bool IsUnauthorized(this Outcome outcome) 
            => outcome.Exception is ServerException
            {
                StatusCode: HttpStatusCode.Unauthorized
            };
    }
}