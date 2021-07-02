using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.BackendServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            return Ok(new { Message = "Hello World", UserId = User.Identity?.Name ?? "(anonymous)" }  );
        }
    }
}