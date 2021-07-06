using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Api.Auth;
using TetraPak.DynamicEntities;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Controllers
{
    public class BusinessApiController : ControllerBase
    {
        public TetraPakApiAuthConfig Config { get; }

        protected ILogger Logger => Config.Logger;

        public AuthenticationHeaderValue AuthenticationHeaderValue =>
            AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out var authHeader)
                ? authHeader
                : null;

        /// <summary>
        ///   Gets a message id for the request. 
        /// </summary>
        public string MessageId => HttpContext.Request.GetMessageId(Config);

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
            {
                return StatusCode(
                    (int) httpException.StatusCode, 
                    new ApiErrorResponse(error.Message, HttpContext.Request.GetMessageId(Config)));
            }

            return InternalServerError(error);
        }

        protected virtual ActionResult OnError(HttpStatusCode status, Exception error) => this.Error(status, error);

        protected async Task<ActionResult> OutcomeResultAsync<T>(Outcome<T> outcome, StringResponseDelegate responseDelegate = null)
        {
            if (!outcome)
                return Error(outcome.Exception);

            var value = outcome.Value;
            if (value is not HttpResponseMessage responseMessage) 
                return Ok(outcome.Value);

            var content = await responseMessage.Content.ReadAsStringAsync();
            try
            {
                if (responseDelegate is { })
                {
                    var delegateOutcome = await responseDelegate(content);
                    if (!delegateOutcome)
                        return Error(delegateOutcome.Exception);

                    content = delegateOutcome.Value;
                }

                object objects = content.Trim().StartsWith('[')
                    ? JsonSerializer.Deserialize<DynamicEntity[]>(content)
                    : JsonSerializer.Deserialize<DynamicEntity>(content);
                
                return Ok(objects);
            }
            catch
            {
                return Error(new SerializationException($"Failed when deserializing JSON data"));

            }
        }

        protected async Task<ActionResult> OutcomeResultAsync<T>(Outcome<T> outcome, StreamResponseDelegate responseDelegate)
        {
            if (!outcome)
                return Error(outcome.Exception);

            var value = outcome.Value;
            if (value is not HttpResponseMessage responseMessage) 
                return Ok(outcome.Value);
            
            var streamOutcome = await responseDelegate(responseMessage);
            if (!streamOutcome)
                return Error(streamOutcome.Exception);

            var stream = streamOutcome.Value;
            try
            {
                var objects = await JsonSerializer.DeserializeAsync<JsonDocument>(stream);
                return Ok(objects);
            }
            catch
            {
                return Error(new SerializationException($"Failed when deserializing JSON data"));
            }
        }

        protected virtual async Task<Outcome<Stream>> OnGetResponseStreamAsync(HttpResponseMessage responseMessage)
        {
            try
            {
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return Outcome<Stream>.Success(stream);
            }
            catch (Exception ex)
            {
                return Outcome<Stream>.Fail(ex);
            }
        }
        
        protected OkObjectResult Ok<T>(EnumOutcome<T> outcome, int totalCount = -1)
        {
            return this.Ok(outcome, totalCount, HttpContext.Request.GetMessageId(Config));
        }

        public override OkObjectResult Ok(object value)
        {
            if (value is null)
                return base.Ok(ApiDataResponse<object>.Empty(MessageId));

            return value.GetType().IsGenericBase(typeof(ApiDataResponse<>)) 
                ? base.Ok(value) 
                : ControllerBaseExtensions.Ok(this, value);
        }

        protected static string DictionaryLogString(IDictionary<string, string> formDictionary, string indent = "  ")
        {
            return formDictionary.ConcatDictionary($"\n{indent}");
        }
        
        public BusinessApiController(TetraPakApiAuthConfig config)
        {
            Config = config;
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

    public delegate Task<Outcome<string>> StringResponseDelegate(string data);
    public delegate Task<Outcome<Stream>> StreamResponseDelegate(HttpResponseMessage responseMessage);
}