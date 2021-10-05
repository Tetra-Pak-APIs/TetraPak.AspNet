#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakApiAuth Class
Provides convenience- and extension methods for Tetra Pak auth purposes.  
```csharp
public static class TetraPakApiAuth
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakApiAuth  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakApiAccessTokenAuthentication(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakApiAuth.AddTetraPakApiAccessTokenAuthentication(IServiceCollection) Method
Configures a basic authentication scheme for Tetra Pak minted access tokens.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakApiAccessTokenAuthentication(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakApiAccessTokenAuthentication(Microsoft_Extensions_DependencyInjection_IServiceCollection)_services'></a>
`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The dependency injection service collection.  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)'></a>
## TetraPakApiAuth.AddTetraPakJwtBearerAssertion(IServiceCollection, string?, JwBearerAssertionOptions?) Method
Configures the app service for Jwt Bearer Authentication.  
```csharp
public static Microsoft.AspNetCore.Authentication.AuthenticationBuilder AddTetraPakJwtBearerAssertion(this Microsoft.Extensions.DependencyInjection.IServiceCollection c, string? defaultScheme=null, TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
A [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection'), to be configured for the requested auth flow.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_defaultScheme'></a>
`defaultScheme` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default="Bearer")<br/>  
Specifies the default authentication scheme.    
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_options'></a>
`options` [JwBearerAssertionOptions](TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions.md 'TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions')  
Options governing how/what to validate JWT bearer tokens.   
  
#### Returns
[Microsoft.AspNetCore.Authentication.AuthenticationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.AuthenticationBuilder 'Microsoft.AspNetCore.Authentication.AuthenticationBuilder')  
The [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') instance.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)'></a>
## TetraPakApiAuth.AddTetraPakJwtBearerAssertion&lt;TCache&gt;(IServiceCollection, string?, JwBearerAssertionOptions?) Method
Configures the app service for Jwt Bearer Authentication while specifying a cache implementation.  
```csharp
public static Microsoft.AspNetCore.Authentication.AuthenticationBuilder AddTetraPakJwtBearerAssertion<TCache>(this Microsoft.Extensions.DependencyInjection.IServiceCollection c, string? defaultScheme=null, TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions? options=null)
    where TCache : class, TetraPak.Caching.ITimeLimitedRepositories;
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_TCache'></a>
`TCache`  
Specifies a class for implementing caching (must implement [TetraPak.Caching.ITimeLimitedRepositories](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Caching.ITimeLimitedRepositories 'TetraPak.Caching.ITimeLimitedRepositories')).  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
A [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection'), to be configured for the requested auth flow.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_defaultScheme'></a>
`defaultScheme` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default="Bearer")<br/>  
Specifies the default authentication scheme.    
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion_TCache_(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_options'></a>
`options` [JwBearerAssertionOptions](TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions.md 'TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions')  
Options governing how/what to validate JWT bearer tokens.   
  
#### Returns
[Microsoft.AspNetCore.Authentication.AuthenticationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.AuthenticationBuilder 'Microsoft.AspNetCore.Authentication.AuthenticationBuilder')  
The [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') instance.  
#### See Also
- [UseTetraPakApiAuthentication(IApplicationBuilder, IWebHostEnvironment)](TetraPak_AspNet_Api_Auth_TetraPakApiAuth.md#TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakApiAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment) 'TetraPak.AspNet.Api.Auth.TetraPakApiAuth.UseTetraPakApiAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Hosting.IWebHostEnvironment)')
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseMessageId(Microsoft_AspNetCore_Builder_IApplicationBuilder)'></a>
## TetraPakApiAuth.UseMessageId(IApplicationBuilder) Method
Ensures a unique message id is available through the whole request/response roundtrip.   
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseMessageId(this Microsoft.AspNetCore.Builder.IApplicationBuilder app);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseMessageId(Microsoft_AspNetCore_Builder_IApplicationBuilder)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The method requires an [TetraPak.AspNet.TetraPakAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakAuthConfig 'TetraPak.AspNet.TetraPakAuthConfig') service is available  
though the DI service locator but no such service could be obtained.   
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakApiAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)'></a>
## TetraPakApiAuth.UseTetraPakApiAuthentication(IApplicationBuilder, IWebHostEnvironment) Method
Installs JWT authentication middleware  
(and, optionally, a built-in local "development proxy"). Please see remarks.   
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakApiAuthentication(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakApiAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
An [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakApiAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_env'></a>
`env` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
An [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder') instance.  
### Remarks
Enabling this mechanism is a flexible way to protect your secure endpoints. When enabled  
client must call your protected endpoints through a reversed proxy acting as your API's "sidecar".  
The sidecar will handle client authentication and, when successful, replace the client's  
access token with a short lived JWT Bearer token, to be exchanged only between the service and its sidecar.  
This JWT Bearer will automatically be validated for every request by the middleware installed by this method.  




  
While securing your traffic the flipside to this approach is that your service cannot function  
without a sidecar. When there is no internal JWT Bearer to validate the request will automatically  
fail and return an "Unauthorized" response ([System.Net.HttpStatusCode.Unauthorized](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode.Unauthorized 'System.Net.HttpStatusCode.Unauthorized')).  
This makes it impossible to host your service locally for debugging during development.  




  
To deal with this you might have to introduce conditional validation and even remove authentication  
completely when debugging your service locally. This is a very bad idea as it would mean you would  
effectively be debugging code that is different from the one deployed to its hosting environments.   




  
A better solution is using a local development proxy (sidecar) that acts as the real thing.  
You can do this by simply adding a `DevProxy` flag to the `ValidateJwtBearer` sub section  
in your json configuration in appsettings.json or (better yet)  
appsettings.Development.json, like so:  


```csharp

 "TetraPak": {
    "ClientId": "abcd1234",
    "ValidateJwtBearer": {
         "Audience": "demo-api",
         "DevProxy": "demo-api-proxy"
    }
}
```


  
The value for the `DevProxy` key should be the Apigee proxy name (you probably need to ask for it),  
or the full proxy URL. Please note that the local development proxy will ONLY be enabled when  
your service is running in the "Development" runtime environment, regardless of the your configuration.  
This is to ensure you cannot accidentally deploy it to any other environment.  
#### See Also
- [AddTetraPakJwtBearerAssertion(IServiceCollection, string?, JwBearerAssertionOptions?)](TetraPak_AspNet_Api_Auth_TetraPakApiAuth.md#TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_) 'TetraPak.AspNet.Api.Auth.TetraPakApiAuth.AddTetraPakJwtBearerAssertion(Microsoft.Extensions.DependencyInjection.IServiceCollection, string?, TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions?)')
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakJwtAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)'></a>
## TetraPakApiAuth.UseTetraPakJwtAuthentication(IApplicationBuilder, IWebHostEnvironment) Method
<b>DEPRECATED!</b>



  
              This method was deprecated in SDK v1.1 and is scheduled for removal in future versions.  
              Please use [UseTetraPakApiAuthentication(IApplicationBuilder, IWebHostEnvironment)](TetraPak_AspNet_Api_Auth_TetraPakApiAuth.md#TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakApiAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment) 'TetraPak.AspNet.Api.Auth.TetraPakApiAuth.UseTetraPakApiAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Hosting.IWebHostEnvironment)') instead.  
              
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakJwtAuthentication(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakJwtAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_app'></a>
`app` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_UseTetraPakJwtAuthentication(Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Hosting_IWebHostEnvironment)_env'></a>
`env` [Microsoft.AspNetCore.Hosting.IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Hosting.IWebHostEnvironment 'Microsoft.AspNetCore.Hosting.IWebHostEnvironment')  
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
#### See Also
- [AddTetraPakJwtBearerAssertion(IServiceCollection, string?, JwBearerAssertionOptions?)](TetraPak_AspNet_Api_Auth_TetraPakApiAuth.md#TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_) 'TetraPak.AspNet.Api.Auth.TetraPakApiAuth.AddTetraPakJwtBearerAssertion(Microsoft.Extensions.DependencyInjection.IServiceCollection, string?, TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions?)')
  
