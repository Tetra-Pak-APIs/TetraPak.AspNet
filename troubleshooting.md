# TetraPak.AspNet - Troubleshooting

Here are a few issues you might bump into, and suggestions for how to resolve them:

## 401 - API key invalid

Your web app is probably referencing the wrong `client id`. Please check your configuration (eg. `appsettings.json` file) and compare the `"ClientId"` value with your [app registration Consumer Key][tetra-pak-dev-portal-appreg-consumer-key].

## <a id="invalid-redirect-uri"></a> 400 - Invalid redirect_uri

Your web app is probably not configured for the correct `callback URL`. Please check your configuration (eg. `appsettings.json` file) and compare the `"CallbackUrl"` value with your [app registration Callback URL][tetra-pak-dev-portal-appreg-consumer-key].

## <a id="no-browser"></a>No browser window opens when I run my web app

If you are debugging your web app (locally) from your IDE and no browser window opens when you Run or Debug then here's what you can do, depending on your IDE:

**Visual Studio**
- In the Solution Explorer; right-click the project node (`TetraPakWebApp`)
- Select "Debug" section
- Ensure the "Launch browser" check box is ticked

**VS Code**
- In the "Explorer" (sidebar); open the "Properties" folder of your project
- Open the `launchSettings.json` file
- Look for the `TetraPakWebApp` json section
- Ensure there is a setting: `"launchBrowser": true,`. Add it otherwise.

**Rider**
- In the Solution Explorer; open the "Properties" folder of your project
- Open the `launchSettings.json` file
- Look for the `TetraPakWebApp` json section
- Ensure there is a setting: `"launchBrowser": true,`. Add it otherwise.

**(other IDE)**
- Sorry, you are own your own but trying the method for VS Code or Rider is probably a good idea


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