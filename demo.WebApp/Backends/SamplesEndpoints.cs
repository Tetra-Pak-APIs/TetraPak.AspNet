using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesEndpoints : ServiceEndpoints
    {
        public ServiceEndpointUrl HelloWorld { get; set; }
        
        public SamplesEndpoints(ServicesAuthConfig servicesConfig, string sectionId = "SamplesServices") 
        : base(servicesConfig, sectionId)
        {
        }
    }
}