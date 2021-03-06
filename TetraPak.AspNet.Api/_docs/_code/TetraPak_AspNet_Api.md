#### [TetraPak.AspNet.Api](index.md 'index')
## TetraPak.AspNet.Api Namespace

| Classes | |
| :--- | :--- |
| [BackendService&lt;TEndpoints&gt;](TetraPak_AspNet_Api_BackendService_TEndpoints_.md 'TetraPak.AspNet.Api.BackendService&lt;TEndpoints&gt;') | Supports configuration for an individual backend service, and a collection of service endpoints. <br/> |
| [HttpClientOptions](TetraPak_AspNet_Api_HttpClientOptions.md 'TetraPak.AspNet.Api.HttpClientOptions') | Used to configure a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') through a [IHttpServiceProvider](TetraPak_AspNet_Api_IHttpServiceProvider.md 'TetraPak.AspNet.Api.IHttpServiceProvider').<br/> |
| [HttpServiceProvider](TetraPak_AspNet_Api_HttpServiceProvider.md 'TetraPak.AspNet.Api.HttpServiceProvider') | Implements base functionality for providing HTTP clients<br/>to be used when consuming configured backend services. <br/> |
| [ServiceAuthConfig](TetraPak_AspNet_Api_ServiceAuthConfig.md 'TetraPak.AspNet.Api.ServiceAuthConfig') |  |
| [ServiceConfigHelper](TetraPak_AspNet_Api_ServiceConfigHelper.md 'TetraPak.AspNet.Api.ServiceConfigHelper') | Convenient helper methods for working with the configuration of backend services.   <br/> |
| [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') |  |
| [ServiceEndpointCollection](TetraPak_AspNet_Api_ServiceEndpointCollection.md 'TetraPak.AspNet.Api.ServiceEndpointCollection') | A specialized [TetraPak.Configuration.ConfigurationSection](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Configuration.ConfigurationSection 'TetraPak.Configuration.ConfigurationSection') for named URLs.<br/> |
| [ServiceEndpointExtensions](TetraPak_AspNet_Api_ServiceEndpointExtensions.md 'TetraPak.AspNet.Api.ServiceEndpointExtensions') |  |
| [ServiceInvalidEndpoint](TetraPak_AspNet_Api_ServiceInvalidEndpoint.md 'TetraPak.AspNet.Api.ServiceInvalidEndpoint') | Represents a service endpoint with issues.<br/>The reason for such endpoints is to assist in creating meaningful error handling.<br/> |
| [TetraPakControllerFactory](TetraPak_AspNet_Api_TetraPakControllerFactory.md 'TetraPak.AspNet.Api.TetraPakControllerFactory') | Deals with activating non-custom (derived) API gateway controllers. <br/> |

| Interfaces | |
| :--- | :--- |
| [IApiLoggerProvider](TetraPak_AspNet_Api_IApiLoggerProvider.md 'TetraPak.AspNet.Api.IApiLoggerProvider') | Classes implementing this contract can be used to acquire a logging provider.<br/> |
| [IBackendService](TetraPak_AspNet_Api_IBackendService.md 'TetraPak.AspNet.Api.IBackendService') | Classes implementing this contract can be used to consume a backend service. <br/> |
| [IHttpServiceProvider](TetraPak_AspNet_Api_IHttpServiceProvider.md 'TetraPak.AspNet.Api.IHttpServiceProvider') | Provides a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient'), either as a singleton or a transient instance.   <br/> |
