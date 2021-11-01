#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## IDownstreamServiceProvider Interface
Classes implementing this contract are able to resolve backend services.  
```csharp
public interface IDownstreamServiceProvider
```
### Methods
<a name='TetraPak_AspNet_Api_IDownstreamServiceProvider_ResolveService(System_Type_string_)'></a>
## IDownstreamServiceProvider.ResolveService(Type, string?) Method
Resolves a service, based on its type and (optionally) service name  
```csharp
TetraPak.Outcome<TetraPak.AspNet.Api.IBackendService> ResolveService(System.Type serviceType, string? serviceName=null);
```
#### Parameters
<a name='TetraPak_AspNet_Api_IDownstreamServiceProvider_ResolveService(System_Type_string_)_serviceType'></a>
`serviceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
  
<a name='TetraPak_AspNet_Api_IDownstreamServiceProvider_ResolveService(System_Type_string_)_serviceName'></a>
`serviceName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Specifies a configured service. This is required if [serviceType](TetraPak_AspNet_Api_IDownstreamServiceProvider.md#TetraPak_AspNet_Api_IDownstreamServiceProvider_ResolveService(System_Type_string_)_serviceType 'TetraPak.AspNet.Api.IDownstreamServiceProvider.ResolveService(System.Type, string?).serviceType')  
if just a generic backend service.   
  
#### Returns
[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
