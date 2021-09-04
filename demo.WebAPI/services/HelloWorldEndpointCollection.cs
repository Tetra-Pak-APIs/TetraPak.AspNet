using TetraPak.AspNet.Api;
using TetraPak.AspNet.Auth;

namespace WebAPI.services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    /// <summary>
    ///   Typed endpoints, instantiated by <see cref="TetraPakControllerFactory"/>.
    /// </summary>
    public class HelloWorldEndpointCollection : ServiceEndpointCollection
    {
        public ServiceEndpoint HelloWorldWithClientCredentials => GetEndpoint();

        public ServiceEndpoint HelloWorldWithTokenExchange => GetEndpoint();
        
        public HelloWorldEndpointCollection(IServiceAuthConfig serviceConfig, string sectionIdentifier = "HelloWorld") 
        : base(serviceConfig, sectionIdentifier)
        {
        }
    }
}