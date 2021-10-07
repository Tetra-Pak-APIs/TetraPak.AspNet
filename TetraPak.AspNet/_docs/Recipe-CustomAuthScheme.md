# Recipe: Adding a custom auth scheme

> The examples in this recipe assumes you are adding a customized auth scheme to an API. The recipe will be the same for web applications however.

If you are writing a new API you will, very likely, be able to rely on the offered default authentication scheme (which is called "`Bearer`"), by just adding "Tetra Pak JWT Assertion" to you `Startup.ConfigureServices` method:

```c#
services.AddTetraPakJwtBearerAssertion();
```

However, if you are adjusting an existing API and/or need supporting some other auth scheme for some reason this can be done quite easily. These are the items you must do or consider:

- (must) Write (or find) a custom authentication classes to implement the auth scheme
- (must) Configure auth schemes in `Startup.ConfigureServices` with unique schema names
- (must) Specify auth schema names for all protected resources (controllers/endpoint methods)
- (consider) Adding a custom claims transformer
- (consider) Muting the DevProxy (for legacy auth schemes)

For sake if clarity we are going to assume you need an extremely basic auth scheme, let's call it "AliBaba" (if you are unfamiliar with that muslim hero please go read up on the tale of [Ali Baba and the Forty Thieves](https://en.wikipedia.org/wiki/Ali_Baba_and_the_Forty_Thieves)). 

The auth scheme assumes the client simply authenticate using [Basic Authentication](https://swagger.io/docs/specification/authentication/basic-authentication/), which simply means the client sends its credentials (user's identity and secret password) as a Base-64 encoded string in the "Authorization" header. This scheme is not to be used normally but will serve for this example as we're not really concerned with security right now. Hopefully, by using an extremely simple auth scheme like this the mechanism for implementing a more potent auth scheme can be understood.

## Implementing the custom auth scheme

To implement a custom auth scheme you start with writing two classes:

- A custom authenticator
- A class to support custom options for your authenticator

Probably, we wouldn't need any options for a simple auth scheme like this but here's just a quick example to give you an idea:

```c#
class AliBabaAuthenticationOptions : AuthenticationSchemeOptions
{
    // add any options here
}
```

The options needs to derive from `AuthenticationSchemeOptions` and you can add any options you need for your auth scheme to the class. 

We can now go on and implement the "Ali Baba" authenticator, which needs to derive from [`AuthenticationHandler<TOptions>`][code-AuthenticationHandler-T]: 

```c#
class AliBabaAuthenticationHandler : AuthenticationHandler<AliBabaAuthenticationOptions>
{
    readonly TetraPakConfig _tetraPakConfig;
    const string ExpectedSecret = "Open Sesame!";
    
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // get token from request and try parsing it as Basic Authentication credentials ...
        var tokenOutcome = await Context.GetAccessTokenAsync(_tetraPakConfig);
        if (!tokenOutcome)
            return AuthenticateResult.Fail("No authorization found");

        var token = tokenOutcome.Value!;
        var credentials = BasicAuthCredentials.Parse(token);
        if (credentials is null)
            return AuthenticateResult.Fail("Invalid token");
        
        // assert the secret is the expected one ...        
        if (credentials.Secret != ExpectedSecret)
            return AuthenticateResult.Fail("Invalid token");

        // construct a claims principal and return a successful authentication result...
        var claims = new[]
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, credentials.Identity),
            new Claim(ClaimTypes.Email, $"{credentials.Identity}@thieves.org")
        };
        var claimsIdentity = new ClaimsIdentity(claims, AliBabaAuthentication.Scheme);
        var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
    
    public AliBabaAuthenticationHandler(IOptionsMonitor<AliBabaAuthenticationOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder, 
        ISystemClock clock,
        TetraPakConfig tetraPakConfig) 
        : base(options, logger, encoder, clock)
    {
        _tetraPakConfig = tetraPakConfig;
    }
}
```

The code is fairly straight forward:
- We start with getting the request security token from the request context and then try parsing it as `BasicAuthCredentials` (and deals with failure, due to the token not being found or not of the expected "basic auth" format).

- We then simply compare the `BasicAuthCredentials.Secret` property value with the expected secret (always "Open Sesame!), returning a failed `AuthenticateResult` if they're not matching.
  > Yes, using the same secret for all actors is of course not good idea but let's keep things simple, right? In a more realistic scenario you would probably consult some service to fetch the actor's secret and then match that value instead, involving hashing as you go. But that's beyond the purpose of this recipe.
  
- When the authentication succeeds we construct a [`ClaimsPrincipal`][code-ClaimsPrincipal] object and add two claims to it:
  - Actor's identity 
  - Actor's email address, which is simply concatenating the actor's id with "@thieves.org"

So, the idea is that a client just makes requests to the API, passing her identity and the secret password ("Open Sesame!") as "basic authentication" credentials. Anyone who knows the secret password will be authorized into the merry band of the 40 thieves! Not so safe but very simple indeed.

## Adding custom auth scheme to API

With the custom auth scheme implementation done we are now ready to configure our API to support it. This is done in the `Startup.ConfigureServices`, like in this example: 

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
            
    // add default Tetra Pak scheme and our own "Ali Baba" scheme ...
    services.AddTetraPakJwtBearerAssertion()
            .AddScheme<AliBabaAuthenticationOptions,AliBabaAuthenticationHandler>("AliBaba", null);
```

The `IServiceCollection.AddScheme<TOptions,TAuthenticator>` is the "raw" option for adding an authentication scheme to the service collection. Oftentimes, this is encapsulated into a more "readable" method that also adds other services, required for the auth scheme to function (this is how `AddTetraPakJwtBearerAssertion` does it).

With this, all incoming requests will be authenticated either by the default (Tetra Pak JWT Bearer Assertion) scheme or our custom "AliBaba" scheme. For resources (controllers and methods) decorated with just the `[Authorize]` attribute the default scheme will be invoked so you now need to specify which scheme to use for your various protected resources.

You can choose to have some resources protected by the default scheme and others by the "AliBaba" scheme, like with this hypothetical controller:

```c#
[ApiController]
[Route("[controller]")]
[Authorize]
public class HypotheticController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult> Get()
    {
        var data = new { Message = $"Welcome, {User.Name()}, to the default endpoint!" };
        return this.RespondAsync(Outcome<object>.Success(data));
    }

    [Authorize(AuthenticationSchemes = "AliBaba")]
    [HttpGet, Route("thieves")]
    public Task<ActionResult> GetThieves()
    {
        var data = new { Message = $"Welcome, {User.Name()}, to the marry band of 40 thieves!" };
        return this.RespondAsync(Outcome<object>.Success(data));
    }
    
    [Authorize(AuthenticationSchemes = "Bearer,AliBaba")]
    [HttpPost, Route("messages")]
    public Task<ActionResult> PostMessage([FromBody] MessageModel model)
    {
        var data = new { Message = $"{User.Name()} says '{model.Message ?? "?"}'" };
        return this.RespondAsync(Outcome<object>.Success(data));
    }
}
```

In this controller:

- The `Get` (default path: `/hypothetic`) method is protected by the default (Tetra Pak JWT Bearer Assertion) scheme. This is because the whole controller is protected that way (no scheme is specified by the `[Authorize]` attribute that decorates the class).

- The `GetThieves` method (path: `/hypothetic/thieves`) will only be protected by the "AliBaba" auth scheme. This is stated by the `[Authorize(AuthenticationSchemes = "AliBaba")]` method attribute.

- The `PostMessage` method (path: `/hypothetic/messages`) will be protected by any of the default and "AliBaba" schemes. The attribute states the scheme identifiers in a comma-separated string: `[Authorize(AuthenticationSchemes = "Bearer,AliBaba")]`

## Concluding

Think carefully whether you actually need a custom auth scheme! You might find that the default auth scheme would work fine but needs some missing feature. If so, please suggest it on the [project site][repo-tetrapak-aspnet-issues]! 

Of course, there might be good reasons to roll your own auth scheme after all, such as supporting legacy protocols or clients. For those scenarios please consider your process for retiring those clients or protocols, or deploy new versions of them to support the recommended auth schemes at Tetra Pak as you move forward. Keeping things simple is not only healthy but also more secure! 
 
Hopefully, this recipe will have clarified how to roll your own auth scheme! If not, feel free to [suggest improvements][repo-tetrapak-aspnet-issues]. Also, when you do implement your own custom auth scheme there is sometimes a need to also make adjustments to how the actor's identity is being constructed. You might have to add some extra [claims][cat-claim] to the [`ClaimsPrincipal`][code-ClaimsPrincipal] carried by the request/response context ([HttpContext][code-HttpContext]). This is done via the [Claims Transformation][cat-claims-transformation] mechanism. if you see a need for this then please continue to [this recipe for implementing your own custom claims transformer][recipe-custom-claims-transformation], where the examples from this recipe will be reused.

[cat-claim]: ../../CAT.md#claim
[cat-claims-transformation]: ../../CAT.md#claims-transformation 
[cat-identity]: ../../CAT.md#identity

[code-AuthenticationHandler-T]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1
[code-ClaimsPrincipal]: https://docs.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal
[code-HttpContext]: https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext

[recipe-custom-claims-transformation]: Recipe-CustomClaimsTransformation.md 

[repo-tetrapak-aspnet-issues]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/issues