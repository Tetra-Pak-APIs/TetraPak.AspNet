using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;
using WebAPI.services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [Authorize]
    public class HelloWorldController : ApiGatewayController<BackendService<HelloWorldEndpoints>>
    {
        [HttpGet]
        public async Task<ActionResult> Get(bool proxy = false)
        {
            var userIdentity = User.Identity;
            this.LogDebug($"GET /helloworld{(proxy ? "proxy=true" : "")}");
            if (!proxy)
                return Ok(new { message = "Hello World!", userId = userIdentity.Name ?? "(unresolved)" } );

            return await OutcomeResultAsync(await Service.Endpoints.HelloWorld.GetAsync());
        }

        public HelloWorldController(BackendService<HelloWorldEndpoints> service, TetraPakApiAuthConfig config)
        : base(service, config)
        {
        }
    }
}