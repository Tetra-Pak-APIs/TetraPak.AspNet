using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        protected AmbientData AmbientData { get; }

        protected TetraPakApiAuthConfig Config => (TetraPakApiAuthConfig) AmbientData.AuthConfig;

        protected ILogger Logger => Config.Logger;

        public AuthenticationHeaderValue AuthenticationHeaderValue =>
            AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out var authHeader)
                ? authHeader
                : null;

        /// <summary>
        ///   Gets a message id for the request. 
        /// </summary>
        public string MessageId => HttpContext.Request.GetMessageId(Config);

        internal TetraPakApiAuthConfig GetConfig() => Config;

        protected Task<Outcome<ActorToken>> GetAccessTokenAsync() => ControllerBaseExtensions.GetAccessTokenAsync(this);

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

        /// <summary>
        ///   Transforms an <see cref="Outcome"/> to an <see cref="ActionResult"/> response,
        ///   including errors, in a format adhering to Tetra Pak's business API guidelines. 
        /// </summary>
        /// <param name="outcome">
        ///   The outcome to be transformed into an <see cref="ActionResult"/>. 
        /// </param>
        /// <param name="responseDelegate">
        ///   (optional)<br/>
        ///   A <see cref="ResponseDelegate{T}"/> to be called before transforming the value/error into a
        ///   correctly formed <see cref="ActionResult"/> response (see remarks).
        /// </param>
        /// <typeparam name="T">
        ///   The type of value expected by the <paramref name="outcome"/>.
        /// </typeparam>
        /// <returns>
        ///   An <see cref="ActionResult"/> instance.
        /// </returns>
        /// <remarks>
        ///   The <paramref name="responseDelegate"/> should be expected to handle these three types of values,
        ///   passed in via its "data" parameter:
        ///   <list> 
        ///   <item>
        ///     <term>
        ///     object
        ///     </term>
        ///     <description>
        ///     Any value carried by the <paramref name="outcome"/> when the outcome type is not a <see cref="HttpResponseMessage"/>. 
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///     <see cref="HttpResponseMessage"/>
        ///     </term>
        ///     <description>
        ///     The raw response message carried by the <paramref name="outcome"/>. The delegate is responsible for
        ///     downloading the response message content and transform it into  
        ///     </description>
        ///   </item>
        ///   </list>
        /// </remarks>
        protected async Task<ActionResult> RespondAsync<T>(
            Outcome<T> outcome, 
            ResponseDelegate<T> responseDelegate = null)
        {
            if (!outcome)
                return Error(outcome.Exception);
            
            if (responseDelegate is {})
            {
                try
                {
                    var delegateOutcome = await responseDelegate(outcome.Value);
                    return !delegateOutcome ? Error(delegateOutcome.Exception) : Ok(delegateOutcome.Value);
                }
                catch (Exception ex)
                {
                    return Error(ex);
                }
            }

            if (outcome.Value is not HttpResponseMessage responseMessage) 
                return Ok(outcome.Value);
            
            var stringValue = await responseMessage.Content.ReadAsStringAsync();
            var entityOutcome = stringValue.TryParseJsonToDynamicEntity();
            return Ok(entityOutcome
                ? entityOutcome.Value
                : stringValue);
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
        
        public BusinessApiController(AmbientData ambientData)
        {
            AmbientData = ambientData;
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

    public delegate Task<Outcome<T>> ResponseDelegate<T>(object data);
}