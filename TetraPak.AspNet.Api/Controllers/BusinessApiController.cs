using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

#nullable enable

namespace TetraPak.AspNet.Api.Controllers
{
    /// <summary>
    ///   Business controller to provide convenient Tetra Pak integration.
    ///   Most of the properties and methods found in this class are also available
    ///   as extension methods of <see cref="ControllerBase"/> so deriving from this class
    ///   is mainly a matter of style and convenience. 
    /// </summary>
    public class BusinessApiController : ControllerBase
    {
        /// <summary>
        ///   Gets the ambient data object. 
        /// </summary>
        protected AmbientData? AmbientData => TetraPakConfig?.AmbientData;

        /// <summary>
        ///   Gets the Tetra Pak integration configuration.
        /// </summary>
        protected TetraPakConfig? TetraPakConfig { get; }

        /// <summary>
        ///   Gets a logger provider.
        /// </summary>
        protected ILogger? Logger => TetraPakConfig?.Logger;

        // public AuthenticationHeaderValue? AuthenticationHeaderValue => obsolete
        //     AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out var authHeader)
        //         ? authHeader
        //         : null;

        // internal void SetAmbientData(AmbientData ambientData) obsolete
        // {
        //     // AmbientData = ambientData;
        //     var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
        //     if (string.IsNullOrEmpty(environment))
        //     {
        //         environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT", EnvironmentVariableTarget.Process);
        //     }
        //
        //     if (string.IsNullOrEmpty(environment))
        //     {
        //         environment = "Production";
        //     }
        //     Logger.Debug($"Initializing controller: {GetType()} (environment={environment})");
        // }

        /// <inheritdoc cref="ControllerBaseExtensions.GetMessageId"/>
        public string? MessageId => HttpContext.Request.GetMessageId(TetraPakConfig);

        internal TetraPakConfig? GetConfig() => TetraPakConfig;

        /// <summary>
        ///   Gets the request access token. 
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected Task<Outcome<ActorToken>> GetAccessTokenAsync() => ControllerBaseExtensions.GetAccessTokenAsync(this);

        /// <summary>
        ///   Responds with standard error format reflecting an issue with query parameters. 
        /// </summary>
        /// <param name="queryParameterName">
        ///   The name of the query parameter causing the issue.
        /// </param>
        /// <param name="example">
        ///   (optional)<br/>
        ///   An example for expected parameter use/format.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/>.
        /// </returns>
        protected ActionResult RespondErrorExpectedQueryParameter(string queryParameterName, string? example = null)
        {
            return ControllerBaseExtensions.RespondExpectedQueryParameterError(this, queryParameterName, example);
        }

        /// <summary>
        ///   Responds with standard error format reflecting an unauthorized request issue. 
        /// </summary>
        /// <param name="error">
        ///   The exception causing the issue.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/>.
        /// </returns>
        protected ActionResult RespondUnauthorizedError(Exception error)
        {
            return OnRespondError(HttpStatusCode.Unauthorized, error);
        }

        /// <summary>
        ///   Responds with standard error format reflecting a unexpected/unhandled technical issue. 
        /// </summary>
        /// <param name="error">
        ///   The exception causing the issue.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/>.
        /// </returns>
        protected ActionResult RespondInternalServerError(Exception error)
        {
            return OnRespondError(HttpStatusCode.InternalServerError, error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        protected ActionResult RespondError(Exception error)
        {
            if (error is HttpException httpException)
            {
                return StatusCode(
                    (int) httpException.StatusCode, 
                    new ApiErrorResponse(error.Message, HttpContext.Request.GetMessageId(TetraPakConfig)));
            }

            return RespondInternalServerError(error);
        }

        /// <summary>
        ///   [virtual method]<br/>
        ///   Invoked automatically by other methods to respond with an error.
        ///   The default implementation simply invokes <see cref="RespondError"/>.  
        /// </summary>
        /// <param name="status">
        ///   The <see cref="HttpStatusCode"/> to be returned to client.
        /// </param>
        /// <param name="error">
        ///   The causing exception.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/>.
        /// </returns>
        protected virtual ActionResult OnRespondError(HttpStatusCode status, Exception error) => this.RespondError(status, error);

        /// <summary>
        ///   Please see <see cref="ControllerBaseExtensions.RespondAsync{T}"/>
        /// </summary>
        protected Task<ActionResult> RespondAsync<T>(
            Outcome<T> outcome,
            int totalCount = -1,
            ReadChunk? chunk = null, 
            ResponseDelegate<T>? responseDelegate = null)
        {
            return ControllerBaseExtensions.RespondAsync(this, outcome, totalCount, chunk, responseDelegate);
            
            // if (!outcome)
            //     return RespondError(outcome.Exception); obsolete
            //
            // if (responseDelegate is {})
            // {
            //     try
            //     {
            //         var delegateOutcome = await responseDelegate(outcome.Value!);
            //         return !delegateOutcome ? RespondError(delegateOutcome.Exception) : Ok(delegateOutcome.Value!);
            //     }
            //     catch (Exception ex)
            //     {
            //         return RespondError(ex);
            //     }
            // }
            //
            // if (outcome.Value is not HttpResponseMessage responseMessage) 
            //     return this.RespondOk(outcome.Value!);
            //
            // var stringValue = await responseMessage.Content.ReadAsStringAsync();
            // var entityOutcome = stringValue.TryParseJsonToDynamicEntity();
            // return Ok(entityOutcome
            //     ? entityOutcome.Value!
            //     : stringValue);
        }

        /// <summary>
        ///   Responds with standard format, reflecting a successful request.
        ///   This method just wraps the <see cref="ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase,object?,int,TetraPak.ReadChunk?)"/>. 
        /// </summary>
        /// <param name="outcome">
        ///   The outcome, carrying a collection of requested items, to be sent to client.
        /// </param>
        /// <param name="totalCount">
        ///   (optional; default=[number of items in <paramref name="outcome"/>])<br/>
        ///   The total number of items available.
        /// </param>
        ///  <typeparam name="T">
        ///    The type of requested items.
        /// </typeparam>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a collection of items or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected OkObjectResult RespondOk<T>(EnumOutcome<T> outcome, int totalCount = -1)
        {
            return this.RespondOk(outcome, totalCount, HttpContext.Request.GetMessageId(TetraPakConfig));
        }

        /// <summary>
        ///   Overrides the <see cref="ControllerBase.Ok()"/> method to instead invoke the
        ///   <see cref="ControllerBaseExtensions.RespondOk(Microsoft.AspNetCore.Mvc.ControllerBase,object?,int,TetraPak.ReadChunk?)"/>
        ///   method.
        /// </summary>
        /// <param name="data">
        ///   The data to be sent in the response.
        /// </param>
        /// <returns>
        ///   An <see cref="OkObjectResult"/>.
        /// </returns>
        public override OkObjectResult Ok(object? data)
        {
            return data is null
                ? this.RespondOk()
                : this.RespondOk(data);
        }

        // /// <summary>
        // ///   Convenience method to yield a string from a <see cref="Dictionary{TKey,TValue}"/>,
        // ///   suitable for logging. 
        // /// </summary>
        // /// <param name="formDictionary"></param>
        // /// <param name="indent"></param>
        // /// <returns></returns>
        // protected static string DictionaryLogString(IDictionary<string, string> formDictionary, string indent = "  ") obsolete
        // {
        //     return formDictionary.ConcatDictionary($"\n{indent}");
        // }

        /// <summary>
        ///   Initializes the <see cref="BusinessApiController"/>.
        /// </summary>
        /// <param name="tetraPakConfig">
        ///   The Tetra Pak integration configuration.
        /// </param>
        public BusinessApiController(TetraPakConfig tetraPakConfig)
        {
            TetraPakConfig = tetraPakConfig;
        }
    }

    /// <summary>
    ///   This type of delegate can be used to customize a response,
    ///   before it is being transformed to the recommended Tetra Pak format and sent to the client.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public delegate Task<Outcome<T>> ResponseDelegate<T>(object data);
}