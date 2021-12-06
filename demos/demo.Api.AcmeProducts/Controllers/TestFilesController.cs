using System.Threading.Tasks;
using demo.AcmeProducts.Services;
using Microsoft.AspNetCore.Mvc;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Api.Controllers;

namespace demo.AcmeProducts.Controllers
{
    /// <summary>
    ///   This controller was made to experiment with streaming large files via backend services.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TestFilesController : ControllerBase
    {
        readonly AssetsService _assetsService;

        [HttpGet, Route("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var outcome = await _assetsService.Endpoints.Files.GetStreamAsync(new { Id = id });
            return await this.RespondAsync(outcome);
        }

        public TestFilesController(AssetsService assetsService)
        {
            _assetsService = assetsService;
        }
    }
}