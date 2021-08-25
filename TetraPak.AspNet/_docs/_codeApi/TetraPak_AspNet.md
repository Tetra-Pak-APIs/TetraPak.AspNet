#### [TetraPak.AspNet](index.md 'index')
## TetraPak.AspNet Namespace

| Classes | |
| :--- | :--- |
| [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') | Provides ambient data to an ASP.NET Core/5+ project throughout a request/response roundtrip.<br/> |
| [AmbientData.Keys](TetraPak_AspNet_AmbientData_Keys.md 'TetraPak.AspNet.AmbientData.Keys') | Provides well-known identifiers to access ambient values.  <br/> |
| [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext') | Used to describe an auth request context.<br/> |
| [ClaimsIdentityExtensions](TetraPak_AspNet_ClaimsIdentityExtensions.md 'TetraPak.AspNet.ClaimsIdentityExtensions') | Convenient extension methods for obtaining typical claims from a [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity') value.<br/> |
| [ConfigurationException](TetraPak_AspNet_ConfigurationException.md 'TetraPak.AspNet.ConfigurationException') | Thrown to reflect configuration issues.<br/> |
| [ControllerExtensions](TetraPak_AspNet_ControllerExtensions.md 'TetraPak.AspNet.ControllerExtensions') | Convenient extension methods for a [Microsoft.AspNetCore.Mvc.Controller](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.Controller 'Microsoft.AspNetCore.Mvc.Controller').<br/> |
| [FormUrlEncodedContentHelper](TetraPak_AspNet_FormUrlEncodedContentHelper.md 'TetraPak.AspNet.FormUrlEncodedContentHelper') | Provides convenience for dealing with [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent') objects.<br/> |
| [HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper') |  |
| [QueryParametersHelper](TetraPak_AspNet_QueryParametersHelper.md 'TetraPak.AspNet.QueryParametersHelper') |  |
| [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig') | Provides access to the main Tetra Pak section in the configuration.  <br/> |
| [TetraPakAuthConfigDelegate](TetraPak_AspNet_TetraPakAuthConfigDelegate.md 'TetraPak.AspNet.TetraPakAuthConfigDelegate') | A partial implementation of the [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate') contract.<br/> |
| [TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation') | Add this class to the DI configuration to automatically provide a Tetra Pak identity to any request.<br/>The class constructor also needs [AmbientData](TetraPak_AspNet_TetraPakClaimsTransformation.md#TetraPak_AspNet_TetraPakClaimsTransformation_AmbientData 'TetraPak.AspNet.TetraPakClaimsTransformation.AmbientData') and <br/>Please note that this is automatically done by calling [TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication#TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakWebClientAuthentication_Microsoft_Extensions_DependencyInjection_IServiceCollection_ 'TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)').<br/> |
| [TetraPakIdentityConfig](TetraPak_AspNet_TetraPakIdentityConfig.md 'TetraPak.AspNet.TetraPakIdentityConfig') | Describes how to populate the ambient [System.Security.Claims.ClaimsPrincipal.Identity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsPrincipal.Identity 'System.Security.Claims.ClaimsPrincipal.Identity') value<br/>available through [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').<br/> |
| [TetraPakWebClientClaimsTransformationHelper](TetraPak_AspNet_TetraPakWebClientClaimsTransformationHelper.md 'TetraPak.AspNet.TetraPakWebClientClaimsTransformationHelper') |  |

| Interfaces | |
| :--- | :--- |
| [IMessageIdProvider](TetraPak_AspNet_IMessageIdProvider.md 'TetraPak.AspNet.IMessageIdProvider') |  |
| [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate') | Classes implementing this contract can be passed as a delegate to customize several aspects<br/>of Tetra Pak related configuration. <br/> |