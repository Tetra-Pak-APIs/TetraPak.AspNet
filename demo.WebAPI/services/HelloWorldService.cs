using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Api;

namespace WebAPI.services
{
    /// <summary>
    ///   <para>
    ///   This is a typed backend service that gets its configuration (endpoints and auth) from the
    ///   <see cref="IConfiguration"/> framework (<c>appsettings.json</c> file[s]). 
    ///   </para>
    ///   <para>
    ///   <a href="https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/blob/master/TetraPak.AspNet.Api/README.md#backend-services">
    ///   Read more here!
    ///   </a>
    ///   </para>
    ///   <para>
    ///   <i><b>CAUTION!</b><br/>
    ///   This demo constitutes experimental code APIs that are not yet part of the official SDK.
    ///   Feel free to try it out and get back to us with feedback<br/>
    ///   - The API innovation team 2021-09-07</i>  
    ///   </para> 
    /// </summary>
    [BackendService("HelloWorld")]
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