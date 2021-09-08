# TetraPak.AspNet.Api

## This document

This document aims to provide the big picture of how to use this SDK while creating or consuming APIs. If this is the first few times you are using the SDK then this is a great place to start. But depending on your background you might also consider starting elsewhere:

If you are somewhat new to ASP.NET Core/5+ web app development then it might be a good idea first check out the [ASP.NET Core/5+ Project Overview][aspnet-webapp-overview] and then come back here.

If you are a seasoned ASP.NET Core/5+ developer and just want to quickly integrate your web app (or API) with Tetra Pak's Auth Services then you can either just skip ahead to the [cheat cheat][tetra-pak-aspnet-api-cheat-sheet] or try [this recipe][tetra-pak-aspnet-api-recipe] on how to build a simple web client and integrate it with Tetra Pak Auth Services.

Also, if you are already well on your way with this SDK and are facing an issue or a use case you are unsure of how to resolve then it might be a good idea to check out [this document][tetra-pak-aspnet-usecases] 

However, if you want some more background or need a better understanding; then please continue.

## Overview

The TetraPak.AspNet libraries are provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical C3 (cross cutting concerns) such as authorization, logging and so on. 

## Authentication and security

When writing web-based solutions for Tetra Pak you should ensure you are in line with the current Tetra Pak guidelines and security policies and the simplest way to do so is to rely on the APIs and helpers provided by this package.

There is a difference, however, depending on whether you are writing a web client application (such as a ASP.NET Core MVC solution based on Razor or Blazor) or whether you are writing a Web API. This package mainly supports you in writing a web API so if you are writing a web client application refer to the [TetraPak.AspNet package][nuget-tetrapak-aspnet].

### The Sidecar JWT Bearer Assertion pattern

One very typical security pattern supported by the Tetra Pak Login APIs is the *Sidecar JWT Bearer Assertion* pattern. 

[nuget-tetrapak-aspnet]: https://www.nuget.org/packages/TetraPak.AspNet

## Backend services

-- TODO --


[aspnet-webapp-overview]: ../TetraPak.AspNet/_docs/aspnet_webapp_overview.md
[tetra-pak-aspnet-api-cheat-sheet]: ./_docs/cheatsheet-webapi.md
[tetra-pak-aspnet-api-recipe]: ./_docs/cheatsheet-webapi.md