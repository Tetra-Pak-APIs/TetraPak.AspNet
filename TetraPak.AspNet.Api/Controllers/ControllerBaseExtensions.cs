using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TetraPak.AspNet.Api.Auth;
using TetraPak.Logging;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api.Controllers
{
    public static class ControllerBaseExtensions
    {
        static readonly Dictionary<ControllerBase, TetraPakApiAuthConfig> s_configs = new();
        
        public static void Configure(this ControllerBase self, TetraPakApiAuthConfig config, bool replace = false)
        {
            if (s_configs.ContainsKey(self) && !replace)
                throw new InvalidOperationException("Controller was already configured");

            s_configs[self] = config;
        }

        /// <inheritdoc cref="ControllerBase.Ok()"/>
        public static OkObjectResult Ok(this ControllerBase self, object value, string messageId = null)
        {
            return self.Ok(value is null 
                ? ApiDataResponse<object>.Empty(messageId) 
                : new ApiDataResponse<object>(new[] { value } ));
        }
        
        public static OkObjectResult Ok<T>(this ControllerBase self, EnumOutcome<T> outcome, int totalCount = -1)
        {
            return self.Ok(new ApiDataResponse<T>(outcome, totalCount));
        }
        
        public static ActionResult ErrorExpectedQueryParameter(this ControllerBase self, string queryParameterName, string example = null)
        {
            var body = !string.IsNullOrWhiteSpace(example) 
                ? new {messages = new [] { $"Expected query parameter: '{queryParameterName}' (example: {example})" }} 
                : new {messages = new [] { $"Expected query parameter: '{queryParameterName}'" }};
            return self.Error(HttpStatusCode.BadRequest, new Exception(body.ToJson()));
        }
        
        public static ActionResult UnauthorizedError(this ControllerBase self, Exception error)
        {
            return self.Error(HttpStatusCode.Unauthorized, error);
        }
        
        public static ActionResult InternalServerError(this ControllerBase self, Exception error)
        {
            return self.Error(HttpStatusCode.InternalServerError, error);
        }
        
        public static ActionResult Error(this ControllerBase self, HttpStatusCode status, Exception error)
        {
            var config = self.GetTetraPakConfiguration();
            
            // error message might already be a standard error response json object 
            var parseOutcome = tryParseTetraPakErrorResponse(error.Message);
            var errorResponse = parseOutcome
                ? parseOutcome.Value
                : new ApiErrorResponse(error.Message, self.HttpContext, config)
                {
                    Status = ((int) status).ToString()
                };
            
            return self.StatusCode(
                (int) status,
                errorResponse);
        }
        
        public static void LogTrace(this ControllerBase self, string message, string referenceId = null)
        {
            if (!self.TryGetTetraPakConfiguration(out var config))
                return;
            
            config.Logger.Trace(message, referenceId);
        }

        public static void LogDebug(this ControllerBase self, string message, string referenceId = null)
        {
            if (!self.TryGetTetraPakConfiguration(out var config))
                return;
            
            config.Logger.Debug(message, referenceId);
        }

        public static void LogInformation(this ControllerBase self, string message, string referenceId = null)
        {
            if (!self.TryGetTetraPakConfiguration(out var config))
                return;
            
            config.Logger.Information(message, referenceId);
        }

        public static void LogWarning(this ControllerBase self, string message, string referenceId = null)
        {
            if (!self.TryGetTetraPakConfiguration(out var config))
                return;
            
            config.Logger.Warning(message, referenceId);
        }

        public static void LogError(this ControllerBase self, Exception exception, string message = null, string referenceId = null)
        {
            if (!self.TryGetTetraPakConfiguration(out var config))
                return;
            
            config.Logger.Error(exception, message, referenceId);
        }

        public static bool TryGetTetraPakConfiguration(this ControllerBase self, out TetraPakApiAuthConfig config)
        {
            return s_configs.TryGetValue(self, out config);
        }
        
        public static TetraPakApiAuthConfig GetTetraPakConfiguration(this ControllerBase self)
        {
            if (self.TryGetTetraPakConfiguration(out var config))
                return config;

            if (self is BusinessApiController apiController)
                return apiController.AuthConfig;
                
            throw new InvalidOperationException($"Controller is not configured: {self}");
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
    }
}