# TetraPak.AspNet

## Overview

The TetraPak.AspNet libraries are provided as a way to get more productive when writing web-based solutions that integrate with Tetra Pak's landscape. It includes code APIs and helpers for typical C3 (cross cutting concerns) such as authorization, logging and so on. 

## Authentication and security

When writing web-based solutions for Tetra Pak you should ensure you are in line with the current Tetra Pak guidelines and security policies and the simplest way to do so is to rely on the APIs and helpers provided by this package.

There is a difference, however, depending on whether you are writing a web client application (such as a ASP.NET Core MVC solution based on Razor or Blazor) or whether you are writing a Web API. This package mainly supports web client applications so if you are writing a Web API then please refer to the TetraPak.AspNet.Api ![TODO: Link to the Api packs] packages.

### Recipe: Securing static pages

Sometimes you might have a need to use public static pages, located under the ASP.NET "wwwroot" folder. Such files are always publicly available (no authorization needed) but what if you need the user's identity? To get that authentication is needed and this recipe is one way to achieve that.

#### Ingredients

For this recipe, static page authentication includes the following:

- A secured endpoint (we'll call it "/userInformation)
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