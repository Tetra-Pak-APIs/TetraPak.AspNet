# TetraPak.AspNet

> *This document is an SDK overview. If you're a seasoned ASP.NET Core developer and just want to quickly integrate your web solution with Tetra Pak's Auth Services these might be faster options:*
> - *[Web App recipe][tetra-pak-aspnet-recipe]: Build a small integrated web app*
> - *[Web App Cheat Sheet][tetra-pak-aspnet-cheat-sheet]: Check list to quickly integrate an existing Web App*
> - *[Web API recipe][tetra-pak-aspnet-api-recipe]: Build a small integrated web app*
> - *[Web API Cheat Sheet][tetra-pak-aspnet-api-cheat-sheet]: Check list to quickly integrate an existing Web App*
> 
> *Also, if you have already started integrating your web solution but are facing issues then you might find this [troubleshooting guide][tetra-pak-aspnet-use-cases] useful.*  
 
The TetraPak.AspNet SDK is provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical cross-cutting concerns (a.k.a. "C3") such as authorization, logging and so on. There are also some useful tools that should help you out to develop and test your solutions.

## The 20 minute rule

We in the Tetra Pak API innovation team tries to live by what we call "*the 20 minute rule*" as our guiding principle. What that means is that API consumers (usually developers) should never have to spend more than 20 minutes on solving a problem that is typical to most projects.

We have seen over the years that many development projects spend considerable time just establishing correct and safe *auth* (authorization & authentication) before they are able to move on to building new business value. This is something we want to address with this SDK.

Hopefully, by the time you have read this documentation and tested the code APIs offered by the `TetraPak.AspNet` SDK packages you will be able to integrate your  should be able to just add a few lines of code and configuration to your project and you should be good to go. When you start your next project you should be done with auth and ready to start building business value in 20 minutes or less!

## Structure

The TetraPak.AspNet SDK consists of two separate Nuget packages (.NET projects): [TetraPak.AspNet][nuget-tetrapak-app] and [TetraPak.AspNet.Api][github-tetrapak-api]. Both Nuget packages requires the [TetraPak.Common][nuget-tetrapak-common] package ([documentation here][github-tetrapak-common]). 

The SDK is open source and both Nuget projects are part of the same solution, [available at GitHub][github-tetrapak-app].

### [TetraPak.AspNet][github-tetrapak-app]

This [Nuget][nuget] package is the base of the SDK and covers code APIs and toos to assist you when building Tetra Pak integrated web clients based on ASP.NET Core/5+. There are three documents to help you get up to speed using the [TetraPak.AspNet][nuget-tetrapak-app]:

- [README][tetra-pak-aspnet]
  
  This document covers the introduction, overview and details of the Nuget package's code APIs and tools. Start here if you have the time and want the full picture.

- [Recipe][tetra-pak-aspnet-recipe]

  Provides a walk-through building a very simple ASP.NET web app and integrate it with the Tetra Pak Auth Services. This might be a great place to start for a quick introduction without too many details.

- [Cheat Sheet][tetra-pak-aspnet-cheat-sheet]

  A very fast and no-nonsense checklist for quickly integrating an existing ASP.NET Core/5+ web client with the Tetra Pak Auth Services. Start here if you have used the SDK for this purpose one or two times before and just need a quick reminder.

### [TetraPak.AspNet.Api][github-tetrapak-api]

This [Nuget][nuget] package contains additional code APIs and tools to help you integrate your web API project with the Tetra Pak Auth Services, and make you more productive implementing typical API related design patterns. The [Nuget][nuget] package is based on the [TetraPak.AspNet][nuget-tetrapak-app], which will automatically be included by Nuget for you.

> You sometime find yourself writing a web project that not only supports views (web pages) but that also has an API. The typical scenario is when you're making calls from your web views back to this API via JavaScript (typically AJAX or SignalR at the time of this writing). 
> 
> If this is the case then you should rely on the [TetraPak.AspNet.Api][nuget-tetrapak-api] Nuget package. By adding this package, as it implicitly relies on the [TetraPak.AspNet][nuget-tetrapak-app] package, you will get the full support for both views and API endpoints.

There are three documents to help you get up to speed using the [TetraPak.AspNet.Api][nuget-tetrapak-api]:

- [README][tetra-pak-aspnet-api]
  
  This document covers the introduction, overview and details of the Nuget package's code APIs. Start here if you have the time and want the full picture.

- [Recipe][tetra-pak-aspnet-api-recipe]

  Provides a walk-through building a very simple ASP.NET web API and integrate it with the Tetra Pak Auth Services. This might be a great place to start for a quick introduction without too many details.

- [Cheat Sheet][tetra-pak-aspnet-api-cheat-sheet]

  A very fast and no-nonsense checklist for quickly integrating an existing ASP.NET Core/5+ web API with the Tetra Pak Auth Services. Start here if you have used the SDK for this purpose one or two times before and just need a quick reminder.

## General Concepts

Regardless of what type of web project you are building - a web app or a web API (or both) - you might find it useful to understand the concepts supported by this SDK. 

### Auth Protocols and Flows

This SDK will give you a very conventient way of integrating with the Tetra Pak Auth Services. Those services support several auth protocols including [OAuth][oauth-wikipedia], [Kerberos][kerberos-wikipedia] and [SAML][saml-wikipedia]. The latter two protocols are older and invented in a time where most communication happened on an intranet. [OAuth][oauth-wikipedia], on the other hand, is tailored for the needs of Internet and the "world wide web". Currently, this SDK will provide integration with the [various auth flows of OAuth][oauth-flows-nordic-apis].

We will not deep dive into how the various [OAuth flows][oauth-flows-nordic-apis] actually work; there are loads of good articles explanining this. Instead, we will look into how those flows are actually supported by this SDK, and when to use which.

The Tetra Pak Auth Services currently support the following [OAuth flows][oauth-flows-nordic-apis]:

- Auth Code Flow
- Open Id Connect (OIDC)
- Token Exchange
- Client Credentials

The process of picking the correct flow for the job, and then configure it correctly is a complex task that requires alot from the developer, including:

- How the flows actually work, including callbacks, the use of proper configuration for the selected flow.
- Which services to actually rely on during the process of authenticating and auhorizing an actor.
- How ASP.NET implements the *auth mechanisms*.
- What ASP.NET Middleware to use and how to correctly configure them, based on the above items.

This task can take alot of time, depending on the developer's background and knowledge of the Tetra Pak Auth Services. To better understand what we are facing, let's just do a quick fly-over to see how ASP.NET implements *auth mechanisms*, by examining the "anatomy" of a request...

### The anatomy of an ASP.NET request 

When an *actor* (a user or service) makes a request for some resource in your web project (such as a web view or through an SPI endpoint), ASP.NET will channel that request through a "[chain of responsibility][design-pattern-chain-of-responsibility]". Each "responsibility" (a.k.a. "command") is a small piece of code that will be called to participate in managing the request. This small piece of code is provided with two things: The "request context" (a [`HttpContext`][http-context]) and a pointer to the next small piece of code to be called afterwards. Microsoft calls these small-pieces-of-code "*Middleware*", so let's use that term from now on.

> Please [go here][doc-webapp-overview-middleware] for a small example of what a simple Middleware can look like.

Each individual Middleware can affect the request, such as modifying, adding or removing headers, "decorating" the request with more "ambient data" or even reject the request, cancelling further processing by subsequent Middleware entirely. This is a very flexible design pattern and also easy to understand and use.

This is also what the ASP.NET "auth" mechanism relies on! As a request enters the wep host an [`HttpContext`][http-context] object gets created and is then channeled through whatever Middleware was set up, in the very order they where declared (in the `Startup.Configure` method of your project). 

This is what this SDK relies on to authenticate and authorize wveey request. What happens when you declare how you want to authenticate an actor is that the SDK injects (and configures) the correct Middleware components into this "Middleware chain".

Examining a typical `Startup.Configure` implementation for a web app (APIs look a bit different), this is what it might look like: 

```c#
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
```

It's pretty simple to imagine what happens to a request just by looking at this code:

1. `app.UseExceptionHandler("/Home/Error")`:
   
   The request gets configured to always redirect a failed request to a custom error page, to be neatly presented.

2. `app.UseHsts()`
   
   The request gets decorated with an additional "`Strict-Transport-Security`" header.

3. `app.UseHttpsRedirection()`
   
   If the incoming request is not made through the secure/encrypted schema ("HTTPS") it will automatically be redirected to an equivalent endpoint, cancelling further processing in the "Middleware chain".

<a name="middleware-routing"></a>
4. `app.UseRouting()`
   
   Adds a point in the Middleware pipeline where the request URL is examined and a decision is made how to route it to the correct `Controller` endpoint. This Middleware assumes another piece of Middleware is later added: `app.UseEndpoints()`. Both of these steps are necessary for an MVC web app. If you where to write an app that relies on plai HTML you could actually leave those out (and write a ton of code yourself).

<a name="middleware-step5-authentication"></a>
5. `app.UseAuthentication()`
   
   This Middleware examines the request, looking for any security token that might have been submitted (usually in the well-known "`Authorization`" header). If one is found it will be validated. If one is not found the Middleware mighth automatically redirect the request to some `authority`, forcing the user to authenticate and, perhaps, concent to having his/her data shared with the app (such as name and/or contact information). If a security token does exist but the validation fails, for whatever reason (it mught have expired or it is found to be corrupt in some way) then, again, this Middleware might decide to simply fail (redirecting to the custom error page) *or* redirect the request to the aforementioned Authority for renewed authentication. 
   
   <a name="middleware-step4-identity"></a>
   To add to the complexity; after a successful authentication this is also the time to construct the actor's *identity*. How this is done might vary but it could be to simply look for an identity token or to call some external *Identity Service* that was configured.

   As you might have guessed; this is a very complex piece of Middleware (actually, it is often a chain of Middleware itself) that can be heavily configured to act correctly in a multitude of security scenarios, invoking the correct Authority, Token Issuer and, potentionally, Identity Service, with the configured details required. Knowing how to set all this up is what usually takes alot of time and requires a good understanding of both the ASP.NET authentication mechanism and of the services acting as the Authority, token issuer and so on. 

   Few coders are proficient in these matterns so time is wasted getting this all to work properly.

   This, as you might have guessed, is where this SDK will save you a ton of time. Please read on.

6. `app.UseAuthorization()`
   
   This Middleware relies on routing information having already been creted (by step 4). Using this information this Middleware can now check to see if the targeted endpoint (a method in a `Controller`) is protected (decorated with the `[Authorize]` attribute). If not, the Middlewre just passes the request on to the next one. If the target endpoint is indeed protected then this Middleware will ensure the request is properly authorized before access is granted, or redirecting it to the configured error response.

7. `app.UseEndpoints()`
   
   Like already mentioned (in [step 4](#middleware-routing)) this Middleware will provide the routing rules required for the [routing Middleware](#middleware-routing).

### Setting up authentication

If you read through the [General concepts](#general-concepts) section you should have a pretty good understanding of how an incoming request is being processed by your web project. It should be apparent that this is all handled by a chain of Middleware code components in the order by which they where added in the `Startup.Configure` method in your project.

One final piece is missing, however, to see the full auth picture: How to pick an auth flow?

Like [mentioned earlier](#auth-protocols-and-flows) the Tetra Pak Auth Services supports several [OAuth flows][oauth-flows-nordic-apis] but how do you pick which one to use and how do you configure the *authentication* [Middleware](#middleware-step5-authentication) to use that flow, and how? 

All we do in `Startup.Configure` is this: `app.UseAuthentication()`. That just enables authentication, at the correct time in the Middleware pipeline (which is **after** *Routing* and **before** *Authorization*). But for the Middleware to actually do its job, using the correct *auth flow* and so on, a multitude of details are needed. This includes the URLs for the correct Tetra Pak Auth Services (*Authority*, *Token Issuer*, *User Information Service*, and so on). That, in turn, depends on which *runtime environment* your process is executing from. You also need to provide one or more *authentication schemes*, each representing an auth flow and then provide the necessary configuration for that flow to actually work, including *client id*, possibly a *client secret*, maybe a *callback URL*, and so on. It all depends on which flow you want for the requested (and protected) resource.

So, you're left with two tasks: 

1. Picking the correct auth flow for the job
2. Configuring that auth flow to work as expected, with the Tetra Pak Auth Services

In an ASP.NET Core/5+ project the supported *auth schemes* (a scheme is basically an *auth flow* and the configuration to support it) are set up using Dependency Injection (DI). In an ASP.NET Core/5+ project DI is configured in the `Startup.ConfigureServices` method.

> It is assumed you already understand what [DI][tetra-pak-aspnet_dependency-injection] is and how to set it up in your project. If not, please go read up [here][di-intro-1] and [here][tetra-pak-aspnet_dependency-injection].

Setting up an auth scheme for integration with the Tetra Pak Auth Services can be a daunting task, as mentioned. We won't dive into how to do that "manually" here. What's important is that you understand this is done via DI, in the `Startup.ConfigureServices` method. We will instead see how this SDK can do the heavy lifting for you, saving you hours (if not weeks) of reading up and getting the correct information from the right people.

## How this SDK can help

Like mentioned in the precious section, as a developer you are tasked with deciding what *auth scheme* (flow) to use for your web app and how to configure it. The second part (the configuration) can be almost completely left over to the SDK. Most confiuration is actually the same as long as you integrate with the Tetra Pak Auth Services, such as the correct URLs for the various services (depending on your [*runtime environment*](#runtime-environment)). All you need to supply is what varies from one project to the next. As a minimum, that includes two items:

- Your *client id*
- The intended [*runtime environment*](#runtime-environment)

Some flows (typically in an API project) also requires a: 
- *client secret*

So, how do you get a *client id* (and *client secret*), and what is it used for, you might ask? Seconfly, how do you configure them along with the *runtime environment* to allow the SDK to do the hard work for you?

Lets look into this now...

### Client Id (and Secret) 

For any client to work with any OAuth flow, it needs a way to identify itself. This is what the *client id* is for. That allows the Tetra Pak Auth Services to know which app is trying to talk to it, and also ensure it is actually the correct app (and not some malicious service). For this to work you need to register your "*app*" (a.k.a. "*client*") with the Tetra Pak Auth Services. This is done through the Tetra Pak Developer Portal.

Basically, what you do is:

- Log in to the [Tetra Pak Developer Portal][tetra-pak-dev-dev-portal]
- Register an *app* (give it a name and, optionally, a short description)
- Pick all Tetra Pak APIs ("*products*") you want to consume, from a list

With this you now have an *app registration*. Part of that registration is a *client id* and *client secret*, generated for you by the Tetra Pak Auth Services. 

**WARNING!** 

The *client id* and *client secret* is ***confidential information*** and you now have a responsibility to ensure they remain secrets!

> One *classic* way to unintentionally reveal your app's *client id* and *client secret* to the world is to copy them to a file that is included in your (version controlled) code repository, perhaps on GitHub or some equivalent service. This could be because you hard-code the data into your code files (a BIG no-no!) or into a configuration file that is mistakenly included in your version controlled code repo.
>
> **Please ensure you don't fall into that trap!**

Protecting your secrets is a topic in itself and we will have to get back to that in the future. As of now there are no tools in this SDK to help you with this (it might be a feature for a a future version however, should you want it).

**TIP**: Please check out the [web app recipe][tetra-pak-aspnet-recipe] (or [web API recipe][tetra-pak-aspnet-api-recipe]) if you want some more insight into how registering an app is actually done.

### Configuration

Assuming you now have a *client id* (and *secret*) you now need to configure your app to use them for your integration with Tetra Pak. This can easily be done through:

- The `appsettings.json` file
- The `TetraPakAuthConfig` class

### Runtime Environment

### Identity

-- TODO --

[tetra-pak-aspnet]: ./TetraPak.AspNet/README.md
[tetra-pak-aspnet_dependency-injection]: ./TetraPak.AspNet/_docs/aspnet_webapp_overview.md#startup
[tetra-pak-aspnet-use-cases]: ./UseCases.md
[tetra-pak-aspnet-recipe]: ./TetraPak.AspNet/_docs/Recipe-WebApp.md
[tetra-pak-aspnet-cheat-sheet]: ./TetraPak.AspNet/_docs/cheatsheet-webapp.md
[tetra-pak-aspnet-api]: ./TetraPak.AspNet.Api/README.md
[tetra-pak-aspnet-api-recipe]: ./TetraPak.AspNet.Api/recipe-webapi.md
[tetra-pak-aspnet-api-cheat-sheet]: ./TetraPak.AspNet.Api/cheatsheet-webapi.md
[doc-webapp-overview-middleware]: ./TetraPak.AspNet/_docs/aspnet_webapp_overview.md#middleware
[github-tetrapak-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet
[nuget-tetrapak-app]: https://www.nuget.org/packages/TetraPak.AspNet
[github-tetrapak-api]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet.Api
[nuget-tetrapak-api]: https://www.nuget.org/packages/TetraPak.AspNet.Api
[github-tetrapak-common]: https://github.com/Tetra-Pak-APIs/TetraPak.Common
[nuget-tetrapak-common]: https://www.nuget.org/packages/TetraPak.Common
[nuget]: https://docs.microsoft.com/en-us/nuget/what-is-nuget
[demo.web-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/demo.WebApp
[middleware]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
[oauth-refresh-flow]: https://datatracker.ietf.org/doc/html/rfc6749#section-1.5
[aspnet-core-configuration]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0
[tetra-pak-dev-dev-portal]: https://developer-dev.tetrapak.com
[tetra-pak-dev-portal]: https://developer.tetrapak.com
[tetra-pak-dev-portal-appreg-consumer-key]: https://developer.tetrapak.com/products/getting-started/manage-your-app#consumer-key
[tetra-pak-dev-portal-appreg-callback]: https://developer.tetrapak.com/products/getting-started/manage-your-app#callback-url
[hsts]: https://en.wikipedia.org/wiki/HTTP_Strict_Transport_Security
[aspnet-layout]: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/layout?view=aspnetcore-5.0
[aspnet-authorize-attribute]: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/simple?view=aspnetcore-5.0
[aspnet-razor]: https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c
[oauth-wikipedia]: https://en.wikipedia.org/wiki/OAuth
[oauth-flows-nordic-apis]: https://nordicapis.com/8-types-of-oauth-flows-and-powers/
[kerberos-wikipedia]: https://en.wikipedia.org/wiki/Kerberos_(protocol)
[saml-wikipedia]: https://en.wikipedia.org/wiki/Security_Assertion_Markup_Language
[design-pattern-chain-of-responsibility]: https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern
[http-context]: https://docs.microsoft.com/en-us/dotnet/api/system.web.httpcontext?view=netframework-4.8
[di-intro-1]: https://medium.com/flawless-app-stories/dependency-injection-for-dummies-168dad181a3d
[di-intro-2]: https://www.freecodecamp.org/news/a-quick-intro-to-dependency-injection-what-it-is-and-when-to-use-it-7578c84fa88f/