#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## TetraPakServiceHelper Class
Assists in configuring support for Tetra Pak managed services consumption.  
```csharp
public static class TetraPakServiceHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TetraPakServiceHelper  
### Methods
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_AddTetraPakServices(Microsoft_Extensions_DependencyInjection_IServiceCollection)'></a>
## TetraPakServiceHelper.AddTetraPakServices(IServiceCollection) Method
(fluent API)<br/>  
Adds services needed to support consumption of "downstream" Tetra Pak managed services.   
```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddTetraPakServices(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_AddTetraPakServices(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection'></a>
`collection` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The service collection.  
  
#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
The [collection](TetraPak_AspNet_Api_TetraPakServiceHelper.md#TetraPak_AspNet_Api_TetraPakServiceHelper_AddTetraPakServices(Microsoft_Extensions_DependencyInjection_IServiceCollection)_collection 'TetraPak.AspNet.Api.TetraPakServiceHelper.AddTetraPakServices(Microsoft.Extensions.DependencyInjection.IServiceCollection).collection').  
  
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_Endpoint(TetraPak_AspNet_Api_IBackendService_string)'></a>
## TetraPakServiceHelper.Endpoint(IBackendService, string) Method
Returns a specified backend service endpoint.  
```csharp
public static TetraPak.AspNet.Api.ServiceEndpoint Endpoint(this TetraPak.AspNet.Api.IBackendService service, string name);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_Endpoint(TetraPak_AspNet_Api_IBackendService_string)_service'></a>
`service` [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService')  
The extended backend service.  
  
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_Endpoint(TetraPak_AspNet_Api_IBackendService_string)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the requested endpoint (as specified in configuration).  
  
#### Returns
[ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint')  
  
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_GetBackendService_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)'></a>
## TetraPakServiceHelper.GetBackendService&lt;TBackendService&gt;(ControllerBase, string?) Method
Obtains and returns a configured backend service ([IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService')).  
```csharp
public static TetraPak.Outcome<TBackendService> GetBackendService<TBackendService>(this Microsoft.AspNetCore.Mvc.ControllerBase controller, string? serviceName=null)
    where TBackendService : TetraPak.AspNet.Api.IBackendService;
```
#### Type parameters
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_GetBackendService_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_TBackendService'></a>
`TBackendService`  
The expected type of backend service.  
  
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_GetBackendService_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_controller'></a>
`controller` [Microsoft.AspNetCore.Mvc.ControllerBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.ControllerBase 'Microsoft.AspNetCore.Mvc.ControllerBase')  
The extended controller.  
  
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_GetBackendService_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_serviceName'></a>
`serviceName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the backend service (must be found in the configuration).  
  
#### Returns
[TetraPak.Outcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')[TBackendService](TetraPak_AspNet_Api_TetraPakServiceHelper.md#TetraPak_AspNet_Api_TetraPakServiceHelper_GetBackendService_TBackendService_(Microsoft_AspNetCore_Mvc_ControllerBase_string_)_TBackendService 'TetraPak.AspNet.Api.TetraPakServiceHelper.GetBackendService&lt;TBackendService&gt;(Microsoft.AspNetCore.Mvc.ControllerBase, string?).TBackendService')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1')  
An [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') to indicate success/failure and, on success, also carry  
a [TBackendService](https://docs.microsoft.com/en-us/dotnet/api/TBackendService 'TBackendService') or, on failure, an [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
  
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_UseTetraPakServicesDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder)'></a>
## TetraPakServiceHelper.UseTetraPakServicesDiagnostics(IApplicationBuilder) Method
(fluent API)<br/>  
Injects middleware that diagnoses and logs statistics for "downstream" services.    
```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseTetraPakServicesDiagnostics(this Microsoft.AspNetCore.Builder.IApplicationBuilder applicationBuilder);
```
#### Parameters
<a name='TetraPak_AspNet_Api_TetraPakServiceHelper_UseTetraPakServicesDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder)_applicationBuilder'></a>
`applicationBuilder` [Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The application builder instance.   
  
#### Returns
[Microsoft.AspNetCore.Builder.IApplicationBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Builder.IApplicationBuilder 'Microsoft.AspNetCore.Builder.IApplicationBuilder')  
The [applicationBuilder](TetraPak_AspNet_Api_TetraPakServiceHelper.md#TetraPak_AspNet_Api_TetraPakServiceHelper_UseTetraPakServicesDiagnostics(Microsoft_AspNetCore_Builder_IApplicationBuilder)_applicationBuilder 'TetraPak.AspNet.Api.TetraPakServiceHelper.UseTetraPakServicesDiagnostics(Microsoft.AspNetCore.Builder.IApplicationBuilder).applicationBuilder')
  
