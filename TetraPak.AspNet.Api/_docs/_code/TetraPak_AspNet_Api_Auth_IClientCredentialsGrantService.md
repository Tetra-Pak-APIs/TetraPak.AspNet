#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Auth](TetraPak_AspNet_Api_Auth.md 'TetraPak.AspNet.Api.Auth')
## IClientCredentialsGrantService Interface
Implementors of this interface are able to acquire a token using the  
OAuth Client Credentials grant.   
```csharp
public interface IClientCredentialsGrantService
```

Derived  
&#8627; [TetraPakClientCredentialsGrantService](TetraPak_AspNet_Api_Auth_TetraPakClientCredentialsGrantService.md 'TetraPak.AspNet.Api.Auth.TetraPakClientCredentialsGrantService')  
### Methods
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)'></a>
## IClientCredentialsGrantService.AcquireTokenAsync(Nullable&lt;CancellationToken&gt;, Credentials, MultiStringValue, bool) Method
Requests a token using the OAuth Client Credentials grant.     
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.AspNet.Api.Auth.ClientCredentialsResponse>> AcquireTokenAsync(System.Nullable<System.Threading.CancellationToken> cancellationToken=null, TetraPak.Credentials clientCredentials=null, TetraPak.MultiStringValue scope=null, bool forceAuthorization=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A cancellation token.  
  
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_clientCredentials'></a>
`clientCredentials` [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')  
(optional)<br/>  
Specifies client credentials.  
  
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_scope'></a>
`scope` [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')  
(optional)<br/>  
Scope to be requested for the authorization.  
  
<a name='TetraPak_AspNet_Api_Auth_IClientCredentialsGrantService_AcquireTokenAsync(System_Nullable_System_Threading_CancellationToken__TetraPak_Credentials_TetraPak_MultiStringValue_bool)_forceAuthorization'></a>
`forceAuthorization` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
Specifies whether to force a new client credentials authorization  
(overriding/replacing any cached authorization).   
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.AspNet.Api.Auth.ClientCredentialsResponse](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Api.Auth.ClientCredentialsResponse 'TetraPak.AspNet.Api.Auth.ClientCredentialsResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') instance indicating success/failure, and the requested token  
when successful; otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
