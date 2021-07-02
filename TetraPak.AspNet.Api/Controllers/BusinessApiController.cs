using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Api.Auth;
using TetraPak.Logging;

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
            return ControllerBaseExtensions.ErrorExpectedQueryParameter(this, queryParameterName, example);
        }

        protected ActionResult UnauthorizedError(Exception error)
        {
            return OnError(HttpStatusCode.Unauthorized, error);
        }

        protected ActionResult InternalServerError(Exception error)
        {
            return OnError(HttpStatusCode.InternalServerError, error);
        }

        protected ActionResult Error(Exception error)
        {
            if (error is HttpException httpException)
                return StatusCode(
                    (int) httpException.StatusCode, 
                    new ApiErrorResponse(error.Message, HttpContext, AuthConfig));

            return InternalServerError(error);
        }

        protected virtual ActionResult OnError(HttpStatusCode status, Exception error) => this.Error(status, error);

        protected async Task<ActionResult> OutcomeResultAsync<T>(Outcome<T> outcome)
        {
            if (!outcome)
                return Error(outcome.Exception);

            var value = outcome.Value;
            if (value is not HttpResponseMessage responseMessage) 
                return Ok(outcome.Value);
            
            var content = await responseMessage.Content.ReadAsStringAsync();
            try
            {
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
                return Ok(dictionary);
            }
            catch (Exception ex)
            {
                return Ok(content);
            }
        }

        protected OkObjectResult Ok<T>(EnumOutcome<T> outcome, int totalCount = -1)
        {
            return ControllerBaseExtensions.Ok(this, outcome, totalCount);
        }

        public override OkObjectResult Ok(object value)
        {
            if (value is null)
                return base.Ok(ApiDataResponse<object>.Empty());

            return value.GetType().IsGenericBase(typeof(ApiDataResponse<>)) 
                ? base.Ok(value) 
                : ControllerBaseExtensions.Ok(this, value);
        }

        protected static string DictionaryLogString(IDictionary<string, string> formDictionary, string indent = "  ")
        {
            return formDictionary.ConcatDictionary($"\n{indent}");
        }
        
        public BusinessApiController(TetraPakApiAuthConfig authConfig)
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