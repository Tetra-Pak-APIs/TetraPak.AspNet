using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TetraPak;
using TetraPak.AspNet;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("HelloWorld")]
    [Authorize]
    public class HelloWorldController : ControllerBase
    {
        readonly ITokenExchangeService _tokenExchangeService;

        /// <summary>
        ///   <para>
        ///   This example shows how your API can consume a "downstream" service.
        ///   In doing so your API needs to be authorized. This is done by exchanging
        ///   the actor's token for a service token using the "Token Exchange" authorization flow.
        ///   </para>
        ///   <para>
        ///   The code is still quite involved and naive, and does not provide a good mechanism for
        ///   caching the needed access token to avoid performing a token exchange for every request.
        ///   </para>
        ///   <para>
        ///   Still, it may serve as a good starting point for your coding.</para>
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var accessToken = await this.GetAccessTokenAsync();
            if (!accessToken)
                return this.UnauthorizedError(new Exception("No valid access token found"));

            if (!this.TryGetTetraPakApiAuthConfig(out var authConfig))
                return this.InternalServerError(new Exception("Service is incorrectly configured"));

            var credentials = new BasicAuthCredentials(authConfig.ClientId, authConfig.ClientSecret);
            var ct = new CancellationToken();
            var tx = await _tokenExchangeService.ExchangeAccessTokenAsync(credentials, accessToken, ct);
            if (!tx)
                return this.InternalServerError(new Exception("Service is incorrectly configured"));

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tx.Value.AccessToken);
            var response = await client.GetAsync("https://api-dev.tetrapak.com/samples/helloworld", ct);
            return await this.RespondAsync(await response.ToOutcomeAsync()); 
        }

        /// <summary>
        ///   Initializes the controller.
        /// </summary>
        /// <param name="tokenExchangeService">
        ///   A token exchange service.
        ///   This service becomes available for dependency injection when you call
        ///   <see cref="TetraPakApiAuth.AddTetraPakJwtBearerAssertion"/> (see <see cref="Startup.ConfigureServices"/>).
        /// </param>
        public HelloWorldController(ITokenExchangeService tokenExchangeService)
        {
            _tokenExchangeService = tokenExchangeService;
        }
    }
}
