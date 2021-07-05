using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    public class HelloWorldEndpoints : ServiceEndpoints
    {
        // ReSharper disable NotAccessedField.Local
        ServiceEndpointUrl _helloWorld;
        // ReSharper restore NotAccessedField.Local

        public ServiceEndpointUrl HelloWorld
        {
            get => GetFromFieldThenSection<ServiceEndpointUrl>();
            set => _helloWorld = value;
        }
        
        public HelloWorldEndpoints(
            ServicesAuthConfig servicesConfig,
            string sectionIdentifier = "HelloWorld") 
        : base(servicesConfig, sectionIdentifier)
        {
        }
    }
}