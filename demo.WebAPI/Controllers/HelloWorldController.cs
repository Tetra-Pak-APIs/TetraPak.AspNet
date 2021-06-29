using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using TetraPak;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.AspNet.Auth;
using TetraPak.Caching;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HelloWorldController : ControllerBase 
    {
        readonly IClientCredentialsService _credentialsService;
        readonly ITimeLimitedRepositories _cache;

        const string HelloWorldHost = "https://localhost:5003";

        [HttpGet]
        public async Task<ActionResult> Get(bool proxy = false)
        {
            var userIdentity = User.Identity;
            this.LogDebug($"GET /helloworld{(proxy ? "proxy=true" : "")}");
            if (!proxy)
                return Ok(new { message = "Hello World!", userId = userIdentity.Name ?? "(unresolved)" } );

            var cache = _cache;
            
            fetch:

            var clientOutcome = await _credentialsService.GetAuthorizedClientAsync(cache);
            if (!clientOutcome)
                return clientOutcome.IsUnauthorized()
                    ? this.UnauthorizedError(clientOutcome.Exception)                              
                    : this.InternalServerError(clientOutcome.Exception);

            var client = clientOutcome.Value.HttpClient;
            var isTokenCached = clientOutcome.Value.IsTokenCached;
            var response = await client.GetAsync($"{HelloWorldHost}/helloworld"); // <-- ersätt med ett riktigt anrop
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    if (!isTokenCached) 
                        return Unauthorized();
                    
                    cache = null;
                    goto fetch;
                }                    
                    
                var content = await response.Content.ReadAsStringAsync();
                return this.InternalServerError(new Exception(content));
            }

            var stream = await response.Content.ReadAsStreamAsync();
            var messageResponse = await JsonSerializer.DeserializeAsync<MessageResponse>(stream);
            return Ok(messageResponse);
        }

        class MessageResponse
        {
            [JsonPropertyName("message")]
            public string Message { get; set; }

            [JsonPropertyName("userId")]
            public string UserId { get; set; }
        }

        public HelloWorldController(
            TetraPakApiAuthConfig config,
            IClientCredentialsService credentialsService,
            ITimeLimitedRepositories cache)
        {
            this.Configure(config);
            _credentialsService = credentialsService;
            _cache = cache;
        }
    }

    public static class HelloWorldHelper 
    {
        const string TokensCache = "ServiceTokens";
        const string HelloWorldToken = "hello_world_access_token";
        
        internal static async Task<Outcome<AuthorizedClient>> GetAuthorizedClientAsync(
            this IClientCredentialsService credentialsService,
            ITimeLimitedRepositories cache,
            HttpClient client = null,
            CancellationToken? cancellationToken = null)
        {
            // ensure a passed in client isn't already authorizing ...
            if (client is {} && client.DefaultRequestHeaders.TryGetValues(HeaderNames.Authorization, out _))
                return Outcome<AuthorizedClient>.Fail(new InvalidOperationException(
                    $"The '{HeaderNames.Authorization}' header cannot be assigned"));
            
            ActorToken token = null;
            var isTokenCached = false;
            if (cache is { })
            {
                var cachedOutcome = await cache.getHelloWorldToken();
                token = cachedOutcome ? cachedOutcome.Value : null;
                isTokenCached = token is {};
            }

            if (token is null)
            {
                var tokenOutcome = await credentialsService.AcquireTokenAsync(cancellationToken ?? new CancellationToken());
                if (!tokenOutcome)
                    return Outcome<AuthorizedClient>.Fail(tokenOutcome.Exception);

                token = tokenOutcome.Value.AccessToken;
                await cache.setHelloWorldToken(tokenOutcome.Value);
            }

            client ??= new HttpClient();
            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
            return Outcome<AuthorizedClient>.Success(new AuthorizedClient(client, isTokenCached));
        }

        static async Task<Outcome<ActorToken>> getHelloWorldToken(this ITimeLimitedRepositories cache)
        {
            return cache is { }
                ? await cache.GetAsync<ActorToken>(TokensCache, HelloWorldToken)
                : Outcome<ActorToken>.Fail(new ArgumentNullException(nameof(cache)));
        }

        static async Task setHelloWorldToken(this ITimeLimitedRepositories cache, ClientCredentialsResponse response)
        {
            if (cache is null)
                return;
                
            if (response.ExpiresIn == TimeSpan.Zero)
            {
                await cache.AddAsync(TokensCache, HelloWorldToken, response.AccessToken);
                return;
            }

            var expiresIn = response.ExpiresIn.Subtract(TimeSpan.FromSeconds(2));
            await cache.AddAsync(TokensCache, HelloWorldToken, response.AccessToken, expiresIn);
        }
        
    }

    public class AuthorizedClient 
    {
        public HttpClient HttpClient { get; }

        public bool IsTokenCached { get; }

        public AuthorizedClient(HttpClient httpClient, bool isTokenCached)
        {
            HttpClient = httpClient;
            IsTokenCached = isTokenCached;
        }
    }
    
}