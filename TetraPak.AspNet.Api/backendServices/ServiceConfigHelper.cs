using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api
{
    public static class ServiceConfigHelper
    {
        // public static Uri GetUri(this ServiceEndpoints self, string path)  obsolete
        //     => new Uri($"{self.Host}{self.BasePath}{path}");
        
        internal static void SetBackendService(this ServiceEndpointCollection self, IBackendService backendService)
        {
            self.BackendService = backendService;
            foreach (var (_, endpoint)  in self)
            {
                endpoint.SetBackendService(backendService);
            }
        }

        public static Outcome<ActorToken> GetInvalidEndpointAuthorization(this ServiceInvalidEndpoint url)
        {
            var issues = url.GetIssues();
            var errorMessage = 
                $"Error calling service: {RequestToString("(Authorize)", url.StringValue, null)}{Environment.NewLine}" + 
                $"  Configuration issues:{Environment.NewLine}{issues.Select(i => i.Message).ConcatCollection(Environment.NewLine + "    ")}";
            var messageId = url.GetMessageId();
            url.Logger.Error(new ConfigurationException(errorMessage), messageId: messageId);
            
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var errorResponse = new ApiErrorResponse("Internal service configuration error (please see logs)", messageId);
            var body = JsonSerializer.Serialize(errorResponse);
            responseMessage.Content = new StringContent(body);
            return Outcome<ActorToken>.Fail(new Exception(errorResponse.Title));
        }
        
        public static Outcome<HttpResponseMessage> GetInvalidEndpointResponse(
            this ServiceInvalidEndpoint url,
            HttpMethod method,
            string path,
            string? queryParameters)
        {
            return GetInvalidEndpointResponse(
                url,
                method.ToString(),
                path,
                queryParameters);
        }
        
        public static Outcome<HttpResponseMessage> GetInvalidEndpointResponse(
            this ServiceInvalidEndpoint url,
            string method,
            string path,
            string? queryParameters)
        {
            var issues = url.GetIssues();
            var errorMessage = 
                $"Error calling service: {RequestToString(method, path, queryParameters)}{Environment.NewLine}" + 
                $"  Configuration issues:{Environment.NewLine}{issues.Select(i => i.Message).ConcatCollection(Environment.NewLine + "    ")}";
            var messageId = url.GetMessageId();
            url.Logger.Error(new ConfigurationException(errorMessage), messageId: messageId);
            
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var errorResponse = new ApiErrorResponse("Internal service configuration error (please see logs)", messageId);
            var body = JsonSerializer.Serialize(errorResponse);
            responseMessage.Content = new StringContent(body);
            return Outcome<HttpResponseMessage>.Fail(responseMessage, new Exception(errorResponse.Title));
        }
        
        public static Outcome<HttpResponseMessage> GetServiceConfigurationErrorResponse(
            HttpMethod method,
            string path, 
            string? queryParameters, 
            IEnumerable<Exception> issues,
            string? messageId,
            ILogger? logger)
        {
            return GetServiceConfigurationErrorResponse(
                method.ToString(),
                path,
                queryParameters,
                issues,
                messageId,
                logger);
        }

        public static Outcome<HttpResponseMessage> GetServiceConfigurationErrorResponse(
            string method,
            string path, 
            string? queryParameters, 
            IEnumerable<Exception> issues,
            string? messageId,
            ILogger? logger)
        {
            var errorMessage = 
                $"Error calling service: {RequestToString(method, path, queryParameters)}{Environment.NewLine}" + 
                $"  Configuration issues:{Environment.NewLine}{issues.Select(i => i.Message).ConcatCollection(Environment.NewLine + "    ")}";
            logger.Error(new ConfigurationException(errorMessage));
            
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var errorResponse = new ApiErrorResponse("Internal service configuration error (please see logs)", messageId);
            var body = JsonSerializer.Serialize(errorResponse);
            responseMessage.Content = new StringContent(body);
            return Outcome<HttpResponseMessage>.Fail(responseMessage, new Exception(errorResponse.Title));
        }

        public static string RequestToString(string method, string path, string? queryParameters)
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