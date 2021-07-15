using TetraPak.AspNet.Api;
using TetraPak.AspNet.Auth;

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
        
        public HelloWorldEndpoints(IServiceAuthConfig serviceConfig, string sectionIdentifier = "HelloWorld") 
        : base(serviceConfig, sectionIdentifier)
        {
        }
    }
}