#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## TetraPakHttpClientProvider Class
A base implementation of the [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider').    
```csharp
public class TetraPakHttpClientProvider :
TetraPak.AspNet.IHttpClientProvider,
TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakHttpClientProvider  

Implements [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider'), [TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider 'TetraPak.AspNet.Diagnostics.ITetraPakDiagnosticsProvider')  
### Constructors
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakHttpClientProvider(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IAuthorizationService__System_Func_TetraPak_AspNet_HttpClientOptions_System_Net_Http_HttpClient___TetraPak_AspNet_HttpClientOptions_)'></a>
## TetraPakHttpClientProvider.TetraPakHttpClientProvider(TetraPakConfig, IAuthorizationService?, Func&lt;HttpClientOptions,HttpClient&gt;?, HttpClientOptions?) Constructor
Initializes the [TetraPakHttpClientProvider](TetraPak_AspNet_TetraPakHttpClientProvider.md 'TetraPak.AspNet.TetraPakHttpClientProvider').  
```csharp
public TetraPakHttpClientProvider(TetraPak.AspNet.TetraPakConfig tetraPakConfig, TetraPak.AspNet.IAuthorizationService? authorizationService=null, System.Func<TetraPak.AspNet.HttpClientOptions,System.Net.Http.HttpClient>? singletonClientFactory=null, TetraPak.AspNet.HttpClientOptions? singletonClientOptions=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakHttpClientProvider(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IAuthorizationService__System_Func_TetraPak_AspNet_HttpClientOptions_System_Net_Http_HttpClient___TetraPak_AspNet_HttpClientOptions_)_tetraPakConfig'></a>
`tetraPakConfig` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakHttpClientProvider(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IAuthorizationService__System_Func_TetraPak_AspNet_HttpClientOptions_System_Net_Http_HttpClient___TetraPak_AspNet_HttpClientOptions_)_authorizationService'></a>
`authorizationService` [IAuthorizationService](TetraPak_AspNet_IAuthorizationService.md 'TetraPak.AspNet.IAuthorizationService')  
(optional)<br/>  
A (custom) authorization service to be invoked instead of amy default service.   
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakHttpClientProvider(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IAuthorizationService__System_Func_TetraPak_AspNet_HttpClientOptions_System_Net_Http_HttpClient___TetraPak_AspNet_HttpClientOptions_)_singletonClientFactory'></a>
`singletonClientFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
(optional)<br/>  
A custom factory to be used for producing singleton [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')s.   
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakHttpClientProvider(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IAuthorizationService__System_Func_TetraPak_AspNet_HttpClientOptions_System_Net_Http_HttpClient___TetraPak_AspNet_HttpClientOptions_)_singletonClientOptions'></a>
`singletonClientOptions` [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
(optional)<br/>  
Options to be used by a custom [singletonClientFactory](TetraPak_AspNet_TetraPakHttpClientProvider.md#TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakHttpClientProvider(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IAuthorizationService__System_Func_TetraPak_AspNet_HttpClientOptions_System_Net_Http_HttpClient___TetraPak_AspNet_HttpClientOptions_)_singletonClientFactory 'TetraPak.AspNet.TetraPakHttpClientProvider.TetraPakHttpClientProvider(TetraPak.AspNet.TetraPakConfig, TetraPak.AspNet.IAuthorizationService?, System.Func&lt;TetraPak.AspNet.HttpClientOptions,System.Net.Http.HttpClient&gt;?, TetraPak.AspNet.HttpClientOptions?).singletonClientFactory').  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
The [tetraPakConfig](TetraPak_AspNet_TetraPakHttpClientProvider.md#TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakHttpClientProvider(TetraPak_AspNet_TetraPakConfig_TetraPak_AspNet_IAuthorizationService__System_Func_TetraPak_AspNet_HttpClientOptions_System_Net_Http_HttpClient___TetraPak_AspNet_HttpClientOptions_)_tetraPakConfig 'TetraPak.AspNet.TetraPakHttpClientProvider.TetraPakHttpClientProvider(TetraPak.AspNet.TetraPakConfig, TetraPak.AspNet.IAuthorizationService?, System.Func&lt;TetraPak.AspNet.HttpClientOptions,System.Net.Http.HttpClient&gt;?, TetraPak.AspNet.HttpClientOptions?).tetraPakConfig') was `null`.  
  
### Properties
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_HttpContext'></a>
## TetraPakHttpClientProvider.HttpContext Property
Provides access to th current [HttpContext](TetraPak_AspNet_TetraPakHttpClientProvider.md#TetraPak_AspNet_TetraPakHttpClientProvider_HttpContext 'TetraPak.AspNet.TetraPakHttpClientProvider.HttpContext').  
```csharp
protected Microsoft.AspNetCore.Http.HttpContext? HttpContext { get; }
```
#### Property Value
[Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext')
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_Logger'></a>
## TetraPakHttpClientProvider.Logger Property
Gets a logging provider.  
```csharp
protected Microsoft.Extensions.Logging.ILogger? Logger { get; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_SingletonClient'></a>
## TetraPakHttpClientProvider.SingletonClient Property
The singleton instance (if applicable) of the [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
```csharp
protected System.Net.Http.HttpClient SingletonClient { get; }
```
#### Property Value
[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_TetraPakConfig'></a>
## TetraPakHttpClientProvider.TetraPakConfig Property
Gets the Tetra Pak integration configuration.  
```csharp
protected TetraPak.AspNet.TetraPakConfig TetraPakConfig { get; }
```
#### Property Value
[TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')
  
### Methods
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_AddDecorator(TetraPak_AspNet_IHttpClientDecorator)'></a>
## TetraPakHttpClientProvider.AddDecorator(IHttpClientDecorator) Method
Adds a custom [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') decorator.  
```csharp
public static void AddDecorator(TetraPak.AspNet.IHttpClientDecorator decorator);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_AddDecorator(TetraPak_AspNet_IHttpClientDecorator)_decorator'></a>
`decorator` [IHttpClientDecorator](TetraPak_AspNet_IHttpClientDecorator.md 'TetraPak.AspNet.IHttpClientDecorator')  
  
### Remarks
All registered client decorators will be automatically invoked when a client is being requested  
to allow applying custom logic before the client is being consumed.    
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_GetDiagnostics()'></a>
## TetraPakHttpClientProvider.GetDiagnostics() Method
Returns a [ServiceDiagnostics](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics') object if available; otherwise `null`.   
```csharp
protected TetraPak.AspNet.Diagnostics.ServiceDiagnostics? GetDiagnostics();
```
#### Returns
[ServiceDiagnostics](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics')  
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)'></a>
## TetraPakHttpClientProvider.GetHttpClientAsync(HttpClientOptions?, Nullable&lt;CancellationToken&gt;) Method
Creates and returns a (configured) [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') for use with a specific service.   
```csharp
public System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions? options=null, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_options'></a>
`options` [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions')  
(optional)<br/>  
A (customizable) set of options to describe the requested [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient').  
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_)_cancellationToken'></a>
`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional)<br/>  
A [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') value indicating success/failure and, on success, carrying  
the requested client as its [TetraPak.Outcome&lt;&gt;.Value](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1.Value 'TetraPak.Outcome`1.Value'); otherwise an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  

Implements [GetHttpClientAsync(HttpClientOptions?, Nullable<CancellationToken>)](TetraPak_AspNet_IHttpClientProvider.md#TetraPak_AspNet_IHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.IHttpClientProvider.GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')  
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_OnDecorateClient(System_Net_Http_HttpClient_TetraPak_AspNet_IHttpClientDecorator__)'></a>
## TetraPakHttpClientProvider.OnDecorateClient(HttpClient, IHttpClientDecorator[]) Method
Called internally (from [GetHttpClientAsync(HttpClientOptions?, Nullable&lt;CancellationToken&gt;)](TetraPak_AspNet_TetraPakHttpClientProvider.md#TetraPak_AspNet_TetraPakHttpClientProvider_GetHttpClientAsync(TetraPak_AspNet_HttpClientOptions__System_Nullable_System_Threading_CancellationToken_) 'TetraPak.AspNet.TetraPakHttpClientProvider.GetHttpClientAsync(TetraPak.AspNet.HttpClientOptions?, System.Nullable&lt;System.Threading.CancellationToken&gt;)')) to decorate the produced client before  
it gets consumed.  
```csharp
protected virtual System.Threading.Tasks.Task<TetraPak.Outcome<System.Net.Http.HttpClient>> OnDecorateClient(System.Net.Http.HttpClient client, TetraPak.AspNet.IHttpClientDecorator[] decorators);
```
#### Parameters
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_OnDecorateClient(System_Net_Http_HttpClient_TetraPak_AspNet_IHttpClientDecorator__)_client'></a>
`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')  
The [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') to be decorated.  
  
<a name='TetraPak_AspNet_TetraPakHttpClientProvider_OnDecorateClient(System_Net_Http_HttpClient_TetraPak_AspNet_IHttpClientDecorator__)_decorators'></a>
`decorators` [IHttpClientDecorator](TetraPak_AspNet_IHttpClientDecorator.md 'TetraPak.AspNet.IHttpClientDecorator')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
All decorators to be invoked.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
  
