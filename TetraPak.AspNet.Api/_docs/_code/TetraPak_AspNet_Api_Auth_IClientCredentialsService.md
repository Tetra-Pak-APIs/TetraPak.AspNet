#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## IClientCredentialsService Interface
Implementors of this interface are able to acquire a token using the  
OAuth Client Credentials grant.   
```csharp
public interface IClientCredentialsService
```

Derived  
&#8627; [TetraPakClientCredentialsService](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsService.md 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsService')  
### Methods
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)'></a>
## IClientCredentialsService.AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials, MultiStringValue, bool) Method
Requests a token using the OAuth Client Credentials grant.     
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.ClientCredentialsResponse>> AcquireTokenAsync(System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.Credentials clientCredentials=null, TetraPak.MultiStringValue scope=null, bool allowCached=true);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A cancellation token.  
  
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_clientCredentials'></a>
`clientCredentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
(optional)<br/>  
Specifies client credentials.  
  
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_scope'></a>
`scope` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Scope to be requested for the authorization.  
  
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_allowCached'></a>
`allowCached` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br/>  
Specifies whether to reuse a cached token if available, or to cache an acquired token when successful.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure, and the requested token  
when successful; otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
