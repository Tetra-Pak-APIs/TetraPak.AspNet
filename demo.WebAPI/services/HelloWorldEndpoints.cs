using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    /// <summary>
    ///   Typed endpoints, instantiated by <see cref="TetraPakControllerFactory"/>.
    /// </summary>
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