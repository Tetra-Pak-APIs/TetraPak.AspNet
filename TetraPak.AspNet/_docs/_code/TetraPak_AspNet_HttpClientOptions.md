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
Can be assigned with [WithMessageHandler(HttpMessageHandler)](TetraPak_AspNet_HttpClientOptions.md#TetraPak_AspNet_HttpClientOptions_WithMessageHandler(System_Net_Http_HttpMessageHandler) 'TetraPak.AspNet.HttpClientOptions.WithMessageHandler(System.Net.Http.HttpMessageHandler)').  
```csharp
public System.Net.Http.HttpMessageHandler? MessageHandler { get; set; }
```
#### Property Value
[System.Net.Http.HttpMessageHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMessageHandler 'System.Net.Http.HttpMessageHandler')
#### See Also
- [WithMessageHandler(HttpMessageHandler)](TetraPak_AspNet_HttpClientOptions.md#TetraPak_AspNet_HttpClientOptions_WithMessageHandler(System_Net_Http_HttpMessageHandler) 'TetraPak.AspNet.HttpClientOptions.WithMessageHandler(System.Net.Http.HttpMessageHandler)')
  
### Methods
<a name='TetraPak_AspNet_HttpClientOptions_WithAuthorization(TetraPak_ActorToken_TetraPak_AspNet_IAuthorizationService_)'></a>
## HttpClientOptions.WithAuthorization(ActorToken, IAuthorizationService?) Method
Fluid API for requesting client authorization.  
```csharp
public TetraPak.AspNet.HttpClientOptions WithAuthorization(TetraPak.ActorToken actorToken, TetraPak.AspNet.IAuthorizationService? authorizationService=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpClientOptions_WithAuthorization(TetraPak_ActorToken_TetraPak_AspNet_IAuthorizationService_)_actorToken'></a>
`actorToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The actor token of the current request.  
  
<a name='TetraPak_AspNet_HttpClientOptions_WithAuthorization(TetraPak_ActorToken_TetraPak_AspNet_IAuthorizationService_)_authorizationService'></a>
`authorizationService` [IAuthorizationService](TetraPak_AspNet_IAuthorizationService.md 'TetraPak.AspNet.IAuthorizationService')  
(optional)<br/>  
A (custom) authorization service to be used for authorizing the requested client.  
  
#### Returns
[HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
  
<a name='TetraPak_AspNet_HttpClientOptions_WithMessageHandler(System_Net_Http_HttpMessageHandler)'></a>
## HttpClientOptions.WithMessageHandler(HttpMessageHandler) Method
Fluid API for assigning a (custom) [System.Net.Http.HttpMessageHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMessageHandler 'System.Net.Http.HttpMessageHandler') to the requested  
HTTP client.  
```csharp
public TetraPak.AspNet.HttpClientOptions WithMessageHandler(System.Net.Http.HttpMessageHandler messageHandler);
```
#### Parameters
<a name='TetraPak_AspNet_HttpClientOptions_WithMessageHandler(System_Net_Http_HttpMessageHandler)_messageHandler'></a>
`messageHandler` [System.Net.Http.HttpMessageHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMessageHandler 'System.Net.Http.HttpMessageHandler')  
  
#### Returns
[HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
`this`
#### See Also
- [MessageHandler](TetraPak_AspNet_HttpClientOptions.md#TetraPak_AspNet_HttpClientOptions_MessageHandler 'TetraPak.AspNet.HttpClientOptions.MessageHandler')
  
