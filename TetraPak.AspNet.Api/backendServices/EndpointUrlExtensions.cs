using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Api
{
    public static class EndpointUrlExtensions
    {
        static readonly Dictionary<EndpointUrl,IBackendService> s_endpoints = new();
        
        public static void SetBackendService(this EndpointUrl self, IBackendService backendService)
        {
            lock (s_endpoints)
            {
                if (s_endpoints.TryGetValue(self, out var existingService))
                    throw new ArgumentException($"Endpoint {self} is already assigned to service {existingService}", nameof(backendService));
                
                s_endpoints.Add(self, backendService);
            }
        }

        public static Task<Outcome<HttpResponseMessage>> PostAsync(
            this EndpointUrl url,
            HttpContent content,
            HttpClientOptions clientOptions = null,
            CancellationToken? cancellationToken = null)
        {
            lock (s_endpoints)
            {
                if (!s_endpoints.TryGetValue(url, out var service))
                    throw new InvalidOperationException($"Endpoint Url {url} was not assigned to a service");

                return service.PostAsync(url, content, clientOptions, cancellationToken);
            }
        }
    }
}