#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## HttpClientOptions Class
Used to configure a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') through a [IHttpServiceProvider](TetraPak_AspNet_Api_IHttpServiceProvider.md 'TetraPak.AspNet.Api.IHttpServiceProvider').  
```csharp
public class HttpClientOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpClientOptions  
### Properties
<a name='TetraPak_AspNet_Api_HttpClientOptions_AuthConfig'></a>
## HttpClientOptions.AuthConfig Property
Gets or sets the configuration required for authenticating the client.   
```csharp
public TetraPak.AspNet.Auth.IServiceAuthConfig AuthConfig { get; set; }
```
#### Property Value
[TetraPak.AspNet.Auth.IServiceAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig 'TetraPak.AspNet.Auth.IServiceAuthConfig')
  
<a name='TetraPak_AspNet_Api_HttpClientOptions_Authorization'></a>
## HttpClientOptions.Authorization Property
Gets or sets an authentication header value to be used for the requested client.  
```csharp
public TetraPak.ActorToken Authorization { get; set; }
```
#### Property Value
[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')
  
<a name='TetraPak_AspNet_Api_HttpClientOptions_IsClientTransient'></a>
## HttpClientOptions.IsClientTransient Property
Gets or sets a value specifying whether the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') should be  
transient (otherwise a singleton instance till be returned).   
```csharp
public bool IsClientTransient { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
  
<a name='TetraPak_AspNet_Api_HttpClientOptions_MessageHandler'></a>
## HttpClientOptions.MessageHandler Property
A custom [System.Net.Http.HttpMessageHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMessageHandler 'System.Net.Http.HttpMessageHandler') to be used by the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
```csharp
public System.Net.Http.HttpMessageHandler MessageHandler { get; set; }
```
#### Property Value
[System.Net.Http.HttpMessageHandler](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpMessageHandler 'System.Net.Http.HttpMessageHandler')
  
### Methods
<a name='TetraPak_AspNet_Api_HttpClientOptions_WithAuthorization(TetraPak_ActorToken)'></a>
## HttpClientOptions.WithAuthorization(ActorToken) Method
Fluid API for assigning the [Authorization](TetraPak_AspNet_Api_HttpClientOptions.md#TetraPak_AspNet_Api_HttpClientOptions_Authorization 'TetraPak.AspNet.Api.HttpClientOptions.Authorization') property value.  
```csharp
public TetraPak.AspNet.Api.HttpClientOptions WithAuthorization(TetraPak.ActorToken authorization);
```
#### Parameters
<a name='TetraPak_AspNet_Api_HttpClientOptions_WithAuthorization(TetraPak_ActorToken)_authorization'></a>
`authorization` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
  
#### Returns
[HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions')  
  
