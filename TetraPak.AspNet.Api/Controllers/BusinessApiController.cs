using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Api.Auth;
using TetraPak.Logging;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api.Controllers
{
    public class BusinessApiController : ControllerBase
    {
        public TetraPakApiAuthConfig AuthConfig { get; }

        protected ILogger Logger => AuthConfig.Logger;

        public AuthenticationHeaderValue AuthenticationHeaderValue =>
            AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out var authHeader)
                ? authHeader
                : null;

        protected ActionResult ErrorExpectedQueryParameter(string queryParameterName, string example = null)
        {
            var body = !string.IsNullOrWhiteSpace(example) 
                ? new {messages = new [] { $"Expected query parameter: '{queryParameterName}' (example: {example})" }} 
                : new {messages = new [] { $"Expected query parameter: '{queryParameterName}'" }};
            return OnError(HttpStatusCode.BadRequest, new Exception(body.ToJson()));
            // return BadRequest(!string.IsNullOrWhiteSpace(example) obsolete
            //     ? new {messages = new [] { $"Expected query parameter: '{queryParameterName}' (example: {example})" }} 
            //     : new {messages = new [] { $"Expected query parameter: '{queryParameterName}'" }});
        }

        protected ActionResult UnauthorizedError(Exception error)
        {
            return OnError(HttpStatusCode.Unauthorized, error);
        }

        protected ActionResult InternalServerError(Exception error)
        {
            return OnError(HttpStatusCode.InternalServerError, error);
        }

        protected virtual ActionResult OnError(HttpStatusCode status, Exception error)
        {
            // error message might already be a standard error response json object
            var parseOutcome = tryParseTetraPakErrorResponse(error.Message);
            var options = new DictionaryTransformationOptions { IgnoreNullValues = true };
            var errorResponse = parseOutcome
                ? parseOutcome.Value
                : new ApiErrorResponse(error.Message, HttpContext, AuthConfig)
                {
                    Status = ((int) status).ToString()
                };
            
            return StatusCode(
                (int) status,
                errorResponse.ToDictionary(options));
        }
        
        static Outcome<ApiErrorResponse> tryParseTetraPakErrorResponse(string s)
        {
            // error might already be a Tetra Pak error response, in which case we'll just pass it along
            s = s.Trim();
            if (!s.StartsWith("{"))
                return Outcome<ApiErrorResponse>.Fail();

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return Outcome<ApiErrorResponse>.Success(JsonSerializer.Deserialize<ApiErrorResponse>(s, options));
            }
            catch (Exception ex)
            {
                return Outcome<ApiErrorResponse>.Fail(ex);
            }
        }

        protected static string DictionaryLogString(IDictionary<string, string> formDictionary, string indent = "  ")
        {
            return formDictionary.ConcatDictionary($"\n{indent}");
        }

        protected BusinessApiController(TetraPakApiAuthConfig authConfig)
        {
            AuthConfig = authConfig;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
            if (string.IsNullOrEmpty(environment))
            {
                environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT", EnvironmentVariableTarget.Process);
            }

            if (string.IsNullOrEmpty(environment))
            {
                environment = "Production";
            }
            Logger.Debug($"Initializing controller: {GetType()} (environment={environment})");
        }

    }
}