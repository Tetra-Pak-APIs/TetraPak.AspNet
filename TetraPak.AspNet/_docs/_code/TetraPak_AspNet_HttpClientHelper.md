#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpClientHelper Class
Provides convenient methods for registering a [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider').  
```csharp
public static class HttpClientHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpClientHelper  
### Methods
<a name='TetraPak_AspNet_HttpClientHelper_AddTetraPakHttpClientProvider(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IHttpClientProvider_)'></a>
## HttpClientHelper.AddTetraPakHttpClientProvider(IServiceCollection, Func&lt;IServiceProvider,IHttpClientProvider&gt;) Method
Adds a custom [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider') factory.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakHttpClientProvider(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection, System.Func<System.IServiceProvider,TetraPak.AspNet.IHttpClientProvider> factory);
```
#### Parameters
<a name='TetraPak_AspNet_HttpClientHelper_AddTetraPakHttpClientProvider(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IHttpClientProvider_)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
<a name='TetraPak_AspNet_HttpClientHelper_AddTetraPakHttpClientProvider(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IHttpClientProvider_)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
The [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider') factory, used to produce [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')a.  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The [collection](TetraPak_AspNet_HttpClientHelper.md#TetraPak_AspNet_HttpClientHelper_AddTetraPakHttpClientProvider(Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Func_System_IServiceProvider_TetraPak_AspNet_IHttpClientProvider_)_collection 'TetraPak.AspNet.HttpClientHelper.AddTetraPakHttpClientProvider(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func&lt;System.IServiceProvider,TetraPak.AspNet.IHttpClientProvider&gt;).collection').  
  
<a name='TetraPak_AspNet_HttpClientHelper_AddTetraPakHttpClientProvider(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## HttpClientHelper.AddTetraPakHttpClientProvider(IServiceCollection) Method
Registers a default Tetra Pak [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider') implementation.  
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakHttpClientProvider(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection);
```
#### Parameters
<a name='TetraPak_AspNet_HttpClientHelper_AddTetraPakHttpClientProvider(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The [collection](TetraPak_AspNet_HttpClientHelper.md#TetraPak_AspNet_HttpClientHelper_AddTetraPakHttpClientProvider(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection 'TetraPak.AspNet.HttpClientHelper.AddTetraPakHttpClientProvider(Microsoft.Extensions.DependencyInjection.IServiceCollection).collection').  
  
