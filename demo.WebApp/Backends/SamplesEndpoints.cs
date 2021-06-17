using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesEndpoints : EndpointsConfig
    {
        public BackendServiceEndpointUrl HelloWorld { get; set; }
        
        public SamplesEndpoints(
            IConfiguration configuration, 
            string sectionId = "SamplesServices") 
        : base(configuration, null, sectionId)
        {
        }
    }
}