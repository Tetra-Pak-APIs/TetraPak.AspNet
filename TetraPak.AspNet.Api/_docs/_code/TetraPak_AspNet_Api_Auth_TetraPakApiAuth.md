#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakApiAuth Class
Provides convenience- and extension methods for Tetra Pak auth purposes.  
```csharp
public static class TetraPakApiAuth
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakApiAuth  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IAuthorizationService_)'></a>
## TetraPakApiAuth.AddTetraPakAuthorizationService(IServiceCollection, Func&lt;IServiceProvider,IAuthorizationService&gt;) Method
Registers a [TetraPak.AspNet.IAuthorizationService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService 'TetraPak.AspNet.IAuthorizationService') for Tetra Pak integration use  
while providing a factory callback handler.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakAuthorizationService(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection, System.Func<System.IServiceProvider,TetraPak.AspNet.IAuthorizationService> factory);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IAuthorizationService_)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The extended [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection').  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IAuthorizationService_)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TetraPak.AspNet.IAuthorizationService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService 'TetraPak.AspNet.IAuthorizationService')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
The factory callback handler responsible for producing the service.   
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The [collection](TetraPak_AspNet_Api_Auth_TetraPakApiAuth.md#TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IAuthorizationService_)_collection 'TetraPak.AspNet.Api.Auth.TetraPakApiAuth.AddTetraPakAuthorizationService(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func&lt;System.IServiceProvider,TetraPak.AspNet.IAuthorizationService&gt;).collection').  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakApiAuth.AddTetraPakAuthorizationService&lt;T&gt;(IServiceCollection) Method
Registers a [TetraPak.AspNet.IAuthorizationService](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IAuthorizationService 'TetraPak.AspNet.IAuthorizationService') type for Tetra Pak integration use.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakAuthorizationService<T>(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection)
    where T : class, TetraPak.AspNet.IAuthorizationService;
```
#### Type parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_T'></a>
`T`  
  
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The extended [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection').  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The [collection](TetraPak_AspNet_Api_Auth_TetraPakApiAuth.md#TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakAuthorizationService_T_(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection 'TetraPak.AspNet.Api.Auth.TetraPakApiAuth.AddTetraPakAuthorizationService&lt;T&gt;(Microsoft.Extensions.DependencyInjection.IServiceCollection).collection').  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_AspNetCore_Authentication_AuthenticationBuilder_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)'></a>
## TetraPakApiAuth.AddTetraPakJwtBearerAssertion(AuthenticationBuilder, JwBearerAssertionOptions?) Method
Adds Tetra Pak recommended JWT bearer assertion to the API while specifying  
the caching implementation type.  
```csharp
public static Microsoft.AspNetCore.Authentication.AuthenticationBuilder AddTetraPakJwtBearerAssertion(this Microsoft.AspNetCore.Authentication.AuthenticationBuilder builder, TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions? options=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_AspNetCore_Authentication_AuthenticationBuilder_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_builder'></a>
`builder` [Microsoft.AspNetCore.Authentication.AuthenticationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.AuthenticationBuilder 'Microsoft.AspNetCore.Authentication.AuthenticationBuilder')  
The extended [Microsoft.AspNetCore.Authentication.AuthenticationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.AuthenticationBuilder 'Microsoft.AspNetCore.Authentication.AuthenticationBuilder') instance.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_AspNetCore_Authentication_AuthenticationBuilder_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_options'></a>
`options` [JwBearerAssertionOptions](TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions.md 'TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions')  
(optional)<br/>  
Specifies options for JWT bearer assertion.   
  
#### Returns
[Microsoft.AspNetCore.Authentication.AuthenticationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Authentication.AuthenticationBuilder 'Microsoft.AspNetCore.Authentication.AuthenticationBuilder')  
The [builder](TetraPak_AspNet_Api_Auth_TetraPakApiAuth.md#TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_AspNetCore_Authentication_AuthenticationBuilder_TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)_builder 'TetraPak.AspNet.Api.Auth.TetraPakApiAuth.AddTetraPakJwtBearerAssertion(Microsoft.AspNetCore.Authentication.AuthenticationBuilder, TetraPak.AspNet.Api.Auth.JwBearerAssertionOptions?).builder') instance.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakApiAuth_AddTetraPakJwtBearerAssertion(Microsoft_Extensions_DependencyInjection_IServiceCollection_string__TetraPak_AspNet_Api_Auth_JwBearerAssertionOptions_)'></a>
## TetraPakApiAuth.AddTetraPakJwtBearerAssertion(IServiceCollection, string?, JwBearerAssertionOptions?) Method
Configures the app service for Jwt Bearer Authentication while specifying a cache implementation.  
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
The method requires an [TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig') service is available  
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
client must call your protected endpoints through a reversed proxy acting as your Api "sidecar".  
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
  
