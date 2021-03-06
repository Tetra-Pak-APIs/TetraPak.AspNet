#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## TetraPakClientCredentialsService Class
A default service to support the client credentials grant type.  
```csharp
public class TetraPakClientCredentialsService :
TetraPak.AspNet.Api.Auth.IClientCredentialsService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakClientCredentialsService  

Implements [IClientCredentialsService](TetraPak_AspNet_Api_Auth_IClientCredentialsService.md 'TetraPak.AspNet.Api.Auth.IClientCredentialsService')  
### Constructors
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_TetraPakClientCredentialsService(TetraPak_AspNet_TetraPakAuthConfig)'></a>
## TetraPakClientCredentialsService.TetraPakClientCredentialsService(TetraPakAuthConfig) Constructor
```csharp
public TetraPakClientCredentialsService(TetraPak.AspNet.TetraPakAuthConfig authConfig);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_TetraPakClientCredentialsService(TetraPak_AspNet_TetraPakAuthConfig)_authConfig'></a>
`authConfig` [TetraPak.AspNet.TetraPakAuthConfig](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.TetraPakAuthConfig 'TetraPak.AspNet.TetraPakAuthConfig')  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
  
### Properties
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_Logger'></a>
## TetraPakClientCredentialsService.Logger Property
Gets a logger provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
### Methods
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)'></a>
## TetraPakClientCredentialsService.AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool) Method
Requests a token using the OAuth Client Credentials grant.     
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.ClientCredentialsResponse>> AcquireTokenAsync(System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.Credentials? clientCredentials=null, TetraPak.MultiStringValue? scope=null, bool allowCached=true);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A cancellation token.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_clientCredentials'></a>
`clientCredentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
(optional)<br/>  
Specifies client credentials.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_scope'></a>
`scope` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Scope to be requested for the authorization.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool)_allowCached'></a>
`allowCached` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to reuse a cached token if available, or to cache an acquired token when successful.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure, and the requested token  
when successful; otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [AcquireTokenAsync(Nullable<CancellationToken>, Credentials, MultiStringValue, bool)](TetraPak_AspNet_Api_Auth_IClientCredentialsService.md#TetraPak_AspNet_Api_Auth_IClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool) 'TetraPak.AspNet.Api.Auth.IClientCredentialsService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials, TetraPak.MultiStringValue, bool)')  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)'></a>
## TetraPakClientCredentialsService.OnCacheResponseAsync(Credentials, ClientCredentialsResponse) Method
Invoked from [AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool)](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool) 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials?, TetraPak.MultiStringValue?, bool)') when receiving a successful auth response.    
```csharp
protected virtual System.Threading.Tasks.Task OnCacheResponseAsync(TetraPak.Credentials credentials, TetraPak.AspNet.Api.Auth.ClientCredentialsResponse response);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
The credentials used to acquire the response.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)_response'></a>
`response` [TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')  
The response to be cached.  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The [response](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_OnCacheResponseAsync(TetraPak_Credentials_TetraPak_AspNet_Api_Auth_ClientCredentialsResponse)_response 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsService.OnCacheResponseAsync(TetraPak.Credentials, TetraPak.AspNet.Api.Auth.ClientCredentialsResponse).response') value.  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_OnGetCachedResponse(TetraPak_Credentials)'></a>
## TetraPakClientCredentialsService.OnGetCachedResponse(Credentials) Method
Invoked from [AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool)](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool) 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials?, TetraPak.MultiStringValue?, bool)') when to try fetching a cached auth response.    
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.ClientCredentialsResponse>> OnGetCachedResponse(TetraPak.Credentials credentials);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_OnGetCachedResponse(TetraPak_Credentials)_credentials'></a>
`credentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
The credentials used to acquire the response.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_OnGetCredentialsAsync()'></a>
## TetraPakClientCredentialsService.OnGetCredentialsAsync() Method
This virtual asynchronous method is automatically invoked when [AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials?, MultiStringValue?, bool)](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService.md#TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials__TetraPak_MultiStringValue__bool) 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsService.AcquireTokenAsync(System.Nullable&lt;System.Threading.CancellationToken&gt;, TetraPak.Credentials?, TetraPak.MultiStringValue?, bool)')  
needs client credentials.   
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> OnGetCredentialsAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
