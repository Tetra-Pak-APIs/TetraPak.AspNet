#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## IAuthorizationService Interface
Classes implementing this interface are able to obtain client authorization,  
resulting in an [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') to be used in requests.     
```csharp
public interface IAuthorizationService
```
### Methods
<a name='TetraPak_AspNet_IAuthorizationService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)'></a>
## IAuthorizationService.AuthorizeAsync(HttpClientOptions, Nullable&lt;CancellationToken&gt;) Method
Authenticates a specific service.   
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<TetraPak.ActorToken>> AuthorizeAsync(TetraPak.AspNet.HttpClientOptions options, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_IAuthorizationService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
Options for obtaining a client.  
  
<a name='TetraPak_AspNet_IAuthorizationService_AuthorizeAsync(TetraPak_AspNet_HttpClientOptions_System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested token as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
