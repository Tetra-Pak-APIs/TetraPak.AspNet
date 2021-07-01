using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    public class HelloWorldEndpoints : EndpointsConfig
    {
        BackendServiceEndpointUrl _helloWorld;

        public BackendServiceEndpointUrl HelloWorld
        {
            get => GetFromFieldThenSection<BackendServiceEndpointUrl>();
            set => _helloWorld = value;
        }
        
        public HelloWorldEndpoints(
            ServicesConfig servicesConfig,
            ILogger<HelloWorldEndpoints> logger,
            string sectionIdentifier = "HelloWorld") 
        : base(servicesConfig, logger, sectionIdentifier)
        {
        }
    }
}