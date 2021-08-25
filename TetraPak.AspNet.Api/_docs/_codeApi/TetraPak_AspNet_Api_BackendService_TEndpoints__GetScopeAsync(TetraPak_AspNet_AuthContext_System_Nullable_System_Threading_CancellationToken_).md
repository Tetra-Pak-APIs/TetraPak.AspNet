#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api').[BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')
## BackendService&lt;TEndpoints&gt;.GetScopeAsync(AuthContext, Nullable&lt;CancellationToken&gt;) Method
Gets a scope to be requested for authorization.  
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_authContext'></a>
`authContext` [TetraPak.AspNet.AuthContext](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AuthContext 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
<a name='TetraPak_AspNet_Api_BackendService_TEndpoints__GetScopeAsync(TetraPak_AspNet_AuthContext_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br />  
Cancellation token for cancellation the operation.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [GetScopeAsync(AuthContext, Nullable<CancellationToken>)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync#TetraPak_AspNet_Auth_IServiceAuthConfig_GetScopeAsync_TetraPak_AspNet_AuthContext,System_Nullable{System_Threading_CancellationToken}_ 'TetraPak.AspNet.Auth.IServiceAuthConfig.GetScopeAsync(TetraPak.AspNet.AuthContext,System.Nullable{System.Threading.CancellationToken})')  
