#### [TetraPak.AspNet.Api](index.md 'index')
## TetraPak.AspNet.Api Namespace

| Classes | |
| :--- | :--- |
| [ApiRequestInitiators](TetraPak_AspNet_Api_ApiRequestInitiators.md 'TetraPak.AspNet.Api.ApiRequestInitiators') | Provides [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') constants representing various standardised API related request initiators.<br/> |
| [BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;') | Supports configuration for an individual backend service, and a collection of service endpoints. <br/> |
| [RequestOptions](TetraPak_AspNet_Api_RequestOptions.md 'TetraPak.AspNet.Api.RequestOptions') | Can be used to control the behavior of a request. <br/> |
| [ServiceAuthConfig](TetraPak_AspNet_Api_ServiceAuthConfig.md 'TetraPak.AspNet.Api.ServiceAuthConfig') |  |
| [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') | Represents a single service endpoint ([BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')).<br/> |
| [ServiceEndpointHelper](TetraPak_AspNet_Api_ServiceEndpointHelper.md 'TetraPak.AspNet.Api.ServiceEndpointHelper') | Convenient methods to help consuming service endpoints.  <br/> |
| [ServiceEndpoints](TetraPak_AspNet_Api_ServiceEndpoints.md 'TetraPak.AspNet.Api.ServiceEndpoints') | A specialized [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') for named URLs.<br/> |
| [ServiceInvalidEndpoint](TetraPak_AspNet_Api_ServiceInvalidEndpoint.md 'TetraPak.AspNet.Api.ServiceInvalidEndpoint') | Represents a service endpoint with issues.<br/>The reason for such endpoints is to assist in creating meaningful error handling.<br/> |
| [TetraPakApiAuthorizationService](TetraPak_AspNet_Api_TetraPakApiAuthorizationService.md 'TetraPak.AspNet.Api.TetraPakApiAuthorizationService') | This class is intended to be instantiated via a dependency injection mechanism. <br/> |
| [TetraPakServiceHelper](TetraPak_AspNet_Api_TetraPakServiceHelper.md 'TetraPak.AspNet.Api.TetraPakServiceHelper') | Assists in configuring support for Tetra Pak managed services consumption.<br/> |

| Interfaces | |
| :--- | :--- |
| [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService') | Classes implementing this contract can be used to consume a backend service. <br/> |
| [IBackendServiceProvider](TetraPak_AspNet_Api_IBackendServiceProvider.md 'TetraPak.AspNet.Api.IBackendServiceProvider') | Classes implementing this contract are able to resolve backend services.<br/> |

| Enums | |
| :--- | :--- |
| [RequestDistribution](TetraPak_AspNet_Api_RequestDistribution.md 'TetraPak.AspNet.Api.RequestDistribution') | Used to specify the request thread distribution when performing multiple resource requests.<br/> |
