using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TetraPak;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Api.Controllers;
using WebAPI.services;

namespace WebAPI.Controllers
{
    /// <summary>
    ///   This is an example of a typed Business API  Gateway controller.
    ///   It derives from a generic api gateway controller supporting a
    ///   custom endpoints class (<see cref="HelloWorldEndpoints"/>),
    ///   allowing for type-safe use of those endpoints and intellisense support when consuming the endpoints. 
    /// </summary>
    [ApiController]
    [Route("HelloWorld")]
    [BackendService("HelloWorld")]
    // [Authorize]
    public class TypedHelloWorldController : HelloWorldApiController 
    {
        [HttpGet]
        public async Task<ActionResult> Get(string svc = null)
        {
            var userIdentity = User?.Identity;
            this.LogDebug($"GET /helloworld{(string.IsNullOrEmpty(svc) ? "" : $"svc={svc}")}");
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
                    if (!await GetAccessTokenAsync())
                        return UnauthorizedError(
                            new Exception($"Cannot perform Token Exchange. No access token was passed in request"));
                        
                    // note This is an example of how you can use an indexer to fetch the endpoint:
                    return await RespondAsync(await Service.Endpoints.HelloWorldWithTokenExchange.GetAsync());
                
                case "cc": 
                    // note This is an example of how you can use a POC property to fetch the endpoint:
                    return await RespondAsync(await Service.Endpoints.HelloWorldWithClientCredentials.GetAsync());
                
                default:
                    return await RespondAsync(Outcome<object>.Fail(new Exception($"Invalid proxy value: '{svc}'")));
            }
        }
    }
    
    public class HelloWorldApiController : ApiGatewayController<HelloWorldService>
    {}
    
    public class HelloWorldService : BackendService<HelloWorldEndpoints>
    {
        public HelloWorldService(
            HelloWorldEndpoints endpoints, 
            IHttpServiceProvider httpServiceProvider) 
        : base(endpoints, httpServiceProvider)
        {
        }
    }
}