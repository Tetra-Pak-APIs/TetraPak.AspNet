#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Auth](TetraPak_AspNet_Auth.md 'TetraPak.AspNet.Auth')
## IClientConfigProvider Interface
Classes implementing this interface can be relied on to provide the app with a client id and client secret.   
```csharp
public interface IClientConfigProvider
```

Derived  
&#8627; [ITetraPakAuthConfigDelegate](TetraPak_AspNet_ITetraPakAuthConfigDelegate.md 'TetraPak.AspNet.ITetraPakAuthConfigDelegate')  
&#8627; [TetraPakAuthConfigDelegate](TetraPak_AspNet_TetraPakAuthConfigDelegate.md 'TetraPak.AspNet.TetraPakAuthConfigDelegate')  
### Methods
<a name='TetraPak_AspNet_Auth_IClientConfigProvider_GetClientSecretsAsync(TetraPak_AspNet_AuthContext)'></a>
## IClientConfigProvider.GetClientSecretsAsync(AuthContext) Method
Gets (confidential) client secrets (client id and, optionally, client secret).  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.Credentials>> GetClientSecretsAsync(TetraPak.AspNet.AuthContext authContext);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IClientConfigProvider_GetClientSecretsAsync(TetraPak_AspNet_AuthContext)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the (confidential) client secrets are requested.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.Credentials](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Credentials 'TetraPak.Credentials') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Auth_IClientConfigProvider_GetScopeAsync(TetraPak_AspNet_AuthContext)'></a>
## IClientConfigProvider.GetScopeAsync(AuthContext) Method
Gets a scope to be used for the configured client.  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.MultiStringValue>> GetScopeAsync(TetraPak.AspNet.AuthContext authContext);
```
#### Parameters
<a name='TetraPak_AspNet_Auth_IClientConfigProvider_GetScopeAsync(TetraPak_AspNet_AuthContext)_authContext'></a>
`authContext` [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext')  
Details the auth context in which the scope is requested.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TetraPak.MultiStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.MultiStringValue 'TetraPak.MultiStringValue') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
