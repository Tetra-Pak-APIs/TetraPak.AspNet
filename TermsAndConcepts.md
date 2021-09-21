# TetraPak.AspNet SDK - Terms & Concepts

The security domain is filled with terms, many to describe the same concept. This document is just a convenient go-to for the terms and concepts referred to by the other SDK documents.

## Actor

We use the term "`actor`" for *the acting party that initiated a request*. This can be a human or some autonomous service. The actor must be recognized as an `identity` by the Tetra Pak Auth Services (TPAS)

See also: [Identity](#identity)

## App (registration)

Aliases: [Client](#client)
See also: [Client id](#client-id), [Client secret](#client-secret)


## Authentication

The process of making sure the responsible [actor](#actor) is indeed who she claims to be. The actor might be human or another software service (such as a web job, daeomon or some other process). There are many ways to authenticat an actor, which are usually referred to as [`schemes`](#authentication-scheme) (ASP.NET) or *flows* (OAuth). 

See also: [Actor](#actor), [Authorization](#authorization), [Identity](#identity), [Scheme](#authentication-scheme)

## Authentication scheme

In ASP.NET an authentication scheme refers to a particular mechanism (a.k.a. *flow* or *grant* in OAuth) for authenticating the [actor](#actor) responsible for making a request.

Each [`scheme`](#authentication-scheme) supports a certain type of actor. For human actors the [OAuth Code Grant][oauth-code-grant] flow is often very popular as it allows a human actor a way to authenticate herself with an authority that is separate from the service asking for the actor's permission to act on her behalf, while also ensuring that service can never get access to the actor's secrets (such as a password). This is an example of a "three-legged auth flow".

For non-human [actors](#actor) the [OAuth Client Credentials][oauth-client-credentials-grant] flow is usually preferred. This type of grant makes it possible for the software service to authenticate by the use of its own credentials (client id and client secret) but also puts a requirement on that service to ensure the client secret is indeed persisted in a secure (encrypted) fashion, to avoid its unintentional spread.

See also: [Actor](#actor), [Authentication](#authentication)

## Authorization

The process of asserting an [actor's](#actor) privileges, ensuring it can only consume resources for which it has proper access to, avoiding the unintentional spread of sensitive information to the wrong consumers.

[Actors](#actor)' [identity](#identity) *usually* needs to be asserted (through   [authentication](#authentication)) when making requests for restricted information but in many scenarios, where requests are made for *public information* anonymous (a.k.a. "guest") [actors](#actor) are authorized as well.

See also: [Authentication](#authentication), [Identity](#identity)

## Claim
In .NET a *claim* is a small piece of information about an [identity](#identity), such as a first/last name or email address. The claim is usually an item in a list of key/value pairs where the "key" (known as a *claim type*) uniquely identifies the claim within the list and the value contains the claim itself (eg. email address).

See also: [Identity](#identity), [ClaimsIdentity][class-ClaimsIdentity]

## Client

Within the world ofd API management a *client* represents a piece of software that consumes APIs (a.k.a. *Services*) within the domain of managed APIs. Please note that an API itself might be a *client*.

Aliases: [App (registration)](#app-registration)
See also: [Client id](#client-id), [Client secret](#client-secret)

## Client Id

A unique name for a client (or "app registration") within an API management system. This concept have many names within the domain of security, such as *API Key* or *Consumer Key*. The value itself might be a random string, a GUID or anything that makes sense within its context, as long as it uniquely identifies an individual client.

## Client Secret

All clients (a.k.a. [App (registration)](#app-registration)) hold a secret piece of information which can be used as proof of the client's identity as it needs to be authenticated when making requests to services. For human actors this is her secret password. For software [clients](#client) it is usually a fairly long random string. 

The client secret is very sensitive information and steps must be taken to ensure it never "leaks", to be used for malicious authentication requests.

## Developer portal

In Tetra Pak this is the go-to web resource for all things related to API consumption and creation. The developer portal is a [sub domain under the Tetra Pak top domain][dev-portal]. There is currently also a ["test" developer portal][dev-portal-test], intended for more experimental scenarios but that might be a bit unstable at times.

Tetra Pak emplyees or consultants should be able to log in to the developer portal using single-signon whereas other clients will have to log on interactively.

The developer portal can be used to find API products and allow 

## Downstream

In architecture downstream usually means a message getting made from an actor to a service, or from such a service to another service. In architectural diagrams the direction is generally *away* from the initiating actor.

## Flow

Alias: [Authentication scheme](#authentication-scheme), [Grant](#grant)

## Grant

Alias: [Authentication scheme](#authentication-scheme), [Flow](#flow)

## Identity

In general terms an all [actors](#actor) have one or more "proofs of identity", or just "identities". In the physical world a person can hold multiple "proofs of identity", such as her driving license, passport, ID card, etc. In .NET an *identity* usually means a "claims identity" (implemented by the [ClaimsIdentity][class-ClaimsIdentity]), which supports a list of [claims](#claim).

See also: [Ator](#actor)

As an example; In an ASP.NET API, a [`ControllerBase`][class-ControllerBase]  supports a [`User`][prop-ControllerBase-User] property, of type [ClaimsIdentity][class-ClaimsIdentity], that identifies the [actor](#actor) that initiated the current request, ***if*** that actor was successfully [authenticated](#authentication).

See also: [Authentication](#authentication)

## Product

An API "product" is the name for an ongoing effort to support one or more Tetra Pak APIs with a shared organization and life cycle management. Each API product is developed, maintained and supportyed by an organization and its [product owner](#product-owner).

See also: [Developer portal](#developer-portal), [Product owner](#product-owner)

## Product owner

A Tetra Pak resource that is responsible for the maintenance, development lifecycle and support of an [API product](#product).

See also: [API product](#product), [Developer portal](#developer-portal)

## Terminus (API)

An API that is self-sustained in that it never makes [downstream](#downstream) requests. Instead all information required to complete the request can be obtained from its own resources.

We use this term in the SDK documentation to distinguish an API because such an API have no need to authenticate itself and, therefore, have no requirement for securely persisting its credentials ([client id](#client-id) and [client secret](#client-secret)), which removes complexity from its configuration and implementation.

## Tetra Pak Auth Services

A suite of services responsible for [authenticating](#authentication) and authorizing 

[class-ClaimsIdentity]: https://docs.microsoft.com/en-us/dotnet/api/system.security.claims.claimsidentity
[class-ControllerBase]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase
[prop-ControllerBase-User]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.user
[oauth-code-grant]: https://www.oauth.com/oauth2-servers/server-side-apps/authorization-code/
[oauth-client-credentials-grant]: https://www.oauth.com/oauth2-servers/access-tokens/client-credentials/
[dev-portal]: https://developer.tetrapak.com
[dev-portal-test]: https://developer-test.tetrapak.com