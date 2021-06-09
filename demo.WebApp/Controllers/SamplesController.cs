using System.Threading.Tasks;
using demo.WebApp.Backends;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;

namespace demo.WebApp.Controllers
{
    public class SamplesController : ApiGatewayController<SamplesService>
    {
        [HttpGet]
        public async Task<ActionResult> HelloWorld()
        {
            return Ok("Hello World");

            // var url = Backend.Endpoints.HelloWorld
        }
        
        public SamplesController(
            SamplesService backend, 
            TetraPakApiAuthConfig authConfig) 
        : base(backend, authConfig)
        {
        }
    }
}