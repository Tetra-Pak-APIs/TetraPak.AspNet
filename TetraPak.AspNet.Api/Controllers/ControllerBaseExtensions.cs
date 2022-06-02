using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.DynamicEntities;
using TetraPak.Logging;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api.Controllers
{
    /// <summary>
    ///   Convenient extension methods for <see cref="ControllerBase"/>.
    /// </summary>
    public static class ControllerBaseExtensions
    {
        /// <summary>
        ///   Gets a unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/>.
        /// </param>
        /// <param name="enforce">
        ///   (optional; default=false)<br/>
        ///   When set, a random unique string will be generated and attached to the request.
        /// </param>
        // ReSharper disable once MemberCanBePrivate.Global
        public static string? GetMessageId(this ControllerBase self, bool enforce = false)
        {
            if (self is BusinessApiController apiController)
                return apiController.MessageId;

            return self.HttpContext.Request.GetMessageId(null!, enforce);
        }

        /// <summary>
        ///   Obtains a security token from the request. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        public static Task<Outcome<ActorToken>> GetAccessTokenAsync(this ControllerBase self) 
            => self.HttpContext.Request.GetAccessTokenAsync();

        /// <summary>
        ///   Creates an <see cref="OkObjectResult"/> object that produces an Status 200 OK response.
        /// </summary>
        /// <param name="self">
        ///   The extended object.
        /// </param>
        /// <param name="data">
        ///   The data to be sent back in response (<c>null</c> is allowed). 
        /// </param>
        /// <param name="totalCount">
        ///   (optional)<br/>
        ///   The total number of items available from service.
        /// </param>
        /// <param name="chunk">
        ///   (optional)<br/>
        ///   A <see cref="ReadChunk"/> object specifying the data requested.
        /// </param>
        /// <param name="okStatusCode">
        ///   (optional; default=<see cref="HttpOkStatusCode.Auto"/>)<br/>
        ///   Specifies a HTTP (successful) status code to be used (leave as <see cref="HttpOkStatusCode.Auto"/>
        ///   to allow the <see cref="IHttpOkResponsePolicy"/> to decide, based on REST best practices.
        /// </param>
        /// <returns>
        ///   An <see cref="OkObjectResult"/> object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="data"/> was unassigned.
        /// </exception>
        public static OkObjectResult RespondOk(
            this ControllerBase self, 
            object? data, 
            int totalCount = -1, 
            ReadChunk? chunk = null,
            HttpOkStatusCode okStatusCode = HttpOkStatusCode.Auto)
        {
            var messageId = self.GetMessageId();

            if (data is null)
                return applyPolicy(
                    new OkObjectResult(new ApiDataResponse<object>(Array.Empty<object>(), messageId: messageId)));

            if (data is DynamicEntity dynamicEntity)
                return applyPolicy(new OkObjectResult(dynamicEntityResponse()));

            if (data.GetType().IsGenericBase(typeof(ApiDataResponse<>))) 
                return applyPolicy(
                    new OkObjectResult(data));
            
            if (!data.IsCollection(out _, out var items, out var count))
                return applyPolicy(
                    new OkObjectResult(new ApiDataResponse<object>(new[] {data}, messageId: messageId)));
            
            totalCount = totalCount < 0 ? count : totalCount;
            var array = items.EnumerableToArray();
            return applyPolicy(
                new OkObjectResult(new ApiDataResponse<object>(
                array,
                chunk?.Skip ?? -1, 
                totalCount,
                messageId)));

            OkObjectResult applyPolicy(OkObjectResult result)
            {
                if (okStatusCode != HttpOkStatusCode.Auto)
                    return result;
                
                var responsePolicy = HttpOkResponsePolicyHelper.GetHttpOkResponsePolicy();
                return responsePolicy.ApplyHttpResponsePolicy(self.HttpContext, result);
            }
            
            object? dynamicEntityResponse()
            {
                return !dynamicEntity.IsApiDataResponse(out var apiDataResponse) 
                    ? new ApiDataResponse<object>(new[] { dynamicEntity }, messageId: messageId) 
                    : apiDataResponse;
            }
        }

        /// <summary>
        ///   Constructs and returns a response from an <see cref="Outcome{T}"/> object (see remarks). 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="outcome">
        ///   The outcome object to be reflected.
        /// </param>
        /// <param name="totalCount">
        ///   (optional)<br/>
        ///   The total number of items available from service.
        /// </param>
        /// <param name="chunk">
        ///   (optional)<br/>
        ///   A <see cref="ReadChunk"/> object specifying the data requested.
        /// </param>
        /// <param name="responseDelegate">
        ///   (optional)<br/>
        ///   A delegate tobe called for custom (successful) <see cref="ActionResult"/> construction.
        /// </param>
        /// <typeparam name="T">
        ///   The <see cref="Type"/> of data carried by the <paramref name="outcome"/>.
        /// </typeparam>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        /// <remarks>
        ///   <para>
        ///   This method automatically resolves whether the outcome is a success or failure and constructs
        ///   a well-formed response, adhering to Tetra Pak Api recommendations. Relying on this method
        ///   for constructing responses will relieve you from having to write the corresponding boiler plate
        ///   code yourself. Also, should Tetra Pak recommendations change you can simply upgrade the SDK
        ///   tp stay current. 
        ///   </para>
        ///   <para>
        ///   If the <paramref name="outcome"/> is unsuccessful the <see cref="RespondError(Microsoft.AspNetCore.Mvc.ControllerBase,System.Exception)"/>
        ///   method will automatically be invoked.
        ///   </para>
        ///   <para>
        ///   A successful outcome will either delegate the construction to <paramref name="responseDelegate"/>
        ///   (when assigned) or dispatch the construction to a suitable "Ok" method (see the "see also" links). 
        ///   </para>
        ///   <para>
        ///   If the <paramref name="outcome"/>'s value (<see cref="Outcome{T}.Value"/>) is
        ///   an <see cref="HttpResponseMessage"/> object, the value will automatically be serialized to JSON
        ///   to be included in the response.  
        ///   </para>
        /// </remarks>
        /// <seealso cref="RespondOk(ControllerBase,HttpOkStatusCode)"/>
        /// <seealso cref="RespondOk(ControllerBase,object?,int,TetraPak.ReadChunk?,HttpOkStatusCode)"/>
        public static async Task<ActionResult> RespondAsync<T>(
            this ControllerBase self,
            Outcome<T> outcome,
            int totalCount = -1,
            ReadChunk? chunk = null, 
            ResponseDelegate<T>? responseDelegate = null)
        {
            if (!outcome)
                return self.RespondError(outcome.Exception);

            if (self.IsRequestCancelled())
                return self.RespondCancelled();

            if (responseDelegate is {})
            {
                try
                {
                    var delegateOutcome = await responseDelegate(outcome.Value!);
                    return !delegateOutcome 
                        ? self.RespondError(delegateOutcome.Exception) 
                        : await RespondAsync(self, delegateOutcome);
                }
                catch (Exception ex)
                {
                    return self.RespondError(ex);
                }
            }

            if (outcome.Value is Stream stream)
                return self.Ok(stream);

            if (outcome.Value is not HttpResponseMessage responseMessage)
                return self.RespondOk(outcome.Value, totalCount, chunk);
            
            var stringValue = await responseMessage.Content.ReadAsStringAsync();
            var entityOutcome = stringValue.TryParseJsonToDynamicEntity();
            return RespondOk(self, 
                entityOutcome
                    ? entityOutcome.Value
                    : stringValue,
                totalCount, 
                chunk);
        }
        
        /// <summary>
        ///   Returns a data body with a specific HTTP status code. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="statusCode">
        ///   The <see cref="HttpStatusCode"/> to be returned.
        /// </param>
        /// <param name="data">
        ///   The <see cref="ApiDataResponse{T}"/> data to be included in the response.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondStatus<T>(
            this ControllerBase self, 
            HttpStatusCode statusCode,
            ApiDataResponse<T> data)
        {
            return self.StatusCode((int)statusCode, data);
        }

        /// <summary>
        ///   Returns a data body with a specific HTTP status code. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="statusCode">
        ///   The <see cref="HttpStatusCode"/> to be returned.
        /// </param>
        /// <param name="outcome">
        ///   An outcome to be transformed into the returned body.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondStatus<T>(
            this ControllerBase self,
            HttpStatusCode statusCode,
            EnumOutcome<T> outcome)
        {
            var data = new ApiDataResponse<T>(outcome);
            return self.RespondStatus(statusCode, data);
        }

        /// <summary>
        ///   Returns a data body with a specific HTTP status code. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="statusCode">
        ///   The <see cref="HttpStatusCode"/> to be returned.
        /// </param>
        /// <param name="outcome">
        ///   An outcome to be transformed into the returned body.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondStatus<T>(
            this ControllerBase self,
            HttpStatusCode statusCode,
            Outcome<T> outcome)
        {
            if (outcome)
                return self.RespondStatus(
                    statusCode,
                    new ApiDataResponse<T>(EnumOutcome<T>.Success(new[] { outcome.Value! })));

            if (outcome.Value is null)
                return self.RespondStatus(
                    statusCode,
                    new ApiDataResponse<T>(EnumOutcome<T>.Fail(outcome.Exception)));

            return self.RespondStatus(
                statusCode,
                new ApiDataResponse<T>(EnumOutcome<T>.Fail(
                    new[] { outcome.Value! }, 
                    outcome.Exception)));
        }

        /// <summary>
        ///   Constructs and returns an 'OK' (HTTP status code 200) response from an <see cref="EnumOutcome{T}"/> object. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="outcome">
        ///   The <see cref="EnumOutcome{T}"/> object.
        /// </param>
        /// <param name="totalCount">
        ///   (optional; default=[read from <see cref="EnumOutcome{T}.Count"/>])<br/>
        ///   Specifies a (custom) total count value. Use when the value from <paramref name="outcome"/> is incorrect.  
        /// </param>
        /// <typeparam name="T">
        ///   The type of data items in response.
        /// </typeparam>
        /// <returns>
        ///   An <see cref="ObjectResult"/> object.
        /// </returns>
        /// <seealso cref="ApiDataResponse{T}"/>
        /// <seealso cref="RespondOk(ControllerBase,HttpOkStatusCode)"/>
        /// <seealso cref="RespondOk(ControllerBase,object?,int,TetraPak.ReadChunk?,HttpOkStatusCode)"/>
        public static OkObjectResult RespondOk<T>(
            this ControllerBase self,
            EnumOutcome<T> outcome, 
            int totalCount = -1)
        {
            return HttpOkResponsePolicyHelper.GetHttpOkResponsePolicy()
                .ApplyHttpResponsePolicy(
                    self.HttpContext, 
                    self.Ok(new ApiDataResponse<T>(outcome, totalCount)));
        }

        /// <summary>
        ///   Constructs and returns an empty "successful" response.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="statusCode">
        ///   (optional; default=<see cref="HttpOkStatusCode.Auto"/>)<br/>
        ///   Specifies the status code to be returned for the successful operation.
        /// </param>
        /// <returns>
        ///   An <see cref="ObjectResult"/> object.
        /// </returns>
        public static OkObjectResult RespondOk(this ControllerBase self, HttpOkStatusCode statusCode = HttpOkStatusCode.Auto)
        {
            return HttpOkResponsePolicyHelper.GetHttpOkResponsePolicy()
                .ApplyHttpResponsePolicy(
                    self.HttpContext,
                    self.Ok(ApiDataResponse<object>.Empty(self.GetMessageId())));
        }

        /// <summary>
        ///   Constructs and returns a 'Created' (HTTP status code 201) response.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="urls">
        ///   One or more URLs to locate the created resource(8). 
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondOkCreated(this ControllerBase self, params string[] urls)
        {
            if (!urls.Any())
                return self.StatusCode((int)HttpStatusCode.Created);

            var data = new ApiDataResponse<string>(EnumOutcome<string>.Success(urls));
            return self.RespondStatus(HttpStatusCode.Created, data);
        }

        /// <summary>
        ///   Constructs and returns a 'Accepted' (HTTP status code 201) response.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="urls">
        ///   One or more URLs to locate the created resource(8). 
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondOkAccepted(this ControllerBase self, params string[] urls)
        {
            if (!urls.Any())
                return self.StatusCode((int)HttpStatusCode.Accepted);

            var data = new ApiDataResponse<string>(EnumOutcome<string>.Success(urls));
            return self.RespondStatus(HttpStatusCode.Accepted, data);
        }

        /// <summary>
        ///   Constructs and returns an <see cref="ActionResult"/> to reflect an issue with a missing query parameter.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="queryParameterName">
        ///   The name of the expected (missing) query parameter.
        /// </param>
        /// <param name="example">
        ///   (optional)<br/>
        ///   A descriptive example, to assist developer in correcting the problem.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondErrorExpectedQueryParameter(
            this ControllerBase self, 
            string queryParameterName, 
            string? example = null)
        {
            var body = !string.IsNullOrWhiteSpace(example) 
                ? new {messages = new [] { $"Expected query parameter: '{queryParameterName}' (example: {example})" }} 
                : new {messages = new [] { $"Expected query parameter: '{queryParameterName}'" }};
            return self.RespondError(HttpStatusCode.BadRequest, new Exception(body.ToJson()));
        }
        
        /// <summary>
        ///   Constructs and returns an <see cref="ActionResult"/> to reflect an unauthorized request.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="error">
        ///   The exception to be reflected.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondErrorUnauthorized(this ControllerBase self, Exception error)
        {
            return self.RespondError(HttpStatusCode.Unauthorized, error);
        }
        
        /// <summary>
        ///   Constructs and returns an <see cref="ActionResult"/> with status code 500
        ///   (<see cref="HttpStatusCode.InternalServerError"/>) to reflect an internal/unexpected error in the service.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="error">
        ///   The exception to be reflected.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        /// <seealso cref="RespondError(Microsoft.AspNetCore.Mvc.ControllerBase,System.Exception)"/>
        public static ActionResult RespondErrorInternalServer(this ControllerBase self, Exception error)
        {
            return self.RespondError(HttpStatusCode.InternalServerError, error);
        }
        
        /// <summary>
        ///   Constructs and returns an <see cref="ActionResult"/> to reflect an error.
        ///   Please see remarks.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="error">
        ///   The exception to be reflected.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        /// <remarks>
        ///   This method will automatically look for an HTTP status code in the <paramref name="error"/>.
        ///   If none can be resolved the <see cref="RespondErrorInternalServer"/> method is invoked, to
        ///   produce a generic status code of 500 (<see cref="HttpStatusCode.InternalServerError"/>).
        /// </remarks>
        /// <seealso cref="RespondError(ControllerBase,HttpStatusCode,Exception)"/>
        /// <seealso cref="RespondErrorInternalServer"/>
        public static ActionResult RespondError(this ControllerBase self, Exception error)
        {
            if (error is HttpServerException httpException)
                return self.StatusCode(
                    (int) httpException.StatusCode, 
                    new ApiErrorResponse(error.Message, self.GetMessageId()));

            return self.RespondErrorInternalServer(error);
        }

        /// <summary>
        ///   Constructs and returns an <see cref="ActionResult"/> to reflect an error with a specified HTTP status code.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="status">
        ///   The HTTP status code to be returned in response.
        /// </param>
        /// <param name="error">
        ///   The exception to be reflected.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        /// <seealso cref="RespondError(ControllerBase,Exception)"/>
        public static ActionResult RespondError(this ControllerBase self, HttpStatusCode status, Exception error)
        {
            // error message might already be a standard error response json object 
            var parseOutcome = tryParseTetraPakErrorResponse(error.Message);
            var errorResponse = parseOutcome
                ? parseOutcome.Value
                : new ApiErrorResponse(error.Message, self.GetMessageId())
                {
                    Status = ((int) status).ToString()
                };
            
            return self.StatusCode(
                (int) status,
                errorResponse);
        }

        /// <summary>
        ///   Constructs and returns a "Bad Request" error response.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="message">
        ///   A textual message describing the issue.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondErrorBadRequest(this ControllerBase self, string message)
            => self.RespondError(HttpStatusCode.BadRequest, new Exception(message));
        
        /// <summary>
        ///   Constructs and returns a "Not Found" error response.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="message">
        ///   A textual message describing the issue.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondErrorNotFound(this ControllerBase self, string message)
            => self.RespondError(HttpStatusCode.NotFound, new Exception(message));
        

        /// <summary>
        ///   Constructs and returns a "Bad Request" error response.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="error">
        ///   An <see cref="Exception"/> describing the issue.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> object.
        /// </returns>
        public static ActionResult RespondErrorBadRequest(this ControllerBase self, Exception error)
            => self.RespondError(HttpStatusCode.BadRequest, error); 

        /// <summary>
        ///   Gets a backend service of a specified <see cref="Type"/> (implementing <see cref="IBackendService"/>).
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="serviceName">
        ///   (optional; default=[see remarks])<br/>
        ///   Identifies the service. 
        /// </param>
        /// <typeparam name="TBackendService">
        ///   The <see cref="Type"/> of backend service to be obtained
        ///   (type must implement <see cref="IBackendService"/> contract).
        /// </typeparam>
        /// <returns>
        ///   A backend service object of type <typeparamref name="TBackendService"/>.
        /// </returns>
        /// <exception cref="HttpServerConfigurationException">
        ///   The backend service could not be resolved.
        ///   Please ensure you haven't misspelled it in service configuration. 
        /// </exception>
        /// <remarks>
        ///   <para>
        ///   Use this method to obtain a backend service with its own custom implementation
        ///   of the <see cref="ServiceEndpoints"/> interface.
        ///   </para>
        ///   <para>
        ///   When the <paramref name="serviceName"/> is omitted it will instead be resolved from naming convention,
        ///   based on the controller's type. As an example; calling this method from a controller of type
        ///   <c>WeatherServiceController</c> will assume the requested backend service name is "WeatherService".   
        ///   </para>
        /// </remarks>
        public static TBackendService Service<TBackendService>(
            this ControllerBase self, 
            string? serviceName = null) 
            where TBackendService : IBackendService
        {
            var outcome = self.GetBackendService<TBackendService>(serviceName);
            if (outcome)
                return outcome.Value!;
            
            if (string.IsNullOrEmpty(serviceName))
                throw new HttpServerConfigurationException($"Could not resolve a backend service for controller {self}");
            
            throw new HttpServerConfigurationException(
                $"Could not resolve a backend service \"{serviceName}\" "+
                $"for controller {self} ");
        }

        // /// <summary> obsolete
        // ///   Gets a backend service with (custom) endpoints.
        // /// </summary>
        // /// <param name="self">
        // ///   The extended <see cref="ControllerBase"/> object.
        // /// </param>
        // /// <param name="serviceName">
        // ///   (optional; default=[see remarks])<br/>
        // ///   Identifies the service. 
        // /// </param>
        // /// <typeparam name="TEndpoints">
        // ///   The service endpoints <see cref="Type"/> (must derive from <see cref="ServiceEndpointCollection"/>).
        // /// </typeparam>
        // /// <returns>
        // ///   A <see cref="BackendService{TEndpoints}"/> object.
        // /// </returns>
        // /// <exception cref="ConfigurationException">
        // ///   The backend service could not be resolved.
        // ///   Please ensure you haven't misspelled it in service configuration. 
        // /// </exception>
        // /// <remarks>
        // ///   <para>
        // ///   Use this method to obtain a backend service that implements an endpoints collection of specified type
        // ///   (derived from <see cref="ServiceEndpointCollection"/>).
        // ///   </para>
        // ///   <para>
        // ///   When the <paramref name="serviceName"/> is omitted it will instead be resolved from naming convention,
        // ///   based on the controller's type. As an example; calling this method from a controller of type
        // ///   <c>WeatherServiceController</c> will assume the requested backend service name is "WeatherService".   
        // ///   </para>
        // /// </remarks>
        // public static BackendService<TEndpoints> ServiceWithEndpoints<TEndpoints>(
        //     this ControllerBase self, 
        //     string? serviceName = null) 
        //     where TEndpoints : ServiceEndpointCollection
        // {
        //     var outcome = TetraPakServiceFactory.GetServiceWithEndpoints<TEndpoints>(self, serviceName);
        //     if (outcome)
        //         return (BackendService<TEndpoints>) outcome.Value;
        //
        //     if (string.IsNullOrEmpty(serviceName))
        //         throw new ConfigurationException($"Could not resolve a backend service for controller {self}");
        //     
        //     throw new ConfigurationException(
        //         "Could not resolve a backend service with endpoints "+
        //         $"of type {typeof(TEndpoints)} for controller {self} ");
        // }

        /// <summary>
        ///   Gets a backend service.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="serviceName">
        ///   (optional; default=[see remarks])<br/>
        ///   Identifies the service. 
        /// </param>
        /// <returns>
        ///   An object implementing the <see cref="IBackendService"/> contract.
        /// </returns>
        /// <exception cref="HttpServerConfigurationException">
        ///   The backend service could not be resolved.
        ///   Please ensure you haven't misspelled it in service configuration. 
        /// </exception>
        /// <remarks>
        ///   When the <paramref name="serviceName"/> is omitted it will instead be resolved from naming convention,
        ///   based on the controller's type. As an example; calling this method from a controller of type
        ///   <c>WeatherServiceController</c> will assume the requested backend service name is "WeatherService".   
        /// </remarks>
        public static IBackendService Service(this ControllerBase self, string? serviceName = null)
        {
            if (string.IsNullOrWhiteSpace(serviceName)) throw new ArgumentNullException(nameof(serviceName));
            var outcome = TetraPakServiceHelper.GetService(self, serviceName);
            if (outcome)
                return outcome.Value!;

            if (string.IsNullOrEmpty(serviceName))
                throw new HttpServerConfigurationException($"Could not resolve a backend service for controller {self}");
            
            throw new HttpServerConfigurationException($"Could not resolve a backend service \"{serviceName}\" for controller {self} ");
        }

        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Trace"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="message">
        ///   The message to be logged.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogTrace(ControllerBase,Func{string},string?)"/>
        public static void LogTrace(this ControllerBase self, string message, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Trace(message, messageId);
        }
        
        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Trace"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="messageHandler">
        ///   A message handler (only invoked when <see cref="LogLevel.Trace"/> is enabled).
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogTrace(ControllerBase,string,string?)"/>
        public static void LogTrace(this ControllerBase self, Func<string> messageHandler, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Trace(messageHandler, messageId);
        }

        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Debug"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="message">
        ///   The message to be logged.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogDebug(ControllerBase,Func{string},string?)"/>
        public static void LogDebug(this ControllerBase self, string message, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Debug(message, messageId);
        }
        
        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Debug"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="messageHandler">
        ///   A message handler (only invoked when <see cref="LogLevel.Debug"/> is enabled).
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogDebug(ControllerBase,string,string?)"/>
        public static void LogDebug(this ControllerBase self, Func<string> messageHandler, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Debug(messageHandler, messageId);
        }

        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Information"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="message">
        ///   The message to be logged.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogInformation(ControllerBase,Func{string},string?)"/>
        public static void LogInformation(this ControllerBase self, string message, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Information(message, messageId);
        }
        
        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Information"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="messageHandler">
        ///   A message handler (only invoked when <see cref="LogLevel.Information"/> is enabled).
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogInformation(ControllerBase,string,string?)"/>
        public static void LogInformation(this ControllerBase self, Func<string> messageHandler, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Information(messageHandler, messageId);
        }

        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Warning"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="message">
        ///   The message to be logged.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogWarning(ControllerBase,Func{string},string?)"/>
        public static void LogWarning(this ControllerBase self, string message, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Warning(message, messageId);
        }
        
        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Warning"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="messageHandler">
        ///   A message handler (only invoked when <see cref="LogLevel.Warning"/> is enabled).
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogWarning(ControllerBase,string,string?)"/>
        public static void LogWarning(this ControllerBase self, Func<string> messageHandler, string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Warning(messageHandler, messageId);
        }

        /// <summary>
        ///   Safely submits an exception (and, optionally, a message) to the logs with log level <see cref="LogLevel.Error"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="exception">
        ///   The exception to be logged.
        /// </param>
        /// <param name="message">
        ///   The message to be logged.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogError(ControllerBase,Exception,Func{string},string?)"/>
        public static void LogError(
            this ControllerBase self,
            Exception exception, 
            string? message = null, 
            string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Error(exception, message, messageId);
        }
        
        /// <summary>
        ///   Safely submits a message to the logs with log level <see cref="LogLevel.Error"/>. 
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="exception">
        ///   The exception to be logged.
        /// </param>
        /// <param name="messageHandler">
        ///   A message handler (only invoked when <see cref="LogLevel.Error"/> is enabled).
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        /// <seealso cref="LogError(ControllerBase,Exception,string,string?)"/>
        public static void LogError(
            this ControllerBase self,
            Exception exception, 
            Func<string> messageHandler, 
            string? messageId = null)
        {
            if (!self.TryGetTetraPakApiConfig(out var config))
                return;
            
            config.Logger.Error(exception, messageHandler, messageId);
        }

        /// <summary>
        ///   Attempts obtaining the Tetra Pak (API) configuration object.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="config">
        ///   Passes back the Tetra Pak (API) configuration object (on success).
        /// </param>
        /// <returns>
        ///   <c>true</c> if the Tetra Pak (API) configuration object could be obtained; otherwise <c>false</c>.
        /// </returns>
        /// <seealso cref="GetTetraPakConfig"/>
        public static bool TryGetTetraPakApiConfig(this ControllerBase self, [NotNullWhen(true)] out TetraPakApiConfig? config)
        {
            config = self.HttpContext.RequestServices.GetService<TetraPakApiConfig>();
            return config is {};
        }
        

        /// <summary>
        ///   Obtains the Tetra Pak (API) configuration object.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <returns>
        ///   A Tetra Pak (API) configuration object.
        /// </returns>
        /// <seealso cref="TryGetTetraPakApiConfig"/>
        /// <exception cref="HttpServerConfigurationException">
        ///   The Tetra Pak (API) configuration object could not be obtained
        /// </exception>
        public static TetraPakConfig? GetTetraPakConfig(this ControllerBase self)
        {
            if (self.TryGetTetraPakApiConfig(out var config))
                return config;

            if (self is BusinessApiController apiController)
                return apiController.GetConfig();
                
            throw new HttpServerConfigurationException($"Could not retrieve a {typeof(TetraPakApiConfig)} instance");
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
                return Outcome<ApiErrorResponse>.Success(JsonSerializer.Deserialize<ApiErrorResponse>(s, options)!);
            }
            catch (Exception ex)
            {
                return Outcome<ApiErrorResponse>.Fail(ex);
            }
        }

        /// <summary>
        ///   Constructs a resource locator for a specific resource id.
        /// </summary>
        /// <param name="self">
        ///   The extended controller.
        /// </param>
        /// <param name="id">
        ///   The resource id.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> resource locator.
        /// </returns>
        public static ResourceLocator ResourceLocatorForId(this ControllerBase self, string id)
            => self.Request.ResourceLocatorForId(id);
        
        
        /// <summary>
        ///   Constructs a resource locator for a specific resource id.
        /// </summary>
        /// <param name="self">
        ///   The extended HTTP request.
        /// </param>
        /// <param name="id">
        ///   The resource id.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> resource locator.
        /// </returns>
        public static ResourceLocator ResourceLocatorForId(this HttpRequest self, string id)
        {
            return new ResourceLocator($"{self.Path}/{id}");
        }
    }
}