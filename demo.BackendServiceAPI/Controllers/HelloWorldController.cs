using System.Linq;
using System.Threading.Tasks;
using demo.BackendServiceAPI.Data;
using demo.BackendServiceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#nullable enable

namespace demo.BackendServiceAPI.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class HelloWorldController: ControllerBase
    {
        readonly GreetingsRepository _repository;

        [HttpGet]
        public async Task<ActionResult> Get(string? id = null)
        {
            var readOutcome = await _repository.ReadAsync(id);
            var greeting = readOutcome ? readOutcome.Value!.First() : new GreetingDTO();
            return Ok(new {
                Message = greeting.GetMessage(), 
                UserId = User.Identity?.Name ?? "(anonymous)" });
        }

        public HelloWorldController(GreetingsRepository repository)
        {
            _repository = repository;
        }
    }
}