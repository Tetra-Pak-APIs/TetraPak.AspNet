using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    public class HelloWorldEndpoints : ServiceEndpoints
    {
        public ServiceEndpoint HelloWorldWithClientCredentials => GetEndpoint();

        public ServiceEndpoint HelloWorldWithTokenExchange => GetEndpoint();
        
        public HelloWorldEndpoints(ServicesAuthConfig servicesConfig, string sectionIdentifier = "HelloWorld") 
        : base(servicesConfig, sectionIdentifier)
        {
        }
    }
}