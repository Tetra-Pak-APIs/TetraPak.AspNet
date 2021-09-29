# Recipe: Create a Tetra Pak API

This document will walk you through creating a small [terminus API][md-terms-terminus] and integrate it with the Tetra Pak Auth Services. After completion you should have a good understanding of how to integrate an existing [terminus API][md-terms-terminus] as well. 

> If you need an overview and some background then please check out the [README document][tetra-pak-aspnet-api-readme]. If you already know everything and just need the fast-track to integrating your existing API then there is also a neat [cheat sheet][tetra-pak-aspnet-api-cheat-sheet] (yes, that rhymes :-). 
>
> For many issues and typical use cases there is also a small ["scenarios" document][tetra-pak-aspnet-scenarios] that might help you out. 
> 
> Finally, please consult the [terms and concepts][md-terms] document if you bump into unfamiliar vocabulary.

The API will be built with ASP.NET Core/5+ and consist of a single "hello" controller with two endpoints: One default `/hello` endpoint that will return a message saying "Hello" (followed by the name of the user), and a `hello/version` endpoint that will return the API version (which we will get from the running assembly metadata). 

To resolve the [identity][md-terms-identity] of the caller the first endpoint (`/hello`) requires the [actor][md-terms-actor] to be [authenticated][md-terms-authentication], which is why the API needs to be integrated with the [TPAS][md-terms-tpas] (identity provider)! The second (`hello/version`) endpoint should be publicly available and will therefore not require authentication.

## Ingredients

To complete this recipe you will need:

- Access to the [Tetra Pak Developer Portal][tetra-pak-dev-test-portal]. 
  
  Please ensure your computer have access to the Tetra Pak network, directly or though a VPN
- A development environment (IDE). 
  
  You can use whichever tool you prefer, such as [Visual Studio][ide-vs], [VS Code][ide-vscode], [Rider][ide-rider], or any other tool. Those mentioned have good .NET support but the choice is yours.

- A tool to make request to your API, for testing.
  
  We till use [Postman][postman] for this but you are can use a different tool if you prefer.

## Disclaimer

This recipe assumes you know how to write, run, and debug C# using your preferred IDE (Integrated Development Environment) be it [Visual Studio][ide-vs], [VS Code][ide-vscode], [Rider][ide-rider], [Eclipse][ide-eclipse] etc. We will not cover the exact how-to of each step required, such as creating a new project, add/restore Nuget packages, start a debug session, and so on. As these details differs from one IDE to the next you are expected to know the required steps.

## Overview 

Before we start the detailed walk-through, let's first get an overview of the steps required to create and integrate a Tetra Pak API:


![Flow - integrate terminus API](../../_graphics/flow_integrate_api_1.png)

In a real-life project there are, at the time of this writing*, a few steps where you need a favor from an [API manager][md-terms-api-manager]; someone with access to Tetra Pak's [API Management System][md-terms-apigee-edge], and that knows how to use it. In the flow shart (above) those steps are marked with asterisks (*). For this recipe you will need two pieces of information from this:

- The API [audience][md-terms-audience] identifier
- The [sidecar][md-terms-sidecar] name
  
However, to avoid having you sit around waiting to get this information, we have configured a special "demo" [sidecar][md-terms-sidecar] for you 
you can get around this by using pre-configured demo resources. If you prefer using this pre-condigured resource then the [audience][md-terms-audience] and [sidecar][md-terms-sidecar] identifier is the same: "`demo_hello_api`". If this is how you want to build your demo API then you can skip the first two preparation steps and continue with [creating the API project](#create-the-api-project).

> \* *The API innovation team strives to provide tools and services to make developers as autonomous and empowered as possible, but as of now some steps needs to be vetted and approved manually.*

1. [**Register the API with Tetra Pak**](#register-the-api-with-tetra-pak)
  
   Before we can integrate the API with [TPAS][md-terms-tpas] we need to first [register it as an "app"][md-terms-client] with Tetra Pak. In this step we'll browse over to the [Tetra Pak Developer Portal][tetra-pak-dev-test-portal] and see how that is done. We will need some information from this step, such as the [audience][md-terms-audience].

   > \* *An `app registration` is how [TPAS][md-terms-tpas] "knows" about your API. But clients of APIs also needs to be recognized and, often, your API needs to consume other APIs, effectively making it both an API **and** a client of other services ([see API recipe 2][tetra-pak-aspnet-api-recipe-2]). We just use the term "app registration" or "app" for sake of simplicity.*
  
2. [**Create a *sidecar***](#create-a-sidecar)
  
   Your API will be managed and protected by its [sidecar][md-terms-sidecar] (deployed with Tetra Pak's [API management system][md-terms-apigee-edge]) so we need one set up for us, by an [API manager][md-terms-api-manager].

3. [**Create the API project**](#create-the-api-project)
  
   Your preferred development tools (IDE) will (probably) offer some sort of [project scaffolding](https://en.wikipedia.org/wiki/Scaffold_(programming)) where you pick a suitable project template, choose authorization mechanism, maybe add Git integration, and so on. The way this is done differs, quite a lot, between IDEs so the recipe will only offer general guidance. You are expected to know your tool!

4. [**Add SDK Nuget package**](#add-sdk-nuget-package)
  
   This step is where you add the SDK support and should be very straight forward. But, again, there will be no detailed steps as this is also done differently from one IDE to another.

5. [**Write business logic**](#write-the-business-logic)
  
   We write the controller and the two endpoints (`/hello` and `/hello/version`). In a real-life project you would probably start writing the business logic *after* you're done integrating your API with [TPAS][md-terms-tpas] but for sake of "flow" we'll do it before the integration step, coming up next.

6. [**Integrate with TPAS**](#integrating-with-tetra-pak-auth-services)
  
   This is where we write the code and add the necessary configuration to integrate with [TPAS][md-terms-tpas] and set your API up to be function behind its [sidecar][md-terms-sidecar]. We'll need some details ([audience][md-terms-audience] and [sidecar][md-terms-sidecar] name) from the previous steps to complete this one (or use the pre-configured "`demo_hello_api`" resource).

   In the above flow diagram you will notice that for configuration there is a choice to be made: "Identity Source". We will explain this in more detail later but, just to give a hint, going with the "`IdToken`" source is faster but also quite limited, whereas the "`RemoteService`" path allows for way more control and user information but adds more complexity and a small performance hit.

7. [**Test the API**](#test-the-api)
  
   When we're done we need to test the API. For this we need a [registered "app"][md-terms-client], set up to be a trusted client of our new API. This is also done from the [Tetra Pak Developer Portal][md-terms-dev-portal].
  
   We will then make test requests to the new API using [Postman][postman].

So, with the plan firmly set in our mind, let's do this...

## Register the API with Tetra Pak

 >This step of the recipe will demonstrate how to [register an "app"][md-terms-client] with Tetra Pak. This is so you can do it yourself in your projects. After registering you would then need the assistance of an [API manager][md-terms-api-manager] to configure your registered app and create a [sidecar][md-terms-sidecar] for it. 
 >
 > For the sake of this recipe you can instead rely on a pre-configured app registration, to avoid the lead time from having to reach out and wait for your registration to be configured and ready for use. Read through the following steps if you want to understand how to register your API "app". Alternativelly, just use the pre-configured "`demo_hello_api`" resource for [audience][md-terms-audience] andn [sidecar name][md-terms-sidecar] and move on to [Create the API project](#create-the-api-project)    

 For any app to integrate with [TPAS][md-terms-tpas] it needs to be recognized by Tetra Pak. This is done by simply registering the app, with a name and unique "[consumer key][md-terms-client-id]". You do this in the [Tetra Pak developer portal][tetra-pak-dev-test-portal] like so:

1. Open a browser and navigate to the [Tetra Pak developer portal][tetra-pak-dev-test-portal]

   >This instruction assumes you are starting out with a DEV (Development) [runtime environment][md-terms-runtime-environment]. For PROD (Production) please use the [production development portal][tetra-pak-dev-portal].

2. Log in
   
3. Click the "Apps" menu item at the top of the page
   
4. Click the "Add app" command (upper left part of page)
   
5. Give your app a name and supply a short description of it
   
6. Specify the [Callback URL][md-terms-callback-url] (from [this step](#save-local-url)). The default callback path for this SDK is `/auth-callback`. So, for example, if your local host is `https://localhost:8080` then the [Callback URL][md-terms-callback-url] should be `https://localhost:8080/auth-callback`

   > Please note that this value can be edited later if you return to your app registration and select the "Edit" tab (will be visible once you save your app registration). If you are unsure at this time which port you'll be using locally then just change this value later, when you know the full callback URL. [For more information please go here][tetra-pak-dev-portal-appreg-callback].

7. In a "real" web app you would probably want to consume one or more [API products][md-terms-product]. For this recipe that is not the case (we will cook a "[terminus API][md-terms-terminus]"). However, please double check that the "`Enterprise Application Security`" service is already selected, or select it otherwise. This service is critical for integrating with [TPAS][md-terms-tpas]. You might have to scroll down to see it

8. Click "ADD APP" (bottom of the web page)
   
9. You are now presented with your app overview page, where all your [app registrations][md-terms-app-registration] are listed. Please select the one you just created by clicking it. This should present the App details, such as the [client credentials][md-terms-client-credentials] ([Consumer Key][md-terms-client-id] and [Consumer Secret][md-terms-client-secret]).
  

## Create a sidecar

All Tetra Pak APIs must be *managed*, meaning they must be running "behind" a [sidecar][md-terms-sidecar] (a managed reverse proxy). Getting a [sidecar][md-terms-sidecar] set up and configured is unfortunately (at the time of this writing) not something you can do yourself. Instead, your project should have one assigned [API manager][md-terms-api-manager] that you need to turn to to get this done. Usually, it's a fairly quick process but you need to reach out to get this done and then wait for these tasks to be completed. In doing so you need to get this information back:

1. You will have to agree on an [audience][md-terms-audience] for the [JWT Bearer Assertion flow][md-terms-jwt-bearer-assertion] to work. This is simply a name (or "*identifier*") to be used by your [sidecar][md-terms-sidecar]. Negotiate a suitable [audience][md-terms-audience] identifier for your [API manager][md-terms-api-manager].
   
2. If you plan to consume other services (APIs) from your API, you need to mention this requirement to your [API manager][md-terms-api-manager]. This will affect how your sidecar gets configured. For this recipe this is not needed (see the [next API recipe][tetra-pak-aspnet-api-recipe-2] for an example of an API that consumes other Tetra Pak services).
   
3. Ask the [API manager][md-terms-api-manager] to add the ability for a [*Development Proxy*][md-terms-dev-proxy]. This is so you can run and debug your API locally. If that was unclear; don't worry. We'll get back to this shortly. Just read on. 
   
4. When you get the [sidecar name][md-terms-sidecar] and [audience][md-terms-audience], note them down for later.

## Get the demo API details

> Like stated before; for this recipe you can skip this step and instead rely on a pre-configured resources. Just use the [audience][md-terms-audience] identifier "`demo_hello_api`".

1. Browse to the [Tetra Pak developer portal][tetra-pak-dev-test-portal].
   
2. Click the "Apps" menu item at the top of the home page.

3. Copy the [Callback URL][md-terms-callback-url] (and then paste it somewhere for later reference): 
   
   ![Copy callback URL](../../_graphics/copy_callback_url.png)

4. Ask your [API manager][md-terms-api-manager] for the negotiated [audience][md-terms-audience] identifier (and save it somewhere).

## Create the API project

For sake of convenience the project will be called "TetraPakHelloApiRecipe".

1. Create a ASP.NET Web API project, name it "TetraPakHelloApiRecipe". Please pick a suitable project template. 
   
   > If your IDE project templates present you with the option to add "Auth" or "Authentication" in some way, please opt out. We will add authentication manually later in this recipe as it's pretty simple anyway.
   > Also, the project template wizard (if your IDE supports one) might offer a web appliction *type*, such as "MVC Razor", "Blazor", "Web API" and so on. If possible select the "Web API" option. Please avoid "Blazor"! This SDK doesn't support it (yet).

2. The recipe assumes the default controller is called `HelloController`. If the project scaffolded some default controller for you; just rename it and remove all the code, or delete the class file and create an empty `HelloController` class instead under the "Controllers" folder (create the folder if necessary).

   This is what the folder/file structure should look like as a minimum (your IDE's project template might have added more files and folders - that's ok). If these files and folders wasn't created by your IDE then please create them:

    ```
    +-- TetraPakApi
        |
        +-- Controllers
        |   |
        |   +-- HelloController.cs
        |
        +-- appsettings.js
        +-- Program.cs
        +-- Startup.cs
    ```

## Add SDK Nuget package

Before we start coding you first need to add the SDK's Nuget package [TetraPak.AspNet.Api][nuget-tetrapak-api] as there will be one or two extension methods in our code that requires it. 

Add the [TetraPak.AspNet.Api][nuget-tetrapak-api] Nuget now.

## Write the business logic

Lets look at the contents of each file, starting with the `HelloController` class and work our way down:

```c#
// ./Controllers/HelloController.cs

using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TetraPak;
using TetraPak.AspNet;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.Logging;

namespace TetraPakHelloApiRecipe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HelloController : ControllerBase
    {
        readonly ILogger<HelloController> _logger;

        [HttpGet]
        public Task<ActionResult> Get()
        {
            logRequest();
            var actorName = User.FirstName() 
                            ?? User.Id() 
                            ?? "stranger";  
            var outcome = Outcome<object>.Success(new
            {
                Message = $"Hello {actorName}!"
            });
            return this.RespondAsync(outcome);
        }

        [AllowAnonymous]
        [HttpGet, Route("version")]
        public Task<ActionResult> GetVersion()
        {
            logRequest();
            var data = new { Version = typeof(Startup).Assembly.GetName().Version?.ToString() ?? "(unknown)" };
            return this.RespondAsync(Outcome<object>.Success(data));
        }

        void logRequest([CallerMemberName] string endpoint = null)
        {
            var identity = $"{User.FirstName()} {User.LastName()}".Trim(); 
            if (identity.Length == 0)
            {
                identity = User.Id();
            }

            _logger.Trace($"{identity} called {endpoint}");
        }

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }
    }
}
```

The controller is decorated with the `[Authorize]` attribute, meaning all endpoints will require the actor to be [authenticated][md-terms-authentication] (using the default [authentication scheme][md-terms-authentication-scheme]).

To allow logging the controller ctor (constructor) accepts a logger provider (`ILogger<HelloController>`) which is stored in a private `readonly` field:  `_logger`. Please note that this logger provider is automatically injected by ASP.NET's dependency injection mechanism as the controller is constructed. The controller declares a convenient private method - `logRequest()` - that will simply trace the actors identity (first and last name) along with the endpoint method name.

> This is just to show some convenient extension methods for logging and getting the [actor's][md-terms-actor] identity (first and last name). If you actually want a good trace for all requests (including the request URL, headers and body) there are better methods to do so but that's beyond the scope of this recipe.

The default endpoint method - `Get()` - is just decorated with the `[HttpGet]` attribute, making it the default endpoint for this controller: `/hello`. Let's look at its content:

```c#
[HttpGet]
public Task<ActionResult> Get()
{
    logRequest();
    var actorName = User.FirstName() 
                    ?? User.Id() 
                    ?? "stranger";  
    var outcome = Outcome<object>.Success(new
    {
        Message = $"Hello {actorName}!"
    });
    return this.RespondAsync(outcome);
}
```

The `logRequest()` has already been explained so lets instead examine how we resolve the [actor's][md-terms-actor] name the response as we construct and retuern the response. 

The [actor's][md-terms-actor] name can be resolved using one of two mechanisms: 
- From a token
- From the [TPAS][md-terms-tpas] User Information (remote) service

Resolving and constructing the [actor's][md-terms-actor] identity is a mechanism we call [claims transformation][md-terms-claims-transformation] and it's an automatic step that gets invoked at the end of the authentication process. This mechanism examines the property [`TetraPakAuthConfig.IdentitySource`][md-prop-TetraPakAuthConfig-IdentitySource], which is a simple enum - [`TetraPakIdentitySource`][md-type-TetraPakIdentitySource] - that (currently) supports two values; `IdToken` and `RemoteService` (`IdToken` is the default).

> You can configure this value in appsettings.json, like so:
> ```json
> {
>   "TetraPak": {
>     "IdentitySource": "RemoteService"
>   }
> }
> ```

When the configuration dictates that the [actor's][md-terms-actor] [identity][md-terms-identity] should be constructed from the `IdToken`; what that means is it will simply examine the incoming `JWT Bearer` (token), transforming it into a `ClaimsPrincipal` and assign that to the request context `User` property. When deciding whether to go with the (default) `IdToken` mechanism or the `RemoteService` mechanism here's what you need to know:

The `IdToken` mechanism is fast but also constrained to  information ([claims][md-terms-claim]) carried by that token. This might vary but it is usually limited to the unique "user name", such as "`USDOEJ`" (for our esteemed American colleague John Doe). If you need claims such as the first name ("John"), last name ("Doe"), or email ("john.doe@tetrapak.com") then you might be out of luck, and should consider the other option: `RemoteService`. That mechanism will instead consult the "User Information" service from [TPAS][md-terms-tpas]. The upside of that is you will gain access to the claims you might need in your API, even custom ones. The flip side (there's always one, isn't there?) is, of course, a small performance cost as the SDK prepares and makes the request for user information. Also, for this mechanism to work we need to provide the [client credentials][md-terms-client-secret], which adds some extra complexity.

For the sake of this recipe we will stick with the default (`IdToken`) mechanism, which might not be able to produce a first (and last) name, so we use a fall back mechanism to get the "user identity" (from `User.Id()`) and if that doesn't work (then something is *really* wrong) we fall back to just "stranger":

```csharp
    var actorName = User.FirstName() 
      ?? User.Id() 
      ?? "stranger";
```

Ok, we now have the [actor's][md-terms-actor] identity so it's time to send back the response. We could just send back an anonymous object with a "message" attribute holding the actual message ("Hello John"), like so:

```csharp
return Ok(new {Message = $"Hello {actorName}"});
```

... which would simply result in an "OK" (200) response with the anonymous object's JSON serialized form as the body: 

```json
{
  "message": "Hello Anna!"
}
```

That might be fine but we're striving a bit higher than that. As mentioned in the ["Writing APIs section" of README][tetra-pak-aspnet-api-readme-jwt-writing-apis] we want this API to be consistent in its response format and we also want to adhere to Tetra Pak's API guidelines, encouraging our clients to invest in code components when consuming different Tetra Pak APIs. In short; this is going to be a (reusable) [Tetra Pak business API][md-terms-business-api]! 

You can read more about [Tetra Pak's API guidelines here][tetra-pak-dev-portal-api-guidelines], but to summarize  this is how your response should be formatted:

```json
{
  "meta": {
    "total": (total-number-of-items-available)
  },
  "data": [
    (data-as-a-list)
  ]
}
```
 
This format is the bare minimum of what to expect from a [reusable Tetra Pak API][md-terms-business-api]. Please note that the requested data is *always* returned as a *JSON list* - even if there is just one item! This approach allows for much better code reuse and makes investing in code components for consuming standardized Tetra Pak APIs simple and cheap - and therefore a very good idea! 

Keeping to one consistent response form would of course need some (reusable) boilerplate code on your part. Nothing fancy but this SDK already provides some convenient classes and extension methods you can rely on for this: 

- The [`Outcome<T>`][md-Outcome-T] and [`EnumOutcome<T>`][md-EnumOutcome-T] classes 
- The [`RespondAsync`][md-RespondAsync] method

The [`Outcome<T>`][md-Outcome-T] class is declared in the base [TetraPak.Common][nuget-tetrapak-common] Nuget package and is heavily used by this SDK to reflect "outcome" and is especially convenient for reflecting *asynchonous* outcome! 

[`RespondAsync`][md-RespondAsync] is an extension method (declared by the [ControllerBaseExtensions][md-ControllerBaseExtensions] class) that accepts an [`Outcome<T>`][md-Outcome-T] object. The method will automatically resolve whether the outcome is a success or failure and then construct a well-formed response from it, as per [Tetra Pak API guidelines][tetra-pak-dev-portal-api-guidelines]. Relying on this method for responding is a convenient way to adhere to Tetra Pak formatting recommendations, now and in the future. 

### Run the API

Let's now make sure everything builds and runs, and that we can actually use the public endpoint: `/hello/version`. 

Start the app from your IDE (or command line).

Now browse to that address and the "version" endpoint: `https://localhost:5001/hello/version`*, using a browser or some preferred tool for testing your APIs, such as [Postman](https://www.postman.com/) or [Curl](https://curl.se/). If all goes well then you should get this response:

```json
{
  "meta": {
    "total": 1
  },
  "data": [
    {
      "version": "1.0.0.0"
    }
  ]
}
```

> \* *The port element -* `5001` *- of the URL might vary. This is controlled from your project's [launch settings][md-setting-localhost-port] when you run the code on your desktop.*

But what about the other (default) endpoint? You can try it out by just calling the `/hello` endpoint, like in this example: [`https://localhost:5001/hello`](https://localhost:5001/hello).

This will fail miserably and you will see a very "techy" response, including a stack trace and some error message that explaind there are no [authentication schemes][md-terms-authentication-scheme] set up. This is expected, as the `HelloController` only accepts authorized requests (we decorated it with the `[Authorize]` attribute, remember?) with `/hello/version` being the exception (we decorated that method with the `[AllowAnonymous]` attribute).

## Integrating with Tetra Pak Auth Services

We are now done with the "business logic" of our little API so now it's time to integrate it with [TPAS][md-terms-tpas], which is quite simple. We will set up the needed [authentication scheme][md-terms-authentication-scheme] - in this case the [Sidecar JWT Bearer Assertion][md-terms-jwt-bearer-assertion] scheme. We won't go into detail how that pattern actually works (follow the link for those details) but, long story short, it ensures all *protected* requests are made through your API's [sidecar][md-terms-sidecar]. Yup, that's right, your API *must* be protected by a reverse proxy that acts as its [sidecar][md-terms-sidecar]. The proxy will help protect from overuse (a.k.a. "throttling"), malicious use (attacks), and other typical disagreeable scenarios you might face when hosting a new API.

To summarize, this is what is left on our to-do:
  
- Add some configuraton to the `appsettings.json` configuration file. We need the details from when you registered the API, earlier, or we'll use the pre-configured app registration instead.
   
- Add two lines of code to the `Startup` class, to enable Tetra Pak Sidecar [JWT Bearer Assertion][md-terms-jwt-bearer-assertion] and Tetra Pak authentication

Let's begin with the configuration:

1. Open the `appsettings.json` file in an editor and add section `"TetraPak"` and a sub section to configure your [JWT Bearer Assertion][md-terms-jwt-bearer-assertion] (ensuring only the sidecar can make requests to your protected endpoints). The sub section, for configuring [JWT Bearer Assertion][md-terms-jwt-bearer-assertion] needs to include the expected audience:

    ```json
    {
       "TetraPak": {
          "JwtBearerAssertion": {
             "Audience": "(audience)"
          }
       }
    }
    ```

  > For [audience][md-terms-audience] you can use the pre-configured value "`demo_hello_api`". However, if youe registered your own app earlier (and requested a [sidecar][md-terms-sidecar] for it) you need to get the `audience` value from your [API manager][md-terms-api-manager].

With configuration done we now need two lines of code to the `Startup` class to set up [JWT Bearer Assertion][md-terms-jwt-bearer-assertion]. Let's do that now ...

2. Open the `Startup.cs` file

3. Add this line somewhere in the `ConfigureServices` method:

  ```csharp
  services.AddTetraPakJwtBearerAssertion();
  ```
  This will inject the necessary middleware to your API for Tetra Pak flavoured [JWT Bearer Assertion][md-terms-jwt-bearer-assertion]

4. Add this line to the `Configure` method:

  ```csharp
  app.UseTetraPakApiAuthentication(env);
  ```

  This line must be injected ***after*** the `app.UseRouting()` middleware and ***before*** the `app.UseAuthorization()` middleware.
  
  > Please note that the `UseTetraPakApiAuthentication` method expects an `IWebHostEnvironment` (the `env` parameter). If your `Configure` method wasn't scaffolded to accept an `IWebHostEnvironment` parameter then just add it and the ASP.NET DI mechanism will inject it for you:
  >
  > ```csharp
  > // ensure the 'env' parameter ...
  > public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  > ```

With this you have now integrated your API with [Tetra Pak Auth Services][md-terms-tpas] and your are ready to test it. 

Bu there's a problem ...

Are you the type of developer that can just code up a complex API and just deploy it to its host? Then congratulations, you are a very rare (and probably extremely well paid) breed. That, however, is not how most of us work. 

In the real world we will face issues and we'll want ways to understand what happens when *happy flows* breaks and stuff goes south. For this you will want to rely on all the sweet debygging and analyzing tools supported by your IDE! 

Once your code runs on its (remote) host you are basically left with *poor man's debugging*, relying on whatever data you remembered to dump to the logs. Sure, some IDEs, such as [Visual Studio][ide-vs], offer the ability to attach the debugger to the remote process but anyone that has ever tried it can testify this makes for a pretty miserable experience. Remote debugging is very *laggy* which makes it difficult to mentally follow the flow as you step through your code.

Instead, you will want to be able to debug your API code *"on your desktop"* (locally). This is where you are most productive and can quickly step through the code to understand what happens. So, *ideally*, you would now want to be able to just run your API on [`https://localhost:5001`](https://localhost:5001) (again, port *may* vary) and do what you're used to when debugging your code. 

The problem is we have just configured the API to ***only work when it is protected by its [sidecar][md-terms-sidecar]***. That [sidecar][md-terms-sidecar] is run by the [API management system][md-terms-api-management-system] on a remote host somewhere and cannot, under any circumstance, monitor and direct traffic to or from your desktop! 

What we could do, of course, is to add some "extra" `if`s and `else`s to remove the [sidecar][md-terms-sidecar] requirement from your API when the code detects it is being deployed to your local desktop. 

You *could*, for example, add compiler flags to only configure the `Startup` class for the [Sidecar JWT Bearer Assertion][md-terms-jwt-bearer-assertion] scheme and then more compiler flags to get rid of the `[Authorize]` attribute from all protected controller endpoint methods.

You *could* maybe do it in some other way but this would be a very bad idea. Not only would it mean stripping away the [TPAS][md-terms-tpas] integration, which we rely on to get the [actor's][md-terms-actor] identity. It is also a risky business to introduce compiler flags in your code just to allow local debugging. Overall, this approach would mean you'd test and debug code locally which would be very different from the code you plan to deploy. That is a very wobbly concept, to say the least. Also, you will introduce a *not-negligable* risk (&lt;-- understatement) of deploying the *wrong* code to the host, causing bugs and general misery for everyone involved, with loss of time, money, and trust from important stakeholder as a consequence.

## The development proxy

So, if we can't fake it to allow running and debugging the [API][md-terms-api] *on the desktop*, and we also can't rely on the necessary [sidecar][md-terms-sidecar], then what? Are we stuck?!


![Kedi master Yoda](../../_graphics/yoda.png)

*Fear not young padawan! The Tetra Pak SDK is here to help with some neat Jedi magic!*

The SDK supports a local (desktop) "development proxy" tool that you can simply activate by adding the `"DevProxy"` key and the name of the actual sidecar (from [step 4 in the "Create a sidecar"](#create-a-sidecar) section earlier). Now, add the `"DevProxy"` to the `"JwtBearerAssertion"` sub section:

```json
{
  "TetraPak": {
    "JwtBearerAssertion": {
      "Audience": "(audience)",
      "DevProxy": "(sidecar name)"
    }
  }
}
```

Just stating actual [sidecar's][md-terms-sidecar] name is the preferred and most resilient method of enabling the `DevProxy` but you can also specify the full URL if needed.

Either way, you will need to consult your [API manager][md-terms-api-manager] to get the name of your [sidecar][md-terms-sidecar]. But, again, if you prefer using the pre-configured [sidecar][md-terms-sidecar] it is called: "`demo_hello_api`". If so, use this configuration:

```json
{
  "TetraPak": {
    "JwtBearerAssertion": {
      "Audience": "demo_hello_api",
      "DevProxy": "demo_hello_api"
    }
  }
}
```

If you opted to create your own [app registration][md-terms-client], however, then you'll need to get the name of the proxy from your [API manager][md-terms-api-manager].

> **IMPORTANT!**
>
> To avoid deployment mistakes the (desktop) `DevProxy` will ***only*** work when you are running your API *locally*, meaning when all the bound host addresses contain the pattern "`://localhost`".

## Register a client with Tetra Pak

We are almost done! What remains now is to test your API. For that we will use [Postman][postman] - a popular tool for API testing and development. But before we can test the API we need a registered client for it.

1. Open a browser and navigate to the [Tetra Pak developer portal][tetra-pak-dev-test-portal]
    
    > This instruction assumes you are starting out with a [DEV (Development) environment][md-terms-runtime-environment]. For the PROD (Production) [environment][md-terms-runtime-environment] please use the [Production development portal][tetra-pak-dev-portal].

2. Log in
   
3. Click the "Apps" menu item at the top of the page 
   
4. Click the "Add app" command (upper left part of page) 
   
5. Give your client app a name and supply a short description of it (such as "Test client for Anna's API recipe")
   
6. Unlike with the API you can leave the [Callback URL][md-terms-callback-url] as-is. You will need it later, when you are testing the API with [Postman][postman], so please note it down (or get back to the client app later when you need this value) 
   
7. Copy the "`Consumer Key`" (a.k.a. [client id][md-terms-client-id]), to be used in the next, final, section.

## Test the API
 
With a [sidecar][md-terms-sidecar] available and a local [DevProxy][md-terms-dev-proxy] enabled you should now be able to test the protected `/hello` endpoint. To test this you need a tool that allows for authenticating with Tetra Pak and then make the request using the security token of that authorization. We'll use [Postman](https://www.postman.com) for this.

1. Install and start [Postman](https://www.postman.com/downloads/).
   
2. From the menus select "File >> New ... >> HTTP Request".
   
3. In the new request UI ensure the method is set to "GET" (should be the default) and add the request URL (eg. `https://localhost:5001/hello`).
   
### Setting up authorization

We now need to set up the authorization comfiguration so that you can obtain an access token to be sent to your new [API][md-terms-api]. Well, actually, the request (and token) are of course sent to your new API's [sidecar][md-terms-sidecar] who will mint a JWT token to be sent along with the request to your new API, as per the [Sidecar JWT Bearer Assertion][md-terms-jwt-bearer-assertion] authorization [scheme][md-terms-authentication-scheme].

Here's how you configure [Postman](https://www.postman.com/downloads/) to authenticate:

4. Set the "[Callback URL][md-terms-callback-url]" to the value you copied from step 6 in the [previous section](#register-a-client-with-tetra-pak)
   
5. Set "Auth URL" to: "https://api-dev.tetrapak.com/oauth2/authorize"
   
6. Set "Access Token URL" to: https://api-dev.tetrapak.com/oauth2/token
 
7. Set the "[Client ID][md-terms-client-id]" to the ("Consumer Key") value you copied from step 7 in the [previous section](#register-a-client-with-tetra-pak)

   > [Postman][postman] might warn about adding the [Client ID][md-terms-client-id] as a string literal like this, suggesting instead that your should create a [Postman][postman] variable and reference it instead. If you're not sure what that is all about then just ignore it.
   
8. From the "Client Authentication" drop down list, select "Send client credentials in body"

This should cover everything needed to successfully obtain a security token. Let's try it out:

9. Scroll down to the "Get New Access Token" button and click it!

10. You should now see a dialog open and, after a second or so, another dialog indicating the authentication is completed successfully. Either click "Proceed" or wait a few more seconds. 
    
11. That dialog should now be replaced with a bigger one containing the details for the token you where just granted. Click "Use Token".'
    
12. Finally, the real test: Click "Send"



That's it! Try running your API locally. If you run into trouble, please consult the [scenarios document][tetra-pak-aspnet-scenarios].

[tetra-pak-aspnet-api-readme]: ../README.md
[tetra-pak-aspnet-api-readme-jwt-bearer-assertion]: ../README.md#the-sidecar-jwt-bearer-assertion-pattern
[tetra-pak-aspnet-api-readme-jwt-writing-apis]: ../README.md#writing-apis
[tetra-pak-aspnet-api-cheat-sheet]: ./cheatsheet-webapi.md
[tetra-pak-aspnet-api-recipe-2]: ./Recipe2-WebApi.md
[tetra-pak-aspnet-scenarios]: ../../Scenarios.md
[tetra-pak-aspnet-scenarios-no-browser]: ../../Scenarios.md#issue-no-browser-window-opens-when-i-run-my-web-app
[tetra-pak-aspnet-scenarios-invalid-redirect-uri]: ../../Scenarios.md#error-400---invalid-redirect_uri
[github-tetrapak-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet
[nuget-tetrapak-app]: https://www.nuget.org/packages/TetraPak.AspNet
[github-tetrapak-api]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet.Api
[nuget-tetrapak-api]: https://www.nuget.org/packages/TetraPak.AspNet.Api
[github-tetrapak-common]: https://github.com/Tetra-Pak-APIs/TetraPak.Common
[nuget-tetrapak-common]: https://www.nuget.org/packages/TetraPak.Common
[demo.web-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/demo.WebApp
[di-intro-1]: https://medium.com/flawless-app-stories/dependency-injection-for-dummies-168dad181a3d
[di-intro-2]: https://www.freecodecamp.org/news/a-quick-intro-to-dependency-injection-what-it-is-and-when-to-use-it-7578c84fa88f/
[middleware]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
[oauth-refresh-flow]: https://datatracker.ietf.org/doc/html/rfc6749#section-1.5
[aspnet-core-configuration]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0
[tetra-pak-dev-test-portal]: https://developer-test.tetrapak.com
[tetra-pak-dev-dev-portal]: https://developer-dev.tetrapak.com
[tetra-pak-dev-portal]: https://developer.tetrapak.com
[tetra-pak-dev-portal-appreg-consumer-key]: https://developer.tetrapak.com/products/getting-started/manage-your-app#consumer-key
[tetra-pak-dev-portal-appreg-callback]: https://developer.tetrapak.com/products/getting-started/manage-your-app#callback-url
[tetra-pak-dev-portal-api-guidelines]: https://developer.tetrapak.com/products/api-design
[hsts]: https://en.wikipedia.org/wiki/HTTP_Strict_Transport_Security
[aspnet-layout]: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/layout?view=aspnetcore-5.0
[aspnet-authorize-attribute]: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/simple?view=aspnetcore-5.0
[aspnet-razor]: https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c
[ide-vs]: https://visualstudio.microsoft.com/
[ide-vscode]: https://code.visualstudio.com/
[ide-rider]: https://www.jetbrains.com/rider/
[ide-eclipse]: https://www.eclipse.org/ide/
[postman]: https://www.postman.com/

[md-RespondAsync]: ./_codeApi/TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md#controllerbaseextensionsrespondasynclttgtcontrollerbase-outcomelttgt-int-readchunk-responsedelegatelttgt-method
[md-ControllerBaseExtensions]: ./_codeApi/TetraPak_AspNet_Api_Controllers_ControllerBaseExtensions.md
[md-Outcome-T]: https://github.com/Tetra-Pak-APIs/TetraPak.Common/blob/master/TetraPak.Common/_docs/_codeApi/TetraPak_Outcome_T_.md
[md-EnumOutcome-T]: https://github.com/Tetra-Pak-APIs/TetraPak.Common/blob/master/TetraPak.Common/_docs/_codeApi/TetraPak_EnumOutcome_T_.md
[md-prop-TetraPakAuthConfig-IdentitySource]: ../../TetraPak.AspNet/_docs/_codeApi/TetraPak_AspNet_TetraPakAuthConfig.md#tetrapakauthconfigidentitysource-property
[md-type-TetraPakIdentitySource]: ../../TetraPak.AspNet/_docs/_codeApi/TetraPak_AspNet_Auth_TetraPakIdentitySource.md

[md-setting-localhost-port]: ../../Scenarios.md#setting-the-localhost-port
[md-terms]: ../../TermsAndConcepts.md
[md-terms-actor]: ../../TermsAndConcepts.md#actor
[md-terms-api]: ../../TermsAndConcepts.md#api
[md-terms-api-key]: ../../TermsAndConcepts.md#api-key
[md-terms-api-management-system]: ../../TermsAndConcepts.md#api-management-system
[md-terms-api-manager]: ../../TermsAndConcepts.md#api-manager
[md-terms-app-registration]: ../../TermsAndConcepts.md#app-registration
[md-terms-audience]: ../../TermsAndConcepts.md#audience
[md-terms-authentication]: ../../TermsAndConcepts.md#authentication
[md-terms-authentication-scheme]: ../../TermsAndConcepts.md#authentication-scheme
[md-terms-apigee-edge]: ../../TermsAndConcepts.md#apigee-edge
[md-terms-business-api]: ../../TermsAndConcepts.md#claim#business-api
[md-terms-callback-url]: ../../TermsAndConcepts.md#callback-url
[md-terms-claim]: ../../TermsAndConcepts.md#claim
[md-terms-claims-transformation]: ../../TermsAndConcepts.md#claims-transformation
[md-terms-client]: ../../TermsAndConcepts.md#client
[md-terms-client-credentials]: ../../TermsAndConcepts.md#client-credentials
[md-terms-client-id]: ../../TermsAndConcepts.md#client-id
[md-terms-client-secret]: ../../TermsAndConcepts.md#client-secret
[md-terms-consumer-key]: ../../TermsAndConcepts.md#consumer-key
[md-terms-dev-portal]: ../../TermsAndConcepts.md#developer-portal
[md-terms-dev-proxy]: ../../TermsAndConcepts.md#development-proxy
[md-terms-identity]: ../../TermsAndConcepts.md#identity
[md-terms-jwt-bearer-assertion]: ../../TermsAndConcepts.md#jwt-bearer-assertion
[md-terms-product]: ../../TermsAndConcepts.md#product
[md-terms-runtime-environment]: ../../TermsAndConcepts.md#runtime-environment
[md-terms-sidecar]: ../../TermsAndConcepts.md#sidecar
[md-terms-terminus]: ../../TermsAndConcepts.md#terminus-api
[md-terms-tpas]: ../../TermsAndConcepts.md#tetra-pak-auth-services