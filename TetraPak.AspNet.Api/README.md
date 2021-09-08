# TetraPak.AspNet.Api

## Overview

The TetraPak.AspNet libraries are provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical C3 (cross cutting concerns) such as authorization, logging and so on. 

## Authentication and security

When writing web-based solutions for Tetra Pak you should ensure you are in line with the current Tetra Pak guidelines and security policies and the simplest way to do so is to rely on the APIs and helpers provided by this package.

There is a difference, however, depending on whether you are writing a web client application (such as a ASP.NET Core MVC solution based on Razor or Blazor) or whether you are writing a Web API. This package mainly supports you in writing a web API so if you are writing a web client application refer to the [TetraPak.AspNet package][nuget-tetrapak-aspnet].


### The "Sidecar JWT Bearer Assertion" pattern

One very typical security pattern supported by the Tetra Pak Login APIs is the *Sidecar JWT Bearer Assertion* pattern. 

[nuget-tetrapak-aspnet]: https://www.nuget.org/packages/TetraPak.AspNet

## Backend services

-- TODO --