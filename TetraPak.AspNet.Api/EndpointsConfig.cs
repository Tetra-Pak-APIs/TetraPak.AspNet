using System;
using Microsoft.Extensions.Configuration;

namespace TetraPak.AspNet.Api
{
    public class EndpointsConfig : ConfigSection
    {
        public string Host { get; set; }

        public string BasePath { get; set; }

        public EndpointsConfig(IConfiguration configuration, string sectionId = "Endpoints")
        : base(configuration, sectionId)
        {
            
        }
    }

    public static class EndpointsConfigExtensions
    {
        public static Uri GetUri(this EndpointsConfig self, string path) 
            => new Uri($"{self.Host}{self.BasePath}{path}");
    }
}