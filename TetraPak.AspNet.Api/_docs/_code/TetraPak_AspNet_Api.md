#### [TetraPak.AspNet.Api](index.md 'index')
## TetraPak.AspNet.Api Namespace

| Classes | |
| :--- | :--- |
| [BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;') | Supports configuration for an individual backend service, and a collection of service endpoints. <br/> |
| [ServiceAuthConfig](TetraPak_AspNet_Api_ServiceAuthConfig.md 'TetraPak.AspNet.Api.ServiceAuthConfig') |  |
| [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') | Represents a single service endpoint ([BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;')).<br/> |
| [ServiceEndpointExtensions](TetraPak_AspNet_Api_ServiceEndpointExtensions.md 'TetraPak.AspNet.Api.ServiceEndpointExtensions') | Convenient methods to help consuming service endpoints.  <br/> |
| [ServiceEndpoints](TetraPak_AspNet_Api_ServiceEndpoints.md 'TetraPak.AspNet.Api.ServiceEndpoints') | A specialized [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') for named URLs.<br/> |
| [ServiceInvalidEndpoint](TetraPak_AspNet_Api_ServiceInvalidEndpoint.md 'TetraPak.AspNet.Api.ServiceInvalidEndpoint') | Represents a service endpoint with issues.<br/>The reason for such endpoints is to assist in creating meaningful error handling.<br/> |
| [TetraPakApiAuthorizationService](TetraPak_AspNet_Api_TetraPakApiAuthorizationService.md 'TetraPak.AspNet.Api.TetraPakApiAuthorizationService') |  |
| [TetraPakApiHttpClientProvider](TetraPak_AspNet_Api_TetraPakApiHttpClientProvider.md 'TetraPak.AspNet.Api.TetraPakApiHttpClientProvider') | Implements base functionality for providing HTTP clients<br/>to be used when consuming configured backend services. <br/> |
| [TetraPakServiceHelper](TetraPak_AspNet_Api_TetraPakServiceHelper.md 'TetraPak.AspNet.Api.TetraPakServiceHelper') | Assists in configuring support for Tetra Pak managed services consumption.<br/> |

| Interfaces | |
| :--- | :--- |
| [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService') | Classes implementing this contract can be used to consume a backend service. <br/> |
| [IDownstreamServiceProvider](TetraPak_AspNet_Api_IDownstreamServiceProvider.md 'TetraPak.AspNet.Api.IDownstreamServiceProvider') | Classes implementing this contract are able to resolve backend services.<br/> |
