using System;
using System.Net;
using System.Threading.Tasks;
using demo.BackendServiceAPI.Data;
using demo.BackendServiceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TetraPak;
using TetraPak.AspNet.Api.Controllers;

#nullable enable

namespace demo.BackendServiceAPI.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class GreetingsController : ControllerBase
    {
        readonly GreetingsRepository _repository;

        [HttpGet]
        public async Task<ActionResult> Get() => this.RespondOk(await _repository.ReadAsync());

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GreetingDTO? greeting)
        {
            if (greeting is null)
                return this.RespondBadRequestError("Expected a greetings object in body");
                
            if (await _repository.ContainsAsync(greeting.Id))
                return this.RespondError(
                    HttpStatusCode.Conflict,
                    new Exception("A greetings entry was already posted. Try PUT och PATCH instead"));

            var outcome = await _repository.CreateOrUpdateAsync(greeting);
            return outcome
                ? this.RespondOk(Request.ResourceLocatorForId(outcome.Value!))
                : this.RespondBadRequestError(outcome.Exception);
        }
        
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] GreetingDTO? greeting)
        {
            if (greeting is null)
                return this.RespondBadRequestError("Expected a greetings object in body");
                
            var statusCode = await _repository.ContainsAsync(greeting.Id)
                ? HttpStatusCode.Accepted
                : HttpStatusCode.Created;

            var outcome = await _repository.CreateOrUpdateAsync(greeting);
            return outcome
                ? this.RespondStatus(statusCode, EnumOutcome<string>.Success(new[] { outcome.Value! }))
                : this.RespondBadRequestError(outcome.Exception); 
        }

        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] GreetingDTO? greeting)
        {
            if (greeting is null)
                return this.RespondBadRequestError("Expected a greetings object in body");

            if (!await _repository.ContainsAsync(greeting.Id))
                return this.RespondBadRequestError("No greetings entry was posted yet. Please use POST");

            var outcome = await _repository.UpdateAsync(greeting);
            return outcome 
                ? this.RespondAcceptedOk(outcome.Value!) 
                : this.RespondInternalServerError(outcome.Exception);
        }

        public GreetingsController(GreetingsRepository repository)
        {
            _repository = repository;
        }
    }
}