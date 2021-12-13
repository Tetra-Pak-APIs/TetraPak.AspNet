#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakTokenExchangeGrantService Class
Use this service for easy token exchange.  
```csharp
public class TetraPakTokenExchangeGrantService :
TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService,
TetraPak.AspNet.IMessageIdProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakTokenExchangeGrantService  

Implements [ITokenExchangeGrantService](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService'), [TetraPak.AspNet.IMessageIdProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider 'TetraPak.AspNet.IMessageIdProvider')  
### Constructors
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)'></a>
## TetraPakTokenExchangeGrantService.TetraPakTokenExchangeGrantService(TetraPakConfig, IHttpClientProvider, IHttpContextAccessor) Constructor
Initializes the [TetraPakTokenExchangeGrantService](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService.md 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService').  
```csharp
public TetraPakTokenExchangeGrantService(TetraPak.AspNet.TetraPakConfig config, TetraPak.AspNet.IHttpClientProvider httpClientProvider, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)_config'></a>
`config` [TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)_httpClientProvider'></a>
`httpClientProvider` [TetraPak.AspNet.IHttpClientProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IHttpClientProvider 'TetraPak.AspNet.IHttpClientProvider')  
A HttpClient factory.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)_httpContextAccessor'></a>
`httpContextAccessor` [Microsoft.AspNetCore.Http.IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHttpContextAccessor 'Microsoft.AspNetCore.Http.IHttpContextAccessor')  
Provides access to the current request/response [TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService.HttpContext 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService.HttpContext').   
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[config](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakTokenExchangeGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)_config 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService.TetraPakTokenExchangeGrantService(TetraPak.AspNet.TetraPakConfig, TetraPak.AspNet.IHttpClientProvider, Microsoft.AspNetCore.Http.IHttpContextAccessor).config') was unassigned.  
            
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Any parameter was `null`.  
  
### Properties
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_Logger'></a>
## TetraPakTokenExchangeGrantService.Logger Property
Gets a logging provider.  
```csharp
private Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_TetraPakConfig'></a>
## TetraPakTokenExchangeGrantService.TetraPakConfig Property
Gets the auth configuration code API.  
```csharp
private TetraPak.AspNet.TetraPakConfig TetraPakConfig { get; }
```
#### Property Value
[TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')
  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakTokenExchangeGrantService.ExchangeAccessTokenAsync(Credentials, ActorToken, bool, Nullable&lt;CancellationToken&gt;) Method
Exchanges a specified access token for a new, to be used for consuming a service.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.TokenExchangeResponse>> ExchangeAccessTokenAsync(TetraPak.Credentials credentials, TetraPak.ActorToken subjectToken, bool forceAuthorization=false, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
Specifies the credentials used for the token exchange  
(typically [TetraPak.BasicAuthCredentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.BasicAuthCredentials 'TetraPak.BasicAuthCredentials') carrying client id and client secret).  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_subjectToken'></a>
`subjectToken` [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')  
The access token to be exchanged.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_forceAuthorization'></a>
`forceAuthorization` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to force a new client authorization (overriding/replacing any cached authorization).   
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
Enables cancellation of the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TokenExchangeResponse](TetraPak_AspNet_Api_Auth_TokenExchangeResponse.md 'TetraPak.AspNet.Api.Auth.TokenExchangeResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and.  
On success the value also carries the requested result; otherwise a [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') might  
be carried instead.  

Implements [ExchangeAccessTokenAsync(Credentials, ActorToken, bool, Nullable<CancellationToken>)](TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_ITokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.Api.Auth.ITokenExchangeGrantService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, bool, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
### Remarks
Please note that (as of 2021-11-01) Tetra Pak auth services does not allow Token Exchange for  
non-human identities (a.k.a. "system identities").  




  
What this means is that if you pass an [subjectToken](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_subjectToken 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, bool, System.Nullable&lt;System.Threading.CancellationToken&gt;).subjectToken')  
that was ultimately issued from a Client Credentials Grant the token exchange will fail  
with a `400 Bad Request`.  
You can examine the [subjectToken](TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_ExchangeAccessTokenAsync(TetraPak_Credentials_TetraPak_ActorToken_bool_System_Nullable_System_Threading_CancellationToken_)_subjectToken 'TetraPak.AspNet.Api.Auth.TetraPakTokenExchangeGrantService.ExchangeAccessTokenAsync(TetraPak.Credentials, TetraPak.ActorToken, bool, System.Nullable&lt;System.Threading.CancellationToken&gt;).subjectToken') using the  
extension method [TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken(TetraPak.ActorToken)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken#TetraPak_AspNet_Auth_JwtHelper_IsSystemIdentityToken_TetraPak_ActorToken_ 'TetraPak.AspNet.Auth.JwtHelper.IsSystemIdentityToken(TetraPak.ActorToken)').  




  
For more details please see article using the link found in this constant:  
[TetraPak.AspNet.Documentations.Docs.DevPortal.TokenExchangeSubjectTokenTypes](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Documentations.Docs.DevPortal.TokenExchangeSubjectTokenTypes 'TetraPak.AspNet.Documentations.Docs.DevPortal.TokenExchangeSubjectTokenTypes')
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_GetMessageId(bool)'></a>
## TetraPakTokenExchangeGrantService.GetMessageId(bool) Method
Retrieves a request message id if available.   
```csharp
public string? GetMessageId(bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakTokenExchangeGrantService_GetMessageId(bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set a message id will be generated and injected into the request/response context.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if a message id was available (or enforced); otherwise `null`.  

Implements [GetMessageId(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider.GetMessageId#TetraPak_AspNet_IMessageIdProvider_GetMessageId_System_Boolean_ 'TetraPak.AspNet.IMessageIdProvider.GetMessageId(System.Boolean)')  
  
