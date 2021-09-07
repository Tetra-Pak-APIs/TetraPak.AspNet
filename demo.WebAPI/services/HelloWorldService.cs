using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    // [BackendService("HelloWorld")]
    public class HelloWorldService : BackendService<HelloWorldService.HelloWorldEndpoints>
    {
        public HelloWorldService(HelloWorldEndpoints endpoints) 
        : base(endpoints)
        {
        }
        
        public class HelloWorldEndpoints : ServiceEndpoints
        {
            public ServiceEndpoint HelloWorldWithClientCredentials => GetEndpoint();

            public ServiceEndpoint HelloWorldWithTokenExchange => GetEndpoint();
        }
    }
}