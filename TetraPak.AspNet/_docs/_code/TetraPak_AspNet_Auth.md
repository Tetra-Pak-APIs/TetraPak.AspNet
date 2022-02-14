#### [TetraPak.AspNet](index.md 'index')
## TetraPak.AspNet.Auth Namespace

| Classes | |
| :--- | :--- |
| [ClientCredentials](TetraPak_AspNet_Auth_ClientCredentials.md 'TetraPak.AspNet.Auth.ClientCredentials') | Represents a set of client credentials, to reflect a certain "configuration level"<br/>([IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')). <br/> |
| [ConfiguredClientCredentialsProvider](TetraPak_AspNet_Auth_ConfiguredClientCredentialsProvider.md 'TetraPak.AspNet.Auth.ConfiguredClientCredentialsProvider') | Provides client credentials from the configuration framework.<br/> |
| [JwtBearerAssertionConfig](TetraPak_AspNet_Auth_JwtBearerAssertionConfig.md 'TetraPak.AspNet.Auth.JwtBearerAssertionConfig') | This code API enables access and manipulation for the [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') (appsettings.json)<br/>sub section "JwtBearerAssertion";<br/> |
| [JwtHelper](TetraPak_AspNet_Auth_JwtHelper.md 'TetraPak.AspNet.Auth.JwtHelper') | Provides convenience- and extension methods to assist in the use of JavaScript Web Tokens (JWT). <br/> |
| [RefreshTokenResponse](TetraPak_AspNet_Auth_RefreshTokenResponse.md 'TetraPak.AspNet.Auth.RefreshTokenResponse') | Used to present the result from a token refresh flow response.<br/> |
| [TetraPakAuth](TetraPak_AspNet_Auth_TetraPakAuth.md 'TetraPak.AspNet.Auth.TetraPakAuth') | Provides convenience- and extension methods to help with integrating an ASP.NET Core/5+<br/>web application with the Tetra Pak Auth Services.<br/> |

| Interfaces | |
| :--- | :--- |
| [IAccessTokenProvider](TetraPak_AspNet_Auth_IAccessTokenProvider.md 'TetraPak.AspNet.Auth.IAccessTokenProvider') | Implementors of this class are capable of providing an access token from a request context. <br/> |
| [IClientConfigDelegate](TetraPak_AspNet_Auth_IClientConfigDelegate.md 'TetraPak.AspNet.Auth.IClientConfigDelegate') | Classes implementing this interface can be relied on to provide the app with (custom) configuration. <br/> |
| [IClientCredentialsProvider](TetraPak_AspNet_Auth_IClientCredentialsProvider.md 'TetraPak.AspNet.Auth.IClientCredentialsProvider') | Implementors of this contract can be used for obtaining client credentials,<br/>typically for token exchange, or similar flows where such credentials are needed.<br/> |
| [IIdentityTokenProvider](TetraPak_AspNet_Auth_IIdentityTokenProvider.md 'TetraPak.AspNet.Auth.IIdentityTokenProvider') | Implementors of this class are capable of providing a identity token from a request context.<br/> |
| [IRefreshTokenGrantService](TetraPak_AspNet_Auth_IRefreshTokenGrantService.md 'TetraPak.AspNet.Auth.IRefreshTokenGrantService') | Classes implementing this interface are able to perform the OAuth2 Refresh Token Grant flow. <br/> |
| [IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig') | Classes implementing this contract can provide information needed for authorization purposes. <br/> |

| Enums | |
| :--- | :--- |
| [GrantType](TetraPak_AspNet_Auth_GrantType.md 'TetraPak.AspNet.Auth.GrantType') | used to specify an authentication method when communicating with a backend service.<br/> |
| [TetraPakIdentitySource](TetraPak_AspNet_Auth_TetraPakIdentitySource.md 'TetraPak.AspNet.Auth.TetraPakIdentitySource') | Used to specify a source for obtaining identity information.  <br/> |
