# TetraPak.AspNet

## Overview

The TetraPak.AspNet SDK libraries are provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical cross-cutting concerns (C3) such as authorization, logging and so on.

## Authentication and security

When writing web-based solutions for Tetra Pak you should ensure you are in line with the current Tetra Pak guidelines and security policies and the simplest way to do so is to rely on the APIs and helpers provided by this package.

There is a difference, however, depending on whether you are writing a web client application (such as a ASP.NET Core MVC solution based on Razor or Blazor) or whether you are writing a web API. This package mainly supports web applications so if you are writing a web API then please refer to the [TetraPak.AspNet.Api][tetrapak-api] package.

### The 20 minute rule

We in the Tetra Pak API innovation team tries to live by what we call "*the 20 minute rule*" as our guiding principle. What that means is that our "customers" (usually developers) should never have to spend more than 20 minutes on solving a problem typical to most projects.

We have seen over the years that many development projects spend large amounts of time just establishing proper *auth* (authorization and authentication) before they can start consuming Tetra Pak data through APIs or other services that require Tetra Pak authorization. This is something we want to address with this package. Hopefully, by the time you have read this documentation and tested the code APIs offered by the `TetraPak.AspNet` packages you will be able to just add a few lines of code, maybe add some configuration, and you should be good to go. When you start your next project you should be able to start building business value in 20 minutes or less!

## Structure

The TetraPak.AspNet solution consists of two separate Nuget packages and projects: 

 - [TetraPak.AspNet][tetrapak-app] - for ASP.NET web application development
 - [TetraPak.AspNet.Api][tetrapak-api] - for ASP.NET web API development

## Basics 

------

 *You can skip this section if you are a seasoned ASP.NET Core developer*

------

In any ASP.NET Core project the structure is the same. You will find the same two files in the project root folder: `Program.cs` and `Startup.cs` and there will be a folder called `Controllers`. 

### Program

The first file - `Program.cs` with the `Program` class is the entry point, where execution begins when the service is being booted up by its host. You rarely need to touch this code if you don't have logging needs. Taken from the demo.WebApp project, this is what the code can look like:

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

This is where the ASP.NET web hos gets created and invoked. The code basically just sets up the logging providers, including the Console and Azure diagnostics and then goes on to instruct the host builder to use the `Startup` class for its configuration.

### Startup

The `Startup` class is where the interesting stuff happens during the startup process. The project template creates two methods that will automatically be looked for by the host builder: 

- `ConfigureServices` - to set up dependency injection (DI)
- `Configure` - to create the request/response "pipeline"

ASP.NET Core relies heavily on the Dependency Injection design pattern. If you are unfamiliar with this concept then please go read up, do a few spikes to get used to it and then get back here. This concept is not trivial to get used to but once you understand its benefit and have gotten used to it you will find development gets a lot easier and you code becomes less interdependent (more "decoupled") and therefore less sensitive to changes. Your code will also be easier to test as you are able to inject mock components to emulate behavior of more complex components, such as communicating with external/remote services. 

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

The `IServiceCollection` object (`services`) is responsible for building all services that should be available during execution, to be automatically injected (DI) or created on request (service location) by you code. You can either set up services as singletons or transient/scoped instances through methods such as ...

- `services.AddSingleton<T>()`
- `services.AddTransient<T>()`
- `services.AddScoped<T>()`

... but a common approach is to instead invoke extension methods that are supplied from libraries you're including in your project. That is what we are looking at in the above code example. The `services.AddControllersWithViews();` statement is added by the project template but we have also added a call to a second extension method: `services.AddTetraPakOidcAuthentication();`. That extension method will then, in turn, add whatever singletons, transient or scoped services required for automatic integration with the Tetra Pak (Open ID Connect) remote services.

Please note that the `Startup.ConfigureServices` method is just setting up DI, making all required services available when needed. It doesn't matter in what order you set them up.

Next, the `Startup` will invoke the `Configure` method, passing `IApplicationBuilder` (`app`) and `IWebHostEnvironment` (`env`) objects. The `app` object is used for creating the "request pipeline" through various middleware components. Those components are simply pieces of code that gets a chance to read, validate and even affect each incoming request. You can add custom middleware code by just calling `app.Use(...)` and supply delegate code to be called for each request. The delegate will receive an `HttpContext` object (that, among other details, carries a `HttpRequest`) and also a delegate for the next middleware to be called after this one.

We won't go into details about ASP.NET Core middleware but just for clarity, you could write a very simple middleware that just adds a header to the request, like this:

```c#
 app.Use((context, func) =>
 {
     context.Request.Headers.Add("my-header", "Hello World!");
     return func();
 });

```

With that every incoming request will be channeled to your middleware code, which simply adds a (nonsensical) header to the request and then calls whatever middleware is set up to be invoked after yours. A lot can be achieved through custom middleware delegates and, just like with setting up DI in `ConfigureServices`, you tend to call extension methods that handles the complex details of injecting middleware in the right order.

Again, the order in which you inject middleware, is very important. All middleware gets called in this order and some middleware, such as authenticating requesting actor, requires the "routing" middleware (logic that resolved which controller and method should be invoked) to have run and added routing information to the context. If this is not the case, the authentication middleware would have no way of figuring out whether the requested endpoint actually requires authentication or not. 

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

By just looking at the code you can pretty much understand how a request gets handled by your web app or API. In this example the code starts with checking whether the app is running in development mode/environment. If that's the case it enables a special page for handling exceptions that allows for more details, useful to diagnostics. For a non-development scenario it instead sets up a more generic error page and also protects the app by requiring HTTP Strict Transport Security (HSTS).

After that a middleware will ensure all unencrypted (HTTP) requests gets redirected to an encrypted (HTTPS) address instead.

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

## Summary

This SDK will make it possible for you to get started with a new web application/API and start writing business logic in less than 20 minutes. To do so here's what you need to do, depending on whether you're writing a web application or a web API:

### Web Application TODO

- Open the `Startup.cs` file.
- In the `ConfigureServices`, add this line of code (anywhere in the method):
```c#
services.AddTetraPakOidcAuthentication(); // <-- add this
```

- In the `Configure` method add this line of code *after* the `app.UseRouting()` method and *before* the `app.UseAuthorization()` method:

```c#
app.UseAuthentication(); // <-- add this after routing / before authorization
```




[tetrapak-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet
[tetrapak-api]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet.Api
[demo.web-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/demo.WebApp
[di-intro-1]: https://medium.com/flawless-app-stories/dependency-injection-for-dummies-168dad181a3d
[di-intro-2]: https://www.freecodecamp.org/news/a-quick-intro-to-dependency-injection-what-it-is-and-when-to-use-it-7578c84fa88f/
[middleware]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
[oauth-refresh-flow]: https://datatracker.ietf.org/doc/html/rfc6749#section-1.5
[aspnet-core-configuration]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0