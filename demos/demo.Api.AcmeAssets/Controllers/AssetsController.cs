using System.Threading.Tasks;
using demo.Acme.Models;
using demo.AcmeAssets.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TetraPak;
using TetraPak.AspNet.Api.Controllers;

namespace demo.AcmeAssets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class AssetsController : ControllerBase
    {
        readonly AssetsRepository _repository;
        
        [HttpGet]
        public async Task<ActionResult> Get(string? id = null)
        {
            var ids = (MultiStringValue)id;
            var outcome = ids.IsEmpty
                ? await _repository.ReadAsync(cancellation: HttpContext.RequestAborted)
                : await _repository.ReadAsync(ids.Items, cancellation: HttpContext.RequestAborted);

            return await this.RespondAsync(outcome);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Asset? asset)
        {
            if (asset is null)
                return this.RespondErrorBadRequest("Expected asset in body");

            return await this.RespondAsync(await _repository.CreateAsync(asset));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Asset? asset)
        {
            if (asset is null)
                return this.RespondErrorBadRequest("Expected asset in body");

            return await this.RespondAsync(await _repository.CreateOrReplaceAsync(asset));
        }
        
        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] Asset? asset)
        {
            if (asset is null)
                return this.RespondErrorBadRequest("Expected asset in body");

            return await this.RespondAsync(await _repository.UpdateAsync(asset));
        }
        
        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            return await this.RespondAsync(await _repository.DeleteAsync(id));
        }
        
        public AssetsController(AssetsRepository repository)
        {
            _repository = repository;
        }
    }
}