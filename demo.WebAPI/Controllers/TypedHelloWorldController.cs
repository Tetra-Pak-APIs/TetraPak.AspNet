using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TetraPak;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.AspNet.Auth;

namespace WebAPI.Controllers
{
    /// <summary>
    ///   This is an example of a typed Business API  Gateway controller.
    ///   It derives from a generic api gateway controller supporting a
    ///   custom endpoints class (<see cref="HelloWorldEndpointCollection"/>),
    ///   allowing for type-safe use of those endpoints and intellisense support when consuming the endpoints. 
    /// </summary>
    [ApiController]
    [Route("TypedHelloWorld")]
    [Authorize]
    public class TypedHelloWorldController : ControllerBase 
    {
        [HttpGet]
        public async Task<ActionResult> Get(string svc = null)
        {
            var userIdentity = User?.Identity;
            this.LogTrace($"GET /helloworld{(string.IsNullOrEmpty(svc) ? "" : $"svc={svc}")}");
            if (string.IsNullOrEmpty(svc))
                return Ok(new 
                { 
                    message = "Hello World!", 
                    remarks = "You can also try sending '?svc=tx' or '?svc=cc' to test token exchange or client "+
                              "credentials, consuming a downstream service",
                    userId = userIdentity?.Name ?? "(unresolved)" 
                } );

            switch (svc.ToLowerInvariant())
            {
                case "tx":
                    if (!await this.GetAccessTokenAsync())
                        return this.UnauthorizedError(
                            new Exception($"Cannot perform Token Exchange. No access token was passed in request"));
                        
                    // note This is an example of how you can use an indexer to fetch the endpoint:
                    return await this.RespondAsync(await this.Service<HelloWorldService>().Endpoints.HelloWorldWithTokenExchange.GetAsync());
                
                case "cc": 
                    // note This is an example of how you can use a POC property to fetch the endpoint:
                    return await this.RespondAsync(await this.Service<HelloWorldService>().Endpoints.HelloWorldWithClientCredentials.GetAsync());
                
                default:
                    return await this.RespondAsync(Outcome<object>.Fail(new Exception($"Invalid proxy value: '{svc}'")));
            }
        }
    }
    
    public class HelloWorldApiController : ApiGatewayController<HelloWorldService>
    {}
    
    public class HelloWorldService : BackendService<HelloWorldService.HelloWorldEndpoints>
    {
        public HelloWorldService(HelloWorldEndpoints endpointCollection, IHttpServiceProvider httpServiceProvider) 
        : base(endpointCollection, httpServiceProvider)
        {
        }
        
        public class HelloWorldEndpoints : ServiceEndpointCollection
        {
            public ServiceEndpoint HelloWorldWithTokenExchange => GetEndpoint();
            
            public ServiceEndpoint HelloWorldWithClientCredentials => GetEndpoint();
            
            public HelloWorldEndpoints(IServiceAuthConfig serviceAuthConfig, string sectionIdentifier = "Endpoints") 
            : base(serviceAuthConfig, sectionIdentifier)
            {
            }
        }
    }
}