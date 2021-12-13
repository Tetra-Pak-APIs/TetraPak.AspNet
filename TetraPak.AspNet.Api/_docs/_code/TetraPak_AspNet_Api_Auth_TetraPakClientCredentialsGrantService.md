#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakClientCredentialsGrantService Class
A default service to support the client credentials grant type.  
```csharp
public class TetraPakClientCredentialsGrantService :
TetraPak.AspNet.Api.Auth.IClientCredentialsGrantService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakClientCredentialsGrantService  

Implements [IClientCredentialsGrantService](TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService.md 'TetraPak.AspNet.Api.Auth.IClientCredentialsGrantService')  
### Constructors
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_TetraPakClientCredentialsGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)'></a>
## TetraPakClientCredentialsGrantService.TetraPakClientCredentialsGrantService(TetraPakConfig, IHttpClientProvider, IHttpContextAccessor) Constructor
Initializes the [TetraPakClientCredentialsGrantService](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService.md 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService').  
```csharp
public TetraPakClientCredentialsGrantService(TetraPak.AspNet.TetraPakConfig tetraPakConfig, TetraPak.AspNet.IHttpClientProvider httpClientProvider, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_TetraPakClientCredentialsGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPak.AspNet.TetraPakConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakConfig 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_TetraPakClientCredentialsGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)_httpClientProvider'></a>
`httpClientProvider` [TetraPak.AspNet.IHttpClientProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IHttpClientProvider 'TetraPak.AspNet.IHttpClientProvider')  
A HttpClient factory.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_TetraPakClientCredentialsGrantService(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IHttpClientProvider_Microsoft_AspNetCore_Http_IHttpContextAccessor)_httpContextAccessor'></a>
`httpContextAccessor` [Microsoft.AspNetCore.Http.IHttpContextAccessor](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHttpContextAccessor 'Microsoft.AspNetCore.Http.IHttpContextAccessor')  
Provides access to the current request/response [TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService.HttpContext 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService.HttpContext').   
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Any parameter was `null`.  
  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)'></a>
## TetraPakClientCredentialsGrantService.AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool) Method
Requests a token using the OAuth Client Credentials grant.     
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.ClientCredentialsResponse>> AcquireTokenAsync(System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.Credentials? clientCredentials=null, TetraPak.MultiStringValue? scope=null, bool forceAuthorization=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A cancellation token.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_clientCredentials'></a>
`clientCredentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
(optional)<br/>  
Specifies client credentials.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_scope'></a>
`scope` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Scope to be requested for the authorization.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_forceAuthorization'></a>
`forceAuthorization` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
Specifies whether to force a new client credentials authorization  
(overriding/replacing any cached authorization).   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure, and the requested token  
when successful; otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [AcquireTokenAsync(Nullable<CancellationToken>, Credentials, MultiStringValue, bool)](TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService.md#TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool) 'TetraPak.AspNet.Api.Auth.IClientCredentialsGrantService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials, TetraPak.MultiStringValue, bool)')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)'></a>
## TetraPakClientCredentialsGrantService.OnCacheResponseAsync(Credentials, ClientCredentialsResponse) Method
Invoked from [AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool)](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool) 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials?, TetraPak.MultiStringValue?, bool)') when receiving a successful auth response.    
```csharp
protected virtual System.Threading.Tasks.Task OnCacheResponseAsync(TetraPak.Credentials credentials, TetraPak.AspNet.Api.Auth.ClientCredentialsResponse response);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
The credentials used to acquire the response.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)_response'></a>
`response` [TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')  
The response to be cached.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The [response](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)_response 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService.OnCacheResponseAsync(TetraPak.Credentials, TetraPak.AspNet.Api.Auth.ClientCredentialsResponse).response') value.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_OnGetCachedResponse(TetraPak_Credentials)'></a>
## TetraPakClientCredentialsGrantService.OnGetCachedResponse(Credentials) Method
Invoked from [AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool)](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool) 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials?, TetraPak.MultiStringValue?, bool)') when to try fetching a cached auth response.    
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.ClientCredentialsResponse>> OnGetCachedResponse(TetraPak.Credentials credentials);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_OnGetCachedResponse(TetraPak_Credentials)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
The credentials used to acquire the response.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_OnGetCredentialsAsync()'></a>
## TetraPakClientCredentialsGrantService.OnGetCredentialsAsync() Method
This virtual asynchronous method is automatically invoked when [AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool)](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool) 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials?, TetraPak.MultiStringValue?, bool)')  
needs client credentials.   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> OnGetCredentialsAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
