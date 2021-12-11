using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;
using HttpMethod=Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

#nullable enable

namespace TetraPak.AspNet.Api
{
    public static class ServiceConfigHelper
    {
        internal static void SetBackendService(this ServiceEndpoints self, IBackendService backendService)
        {
            self.BackendService = backendService;
            foreach (var (_, endpoint)  in self)
            {
                endpoint.SetBackendService(backendService);
            }
        }

        internal static Outcome<ActorToken> GetInvalidEndpointAuthorization(this ServiceInvalidEndpoint url)
        {
            var issues = url.GetIssues();
            var errorMessage = 
                $"Error calling service: {requestToString("(Authorize)", url.StringValue, null)}{Environment.NewLine}" + 
                $"  Configuration issues:{Environment.NewLine}{issues.Select(i => i.Message).ConcatCollection(Environment.NewLine + "    ")}";
            var messageId = url.GetMessageId();
            url.Logger.Error(new ServerConfigurationException(errorMessage), messageId: messageId);
            
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var errorResponse = new ApiErrorResponse("Internal service configuration error (please see logs)", messageId);
            var body = JsonSerializer.Serialize(errorResponse);
            responseMessage.Content = new StringContent(body);
            return Outcome<ActorToken>.Fail(new Exception(errorResponse.Title));
        }
        
        internal static HttpOutcome<HttpResponseMessage> GetInvalidEndpointResponse(
            this ServiceInvalidEndpoint url,
            HttpMethod method,
            string path,
            string? queryParameters)
        {
            return GetInvalidEndpointResponse(
                url,
                method.ToStringVerb(),
                path,
                queryParameters);
        }
        
        static HttpOutcome<HttpResponseMessage> GetInvalidEndpointResponse(
            this ServiceInvalidEndpoint url,
            string httpMethod,
            string path,
            string? queryParameters)
        {
            var issues = url.GetIssues();
            var errorMessage = 
                $"Error calling service: {requestToString(httpMethod, path, queryParameters)}{Environment.NewLine}" + 
                $"  Configuration issues:{Environment.NewLine}{issues.Select(i => i.Message).ConcatCollection(Environment.NewLine + "    ")}";
            var messageId = url.GetMessageId();
            url.Logger.Error(new ServerConfigurationException(errorMessage), messageId: messageId);
            
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var errorResponse = new ApiErrorResponse("Internal service configuration error (please see logs)", messageId);
            var body = JsonSerializer.Serialize(errorResponse);
            responseMessage.Content = new StringContent(body);
            return HttpOutcome<HttpResponseMessage>.Fail(
                httpMethod.ToHttpMethod(), 
                new Exception(errorResponse.Title),
                responseMessage);
        }
        internal static HttpOutcome<ApiDataResponse<T>> GetInvalidEndpointResponse<T>(
            this ServiceInvalidEndpoint url,
            HttpMethod httpMethod,
            string path,
            string? queryParameters)
        {
            var issues = url.GetIssues();
            var errorMessage = 
                $"Error calling service: {requestToString(httpMethod.ToStringVerb(), path, queryParameters)}{Environment.NewLine}" + 
                $"  Configuration issues:{Environment.NewLine}{issues.Select(i => i.Message).ConcatCollection(Environment.NewLine + "    ")}";
            var messageId = url.GetMessageId();
            url.Logger.Error(new ServerConfigurationException(errorMessage), messageId: messageId);
            return HttpOutcome<ApiDataResponse<T>>.Fail(
                httpMethod, 
                new Exception("Internal service configuration error (please see logs)"));
        }
        
        internal static HttpOutcome<HttpResponseMessage> GetServiceConfigurationErrorResponse(
            string httpMethod,
            string path, 
            string? queryParameters, 
            IEnumerable<Exception> issues,
            string? messageId,
            ILogger? logger)
        {
            var errorMessage = 
                $"Error calling service: {requestToString(httpMethod, path, queryParameters)}{Environment.NewLine}" + 
                $"  Configuration issues:{Environment.NewLine}{issues.Select(i => i.Message).ConcatCollection(Environment.NewLine + "    ")}";
            logger.Error(new ServerConfigurationException(errorMessage));
            
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var errorResponse = new ApiErrorResponse("Internal service configuration error (please see logs)", messageId);
            var body = JsonSerializer.Serialize(errorResponse);
            responseMessage.Content = new StringContent(body);
            return HttpOutcome<HttpResponseMessage>.Fail(
                httpMethod.ToHttpMethod(),
                new Exception(errorResponse.Title),
                responseMessage);
        }

        static string requestToString(string method, string path, string? queryParameters)
        {
            var sb = new StringBuilder(method);
            sb.Append(' ');
            sb.Append(path);
            if (string.IsNullOrWhiteSpace(queryParameters))
                return sb.ToString();

            sb.Append(queryParameters.EnsurePostfix("?"));
            return sb.ToString();
        }        
    }
}