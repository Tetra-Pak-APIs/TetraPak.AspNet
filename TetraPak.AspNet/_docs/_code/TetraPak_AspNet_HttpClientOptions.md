#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpClientOptions Class
Used to configure a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') through a [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider').  
```csharp
public class HttpClientOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpClientOptions  
### Constructors
<a name='TetraPak_AspNet_HttpClientOptions_HttpClientOptions(bool)'></a>
## HttpClientOptions.HttpClientOptions(bool) Constructor
Initializes the [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions').  
```csharp
public HttpClientOptions(bool isClientTransient=true);
```
#### Parameters
<a name='TetraPak_AspNet_HttpClientOptions_HttpClientOptions(bool)_isClientTransient'></a>
`isClientTransient` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Initializes [IsClientTransient](TetraPak_AspNet_HttpClientOptions.md#TetraPak_AspNet_HttpClientOptions_IsClientTransient 'TetraPak.AspNet.HttpClientOptions.IsClientTransient').  
  
  
### Properties
<a name='TetraPak_AspNet_HttpClientOptions_ActorToken'></a>
## HttpClientOptions.ActorToken Property
Gets or sets an authentication header value to be used for the requested client.  
```csharp
public TetraPak.ActorToken? ActorToken { get; set; }
```
#### Property Value
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')
  
<a name='TetraPak_AspNet_HttpClientOptions_AuthConfig'></a>
## HttpClientOptions.AuthConfig Property
Gets or sets the configuration required for authenticating the client.   
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig? AuthConfig { get; set; }
```
#### Property Value
[IServiceAuthConfig](TetraPak_AspNet_Auth_IServiceAuthConfig.md 'TetraPak.AspNet.Auth.IServiceAuthConfig')
  
<a name='TetraPak_AspNet_HttpClientOptions_AuthorizationService'></a>
## HttpClientOptions.AuthorizationService Property
Gets or sets an (optional) authorization service. When set this is an indicator that the  
requested client should be automatically authorized as per the configured [AuthConfig](TetraPak_AspNet_HttpClientOptions.md#TetraPak_AspNet_HttpClientOptions_AuthConfig 'TetraPak.AspNet.HttpClientOptions.AuthConfig').     
```csharp
public TetraPak.AspNet.IAuthorizationService? AuthorizationService { get; set; }
```
#### Property Value
[IAuthorizationService](TetraPak_AspNet_IAuthorizationService.md 'TetraPak.AspNet.IAuthorizationService')
  
<a name='TetraPak_AspNet_HttpClientOptions_IsClientTransient'></a>
## HttpClientOptions.IsClientTransient Property
Gets or sets a value specifying whether the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') should be  
transient (otherwise a singleton instance till be returned).   
```csharp
public bool IsClientTransient { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_HttpClientOptions_MessageHandler'></a>
## HttpClientOptions.MessageHandler Property
A custom [System.Net.Http.HttpMessageHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMessageHandler 'System.Net.Http.HttpMessageHandler') to be used by the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
```csharp
public System.Net.Http.HttpMessageHandler? MessageHandler { get; set; }
```
#### Property Value
[System.Net.Http.HttpMessageHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMessageHandler 'System.Net.Http.HttpMessageHandler')
  
### Methods
<a name='TetraPak_AspNet_HttpClientOptions_WithAuthorization(TetraPak_ActorToken_)'></a>
## HttpClientOptions.WithAuthorization(ActorToken?) Method
Fluid API for assigning the [ActorToken](TetraPak_AspNet_HttpClientOptions.md#TetraPak_AspNet_HttpClientOptions_ActorToken 'TetraPak.AspNet.HttpClientOptions.ActorToken') property value.  
```csharp
public TetraPak.AspNet.HttpClientOptions WithAuthorization(TetraPak.ActorToken? authorization);
```
#### Parameters
<a name='TetraPak_AspNet_HttpClientOptions_WithAuthorization(TetraPak_ActorToken_)_authorization'></a>
`authorization` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
  
#### Returns
[HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
  
<a name='TetraPak_AspNet_HttpClientOptions_WithAuthorizationService(TetraPak_AspNet_IAuthorizationService)'></a>
## HttpClientOptions.WithAuthorizationService(IAuthorizationService) Method
(Fluid API)<br/>  
Assigns the [AuthorizationService](TetraPak_AspNet_HttpClientOptions.md#TetraPak_AspNet_HttpClientOptions_AuthorizationService 'TetraPak.AspNet.HttpClientOptions.AuthorizationService') and returns `this`.  
```csharp
public TetraPak.AspNet.HttpClientOptions WithAuthorizationService(TetraPak.AspNet.IAuthorizationService authorizationService);
```
#### Parameters
<a name='TetraPak_AspNet_HttpClientOptions_WithAuthorizationService(TetraPak_AspNet_IAuthorizationService)_authorizationService'></a>
`authorizationService` [IAuthorizationService](TetraPak_AspNet_IAuthorizationService.md 'TetraPak.AspNet.IAuthorizationService')  
  
#### Returns
[HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
  
