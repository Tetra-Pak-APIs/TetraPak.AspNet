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
            _log.Debug("GET /helloworld");
            return Ok("Hello World!");
        }
        
        public HelloWorldController(ILogger<HelloWorldController> log)
        {
            _log = log;
        }
    }
}