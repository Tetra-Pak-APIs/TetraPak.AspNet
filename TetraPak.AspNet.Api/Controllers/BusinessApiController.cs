using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
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

        protected virtual ActionResult OnError(HttpStatusCode status, Exception error) => this.Error(status, error);

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