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

#nullable enable

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HelloWorldController : ControllerBase
    {
        readonly ITokenExchangeService _tokenExchangeService;
        readonly TetraPakAuthConfig _tetraPakConfig;

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
            var actorTokenOutcome = await this.GetAccessTokenAsync();
            if (!actorTokenOutcome)
                return this.UnauthorizedError(actorTokenOutcome.Exception);

            var credentials = new BasicAuthCredentials(_tetraPakConfig.ClientId, _tetraPakConfig.ClientSecret);
            var ct = new CancellationToken();
            var txOutcome = await _tokenExchangeService.ExchangeAccessTokenAsync(credentials, actorTokenOutcome!, ct);
            if (!txOutcome)
                return this.InternalServerError(new ConfigurationException("Service is incorrectly configured"));

            var apiAccessToken = txOutcome.Value!.AccessToken;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiAccessToken);
            var response = await client.GetAsync("https://api-dev.tetrapak.com/samples/helloworld", ct);
            return await this.RespondAsync(await response.ToOutcomeAsync()); 
        }

        [AllowAnonymous]
        [HttpGet, Route("version")]
        public Task<ActionResult> GetVersion()
        {
            var data = new { Version = typeof(Startup).Assembly.GetName().Version?.ToString() ?? "(unknown)" };
            return this.RespondAsync(Outcome<object>.Success(data));
        }

        /// <summary>
        ///   Initializes the controller.
        /// </summary>
        /// <param name="tokenExchangeService">
        ///   A token exchange service.
        ///   This service becomes available for dependency injection when you call
        ///   <see cref="TetraPakApiAuth.AddTetraPakJwtBearerAssertion"/> (see <see cref="Startup.ConfigureServices"/>).
        /// </param>
        public HelloWorldController(TetraPakAuthConfig tetraPakConfig, ITokenExchangeService tokenExchangeService)
        {
            _tetraPakConfig = tetraPakConfig;
            _tokenExchangeService = tokenExchangeService;
        }
    }

    
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        readonly IClientCredentialsService _clientCredentialsService;
        readonly IOrdersService _ordersService;

        [HttpGet]
        [Route("/{id?}")]
        public async Task<ActionResult> Get(string? id)
        {
            ActorToken clientAccessToken;
            Outcome<ActorToken> cachedTokenOutcome = await getCachedAccessTokenAsync();
            if (cachedTokenOutcome)
            {
                clientAccessToken = cachedTokenOutcome.Value!;
            }
            else
            {
                Outcome<ClientCredentialsResponse> ccOutcome = await _clientCredentialsService.AcquireTokenAsync();
                if (!ccOutcome)
                    return this.UnauthorizedError(ccOutcome.Exception);

                clientAccessToken = ccOutcome.Value!.AccessToken;
            }

            EnumOutcome<Order> readOrdersOutcome = await _ordersService.ReadAsync(clientAccessToken, id);
            return await this.RespondAsync(readOrdersOutcome);

        }

        async Task<Outcome<ActorToken>> getCachedAccessTokenAsync()
        {
            throw new NotImplementedException();
        }

        public OrdersController(IClientCredentialsService clientCredentialsService, IOrdersService ordersService)
        {
            _clientCredentialsService = clientCredentialsService;
            _ordersService = ordersService;
        }
    }
    
    public interface IOrdersService
    {
        Task<EnumOutcome<Order>> ReadAsync(ActorToken clientAccessToken, string? id);
    }
    
    public class Order
    {}
}
