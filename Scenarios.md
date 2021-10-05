# TetraPak.AspNet SDK - Scenarios

This document presents typical ASP.NET related scenarios, including issues, you will likely face and suggestions for what to do:

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

Obtaining the [identity][cat-identity] of the authenticated [actor][cat-actor] is a feature built in to ASP.NET. This can be easily done via your controller's `User` property. This property's value is a [`ClaimsPrincipal`](https://docs.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal?view=net-5.0) that supports a collection of 'claims'. You can either examine those claims or you can use the [`ClaimsPrincipal.Identity`] property, which will return an [`IIdentity`][dotnet-iidentity].

The [TetraPak.AspNet][nuget-tetrapak-app] SDK also offers some convenient extension methods for obtaining typical identity-related [claims][cat-claim], like in this example:

```csharp
[ApiController]
[Route("[controller]")]
[Authorize]
public class MyController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var userId = User.Id(); // also works: User.Name()
        var userFirstName = User.FirstName();
        var userLastName = User.LastName();
        var userEmail = User.Email();
        :
    }
}
```

## Getting the token

Sometimes it is necessary for your code, in your Web App or Web API, to obtain the incoming access token or identity token. This can be easily done using the `GetAccessToken()` extension method, like in this example:

```c#
[ApiController]
[Route("[controller]")]
[Authorize]
public class MyController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var accessTokenOutcome = await this.GetAccessTokenAsync();
        var accessToken = accessTokenOutcome
            ? accessTokenOutcome.Value
            : null;
        :
    }
}
```

See also: [`GetAccessTokenAsync` extension method][md-code-GetAccessTokenAsync]

## Configuring secrets

Configuring your Tetra Pak integration is easily done by simply adding a "`TetraPak`" configuration section in your `appsettings.json` file (or one of the runtime environment versions, such as `appsettings.Development.json`):

```json
{
  "TetraPak": {
    "ClientId": "-my-client-id-",
    "ClientSecret": "-m4-c7i3nt-s3cr3t"
  }
}
```

Those files, however, have a tendency to find their way into your code repository unless you take the extra precaution to include them in your `.gitignore` file. Depending on your IDE of choice this might (or might not) be handled by the project template you pick when you create your web project. Either way, placing confidential information into unencrypted text files is a risky affair, at best. You should instead rely on the various "secure storage" options available to you. 

We will not dive into how to choose or interact with a secure storage; that is different topic. Assuming you know how to integrate with secure storage services the SDK offers a simple way for you to provide secrets, when needed, without storing them in unencrypted files, by use of the [`ITetraPakSecretsProvider`][code-ITetraPakSecretsProvider] interface.

This is a very simple example implementation of the [`ITetraPakSecretsProvider`][code-ITetraPakSecretsProvider]:

```c#
// a simple secrets provider implementation:
public class MySecretsProvider : ITetraPakSecretsProvider
{
    public async Task<Outcome<string>> GetSecretStringAsync(DynamicPath path)
    {
        if (path == Secrets.ClientIdUri)
            return getClientIdAsync(path);
        
        if (path == Secrets.ClientIdUri)
            return getClientSecretAsync(path);
        
        return Outcome<string>.Fail(
                  new ArgumentOutOfRangeException(nameof(path)));
    }

    Outcome<string> getClientIdAsync(DynamicPath path)
    {
        /*
          in reality you might have a need to obtain different 
          client ids here, and do so from a secure persistent 
          store somewhere, such as an Azure Key Vault
        */
        return Outcome<string>.Success("-my-client-id-");
    }

    Outcome<string> getClientSecretAsync(DynamicPath path)
    {
        /*
          in reality you might have a need to obtain different 
          client secrets here, and do so from a secure persistent 
          store somewhere, such as an Azure Key Vault
        */
        return Outcome<string>.Success("-m4-c713nt-Z3cr3t==");
    }
}
```

You then configure your secrets provider as a DI service in the `Startup.ConfigureServices` method:

```c#
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        : 
        services.AddControllers();
        services.AddSingleton<ITetraPakSecretsProvider,MySecretsProvider>();
        :
    }
}        
```

## Setting the localhost port

It is sometimes necessary to specify a TCP port to run and debug your web project locally. This can be because the scaffolded port is already in use on your machine or because you need to adapt to some other requirement.

With ASP.NET Core/5+ You can specify how your host binds to addresses (including the port) by editing your project's launch configuration file. This file can be found under your project's `Prperties` sub folder and it's called `launchSettings.json`. If you need a better understanding for how this file is used and structured then [here's a great tutorial](https://dotnettutorials.net/lesson/asp-net-core-launchsettings-json-file/).

The file has a sub section called "`profiles`", which typically contains two launch profiles: "`IIS Express`" and "`(project name)`". To complicate things a wee bit different rules are used depending on the value of each profile's "`commandName`" value. Profiles running `commandName` = "`IISExpress`" takes its settings from the root section "`iisSettings`" and its sub section "`iisExpress`", whereas profiles running `commandName` = "`Project`" takes its settings directly from that same profile configuration section. 

Look for the "`applicationUrl`" setting to see which addresses that profile will attempt binding to. Typically, a "Kestrel" based launch profile is configured for `"applicationUrl": "http://localhost:5000"` whereas the `iisSettings:iisExpress` configuration uses `"applicationUrl": "http://localhost:9256"` (port may vay over time).

You can change the port and also add more addresses. One typical requirement might be to run SSL (TLS), even locally, so you could add that using a different port, like in this example: `"applicationUrl": "https://localhost:5001;http://localhost:5000"`.

Depending on how you start/debug your project, whether from Visual Studio, VS Code, Rider or even the command line, different profiles will be used. Starting your app from the command line, for example, will usually pick the launch profile with `"commandName": "Project"` (running the Kestrel web server) whereas your IDE might default to the profile with `"commandName": "IISExpress"` (running IISExpress web server). Within your IDE you can select which launch profile to use however.

## Controlling the runtime environment

When you run your code locally, the code targets one of many possible runtime environment, such as:

- Production
- Staging
- Development

As you might have already seen, the ASP.NET configuration system supports a mechanism where you can deploy different configuration depending on the targeted runtime environment. The `appsettings.json` file, found in your project root, is the "base" configuration, used for all runtime environments (including `Production`) but you can easily override or add additional configuration that will only be used when you target the `Development` runtime environment, by adding a second appsettings file: `appsettings.Development.json`. If you need to target more runtime environments you can do so by adding more launch profiles and `appsettings.{name of environment}.json` files as well.

The launch profiles are configured in the `launchSettings.json` file, found under the sub folder `Properties` in your project. Typically it looks something like this:

```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:53419",
      "sslPort": 44380
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "MyAPI": {
      "commandName": "Project",
      "dotnetRunMessages": "true",
      "launchBrowser": false,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

The launch profiles are found in the sub section "profiles" and there is usually two: "`IIS Express`" and "`{name of your project}`" ("`MyAPI`" in this example). Within each launch profile sub section is another sub section called "`environmentVariables`" where you can create or override your machine's environment variables and, as I'm sure you've guessed by now, the runtime environment is controlled by the "`"ASPNETCORE_ENVIRONMENT"`" variable, and is typically set to "`Dwevelopment`".

You can easily add more launch profiles, such as "`Migration`", by just adding another sub section to the list of "`profiles`":

```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:53419",
      "sslPort": 44380
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "MyAPI": {
      "commandName": "Project",
      "dotnetRunMessages": "true",
      "launchBrowser": false,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "MyAPI:Staging": {
      "commandName": "Project",
      "dotnetRunMessages": "true",
      "launchBrowser": false,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Staging"
      }
    }

  }
}
```

For that to make sense you might also want the corresponding `appsettings.Staging.json` file, to add or override configuration to be used specifically for this runtime environment.

Please note that the `launchSettings.json` file is ***only*** used when running your code locally. It will be ignored, for example, if you deploy the code to an Azure app service. The `appsettings` files, however, are honoured by that same app service. You control the targeted runtime environment by assigning the same environment variable (in Azure) but you do that using other tools than the `launchSettings.json` file.

## Debugging

-- TODO --

## Getting state (for diagnostics)

-- TODO -- 
Extension method: `AmbientData.GetState`

## Profiling

-- TODO -- 
Explain how to activate profiling and analyse the output. Also how to create custom profiling  

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

[dotnet-iidentity]: https://docs.microsoft.com/en-us/dotnet/api/system.security.principal.iidentity

[md-code-GetAccessTokenAsync]: ./TetraPak.AspNet/_docs/_code/TetraPak_AspNet_ControllerExtensions.md#controllerextensionsgetaccesstokenasynccontroller-method

[code-ITetraPakSecretsProvider]: https://github.com/Tetra-Pak-APIs/TetraPak.Common/blob/master/TetraPak.Common/_docs/_code/TetraPak_SecretsManagement_ITetraPakSecretsProvider.md

[code-TetraPakAuthConfig]: ./TetraPak.AspNet/_docs/_code/TetraPak_AspNet_TetraPakAuthConfig.md

[code-TetraPakAuthConfigDelegate]: ./TetraPak.AspNet/_docs/_code/TetraPak_AspNet_TetraPakAuthConfigDelegate.md 

[cat-actor]: ./CAT.md#actor
[cat-claim]: ./CAT.md#claim
[cat-client-credentials]: ./CAT.md#client-credentials
[cat-identity]: ./CAT.md#identity
