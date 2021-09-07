using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TetraPak;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Api.Controllers;
using WebAPI.services;

namespace WebAPI.Controllers
{
    /// <summary>
    ///   This example shows how a controller can consume typed backend services,
    ///   allowing for type-safety and intellisense support. 
    /// </summary>
    [ApiController]
    [Route("TypedHelloWorld")]
    [Authorize]
    public class TypedHelloWorldController : ControllerBase 
    {
        readonly HelloWorldService _helloWorldService;

        [HttpGet]
        public async Task<ActionResult> Get(string svc = null)
        {
            var userIdentity = User?.Identity;
            this.LogTrace($"GET /helloworld{(string.IsNullOrEmpty(svc) ? "" : $"svc={svc}")}");
            if (string.IsNullOrEmpty(svc))
                return Ok(new 
                { 
                    message = "Hello World!", 
                    remarks = "You can also try sending '?svc=tx' or '?svc=cc' to test token exchange or client "+
                              "credentials, consuming a downstream service",
                    userId = userIdentity?.Name ?? "(unresolved)" 
                } );

            switch (svc.ToLowerInvariant())
            {
                case "tx":
                    if (!await this.GetAccessTokenAsync())
                        return this.UnauthorizedError(
                            new Exception($"Cannot perform Token Exchange. No access token was passed in request"));

                    // note This is an example of how you can use an indexer to fetch the endpoint:
                    return await this.RespondAsync(await _helloWorldService.Endpoints["HelloWorldWithTokenExchange"].GetAsync());
                
                case "cc": 
                    // note This is an example of how you can use a POC property to fetch the endpoint:
                    return await this.RespondAsync(await _helloWorldService.Endpoints.HelloWorldWithClientCredentials.GetAsync());
                
                default:
                    return await this.RespondAsync(Outcome<object>.Fail(new Exception($"Invalid proxy value: '{svc}'")));
            }
        }

        // ReSharper disable once UnusedParameter.Local
        public TypedHelloWorldController(HelloWorldService helloWorldService) // <-- you need to add a TetraPakServices parameter
        {
            _helloWorldService = helloWorldService;
        }
    }
}