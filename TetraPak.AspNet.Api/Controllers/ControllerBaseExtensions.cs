using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TetraPak.AspNet.Api.Auth;
using TetraPak.Logging;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api.Controllers
{
    public static class ControllerBaseExtensions
    {
        /// <inheritdoc cref="BusinessApiController.MessageId"/>
        public static string GetMessageId(this ControllerBase self)
        {
            if (self is BusinessApiController apiController)
                return apiController.MessageId;

            return self.HttpContext.Request.GetMessageId(null);
        }

        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(this ControllerBase self)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return Task.FromResult(Outcome<ActorToken>.Fail(
                    new Exception(
                        "Cannot get access token. Failed when trying to obtain a "+
                        $" configuration ({typeof(TetraPakApiAuthConfig)})")));
                
            return self.HttpContext.Request.GetAccessTokenAsync(config);
        }

        /// <inheritdoc cref="ControllerBase.Ok()"/>
        public static OkObjectResult Ok(
            this ControllerBase self, 
            object value, 
            int totalCount = -1, 
            ReadChunk chunk = null)
        {
            var messageId = self.GetMessageId();
            if (!value.IsCollection(out _, out var items, out var count))
                return self.Ok(value is null
                    ? ApiDataResponse<object>.Empty(messageId)
                    : new ApiDataResponse<object>(new[] {value}));
            
            totalCount = totalCount < 0 ? count : totalCount;
            var array = items.EnumerableToArray();
            return self.Ok(new ApiDataResponse<object>(
                array,
                chunk?.Skip ?? -1, 
                totalCount,
                messageId));

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
            var config = self.GetTetraPakApiAuthConfig();
            
            // error message might already be a standard error response json object 
            var parseOutcome = tryParseTetraPakErrorResponse(error.Message);
            var errorResponse = parseOutcome
                ? parseOutcome.Value
                : new ApiErrorResponse(error.Message, self.HttpContext.Request.GetMessageId(config))
                {
                    Status = ((int) status).ToString()
                };
            
            return self.StatusCode(
                (int) status,
                errorResponse);
        }
        
        public static void LogTrace(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Trace(message, messageId);
        }

        public static void LogDebug(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Debug(message, messageId);
        }

        public static void LogInformation(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Information(message, messageId);
        }

        public static void LogWarning(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Warning(message, messageId);
        }

        public static void LogError(this ControllerBase self, Exception exception, string message = null, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Error(exception, message, messageId);
        }

        public static bool TryGetTetraPakApiAuthConfig(this ControllerBase self, out TetraPakApiAuthConfig config)
        {
            config = self.HttpContext.RequestServices.GetService<TetraPakApiAuthConfig>();
            return config is {};
        }
        
        public static TetraPakApiAuthConfig GetTetraPakApiAuthConfig(this ControllerBase self)
        {
            if (self.TryGetTetraPakApiAuthConfig(out var config))
                return config;

            if (self is BusinessApiController apiController)
                return apiController.GetConfig();
                
            throw new Exception($"Could not retrieve a {typeof(TetraPakApiAuthConfig)} instance");
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