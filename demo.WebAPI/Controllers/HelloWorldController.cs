using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HelloWorldController : ControllerBase
    {
        readonly ILogger<HelloWorldController> _log;

        [HttpGet]
        public ActionResult Get()
        {
            var userIdentity = User.Identity;
            _log.Debug("GET /helloworld");
            return Ok(new { message = "Hello World!", userId = userIdentity.Name ?? "(unresolved)" } );
        }
        
        public HelloWorldController(ILogger<HelloWorldController> log)
        {
            _log = log;
        }
    }
}