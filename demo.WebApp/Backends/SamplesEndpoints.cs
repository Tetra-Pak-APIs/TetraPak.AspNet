using TetraPak.AspNet.Api;

namespace demo.WebApp.Backends
{
    public class SamplesEndpoints : ServiceEndpoints
    {
        public ServiceEndpoint HelloWorld { get; set; }
        
        public SamplesEndpoints(ServiceAuthConfig serviceConfig, string sectionId = "SamplesServices") 
        : base(serviceConfig, sectionId)
        {
        }
    }
}