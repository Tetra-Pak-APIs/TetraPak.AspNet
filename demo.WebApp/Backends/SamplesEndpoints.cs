using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesEndpoints : Endpoints
    {
        public EndpointUrl HelloWorld { get; set; }
        
        public SamplesEndpoints(
            IConfiguration configuration, 
            string sectionId = "SamplesServices") 
        : base(configuration, sectionId)
        {
        }
    }
}