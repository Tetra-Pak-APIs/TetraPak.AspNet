#### [TetraPak.AspNet](index.md 'index')
## TetraPak.AspNet.Auth Namespace

| Classes | |
| :--- | :--- |
| [ConfiguredClientCredentialsProvider](TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider.md 'TetraPak.AspNet.Auth.ConfiguredClientCredentialsProvider') | Provides client credentials from the configuration framework.<br/> |
| [JwtHelper](TetraPak_AspNet_Auth_JwtHelper.md 'TetraPak.AspNet.Auth.JwtHelper') | Provides convenience- and extension methods to assist in the use of JavaScript Web Tokens (JWT). <br/> |
| [TetraPakAuth](TetraPak_AspNet_Auth_TetraPakAuth.md 'TetraPak.AspNet.Auth.TetraPakAuth') | Provides convenience- and extension methods to help with integrating an ASP.NET Core/5+<br/>web application with the Tetra Pak Auth Services.<br/> |
| [TetraPakAuthConfig](TetraPak_AspNet_Auth_TetraPakAuthConfig.md 'TetraPak.AspNet.Auth.TetraPakAuthConfig') | Provides access to the main Tetra Pak section in the configuration.  <br/> |
| [TetraPakIdentityConfig](TetraPak_AspNet_Auth_TetraPakIdentityConfig.md 'TetraPak.AspNet.Auth.TetraPakIdentityConfig') | Describes how to populate the ambient [ClaimsPrincipal.Identity.](https://docs.microsoft.com/en-us/dotnet/api/ClaimsPrincipal.Identity. 'ClaimsPrincipal.Identity.') value<br/>available through [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').<br/> |

| Interfaces | |
| :--- | :--- |
| [IAccessTokenProvider](TetraPak_AspNet_Auth_IAccessTokenProvider.md 'TetraPak.AspNet.Auth.IAccessTokenProvider') | Implementors of this class are capable of providing an access token from a request context. <br/> |
| [IIdentityTokenProvider](TetraPak_AspNet_Auth_IIdentityTokenProvider.md 'TetraPak.AspNet.Auth.IIdentityTokenProvider') | Implementors of this class are capable of providing a identity token from a request context.<br/> |
| [IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig') | Classes implementing this contract can provide information needed fot authorization purposes. <br/> |
| [ITetraPakAuthConfigDelegate](TetraPak_AspNet_Auth_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.Auth.ITetraPakAuthConfigDelegate') |  |

| Enums | |
| :--- | :--- |
| [GrantType](TetraPak_AspNet_Auth_GrantType.md 'TetraPak.AspNet.Auth.GrantType') | used to specify an authentication method when communicating with a backend service.<br/> |
| [TetraPakIdentitySource](TetraPak_AspNet_Auth_TetraPakIdentitySource.md 'TetraPak.AspNet.Auth.TetraPakIdentitySource') | Used to specify a source for obtaining identity information.  <br/> |
