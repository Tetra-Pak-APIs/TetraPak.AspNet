using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesEndpoints : EndpointsConfig
    {
        public EndpointUrl HelloWorld { get; set; }
        
        public SamplesEndpoints(
            IConfiguration configuration, 
            string sectionId = "SamplesServices") 
        : base(configuration, null, sectionId)
        {
        }
    }
}