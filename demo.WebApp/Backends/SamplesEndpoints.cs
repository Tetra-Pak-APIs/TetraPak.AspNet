using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesEndpoints : EndpointsConfig
    {
        public BackendServiceEndpointUrl HelloWorld { get; set; }
        
        public SamplesEndpoints(ServicesConfig servicesConfig, string sectionId = "SamplesServices") 
        : base(servicesConfig, null, sectionId)
        {
        }
    }
}