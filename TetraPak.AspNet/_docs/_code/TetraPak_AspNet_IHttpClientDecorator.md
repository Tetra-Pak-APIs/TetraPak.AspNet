#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## IHttpClientDecorator Interface
Classes implementing this interface can be registered to decorate [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')s  
produced by a [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider') (based on [TetraPakHttpClientProvider](TetraPak_AspNet_TetraPakHttpClientProvider.md 'TetraPak.AspNet.TetraPakHttpClientProvider')).   
```csharp
public interface IHttpClientDecorator
```
### Methods
<a name='TetraPak_AspNet_IHttpClientDecorator_DecorateAsync(System_Net_Http_HttpClient)'></a>
## IHttpClientDecorator.DecorateAsync(HttpClient) Method
Called by a [TetraPakHttpClientProvider](TetraPak_AspNet_TetraPakHttpClientProvider.md 'TetraPak.AspNet.TetraPakHttpClientProvider') to decorate a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
```csharp
System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> DecorateAsync(System.Net.Http.HttpClient client);
```
#### Parameters
<a name='TetraPak_AspNet_IHttpClientDecorator_DecorateAsync(System_Net_Http_HttpClient)_client'></a>
`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')  
The [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') to be decorated.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
