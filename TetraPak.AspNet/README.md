# TetraPak.AspNet

## Overview

The TetraPak.AspNet libraries are provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical C3 (cross cutting concerns) such as authorization, logging and so on. 

## Authentication and security

When writing web-based solutions for Tetra Pak you should ensure you are in line with the current Tetra Pak guidelines and security policies and the simplest way to do so is to rely on the APIs and helpers provided by this package.

There is a difference, however, depending on whether you are writing a web client application (such as a ASP.NET Core MVC solution based on Razor or Blazor) or whether you are writing a Web API. This package mainly supports web applications so if you are writing a Web API then please refer to the [TetraPak.AspNet.Api][tetrapak-api] package.

### The 20 minute rule

We in the Tetra Pak API innovation team tries ty live by what we call "*the 20 minute rule*" as our own guiding principle. What that means is that our "customers" (usually developers) should never have to spend more than 20 minutes on solving a problem typical to most projects. 

We have seen over the years that many development projects spend large amounts of time just establishing proper *auth* (authorization and authentication) before they xan start consuming Tetra Pak data through APIs or other services that require Tetra Pak authorization. This is something we want to address with this package. Hopefully, by the time you have read this documentation, and tested the code APIs offered by the `TetraPak.AspNet` packages you will be able to just add a few lines of code, maybe add some configuration, and you should be good to go, focusing on adding business value!

## Getting Started

---

*This package is focused on integrating **web applications** with the Tetra Pak authorization services. For **web API projects** please look to [TetraPak.AspNet.Api][tetrapak-api]* 

---

In any Tetra Pak web application project, to integrate with the company's authorization services through this package, this is the typical pattern:

- Add one or two lines of code to the `Startup.cs` file, enabling auth
- Add whatever configuration is needed to the `appsettings.json` file(s). For a typical web applications no configuration is needed.

### Demo projects

A good way to get started is to investigate existing apps that consume the tools you're interested in. This is why we have included demo projects to the repository. For web apps check out the [demo.WebApp][demo.web-app] project. Let's walk through it ...

In the `Startup` class there are two methods that gets created by any ASP.NET Core (or .NET 5+) project template: `ConfigureServices` and `Configure`. The first one - `ConfigureServices` - is where you set up your [Dependency Injection (DI)][dependency-injection]. The second method - `Configure` - is where you are supposed to configure the web app's [middleware][middleware], i e how requests should be handled and in what order.

Let's have a look at what you need to add in those two methods for your web app to be fully compliant with Tetra Pak's *auth* services:

Anywhere in the `ConfigureServices` method just add this line: 

```c#
services.AddTetraPakOidcAuthentication();
```

This will set up the required DI services for Tetra Pak *auth*. 

Next, in the `Configure` method, add this line: 

```c#
app.UseAuthentication();
```

---

**IMPORTANT:** *This line needs to be added *after* `app.UseRouting()` and *before* `app.UseAuthorization()`.*

---

This will have you covered for basic auth with Tetra Pak's auth services. If that service also offers refresh tokens you can add support for [automatic token refreshing][oauth-refresh-flow] by adding a client id to your [configuration][aspnet-core-configuration], in the `appsettings.json` file(s). 

In the `appsettings.json` file, add a section named "`TetraPak-Auth`" and add your client id to the "`ClientId`" value, like in this example:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Auth-TetraPak": {
    "ClientId": "example-1234567890",
  }
}
```

## Protecting your web app

With the above steps your web app is now wired to automatically authenticate and authorize your resources but you still need to specify what resources requires authorization. Some pages might be open to anyone without needing to authenticate. In a MVC-based web project you can protect individual views or all views controlled by specific view controllers by attributing them with the `[Authorize]` attribute. 

In the following example the "Overview" and "Details" views requires authorization whereas the others are available to all (anonymous) users:

```c#
public class HomeController : Controller
 {
     readonly ILogger<HomeController> _logger;
     readonly IConfiguration _configuration;

     public IActionResult Index()
     {
         return View();
     }

     [Authorize]
     public async Task<IActionResult> Overview()
     {
         return View(new OverviewModel(User.Identity));
     }

     [Authorize]
     public IActionResult Details()
     {
         var token = await Request.HttpContext.GetAccessTokenAsync();
         return View(new DetailsModel(token));
     }

     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
     public IActionResult Error()
     {
         return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
     }
     
     public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
     {
         _logger = logger;
         _configuration = configuration;
     }
 }
```

### Getting the user's identity

Oftentimes you might need the (authenticated) user's identity. It might be because you simply want to present it in a view or because it is needed in calls to services you call to fetch data.

The authorized user's identity is always available in the view controller's `User.Identity` property. Please check out the `Details` (view) method in the above example to see how that can be used.

---

*Please not that the user identity is only reliably available if the user was actually authorized.* 

---

### Getting the access token 

At other times it might be necessary to obtain the security token provided by the authorized client/user. This value is provided by calling an extension method of the 

### Recipe: Securing static pages

Sometimes you might have a need to use public static pages, located under the ASP.NET "wwwroot" folder. Such files are always publicly available (no authorization needed) but what if you need the user's identity? To get that authentication is needed and this recipe is one way to achieve that.

#### Ingredients

For this recipe, static page authentication includes the following:

- A secured endpoint (we'll call it `/userinformation`)
- Some restructuring and a few lines of extra code in the `Configure` method (Startup.cs file)

#### Steps

To make it work, do the following:

1. Create a new controller and name it `UserInformationController`:
```c#
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetraPak.AspNet.Recipe
{
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult Get(string origin = null) 
        {
            if (origin is { })
                return Redirect(origin);

            var identity = (ClaimsIdentity) User.Identity;
            var userInfo = new
            {
                userName = User.Identity.Name,
                firstName = identity.FirstName(),
                lastName = identity.LastName()
            }; 
            return Ok(userInfo);
        }
    }
}
```

2. Open the *Startup.cs* file to edit the `Configure` method:
   1. Ensure the `UseStaticFiles` middleware is included and then move it so that is inserted *after* the `UseAuthentication` middleware:
   
   ```c#
   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
       if (env.IsDevelopment())
       {
           app.UseDeveloperExceptionPage();
       }

       app.UseDefaultFiles();
       app.UseWebSockets();
       app.UseRouting();
       app.UseAuthentication();
       app.UseAuthorization();
       app.UseStaticFiles(); // <-- AFTER UseAuthentication
       app.UseEndpoints(endpoints =>
       {
           endpoints.MapControllers();
       });
    }
   ```
   2. Edit the `UseStaticFiles` middleware to enforce redirect to the protected endpoint if user is not authenticated:
   
   ```c#
   app.UseStaticFiles(new StaticFileOptions
   {
       // always require authentication for static files ...
       OnPrepareResponse = context => 
       {
           var path = context.Context.Request.Path.ToString();
           if (!context.Context.User.Identity.IsAuthenticated)
           {
               context.Context.Response.Redirect($"/userInformation?origin={path}");
           }
       }
    });
   ```

[tetrapak-api]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/TetraPak.AspNet.Api
[demo.web-app]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/tree/master/demo.WebApp
[dependency-injection]: https://www.freecodecamp.org/news/a-quick-intro-to-dependency-injection-what-it-is-and-when-to-use-it-7578c84fa88f/
[middleware]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
[oauth-refresh-flow]: https://datatracker.ietf.org/doc/html/rfc6749#section-1.5
[aspnet-core-configuration]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0