using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    public class HelloWorldEndpoints : EndpointsConfig
    {
        // ReSharper disable NotAccessedField.Local
        BackendServiceEndpointUrl _helloWorld;
        // ReSharper restore NotAccessedField.Local

        public BackendServiceEndpointUrl HelloWorld
        {
            get => GetFromFieldThenSection<BackendServiceEndpointUrl>();
            set => _helloWorld = value;
        }
        
        public HelloWorldEndpoints(
            ServicesConfig servicesConfig,
            string sectionIdentifier = "HelloWorld") 
        : base(servicesConfig, sectionIdentifier)
        {
        }
    }
}