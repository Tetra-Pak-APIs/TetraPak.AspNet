# TetraPak.AspNet

---

*If you're a seasoned ASP.NET Core developer and all you want to achieve is to quickly integrate your web app (or API) with Tetra Pak's auth services then you can [just skip ahead to the Summary section](#summary). If you want some more background and  need a better understanding, however, please continue.*

---

## Overview

The TetraPak.AspNet SDK libraries are provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical cross-cutting concerns (C3) such as authorization, logging and so on.

## Authentication and security

When writing web-based solutions for Tetra Pak you should ensure you are in line with the current Tetra Pak guidelines and security policies and the simplest way to do so is to rely on the APIs and helpers provided by this package.

There is a difference, however, depending on whether you are writing a web client application (such as a ASP.NET Core MVC solution based on Razor or Blazor) or whether you are writing a web API. This package mainly supports web applications so if you are writing a web API then please refer to the [TetraPak.AspNet.Api][tetrapak-api] package.

### The 20 minute rule

We in the Tetra Pak API innovation team tries to live by what we call "*the 20 minute rule*" as our guiding principle. What that means is that our "customers" (usually developers) should never have to spend more than 20 minutes on solving a problem that is typical to most projects.

We have seen over the years that many development projects spend considerable amounts of time just establishing correct and safe *auth* (authentication and authorization) just to enable safe and secure Tetra Pak data consumption, and commende in creating new business value. This is something we want to address with this package. 

Hopefully, by the time you have read this documentation and tested the code APIs offered by the `TetraPak.AspNet` packages you will be able to just add a few lines of code and configuration, and you should be good to go. When you start your next project you should be able to start building business value in 20 minutes or less!

## Structure

The TetraPak.AspNet solution consists of two separate Nuget packages and projects: 

 - [TetraPak.AspNet][tetrapak-app] - for ASP.NET web application development
 - [TetraPak.AspNet.Api][tetrapak-api] - for ASP.NET web API development

## Basics 

------

*You may skip this section if you are a seasoned ASP.NET Core developer. If so you can skip ahead to [API Management and Security patterns](#api-management-and-security-patterns).*

------

In all ASP.NET Core project the structure is the same. You will find the same two files in the project root folder: `Program.cs` and `Startup.cs` and there will be a folder called `Controllers`. This goes for web applications, serving "views" (web pages), as well as web APIs (serving data). Let's walk through the purpose of the two .cs (code) files:

### Program

The first file - `Program.cs` declares the `Program` which serves as the service entry point, where execution begins when the service is being booted up by its host. You rarely need to touch this code unless you have custom logging needs. Taken from the demo.WebApp project, this is what the code can look like:

```c#
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => 
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddAzureWebAppDiagnostics();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
```

The code creates and invokes an ASP.NET Core web host. The code basically just sets up the logging providers, including the Console and Azure diagnostics and then goes on to instruct the host builder to use the `Startup` class for its configuration.

### Startup

The `Startup` class is declared in the `Startup.cs` file and this is where the interesting stuff happens during the startup process. The project template creates two methods that will automatically be looked for by the host builder: 

- `ConfigureServices` - to set up dependency injection (DI)
- `Configure` - to create the request/response "pipeline"

ASP.NET Core relies heavily on the Dependency Injection design pattern. If you are unfamiliar with this concept then please go read up, do a few spikes to get used to it and then get back here. This concept is not trivial to get used to but once you understand its benefit and have gotten used to it you will find development gets a lot easier and your code becomes less interdependent (more "decoupled") and therefore less sensitive to changes. Your code will also be easier to test as you are able to inject mock components to emulate behavior of more complex components, such as communicating with external/remote services. 

Searching for "dependency injection" will get you a ton of results but here are two resources you might like: 

- [Dependency Injection for dummies][di-intro-1]
- [A quick intro to Dependency Injection: what it is, and when to use it][di-intro-2]

Again, using the demo.WebApp as an example, let's look at some code and go from there:

```c#
public void ConfigureServices(IServiceCollection services)
{
   services.AddControllersWithViews();
   services.AddTetraPakOidcAuthentication(); // <-- add this
}
```

The `IServiceCollection` object (`services`) is responsible for preparing all services that should be available during execution, to be automatically injected (DI) or created on request by you code (service location). You can either set up services as singletons or transient/scoped instances through methods such as ...

- `services.AddSingleton<T>()`
- `services.AddTransient<T>()`
- `services.AddScoped<T>()`

... but a common approach is to instead invoke extension methods that are supplied from libraries you're including in your project. That is what we are looking at in the above code example. The `services.AddControllersWithViews();` statement is added by the project template but we have also added a call to a second extension method: `services.AddTetraPakOidcAuthentication();`. That extension method will then, in turn, add whatever singletons, transient or scoped services are required for automatic integration with the Tetra Pak (Open ID Connect - "OIDC") remote services.

Please note that the `Startup.ConfigureServices` method is just setting up DI, making all required services available when needed. It doesn't matter in what order you set them up.

Next, the `Startup` will invoke the `Configure` method, passing `IApplicationBuilder` (`app`) and `IWebHostEnvironment` (`env`) objects. The `app` object is used for creating the "request pipeline" through various middleware components. Those components are simply pieces of code that gets a chance to read, validate and even affect every request as they are being sent to your service. 

You can add custom middleware code by just calling `app.Use(...)` and supply delegate code to be called for each request. The delegate will receive an `HttpContext` object (that, among other details, carries a `HttpRequest`) and also a delegate for the next middleware to be called after this one.

We won't go into details about ASP.NET Core middleware but just for clarity, you could write a very simple middleware that just adds a header to the request, like this:

```c#
 app.Use((context, func) =>
 {
     context.Request.Headers.Add("my-header", "Hello World!");
     return func();
 });

```

With that, every incoming request will be channeled to your middleware code, which simply adds a header to the request and then calls whatever middleware is set up to be invoked after yours. A lot can be achieved through custom middleware delegates and, just like with setting up DI in `ConfigureServices`, you tend to call extension methods that handles the complex details of injecting middleware in the right order.

Again, the order in which you inject middleware, is very important. All middleware gets called in this order and some middleware, such as authenticating requesting actor, requires the "routing" middleware (logic that resolves the correct controller and method to be invoked) to have run and added routing information to the request/response context. If this information has not been provided, the authentication middleware would have no way of figuring out whether the requested endpoint actually requires authentication or not. 

A typical middleware setup for a web application would look similar to this: 

```c#
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// HINT: this is a good place to add: app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
```

By just looking at the code you can pretty much understand how a request gets handled by your web app or API. In this example the code starts with checking whether the app is running in development mode/environment. If that's the case it enables a special page for handling exceptions that allows for more details, useful to diagnostics. For a non-development scenario it instead sets up a more generic error page and also protects the app by signalling to browsers that the service is requiring HTTP Strict Transport Security (HSTS).

After this, the request gets pssed to a middleware will ensure all unencrypted (HTTP) requests gets redirected to an encrypted (HTTPS) address instead.

The request will then be routed to the correct method in a Controller (routing). This will make routing information available to all middleware that runs after this point.

After the routing middleware the app will authorize the actor. We won't go into details about ASP.NET authorization (it's a pretty large subject) but before that happens you might notice that the identity of the actor has not actually been validated. This is how a typical ASP.NET Core project gets scaffolded from its template. That won't work for Tetra Pak web applications however.  

Incoming access tokens/credentials (depending on the supported authentication schemes) needs to be validated through a middleware that can establish the authenticity of the actor and also build his/her/its identity (name, e-mail, roles and so on). All of that can be achieved either by standard middleware supplied by Microsoft or by using one of the specialized schemes supplied by this SDK. On such scheme is Tetra Pak OIDC (Open ID Connect). You can add that authentication scheme with a single line of code:

```c#
app.UseAuthentication(); // <-- add this after routing / before authorization
```

That looks pretty generic doesn't it? There is no mention of OIDC or "Tetra Pak" anywhere. The reason for that is that there can be many different authentication schemes in a web app (or API) and the 'authentication' middleware will simply let all of them have a go at validating the actor, using their own internal logic. The authentication schemes are therefore supplied through DI, meaning you set them up in the `ConfigureServices` method, not in the `Configure` method.  

Setting up OIDC authentication while also supporting cookies (for web applications; APIs doesn't support cookies) is a fairly complex task that require you have a good understanding of that's happening in the various "auth flows" you want to support. Put simply; this means you need to know about authority endpoints, "well-known" discovery document endpoints and quite a few other nitty-gritty.

As a Tetra Pak developer, however, these things are pretty much always the same and, like mentioned, we want you to get started adding business value in less than 20 minutes, remember? So (and here's the good news!) all you need to add to the `ConfigureServices` method, in your web application, is this line of code:

```c#
services.AddTetraPakOidcAuthentication(); // <-- add this
```

If you are writing a web API, instead add this line to protect it with an Apigee "sidecar" reverse proxy:

```c#
services.AddSidecarJwtAuthentication(); // <-- add this
```

## API Management and Security Patterns

**--TODO--** Overview / Intro to API mgmt and why we want to protect the APIs

**--TODO--** Graphic (Managed API Patterns)

### Managed API pattern

**--TODO--** Explanatory text


### 

## Summary

This SDK will make it possible for you to get started with a new web application/web API and begin adding business value in less than 20 minutes. To do so here's what you need to do, depending on whether you're writing a web application or a web API:

### Register your App in Developer portal

For any app to integrate with the Tetra Pak auth services it needs to be registered and recognized. This is done by simply registering the app, with a name and unique "client id" (a.k.a. "consumer key"), in the Tetra Pak Developer Portal. This is very easily done by just following these steps:

1. Open a browser and navigate to the [Tetra Pak developer portal][tetra-pak-dev-dev-portal] (see next NOTE! below)

---

 NOTE! *This instruction assumes you are starting out with a DEV (Development) environment. For PROD (Production) please use the [Production development portal][tetra-pak-dev-portal].*

---


2. Log in (please note that Tetra Pak users should use the link to single sign-on, in the login form, not the form itself)
3. Click the "Apps" menu item in the top of the page
4. Click the "Add app" command
5. Give your app a name and supply a short description of it (generally you can leave the Callback URL as is)
6. Select one or more API products to be consumed by your app. Please note that "Enterprise Application Security" is already selected; this service is what you're integrating with using this SDK.
7. Click "ADD APP" (you might have to scroll down)
8. You are now taken to your app overview page, where all your app registrations are listed. Please select the one you just created by clicking it. This should present the App details.
9. From the App details click the "copy" icon next to the "Consumer Key" (you will need this value in the next phase; [Integrating your Web App](#integrating-your-web-app-aspnet-core--aspnet-5)).

![Copy consumer key (client id)](./_graphics/copy_client_id.png)


### Integrating your Web App (ASP.NET Core / ASP.NET 5+):

1. Create the project through standard project templates
2. Open the `appsettings.json` file in an editor
3. Add a new section and name it "TetraPak" and paste the consumer key you copied in the previous phase as a named "ClientId":

```json
"TetraPak": {
    "ClientId": "(paste the consumer key value here)"
}
```

This is the minimum amount of configuration needed to successfully integrate your new web app with Tetra Pak's auth services. To finish the integration, let's add two lines of code into two separate methods:

4. Open the `Startup.cs` file.
5. In the `ConfigureServices` method, add this line of code (anywhere in the method):

```c#
services.AddTetraPakOidcAuthentication(); // <-- add this
```

6. In the `Configure` method add this line of code ***after*** the `app.UseRouting()` method and ***before*** the `app.UseAuthorization()` method:

```c#
app.UseAuthentication(); // <-- add this after routing / before authorization
```

Just to perform a quick sanity check; this is more or less what those two method should look like if you made no other changes (disclamer: there might be more or less code added by the project template):

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddTetraPakOidcAuthentication(); // <-- add this
    services.AddControllersWithViews();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthentication(); // <-- add this

    app.UseAuthorization();
}

```


[tetrapak-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet
[tetrapak-api]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet.Api
[demo.web-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/demo.WebApp
[di-intro-1]: https://medium.com/flawless-app-stories/dependency-injection-for-dummies-168dad181a3d
[di-intro-2]: https://www.freecodecamp.org/news/a-quick-intro-to-dependency-injection-what-it-is-and-when-to-use-it-7578c84fa88f/
[middleware]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
[oauth-refresh-flow]: https://datatracker.ietf.org/doc/html/rfc6749#section-1.5
[aspnet-core-configuration]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0
[tetra-pak-dev-dev-portal]: https://developer-dev.tetrapak.com
[tetra-pak-dev-portal]: https://developer.tetrapak.com