## Integrate an API with Tetra Pak

This is the typical recipe for integrating a (.NET based) API with Tetra Pak's Auth Services, and an overviewing flow chart for the steps: 

![Flow - integrate terminus API](../_graphics/flow_integrate_api_1.png)

In a real-life project there are, at the time of this writing*, a few steps where you need a favor from an [API manager][cat-api-manager]; someone with access to Tetra Pak's [API Management System][cat-apigee-edge], and that knows how to use it. In the flow chart (above) those steps are marked with asterisks (*). For the integration you need one piece of information this recipe you will need two pieces of information from the [API manager][cat-api-manager]: The API [audience][cat-audience] identifier.

As your API will always be running "behind" a protective [sidecar][cat-sidecar] (a reverse proxy), and the integration requires this sidecar, you might also need the name of the [sidecar][cat-sidecar] to be able to run and debug your API locally, using your preferred IDE.   

However, to avoid having you sitting around waiting to get this information, we have configured a special "demo" [sidecar][cat-sidecar] for you. If you prefer using this pre-configured resource then the [audience][cat-audience] and [sidecar][cat-sidecar] identifier is the same: "`demo_hello_api`". If this is how you want to build your demo API then you can skip the first two preparation steps and continue with [creating the API project](#create-the-api-project).

> \* *The API innovation team strives to provide tools and services to make developers as autonomous and empowered as possible, but as of now some steps needs to be vetted and approved manually.*

- [Integrate an API with Tetra Pak](#integrate-an-api-with-tetra-pak)
- [Register the API with Tetra Pak](#register-the-api-with-tetra-pak)
- [Create a sidecar](#create-a-sidecar)

1. [**Register the API with Tetra Pak**](#register-the-api-with-tetra-pak)

Before we can integrate the API with [TPAS][cat-tpas] we need to first [register it as an "app"][cat-client] with Tetra Pak. In this step we'll browse over to the [Tetra Pak Developer Portal][tetra-pak-dev-test-portal] and see how that is done. We will need some information from this step, such as the [audience][cat-audience].

> \* *An `app registration` is how [TPAS][cat-tpas] "knows" about your API. But clients of APIs also needs to be recognized and, often, your API needs to consume other APIs, effectively making it both an API **and** a client of other services ([see API recipe 2][tetra-pak-aspnet-api-recipe-2]). We just use the term "app registration" or "app" for sake of simplicity.*

2. [**Create a *sidecar***](#create-a-sidecar)

   Your API will be managed and protected by its [sidecar][cat-sidecar] (deployed with Tetra Pak's [API management system][cat-apigee-edge]) so we need one set up for us, by an [API manager][cat-api-manager].

3. [**Create the API project**](#create-the-api-project)

   Your preferred development tools (IDE) will (probably) offer some sort of [project scaffolding](https://en.wikipedia.org/wiki/Scaffold_(programming)) where you pick a suitable project template, choose authorization mechanism, maybe add Git integration, and so on. The way this is done differs (quite a lot) between IDEs so the recipe will only offer general guidance. You are expected to know your tool!

4. [**Add SDK Nuget package**](#add-sdk-nuget-package)

   This step is where you add the SDK support and should be very straight forward. But, again, there will be no detailed steps as this is also done differently from one IDE to another.

5. [**Write business logic**](#write-the-business-logic)

   We write the controller and the two endpoints (`/hello` and `/hello/version`). In a real-life project you would probably start writing the business logic *after* you're done integrating your API with [TPAS][cat-tpas] but for sake of "flow" we'll do it before the integration step, coming up next.

6. [**Integrate with TPAS**](#integrating-with-tetra-pak-auth-services)

   This is where we write the code and add the necessary configuration to integrate with [TPAS][cat-tpas] and set your API up to be function behind its [sidecar][cat-sidecar]. We'll need some details ([audience][cat-audience] and [sidecar][cat-sidecar] name) from the previous steps to complete this one (or use the pre-configured "`demo_hello_api`" resource).

   In the above flow diagram you will notice that for configuration there is a choice to be made: "Identity Source". We will explain this in more detail later but, just to give a hint, going with the "`IdToken`" source is faster but also quite limited, whereas the "`RemoteService`" path allows for way more control and user information but adds more complexity and a small performance hit.

7. [**Test the API**](#test-the-api)

   When we're done we need to test the API. For this we need a [registered "app"][cat-client], set up to be a trusted client of our new API. This is also done from the [Tetra Pak Developer Portal][cat-dev-portal].

   We will then make test requests to the new API using [Postman][postman].

So, with the plan firmly set in our mind, let's do this...

## Register the API with Tetra Pak

>This step of the recipe will demonstrate how to [register an "app"][cat-client] with Tetra Pak. This is so you can do it yourself in your projects. After registering you would then need the assistance of an [API manager][cat-api-manager] to configure your registered app and create a [sidecar][cat-sidecar] for it.
>
> For the sake of this recipe you can instead rely on a pre-configured app registration, to avoid the lead time from having to reach out and wait for your registration to be configured and ready for use. Read through the following steps if you want to understand how to register your API "app". Alternatively, just use the pre-configured "`demo_hello_api`" resource for [audience][cat-audience] andn [sidecar name][cat-sidecar] and move on to [Create the API project](#create-the-api-project)

For any app to integrate with [TPAS][cat-tpas] it needs to be recognized by Tetra Pak. This is done by simply registering the app, with a name and unique "[consumer key][cat-client-id]". You do this in the [Tetra Pak developer portal][tetra-pak-dev-test-portal] like so:

1. Open a browser and navigate to the [Tetra Pak developer portal][tetra-pak-dev-test-portal]

   >This instruction assumes you are starting out with a DEV (Development) [runtime environment][cat-runtime-environment]. For PROD (Production) please use the [production development portal][tetra-pak-dev-portal].

2. Log in

3. Click the "Apps" menu item at the top of the page

4. Click the "Add app" command (upper left part of page)

5. Give your app a name and supply a short description of it

6. Specify the [Callback URL][cat-callback-url] (from [this step](#save-local-url)). The default callback path for this SDK is `/auth-callback`. So, for example, if your local host is `https://localhost:8080` then the [Callback URL][cat-callback-url] should be `https://localhost:8080/auth-callback`

   > Please note that this value can be edited later if you return to your app registration and select the "Edit" tab (will be visible once you save your app registration). If you are unsure at this time which port you'll be using locally then just change this value later, when you know the full callback URL. [For more information please go here][tetra-pak-dev-portal-appreg-callback].

7. In a "real" web app you would probably want to consume one or more [API products][cat-product]. For this recipe that is not the case (we will cook a "[terminus API][cat-terminus]"). However, please double check that the "`Enterprise Application Security`" service is already selected, or select it otherwise. This service is critical for integrating with [TPAS][cat-tpas]. You might have to scroll down to see it

8. Click "ADD APP" (bottom of the web page)

9. You are now presented with your app overview page, where all your [app registrations][cat-app-registration] are listed. Please select the one you just created by clicking it. This should present the App details, such as the [client credentials][cat-client-credentials] ([Consumer Key][cat-client-id] and [Consumer Secret][cat-client-secret]).


## Create a sidecar

All Tetra Pak APIs must be *managed*, meaning they must be running "behind" a [sidecar][cat-sidecar] (a managed reverse proxy). Getting a [sidecar][cat-sidecar] set up and configured is unfortunately (at the time of this writing) not something you can do yourself. Instead, your project should have one assigned [API manager][cat-api-manager] that you need to turn to to get this done. Usually, it's a fairly quick process but you need to reach out to get this done and then wait for these tasks to be completed. In doing so you need to get this information back:

1. You will have to agree on an [audience][cat-audience] for the [JWT Bearer Assertion flow][cat-jwt-bearer-assertion] to work. This is simply a name (or "*identifier*") to be used by your [sidecar][cat-sidecar]. Negotiate a suitable [audience][cat-audience] identifier for your [API manager][cat-api-manager].

2. If you plan to consume other services (APIs) from your API, you need to mention this requirement to your [API manager][cat-api-manager]. This will affect how your sidecar gets configured. For this recipe this is not needed (see the [next API recipe][tetra-pak-aspnet-api-recipe-2] for an example of an API that consumes other Tetra Pak services).

3. Ask the [API manager][cat-api-manager] to add the ability for a [*Development Proxy*][cat-dev-proxy]. This is so you can run and debug your API locally. If that was unclear; don't worry. We'll get back to this shortly. Just read on.

4. When you get the [sidecar name][cat-sidecar] and [audience]
 

[cat-actor]: ./CAT.md#actor
[cat-api]: ./CAT.md#api
[cat-api-key]: ./CAT.md#api-key
[cat-api-management-system]: ./CAT.md#api-management-system
[cat-api-manager]: ./CAT.md#api-manager
[cat-app-registration]: ./CAT.md#app-registration
[cat-audience]: ./CAT.md#audience
[cat-authentication]: ./CAT.md#authentication
[cat-authentication-scheme]: ./CAT.md#authentication-scheme
[cat-apigee-edge]: ./CAT.md#apigee-edge
[cat-business-api]: ./CAT.md#business-api
[cat-callback-url]: ./CAT.md#callback-url
[cat-claim]: ./CAT.md#claim
[cat-claims-transformation]: ./CAT.md#claims-transformation
[cat-client]: ./CAT.md#client
[cat-client-credentials]: ./CAT.md#client-credentials
[cat-client-id]: ./CAT.md#client-id
[cat-client-secret]: ./CAT.md#client-secret
[cat-consumer-key]: ./CAT.md#consumer-key
[cat-dev-portal]: ./CAT.md#developer-portal
[cat-dev-proxy]: ./CAT.md#development-proxy
[cat-identity]: ./CAT.md#identity
[cat-jwt-bearer-assertion]: ./CAT.md#jwt-bearer-assertion
[cat-product]: ./CAT.md#product
[cat-runtime-environment]: ./CAT.md#runtime-environment
[cat-sidecar]: ./CAT.md#sidecar
[cat-terminus]: ./CAT.md#terminus-api
[cat-tpas]: ./CAT.md#tetra-pak-auth-services

[tetra-pak-aspnet-api-recipe-2]: ../TetraPak.AspNet.Api/_docs/Recipe2-WebApi.md
[tetra-pak-dev-test-portal]: https://developer-test.tetrapak.com
