# TetraPak.AspNet SDK - Concepts and Terms

The security and API management domains are filled with terms, many to describe the same concept. This document is just a convenient go-to for those terms and concepts referred to by the other SDK documents.

Each term/concept is presented as a separate section and in alphabetical order.

## Actor

We use the term "`actor`" for *the acting party that initiated a request*. This can be a human or some autonomous service. The actor must be recognized as an `identity` by the Tetra Pak Auth Services (TPAS)

See also: [Identity](#identity)

## API

-- TODO --

## API key

See: [Client ID](#client-id)

## API manager

A Tetra Pak resource with access to- and know-how of the [API management system](#api-management-system). A typical API development project is (currently) assumed to have one such resource assigned to it. This might change in the future as the 

## API management

The process of publishing, maintaining, designing, documenting, analyzing and protecting APIs, usually implemented by an organization that owns and maintains those APIs. Such organizations usually rely on ["API management" systems](#api-management-system) to offer a pleasant API experience for its consumers while maintaining security and building insight for continuous improvements.

Managing a growing suite of APIs creates the need for data consumers to explore and discover them. This can be achieved through some form av "portal", such as the [Tetra Pak Developer Portal][dev-portal], where [API products](#product) can be found, along with information about the product, how to get access to it and how to consume it.

### API management patterns

One or more security patterns, designed to provide a very high level of security while allowing for good performance in APIs. 

Tetra Pak implements multiple security patterns for its (reusable) [business APIs](#business-api), all built on the foundation of [API sidecars](#sidecar). One such security pattern is the [JWT bearer assertion](#jwt-bearer-assertion) pattern.

### API management system

Aliases: "API management platform"

-- TODO --

## Apigee Edge

The [API management system](#api-management-system) product used by Tetra Pak. Apigee was a company now acquired by Google. 

See also: ([official product page](https://cloud.google.com/apigee/))

## App (registration)

Aliases: [Client](#client)
See also: [Client id](#client-id), [Client secret](#client-secret)

## Asynchronous outcome

In programming you often find a need to reflect an "outcome" of an operation. A good example of this is parsing string values to a .NET type, such as with [`int.TryParse(string? s, out int result)`](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-5.0#System_Int32_TryParse_System_String_System_Int32__). Invoking that method will produce two pieces of information you need:
- Whether or not the parsing operation was successful 
- The `Int32` value if the operation succeeded

This type of code APIs are very convenient (unless you're a purist that gets runny eyes from `out` parameters) but they will only work with *synchronous* methods. When you rely on the `async` patterns of .NET you can no longer enjoy `out` parameters.

For this reason the `TetraPak.Common` library ([Nuget][nuget-tetrapak-common]) offers the [Outcome&lt;T&gt;][md-Outcome-T] and [EnumOutcome&lt;T&gt;][md-EnumOutcome-T] classes.

## Audience

In OAuth 2 the *audience* identifies an intended resource service to be accessed with a [bearer token](#bearer-token).

[Bearer tokens](#bearer-token) must be kept and sent in a cryptographically securely manner but to minimize the "risk surface" (if the token nevertheless gets stolen) the [bearer tokens](#bearer-token) cannot be used for any other service (audience) than the one it was originally issued for.

## Auth

A conveniently short word that might mean [authentication](#authentication), [authorization](#authorization), or both.

## Authentication

The process of making sure the responsible [actor](#actor) is indeed who she claims to be. The actor might be human or another software service (such as a web job, daemon or some other process). There are many ways to authenticate an actor, which are usually referred to as [`schemes`](#authentication-scheme) (ASP.NET) or *flows* (OAuth). 

See also: [Actor](#actor), [Authorization](#authorization), [Identity](#identity), [Scheme](#authentication-scheme)

## Authentication scheme

In ASP.NET an authentication scheme refers to a particular mechanism (a.k.a. *flow* or *grant* in OAuth) for authenticating the [actor](#actor) responsible for making a request.

Each [`scheme`](#authentication-scheme) supports a certain type of actor. For human actors the [OAuth Code Grant][oauth-code-grant] flow is often very popular as it allows a human actor a way to authenticate herself with an authority that is separate from the service asking for the actor's permission to act on her behalf, while also ensuring that service can never get access to the actor's secrets (such as a password). This is an example of a "three-legged auth flow".

For non-human [actors](#actor) the [OAuth Client Credentials][oauth-client-credentials-grant] flow is usually preferred. This type of grant makes it possible for the software service to authenticate by the use of its own credentials (client id and client secret) but also puts a requirement on that service to ensure the client secret is indeed persisted in a secure (encrypted) fashion, to avoid its unintentional spread.

See also: [Actor](#actor), [Authentication](#authentication)

## Authority

-- TODO --

## Authorization

The process of asserting an [actor's](#actor) privileges, ensuring it can only consume resources for which it has proper access to, avoiding the unintentional spread of sensitive information to the wrong consumers.

[Actors](#actor)' [identity](#identity) *usually* needs to be asserted (through   [authentication](#authentication)) when making requests for restricted information but in many scenarios, where requests are made for *public information* anonymous (a.k.a. "guest") [actors](#actor) are authorized as well.

See also: [Authentication](#authentication), [Identity](#identity)

## Bearer token

In OAuth 2 any party in possession of a bearer token should be granted access to the requested resources, without being further challenged.

To prevent misuse two very important criteria must be met: 

- The bearer token must be securely kept from disclosure (eg. cryptographically secure storage) and in transport (sent over TLS in header or body)
- The bearer token must only be valid for use with a specific resource service (the [audience](#audience))

## Business API

Aliases: [Reusable API](#reusable-api)

The term usually refers to a high quality API that is very consistent in its path design, use of resource names, concepts and formats. 

What that means is it should be a reusable "general purpose" API. To make an API "reusable" means your clients should find it worthwhile to invest in reusable code components to make request and handle the responses, successful ones as well as failed ones. For that to happen you need to make sure your clients doesn't have to write [complex messy code with endless if-else clauses everywhere][tetra-pak-aspnet-api-readme-jwt-writing-apis], dealing with exceptions and inconsistencies. Everything, from naming conventions to format, should be as consistent as possible. If a certain type of resource is called "Message", for instance, in one endpoint then you should take care to call it the same thing everywhere else in your API(s). 

Failing to design a "*business grade*" API, consistent in conventions and format, will mean client development will be costly. 

On the other hand, if you follow [Tetra Pak's API guidelines][dev-portal-api-guidelines] you have a very high chance of creating a successful API as your clients might already have invested in such code components in previous projects that also consume Tetra Pak business APIs. As they are now about to consume your new shiny API, and you stick to the same design principles, conventions, and formats, that client can likely focus on adding code just to deal with the differences, which should be few indeed.

## Callback URL

In OAuth 2 some [*flows*](#authentication-scheme) (especially the [Authorization Code Grant](#code-grant-oauth-flow) flow) the [authority](#authority) will respond with a *redirect* status. In that response it specifies a target URL - the *callback URL*.

## Claim

In .NET a *claim* is a small piece of information about an [identity](#identity), such as a first/last name or email address. The claim is usually an item in a list of key/value pairs where the "key" (known as a *claim type*) uniquely identifies the claim within the list and the value contains the claim itself (eg. email address).

See also: [Identity](#identity), [ClaimsIdentity][class-ClaimsIdentity]

## Claims transformation

The process of constructing the [identity](#identity) of an [actor](#actor) during an ASP.NET request/response operation. This happens automatically after a successful [authentication](#authentication) operation. It is possible to inject one's own "claims transformation delegate" by simply configuring the `IClaimsTransformation` service during the DI services configuration (usually from the `ConfigureServices` method of the `Startup`).

Please note that the SDK ([TetraPak.AspNet][nuget-tetrapak-aspnet]) already does this so replacing the claims transformation service with a custom one might cause unexpected results.

## Client

Within the world ofd [API management](#api-management-system) a *client* is a type of [actor](#actor) but, unlike a *human* [actor](#actor) a *client* is typically a piece of software that consumes [APIs](#api) (a.k.a. *Services*). Please note that an [API](#api) itself might be a *client*.

Aliases: [App (registration)](#app-registration)
See also: [Actor](#actor), [Client id](#client-id), [Client secret](#client-secret)

## Client credentials

A set of values used to identify and authenticate a [client](#client) (as opposed to a human). The concept is the same as for human [actors](#actor) though and usually consists of a [client id](#client-id) and a [client secret](#client-secret), analogous to a user id and password.

Unlike humans, who are expected to simply keep their password a secret (by avoiding noting it down on back of post-its etc.) technical measures must be taken to keep a [client secret](#client-secret) secret!

*Client credentials* must be passed by the [client](#client) necessary in some [OAuth 2 flows](#authentication-scheme), such as the [Client Credentials flow][oauth-client-credentials-grant] or the [Token Exchange flow][oauth-client-token-exchange].

## Client credentials (OAuth flow)

In OAuth this flow can be used for authorizing a non-human [client](#client) (such as an [API](#api)) to consume another service. The flow will submit [client credentials](#client-credentials) and some meta data as [`FormUrlEncodedContent`](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.formurlencodedcontent) to [TPAS](#tpas). If the [authorization](#authorization) succeeds a security token is issued for use by the [client](#client) and sent back in the response.

The [TetraPak.AspNet][nuget-tetrapak-aspnet] SDK supports this flow through the [`IClientCredentialsService`][iface-IClientCredentialsService], like in this example controller:

```c#
[ApiController]
[Route("[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    readonly IClientCredentialsService _clientCredentialsService;
    readonly IOrdersService _ordersService;

    [HttpGet]
    [Route("{id?}")]
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
        // implement token caching here
    }

    public OrdersController(IClientCredentialsService clientCredentialsService, IOrdersService ordersService)
    {
        _clientCredentialsService = clientCredentialsService;
        _ordersService = ordersService;
    }
}
```
 
See: [specification][oauth-client-credentials-grant]

See also: [Token exchange (OAuth flow)](#token-exchange-oauth-flow)

## Client id

Aliases: [API key](#api-key), [Consumer key](#consumer-key)

The public value used to identity a [client](#client)

See: [Client credentials](#client-credentials)

## Client secret

Aliases: [Consumer secret](#consumer-secret)

The secret value used to authenticate a [client](#client)

See: [Client credentials](#client-credentials)

## Code Grant (OAuth flow)

-- TODO --

## Consumer key

Aliases: [API key](#api-key), [Client id](#client-id)

See: [Client credentials](#client-credentials)

## Consumer secret

Aliases: [Client secret](#client-secret)

See: [Client credentials](#client-credentials)

## Developer portal

In Tetra Pak this is the go-to web resource for all things related to API consumption and creation. The developer portal is a [sub domain under the Tetra Pak top domain][dev-portal]. There is currently also a ["test" developer portal][dev-portal-test], intended for more experimental scenarios but that might be a bit unstable at times.

Tetra Pak employees or consultants should be able to log in to the developer portal using single-signon whereas other clients will have to log on interactively.

The developer portal can be used to explore and discover [API products](#product) and allow creation and management of new "[apps](#client)" and [API products](#product). The portal also contains guidelines, recommendations and other useful information.

## Development proxy

Aliases: "`DevProxy`", "`development sidecar`"

A tool, supported by the SDK [TetraPak.AspNet.Api][nuget-tetrapak-aspnet-api] Nuget package, that emulates the behavior of an [API sidecar](#sidecar) that protects the API, even when running the API project locally from your IDE ("*on the desktop*").

The *development proxy* is a small piece of [middleware](#middleware-aspnet) that automatically gets injected when you specify other SDK Tetra Pak middlewares, such as `UseTetraPakApiAuthentication`, like in this example:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseHttpsRedirection();
    app.UseRouting();

    // add this (after UserRouting and before UseAuthorization)
    app.UseTetraPakApiAuthentication(env);
    
    app.UseAuthorization();

    app.UseEndpoints(builder => { builder.MapControllers(); });
}
```

The *development proxy* [middleware](#middleware-aspnet) supports (and assumes) the [JWT bearer assertion scheme](#jwt-bearer-assertion) and functions like this, for every request:

- Looks for an access token. If one is not found it will terminate the request with a 401 (Unauthorized) response.
- Sends a message to the "actual" [sidecar](#sidecar), passing the access token to have it exchanged for a [JWT bearer token](#bearer-token). If the request fails it will terminate the request, logging the error and respond accordingly.
- To increase performance the *developer proxy* also supports caching of [JWT bearer tokens](#bearer-token), avoiding unnecessary round trips for every request.

While the *development proxy* is a useful tool for local debugging requirements it cannot be deployed to a (remote) web host. To minimize security risks and avoid deployment mistakes the *DevProxy* [middleware](#middleware-aspnet) will ***only*** be injected when the following criteria are met: 

- The bound host URL(s) contain the textual pattern "`://localhost`"
- The "actual" [sidecar](#sidecar) is properly named (configuration) and supports a *development proxy*. The [sidecar](#sidecar) name can be obtained from an [API manager](#api-manager)

See: [API recipe][md-api-recipe-dev-proxy]

## Downstream

In architecture downstream usually means a message getting made from an actor to a service, or from such a service to another service. In architectural diagrams the direction is generally *away* from the initiating actor.

## Flow

Alias: [Authentication scheme](#authentication-scheme), [Grant](#grant)

## Grant

Alias: [Authentication scheme](#authentication-scheme), [Flow](#flow)

## Identity

In general terms an all [actors](#actor) have one or more "proofs of identity", or just "identities". In the physical world a person can hold multiple "proofs of identity", such as her driving license, passport, ID card, etc. In .NET an *identity* usually means a "claims identity" (implemented by the [ClaimsIdentity][class-ClaimsIdentity]), which supports a list of [claims](#claim).

See also: [Actor](#actor)

As an example; In an ASP.NET API, a [`ControllerBase`][class-ControllerBase]  supports a [`User`][prop-ControllerBase-User] property, of type [ClaimsIdentity][class-ClaimsIdentity], that identifies the [actor](#actor) that initiated the current request, ***if*** that actor was successfully [authenticated](#authentication).

See also: [Authentication](#authentication)

## JWT Bearer Assertion

A security pattern (or "[auth scheme](#authentication-scheme)") based on the use of a [JWT bearer](#bearer-token) that gets issued to a [sidecar](#sidecar) by [TPAS](#tpas), authorizing the [sidecar](#sidecar) to consume its [API](#api) 

![API management pattern](_graphics/api-mgmt-pattern.png)

Looking at the above diagram we can follow the full request/response round trip, which includes the *JWT bearer assertion* security mechanism:

- User makes request via her client (`Client X`)
- (`a`) `Client X` is granted authorization (authenticating the `User` in the process). [TPAS](#tpas) issues an access token (`1`) and sends it back at the end of the auth process.
- (`b`) `Client X` sends request to the API [sidecar](#sidecar). This is the start of the *JWT bearer assertion* sub flow.
  
  \>>> start of JWT bearer assertion sub flow >>>

- (`c`) [sidecar](#sidecar) asserts the access token (1) and requests authorization to consume its API (`API 1`). [TPAS](#tpas) accepts the request and issues a [JWT bearer](#bearer-token) (2) for [sidecar](#sidecar).
- (`d`) [sidecar](#sidecar) passes the request to its api, passing the [JWT bearer](#bearer-token) (2) with the request.
- (`e`) `API 1` asserts the [JWT bearer](#bearer-token) (2) token. This is done by obtaining the public keys, from [TPAS](#tpas), used to sign the [JWT bearer](#bearer-token). The [JWT bearer](#bearer-token) is found to be genuine (and not expired) so it is accepted.

  <<< end of JWT bearer assertion sub flow <<<

- (`f` through `j`) As `API 1` needs data from `API 2` it first requests and gets authorization to consume `API 2`. This is achieved with the [token exchange flow](#token-exchange-oauth-flow) (`f`). The same pattern then gets repeated (see `b` through `e`)

## Middleware (ASP.NET)

A delegate to be called by the ASP.NET runtime to manage every request/response round trip. The concept is similar to the [chain of responsibility design pattern](https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern) and each *middleware* is responsible for calling the next one in the "chain".

A middleware gets full access to the request/response context (request URL, headers, body and any adata added by other *middleware*) and can terminate the request, if needed, sending a customized response back to the client.

The ASP.NET Core/5+ web technology design is based on the *middleware* concept, depending on the *middleware* "chain" to be configured correctly by the `Configure` method declared by the startup class (usually called `Startup`).

This diagram shows an example of how the ASP.NET host creates a request/response context and then simply sends it to the *middleware chain*. In the example, the last *middleware* resolves which controller and method to invoke, sending the correct parameters (if any). As the controller sends its response the middleware chain again gets called, backwards:

![ASP.NET middleware chain](_graphics/aspnet-middleware.png)

You can inject your own middleware by simply calling the `Use()` extension method, like in this example:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // custom middleware
    app.Use((context, next) =>
    {
        context.Request.Headers.Add("my-header", "Hello World!");
        return next();  // <-- calls next middleware
    });
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseTetraPakApiAuthentication(env);
    app.UseAuthorization();
    app.UseEndpoints(builder => { builder.MapControllers(); });
}
```

*The example simply adds a pointless extra header (`"my-header"`) to the request and sets its value to `"Hello World!"`.*

## OAuth 2

-- TODO --

[](#middleware-aspnet)

## Opaque token

THis term is often used with tokens that lacks "semantics" for the consumer/client. What this means is the consumer/client cannot discern any information from the token itself. Often, the token is simply a randomized string, created by the issuer that is then used as a key value to lookup meta data about the token, such as its expiration time and [audience](#audience).

## Product

An API *product* is the name for an ongoing effort to support one or more Tetra Pak APIs with a shared organization and life cycle management. Each API product is developed, maintained and supported by an organization and its [product owner](#product-owner).

See also: [Developer portal](#developer-portal), [Product owner](#product-owner)

## Product owner

A Tetra Pak resource that is responsible for the maintenance, development lifecycle and support of an [API product](#product).

See also: [API product](#product), [Developer portal](#developer-portal)

## Protected controllers and endpoints (ASP.NET)

-- TODO -- 

## Reusable API

See: [Business API](#business-api)

## Reverse proxy

-- TODO --

## Risk surface

In security theory a *risk surface* describes the probability of misuse, usually for security tokens. A *risk surface* can have several dimensions, depending on the security context. For example, the *risk surface* for a [bearer token](#bearer-token) can be expressed by its lifetime (expiration date/time), [audience](#audience) and, possibly also, [scope](#scope) as these parameters governs what can be done with the token, as well as for how long.

As an example; a [bearer token](#bearer-token) with a very long lifetime and unlimited scope (eg. [audience](#audience)) can be assumed to have a larger *risk surface* than other tokens, with a shorter lifetime and limited [scope](#scope)/[audience](#audience), simply because there will be more time available to misuse it and more resource services would be susceptible during that time.

See also: [Audience](#audience), [Bearer token](#bearer-token), [Scope](#scope)

## Runtime environment

-- TODO --

## Scope

-- TODO --

## Sidecar

An [API](#api) that supports another [API](#api), resolving typical (cross-cutting) issues and features as well as monitoring the traffic and protecting the "real" [API](#api) from attacks or other harmful requests.

The *sidecar* is implemented as a [reverse proxy](#reverse-proxy), usually hosted by the [API management system](#api-management-system). The *sidecar* can implement any security pattern (policy) needed by the API owner.

See also: [this article](https://docs.microsoft.com/en-us/azure/architecture/patterns/sidecar), [JWT bearer assertion security pattern](#jwt-bearer-assertion)

## Terminus (API)

An API that is self-sustained in that it never makes [downstream](#downstream) requests. Instead all information required to complete the request can be produced by the API, or obtained from the API's own resources.

We use this term in the SDK documentation to distinguish an API because such an API have no need to authenticate itself and, therefore, have no requirement for securely persisting its credentials ([client id](#client-id) and [client secret](#client-secret)), which removes complexity from its configuration and implementation.

See also: [Transitive API](#transitive-api)

## Tetra Pak Auth Services

Aliases: [TPAS (abbrev.)](#tpas)

Often abbreviated "TPAS"; a suite of services responsible for [authenticating](#authentication) a [actors](#actor) and [authorizing](#authorization) their access to Tetra Pak APIs. The service suite provides convenient APIs not only for [authenticating](#authentication), but also for requests for information about [actors](#actor).

TPAS integrates with several related solutions, including other "[auth](#auth)" and identity providers

## Token exchange (OAuth flow)

This flow can be used to authorize a non-human [client](#client) (such as an [API](#api)) to consume another service. The flow will submit [client credentials](#client-credentials) and some meta data as [`FormUrlEncodedContent`](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.formurlencodedcontent) to [TPAS](#tpas). If the [authorization](#authorization) succeeds a security token is issued for use by the [client](#client) and sent back in the response.

The [TetraPak.AspNet][nuget-tetrapak-aspnet] SDK supports this flow through the [`ITokenExchangeService`][iface-ITokenExchangeService], like in this example controller:

```c#
[ApiController]
  [Route("[controller]")]
  [Authorize]
  public class HelloWorldController : ControllerBase
  {
      readonly ITokenExchangeService _tokenExchangeService;
      readonly TetraPakAuthConfig _tetraPakConfig;

      [HttpGet]
      public async Task<ActionResult> Get()
      {
          var actorTokenOutcome = await this.GetAccessTokenAsync();
          if (!actorTokenOutcome)
              return this.UnauthorizedError(actorTokenOutcome.Exception);

          var credentials = new BasicAuthCredentials(
              _tetraPakConfig.ClientId, 
              _tetraPakConfig.ClientSecret);
          var ct = new CancellationToken();
          var txOutcome = await _tokenExchangeService.ExchangeAccessTokenAsync(
              credentials, 
              actorTokenOutcome!, 
              ct);
          if (!txOutcome)
              return this.InternalServerError(
                  new ConfigurationException("Service is incorrectly configured"));

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
```


In OAuth this flow is recommended for authorizing a non-human [client](#client) to consume another service.

See: [specification][oauth-client-token-exchange]

See also: [Client credentials (OAuth flow)](#client-credentials-oauth-flow)

## TPAS

See: [Tetra Pak Auth Services](#tetra-pak-auth-services)

## Transitive API

An [API](#api) that consumes data from other services. Building *transitive APIs* adds some extra complexity as they will need [authorization](#authorization) to consume those other services. This means they will have a need for one or more  [authentication scheme(s)](#authentication-scheme), such as [token exchange](#token-exchange-oauth-flow) or [client credentials flow](#client-credentials-oauth-flow). Other than supporting those [auth flows](#authentication-scheme) this also adds a responsibility to secure the *transitive API's* secrets ([client credentials](#client-credentials)).

See also: [Terminus API](#terminus-api)


[class-ClaimsIdentity]: https://docs.microsoft.com/en-us/dotnet/api/system.security.claims.claimsidentity
[class-ControllerBase]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase
[prop-ControllerBase-User]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.user
[iface-IClientCredentialsService]: ./TetraPak.AspNet/_docs/_code/TetraPak_AspNet_Auth_IClientCredentialsProvider.md
[iface-ITokenExchangeService]: ./TetraPak.AspNet.Api/_docs/_code/TetraPak_AspNet_Api_Auth_ITokenExchangeService.md

[oauth-code-grant]: https://datatracker.ietf.org/doc/html/rfc6749
[oauth-client-credentials-grant]: https://datatracker.ietf.org/doc/html/rfc6749#section-4.4
[oauth-client-token-exchange]: https://datatracker.ietf.org/doc/html/rfc8693

[dev-portal]: https://developer.tetrapak.com
[dev-portal-test]: https://developer-test.tetrapak.com
[dev-portal-api-guidelines]: https://developer.tetrapak.com/products/api-design

[nuget-tetrapak-common]: https://www.nuget.org/packages/TetraPak.Common

[md-Outcome-T]: https://github.com/Tetra-Pak-APIs/TetraPak.Common/blob/master/TetraPak.Common/_docs/_code/TetraPak_Outcome_T_.md
[md-EnumOutcome-T]: https://github.com/Tetra-Pak-APIs/TetraPak.Common/blob/master/TetraPak.Common/_docs/_code/TetraPak_EnumOutcome_T_.md

[md-api-recipe-dev-proxy]: ./TetraPak.AspNet.Api/_docs/Recipe-WebApi.md#the-development-proxy

[nuget-tetrapak-aspnet]: https://www.nuget.org/packages/TetraPak.AspNet
[nuget-tetrapak-aspnet-api]: https://www.nuget.org/packages/TetraPak.AspNet.Api