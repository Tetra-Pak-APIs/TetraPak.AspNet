using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TetraPak;
using TetraPak.AspNet;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Api.Controllers;
using WebAPI.services;

#nullable enable

namespace WebAPI.Controllers
{
    /// <summary>
    ///   <para>
    ///   This example shows how a controller can consume configured and typed backend services,
    ///   allowing for type-safety, intellisense support and a very convenient approach that will
    ///   have you focus on writing business logic and way less on boilerplate code such as getting your client
    ///   authorized for backend service consumption.
    ///   </para>
    ///   <para>
    ///   The typed service gets its configuration from the <see cref="IConfiguration"/> framework (appsettings.json),
    ///   via the sub section <see cref="ServiceAuthConfig.ServicesConfigName"/>.
    ///   </para>
    ///   <para>
    ///   <a href="https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/blob/master/TetraPak.AspNet.Api/README.md#backend-services">
    ///   Read more here!
    ///   </a>
    ///   </para>
    ///   <para>
    ///   <i><b>CAUTION!</b><br/>
    ///   This demo constitutes experimental code APIs that are not yet part of the official SDK.
    ///   Feel free to try it out and get back to us with feedback<br/>
    ///   - The API innovation team 2021-09-07</i>  
    ///   </para> 
    /// </summary>
    [ApiController]
    [Route("TypedHelloWorld")]
    [Authorize]
    public class TypedHelloWorldController : ControllerBase 
    {
        readonly HelloWorldService _helloWorldService;
        readonly GreetingsService _greetingsService;

        [HttpGet]
        public async Task<ActionResult> Get(string? svc = null, string? id = null)
        {
            var userIdentity = User?.Identity;
            this.LogTrace(() => 
                $"GET /helloworld{(string.IsNullOrEmpty(svc) ? "" : $"svc={svc}")}{(string.IsNullOrEmpty(id) ? "": $"greetingId={id}")}");
                
            if (string.IsNullOrEmpty(svc))
                return Ok(new 
                { 
                    message = "Hello World!", 
                    remarks = "You can also try sending '?svc=tx' or '?svc=cc' to test token exchange or client "+
                              "credentials, consuming a downstream service",
                    userId = userIdentity?.Name ?? "(unresolved)" 
                } );

            // transient API, using token exchange (TX) or client credentials (CC) ...
            HttpQueryParameters query = id is null
                ? null!
                : $"id={id}";
            switch (svc.ToLowerInvariant())
            {
                case "tx":
                    if (!await this.GetAccessTokenAsync())
                        return this.RespondErrorUnauthorized(
                            new Exception("Cannot perform Token Exchange. No access token was passed in request"));

                    // note This is an example of how you can use an indexer to fetch the endpoint:
                    return await this.RespondAsync(
                        await _helloWorldService.Endpoints["HelloWorldWithTokenExchange"]
                        .GetAsync(query));
                
                case "cc": 
                    // note This is an example of how you can use a POC property to fetch the endpoint:
                    return await this.RespondAsync(
                        await _helloWorldService.Endpoints.HelloWorldWithClientCredentials
                            .GetAsync(query)
                        );
                
                default:
                    return await this.RespondAsync(Outcome<object>.Fail(new Exception($"Invalid proxy value: '{svc}'")));
            }
        }

        // ReSharper disable once UnusedParameter.Local
        public TypedHelloWorldController(HelloWorldService helloWorldService, GreetingsService greetingsService) // <-- just inject the typed backend service
        {
            _helloWorldService = helloWorldService;
            _greetingsService = greetingsService;
        }
    }

    
}