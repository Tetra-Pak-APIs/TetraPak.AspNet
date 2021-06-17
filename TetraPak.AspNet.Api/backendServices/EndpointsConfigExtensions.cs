using System;

namespace TetraPak.AspNet.Api
{
    public static class EndpointsConfigExtensions
    {
        public static Uri GetUri(this EndpointsConfig self, string path) 
            => new Uri($"{self.Host}{self.BasePath}{path}");
        
        internal static void SetBackendService(this EndpointsConfig self, IBackendService backendService)
        {
            foreach (var (_, endpointUrl)  in self)
            {
                endpointUrl.SetBackendService(backendService);
            }
        }
    }
}