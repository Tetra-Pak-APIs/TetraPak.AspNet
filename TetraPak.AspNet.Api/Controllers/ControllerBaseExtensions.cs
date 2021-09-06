using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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
        /// <inheritdoc cref="BusinessApiController.MessageId"/>
        public static string GetMessageId(this ControllerBase self)
        {
            if (self is BusinessApiController apiController)
                return apiController.MessageId;

            return self.HttpContext.Request.GetMessageId(null);
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
            if (value.GetType().IsGenericBase(typeof(ApiDataResponse<>))) 
                return new OkObjectResult(value);
            
            var messageId = self.GetMessageId();
            if (!value.IsCollection(out _, out var items, out var count))
                return new OkObjectResult(new ApiDataResponse<object>(new[] {value}));
            
            totalCount = totalCount < 0 ? count : totalCount;
            var array = items.EnumerableToArray();
            return new OkObjectResult(new ApiDataResponse<object>(
                array,
                chunk?.Skip ?? -1, 
                totalCount,
                messageId));
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
        /// <param name="responseDelegate">
        ///   (optional)<br/>
        ///   A delegate tobe called for custom (successful) <see cref="ActionResult"/> construction.
        /// </param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <remarks>
        ///   <para>
        ///   If the <paramref name="outcome"/> is unsuccessful the <see cref="Error(ControllerBase,Exception)"/>
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
        /// <seealso cref="Ok(ControllerBase)"/>
        /// <seealso cref="Ok(ControllerBase,object,int,ReadChunk)"/>
        public static async Task<ActionResult> RespondAsync<T>(
            this ControllerBase self,
            Outcome<T> outcome,
            ResponseDelegate<T> responseDelegate = null)
        {
            if (!outcome)
                return self.Error(outcome.Exception);
            
            if (responseDelegate is {})
            {
                try
                {
                    var delegateOutcome = await responseDelegate(outcome.Value);
                    return !delegateOutcome ? self.Error(delegateOutcome.Exception) : self.Ok(delegateOutcome.Value);
                }
                catch (Exception ex)
                {
                    return self.Error(ex);
                }
            }

            if (outcome.Value is not HttpResponseMessage responseMessage) 
                return self.Ok(outcome.Value);
            
            var stringValue = await responseMessage.Content.ReadAsStringAsync();
            var entityOutcome = stringValue.TryParseJsonToDynamicEntity();
            return Ok(self, entityOutcome
                ? entityOutcome.Value
                : stringValue);
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
        /// <seealso cref="Ok(Microsoft.AspNetCore.Mvc.ControllerBase)"/>
        /// <seealso cref="Ok(Microsoft.AspNetCore.Mvc.ControllerBase,object,int,TetraPak.ReadChunk)"/>
        public static OkObjectResult Ok<T>(this ControllerBase self, EnumOutcome<T> outcome, int totalCount = -1)
        {
            return self.Ok(new ApiDataResponse<T>(outcome, totalCount));
        }
        
        /// <summary>
        ///   Constructs and returns an empty 'OK' (HTTP status code 200) response.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <returns>
        ///   An <see cref="ObjectResult"/> object.
        /// </returns>
        public static OkObjectResult Ok(this ControllerBase self)
        {
            return self.Ok(ApiDataResponse<object>.Empty(self.GetMessageId()));
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
        public static ActionResult ErrorExpectedQueryParameter(
            this ControllerBase self, 
            string queryParameterName, 
            string example = null)
        {
            var body = !string.IsNullOrWhiteSpace(example) 
                ? new {messages = new [] { $"Expected query parameter: '{queryParameterName}' (example: {example})" }} 
                : new {messages = new [] { $"Expected query parameter: '{queryParameterName}'" }};
            return self.Error(HttpStatusCode.BadRequest, new Exception(body.ToJson()));
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
        public static ActionResult UnauthorizedError(this ControllerBase self, Exception error)
        {
            return self.Error(HttpStatusCode.Unauthorized, error);
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
        /// <seealso cref="Error(ControllerBase,Exception)"/>
        public static ActionResult InternalServerError(this ControllerBase self, Exception error)
        {
            return self.Error(HttpStatusCode.InternalServerError, error);
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
        ///   If none can be resolved the <see cref="InternalServerError"/> method is invoked, to
        ///   produce a generic status code of 500 (<see cref="HttpStatusCode.InternalServerError"/>).
        /// </remarks>
        /// <seealso cref="Error(ControllerBase,HttpStatusCode,Exception)"/>
        /// <seealso cref="InternalServerError"/>
        public static ActionResult Error(this ControllerBase self, Exception error)
        {
            switch (error)
            {
                case HttpException httpException:
                    return self.StatusCode(
                        (int) httpException.StatusCode, 
                        new ApiErrorResponse(error.Message, self.GetMessageId()));
                
                case ApiErrorResponseException responseException:
                    return self.StatusCode(responseException.StatusCode, responseException.ErrorResponse);
                
                default:
                    return self.InternalServerError(error);
            }
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
        public static ActionResult Error(this ControllerBase self, HttpStatusCode status, Exception error)
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
        /// <exception cref="ConfigurationException">
        ///   The backend service could not be resolved.
        ///   Please ensure you haven't misspelled it in service configuration. 
        /// </exception>
        /// <remarks>
        ///   <para>
        ///   Use this method to obtain a backend service with its own custom implementation
        ///   of the <see cref="ServiceEndpointCollection"/> interface.
        ///   </para>
        ///   <para>
        ///   When the <paramref name="serviceName"/> is omitted it will instead be resolved from naming convention,
        ///   based on the controller's type. As an example; calling this method from a controller of type
        ///   <c>WeatherServiceController</c> will assume the requested backend service name is "WeatherService".   
        ///   </para>
        /// </remarks>
        public static TBackendService Service<TBackendService>(
            this ControllerBase self, 
            string serviceName = null) 
            where TBackendService : IBackendService
        {
            var outcome = TetraPakServiceFactory.GetService<TBackendService>(self, serviceName);
            if (outcome)
                return outcome.Value;
            
            if (string.IsNullOrEmpty(serviceName))
                throw new ConfigurationException($"Could not resolve a backend service for controller {self}");
            
            throw new ConfigurationException(
                $"Could not resolve a backend service \"{serviceName}\" "+
                $"for controller {self} ");
        }

        /// <summary>
        ///   Gets a backend service with (custom) endpoints.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ControllerBase"/> object.
        /// </param>
        /// <param name="serviceName">
        ///   (optional; default=[see remarks])<br/>
        ///   Identifies the service. 
        /// </param>
        /// <typeparam name="TEndpoints">
        ///   The service endpoints <see cref="Type"/> (must derive from <see cref="ServiceEndpointCollection"/>).
        /// </typeparam>
        /// <returns>
        ///   A <see cref="BackendService{TEndpoints}"/> object.
        /// </returns>
        /// <exception cref="ConfigurationException">
        ///   The backend service could not be resolved.
        ///   Please ensure you haven't misspelled it in service configuration. 
        /// </exception>
        /// <remarks>
        ///   <para>
        ///   Use this method to obtain a backend service that implements an endpoints collection of specified type
        ///   (derived from <see cref="ServiceEndpointCollection"/>).
        ///   </para>
        ///   <para>
        ///   When the <paramref name="serviceName"/> is omitted it will instead be resolved from naming convention,
        ///   based on the controller's type. As an example; calling this method from a controller of type
        ///   <c>WeatherServiceController</c> will assume the requested backend service name is "WeatherService".   
        ///   </para>
        /// </remarks>
        public static BackendService<TEndpoints> ServiceWithEndpoints<TEndpoints>(
            this ControllerBase self, 
            string serviceName = null) 
            where TEndpoints : ServiceEndpointCollection
        {
            var outcome = TetraPakServiceFactory.GetServiceWithEndpoints<TEndpoints>(self, serviceName);
            if (outcome)
                return (BackendService<TEndpoints>) outcome.Value;

            if (string.IsNullOrEmpty(serviceName))
                throw new ConfigurationException($"Could not resolve a backend service for controller {self}");
            
            throw new ConfigurationException(
                "Could not resolve a backend service with endpoints "+
                $"of type {typeof(TEndpoints)} for controller {self} ");
        }

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
        /// <exception cref="ConfigurationException">
        ///   The backend service could not be resolved.
        ///   Please ensure you haven't misspelled it in service configuration. 
        /// </exception>
        /// <remarks>
        ///   When the <paramref name="serviceName"/> is omitted it will instead be resolved from naming convention,
        ///   based on the controller's type. As an example; calling this method from a controller of type
        ///   <c>WeatherServiceController</c> will assume the requested backend service name is "WeatherService".   
        /// </remarks>
        public static IBackendService Service(this ControllerBase self, string serviceName = null)
        {
            var outcome = TetraPakServiceFactory.GetService(self, serviceName);
            if (outcome)
                return outcome.Value;

            if (string.IsNullOrEmpty(serviceName))
                throw new ConfigurationException($"Could not resolve a backend service for controller {self}");
            
            throw new ConfigurationException($"Could not resolve a backend service \"{serviceName}\" for controller {self} ");
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
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        public static void LogTrace(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Trace(message, messageId);
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
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        public static void LogDebug(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Debug(message, messageId);
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
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        public static void LogInformation(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Information(message, messageId);
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
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        public static void LogWarning(this ControllerBase self, string message, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Warning(message, messageId);
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
        ///   (optional)<bt/>
        ///   A unique string value to be used for referencing/diagnostics purposes.
        /// </param>
        /// <remarks>
        ///   If no logging is configured the call will simply be ignored.
        /// </remarks>
        public static void LogError(this ControllerBase self, Exception exception, string message = null, string messageId = null)
        {
            if (!self.TryGetTetraPakApiAuthConfig(out var config))
                return;
            
            config.Logger.Error(exception, message, messageId);
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
        /// <seealso cref="GetTetraPakApiAuthConfig"/>
        public static bool TryGetTetraPakApiAuthConfig(this ControllerBase self, out TetraPakApiAuthConfig config)
        {
            config = self.HttpContext.RequestServices.GetService<TetraPakApiAuthConfig>();
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
        /// <seealso cref="TryGetTetraPakApiAuthConfig"/>
        /// <exception cref="ConfigurationException">
        ///   The Tetra Pak (API) configuration object could not be obtained
        /// </exception>
        public static TetraPakApiAuthConfig GetTetraPakApiAuthConfig(this ControllerBase self)
        {
            if (self.TryGetTetraPakApiAuthConfig(out var config))
                return config;

            if (self is BusinessApiController apiController)
                return apiController.GetConfig();
                
            throw new ConfigurationException($"Could not retrieve a {typeof(TetraPakApiAuthConfig)} instance");
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