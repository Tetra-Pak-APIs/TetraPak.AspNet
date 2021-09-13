# TetraPak.AspNet - Web App Cheat Sheet

This is the fast-track to get your web app integrated with Tetra Pak Auth Services with minimum fuzz. 

---

*NOTE*

*If you need a better overview and some in-depth then please check out the [README document][tetra-pak-aspnet-readme]. There is also a [nice recipe][tetra-pak-aspnet-recipe] where you are walked through building a simple web app and integrating it with the Tetra Pak Auth Services.*

---

## Register your app in the Tetra Pak Developer Portal

1. Browse to https://developer.tetrapak.com and log in (for development/test purposes instead browse to https://developer-test.tetrapak.com)
2. Click the "Apps" menu item in the top of the page
3. Click the "Add app" command (upper left part of page)
4. Give your app a name and supply a short description of it.
5. If necessary, specify your callback URL 

    (always necessary for local debugging, e.g. https://localhost:8080/auth-callback)

6. Copy the Consumer Key

## Configure your web app

7. In the `appsettings.json`; add section `"TetraPak"` and paste in the consumer key as `"ClientId"`:

    ```json
    {
       "TetraPak": {
          "ClientId": "(paste consumer key here)"
       }
    }
    ```

## Add Tetra Pak authentication to Startup.cs

9. In your web app project; open the `Startup.cs` file
10. Add this line anywhere in the `Startup.ConfigureServices` method:
    
    ```c#
    services.AddTetraPakOidcAuthentication(); // <-- add this
    ```
11. In the `Startup.Configure` method; ensure these middleware exists in this order:

    ```c#
    app.UseRouting();        // <-- necessary

    app.UseTetraPakAuthentication(hostEnvironment); // <-- _after_ routing and _before_ authorization

    app.UseAuthorization();  // <-- necessary    
    ```


[tetra-pak-aspnet-readme]: ../README.md
[tetra-pak-aspnet-scenarios]: ../../Scenarios.md
[tetra-pak-aspnet-recipe]: ./Recipe-WebApp.md
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