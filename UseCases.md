# TetraPak.AspNet SDK - Use Cases

Here are a several typical use cases, including issues, you will likely face and suggestions for what to do:

<a id="api-key-invalid"></a>
## Error `401 - API key invalid`

Your web app is probably referencing the wrong `client id`. Please check your configuration (eg. `appsettings.json` file) and compare the `"ClientId"` value with your [app registration Consumer Key][tetra-pak-dev-portal-appreg-consumer-key].

<a id="invalid-redirect-uri"></a>
## ERROR `400 - Invalid redirect_uri`

Your web app is probably not configured for the correct `callback URL`. Please check your configuration (eg. `appsettings.json` file) and compare the `"CallbackUrl"` value with your [app registration Callback URL][tetra-pak-dev-portal-appreg-consumer-key].

<a id="no-browser"></a>
## ISSUE: No browser window opens when I run my web app

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

## Getting the actor's identity

Obtaining the authenticated actor's identity is a feature built in to ASP.NET already. This can be easily done via your controller's `User` property. This property's value is a [`ClaimsPrincipal`](https://docs.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal?view=net-5.0) that supports a collection of 'claims'. You can either examine those claims or you can use the [`ClaimsPrincipal.Identity`] property, which will return an [`IIdentity`]. 

## Getting the token

Sometimes it is necessary for your code, in your Web App or Web API, to obtain the incoming access token or identity token. 

## Configuring secrets

Configuring your Tetra Paj integration is easily done by simply adding a "`TetraPak`" configuration section in your `appsettings.json` file (or one of the runtime environment versions, such as `appsettings.Development.json`). 

Those files, however, have a tendency to find their way into your code repository unless you take the extra precaution to include them in your `.gitignore` file. Depending on your IDE of choice this might (or might not) be handled by the project template you pick when you create your web project. Either way, placing confidential information into unencrypted text files is not a very good idea. You should instead rely on the various "secure storage" options available to you. 

We will not dive into how to pick a secure storage or how to work with them; that is a topic beyond the scope of this document. But the SDK offers a simple way to include confidential information in configuration without adding it into unencrypted configuration files, by use of the `ITetraPakAuthConfigDelegate` interface.

By implementing this contract and configuring the DI framework to use it you get full control over how secrets are obtained. The interface supports several method, to provide fine delegation control, but only one is needed for obtaining secrets: `ITetraPakAuthConfigDelegate.OnGetClientSecretsAsync`. For convenience the SDK offers a basic implementation of this interface - `TetraPakAuthConfigDelegate`. This is an `abstract` class that does *not* provide an implementation for the `OnGetClientSecretsAsync` method. This example is just to give you an idea:

```c#
public class MyAuthConfigDelegate : TetraPakAuthConfigDelegate
{
    protected override async Task<Outcome<Credentials>> OnGetClientSecretsAsync(AuthContext authContext)
    {
        if (!TryGetConfiguredValue(nameof(TetraPakAuthConfig.ClientId), authContext, out var clientId, true))
            return Outcome<Credentials>.Fail(new Exception("Client Id was not found"));

        var secret = await _mySecretVault.GetSecretAsync(); // _mySecretVault represents some code API for a "secret vault"
        if (secret is null)
            return Outcome<Credentials>.Fail(new Exception("Client Secret was not found"));
        
        return Outcome<Credentials>.Success(new Credentials(clientId, clientSecret))
    }
}
```

With this, all you need do is to declare the class as the implementation of the `ITetraPakAuthConfigDelegate` interface in the `Startup.ConfigureServices` method: 

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    // add auth config delegate before the Tetra Pak auth integration:
    services.AddSingleton<ITetraPakAuthConfigDelegate, MyAuthConfigDelegate>(); 
    services.AddTetraPakOidcAuthentication();
}
```

This should cover your needs to integrate the Tetra Pak ASP.NET SDK with whatever secure storage service you prefer. The SDK might be updated in future versions, however, to offer other methods if needed.

## Debugging

-- TODO --

### Getting state (for diagnostics)

-- TODO -- Extension method: `AmbientData.GetState`

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

