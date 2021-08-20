# TetraPak.AspNet

## This document

This document aims to provide the big picture of how to use this SDK. If this is the first few times you are using the SDK then this is a great place to start. But depending on your background you might also consider starting elsewhere:

If you are somewhat new to ASP.NET Core/5+ web app development then it might be a good idea first check out the [ASP.NET Core/5+ Project Overview][aspnet-webapp-overview] and then come back here.

If you are a seasoned ASP.NET Core/5+ developer and just want to quickly integrate your web app (or API) with Tetra Pak's Auth Services then you can either just skip ahead to the [cheat cheat][tetra-pak-aspnet-cheat-sheet] or try [this recipe][tetra-pak-aspnet-recipe] on how to build a simple web client and integrate it with Tetra Pak Auth Services.

Also, if you are already well on your way with this SDK and are facing an issue or a use case you are unsure of how to resolve then it might be a good idea to check out [this document][tetra-pak-aspnet-usecases] 

However, if you want some more background or need a better understanding; then please continue.

## Overview

The TetraPak.AspNet SDK is provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical cross-cutting concerns (a.k.a. "C3") such as authorization, logging and so on. There are also some useful tools that should help you out to develop and test your solutions.

This document will first walk you through the motivation for this package and then introduce you to the project structure and start up procedure of a typical ASP.NET Core/5+ web application. This is to ensure you have the background information needed to better understand how this package can help you get more productive when building Tetra Pak integrated web apps. With that out of the way the document then provides an overview of the various code APIs and tools offered, explaining how they work and the options provided for them.

This document mainly offers the "big picture" for concepts, tools, and code APIs. More details are then provided in separate documents. If you feel you already have a very good understanding of ASP.NET Core/5+ web app project structure and startup, then 

### The 20 minute rule

We in the Tetra Pak API innovation team tries to live by what we call "*the 20 minute rule*" as our guiding principle. What that means is that our "customers" (usually developers) should never have to spend more than 20 minutes on solving a problem that is typical to most projects.

We have seen over the years that many development projects spend considerable amounts of time just establishing correct and safe *auth* (authentication and authorization) to enable Tetra Pak data consumption create new business value. This is something we want to address with this package.

Hopefully, by the time you have read this documentation and tested the code APIs offered by the `TetraPak.AspNet` package you will be able to just add a few lines of code and configuration, and you should be good to go. When you start your next project you should be done with auth and ready to start building business value in 20 minutes or less!

### Authentication and security

When writing web-based solutions for Tetra Pak you should ensure you are in line with the current Tetra Pak guidelines and security policies and the simplest way to do so is to rely on the code APIs and helpers provided by this SDK.

There is a difference, however, depending on whether you are writing a web client application (such as a ASP.NET Core/5+ **web app**, based on [Razor][aspnet-razor]) or whether you are writing a **web API**. Web clients often relies on session state from cookies whereas APIs do not. Web apps are designed to be consumed by a web browser. If a request needs to be authorized but there is no security token within the request, the web app can automatically redirect the web client to the proper authority to participate in the required *auth flow* to establish a secure session and security token. The *auth flow* is one of several [OAuth flows][oauth-flows] (typically the [*authorization code grant*][oauth-auth-code-flow]). 

 Web APIs, however, are designed to be consumed by any type of client. The client can be a native mobile or desktop app, a web app or even a daemon process running in some IOT device that regularily consumed pices of data to provide its service. As an API cannot rely on the capabilities of a web client (browser) it cannot offer the automated authorization funtionality of a web app. Instead, the API's client is responsible for "knowing" beforehand how to establish a secure session with the API and provide whatever security token is required when it makes its first request to the API.

This SDK supports the needs of a web app. If you are building a web API, or a web client that also supports an API, then you should instead look to the [TetraPak.AspNet.Api][nuget-tetrapak-api] package.

## TetraPak.AspNet Code APIs

With the ASP.NET Core/5+ project structure out of the way let's now turn our attention to the various options and tools you have when integrating your web app with the Tetra Pak Auth Services.

The SDK currently supports integration with Tetra Pak's Auth Services using the Open Id Connection (IODC) auth flow. To use it just call the `IServiceCollection.AddTetraPakOidcAuthentication` method somewhere in the `Startup.ConfigureServices` method.

## Configuration



### Caching

-- TODO --


## API Management and Security Patterns

**--TODO--** Overview / Intro to API mgmt and why we want to protect the APIs

**--TODO--** Graphic (Managed API Patterns)

### Managed API pattern

**--TODO--** Explanatory text




[tetra-pak-aspnet]: ./README.md
[tetra-pak-aspnet-use-cases]: ../UseCases.md
[tetra-pak-aspnet-recipe]: ./_docs/Recipe-WebApp.md
[tetra-pak-aspnet-cheat-sheet]: ./_docs/cheatsheet-webapp.md
[aspnet-webapp-overview]: ./_docs/aspnet_webapp_overview.md

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
[aspnet-core-configuration]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0
[tetra-pak-dev-dev-portal]: https://developer-dev.tetrapak.com
[tetra-pak-dev-portal]: https://developer.tetrapak.com
[tetra-pak-dev-portal-appreg-consumer-key]: https://developer.tetrapak.com/products/getting-started/manage-your-app#consumer-key
[tetra-pak-dev-portal-appreg-callback]: https://developer.tetrapak.com/products/getting-started/manage-your-app#callback-url
[hsts]: https://en.wikipedia.org/wiki/HTTP_Strict_Transport_Security
[aspnet-layout]: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/layout?view=aspnetcore-5.0
[aspnet-authorize-attribute]: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/simple?view=aspnetcore-5.0
[aspnet-razor]: https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c
[oauth-flows]: https://auth0.com/docs/flows
[oauth-auth-code-flow]: https://datatracker.ietf.org/doc/html/rfc6749#section-1.3.1
[oauth-refresh-flow]: https://datatracker.ietf.org/doc/html/rfc6749#section-1.5

