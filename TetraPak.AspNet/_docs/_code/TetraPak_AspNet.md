#### [TetraPak.AspNet](index.md 'index')
## TetraPak.AspNet Namespace

| Classes | |
| :--- | :--- |
| [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') | Provides ambient data to an ASP.NET Core/5+ project throughout a request/response roundtrip.<br/> |
| [AmbientData.Keys](TetraPak_AspNet_AmbientData_Keys.md 'TetraPak.AspNet.AmbientData.Keys') | Provides well-known identifiers to access ambient values.  <br/> |
| [AmbientDataServiceHelper](TetraPak_AspNet_AmbientDataServiceHelper.md 'TetraPak.AspNet.AmbientDataServiceHelper') | Declares convenient methods for dealing with [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') as a service.<br/> |
| [ApiChunkedMetadata](TetraPak_AspNet_ApiChunkedMetadata.md 'TetraPak.AspNet.ApiChunkedMetadata') | Derived from [ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata') to add "chunked" meta data attributes.<br/> |
| [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;') | Represents a standardized Tetra Pak API data response.<br/> |
| [ApiDataResponseHelper](TetraPak_AspNet_ApiDataResponseHelper.md 'TetraPak.AspNet.ApiDataResponseHelper') | Convenient methods for dealing with HTTP response use cases. <br/> |
| [ApiErrorResponse](TetraPak_AspNet_ApiErrorResponse.md 'TetraPak.AspNet.ApiErrorResponse') | Represents a standard Tetra Pak API error response (body). <br/> |
| [ApiErrorResponseHelper](TetraPak_AspNet_ApiErrorResponseHelper.md 'TetraPak.AspNet.ApiErrorResponseHelper') | Provides convenient methods for dealing with standard Tetra Pak error responses. <br/> |
| [ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata') | Used as the meta data block in [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;'). <br/> |
| [AuthContext](TetraPak_AspNet_AuthContext.md 'TetraPak.AspNet.AuthContext') | Used to describe an auth request context.<br/> |
| [CacheRepositories](TetraPak_AspNet_CacheRepositories.md 'TetraPak.AspNet.CacheRepositories') | Provides identifiers for supported caches as well as convenient methods<br/>for working with caching.<br/> |
| [CacheRepositories.Tokens](TetraPak_AspNet_CacheRepositories_Tokens.md 'TetraPak.AspNet.CacheRepositories.Tokens') | Provides identifiers for token caches. <br/> |
| [CancellationHelper](TetraPak_AspNet_CancellationHelper.md 'TetraPak.AspNet.CancellationHelper') | Convenient methods for dealing with aborted/canceled HTTP requests.<br/> |
| [ClaimsIdentityExtensions](TetraPak_AspNet_ClaimsIdentityExtensions.md 'TetraPak.AspNet.ClaimsIdentityExtensions') | Convenient extension methods for obtaining typical claims from a [System.Security.Claims.ClaimsIdentity](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Claims.ClaimsIdentity 'System.Security.Claims.ClaimsIdentity') value.<br/> |
| [ConfigurationException](TetraPak_AspNet_ConfigurationException.md 'TetraPak.AspNet.ConfigurationException') | Thrown to reflect configuration issues.<br/> |
| [ControllerExtensions](TetraPak_AspNet_ControllerExtensions.md 'TetraPak.AspNet.ControllerExtensions') | Convenient extension methods for a [Microsoft.AspNetCore.Mvc.Controller](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Mvc.Controller 'Microsoft.AspNetCore.Mvc.Controller').<br/> |
| [FormUrlEncodedContentHelper](TetraPak_AspNet_FormUrlEncodedContentHelper.md 'TetraPak.AspNet.FormUrlEncodedContentHelper') | Provides convenience for dealing with [System.Net.Http.FormUrlEncodedContent](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.FormUrlEncodedContent 'System.Net.Http.FormUrlEncodedContent') objects.<br/> |
| [HttpClientOptions](TetraPak_AspNet_HttpClientOptions.md 'TetraPak.AspNet.HttpClientOptions') | Used to configure a [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient') through a [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider').<br/> |
| [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison') | A string compatible (criteria) expression for use with HTTP requests.<br/> |
| [HttpComparison.Elements](TetraPak_AspNet_HttpComparison_Elements.md 'TetraPak.AspNet.HttpComparison.Elements') | Specifies recognized elements of a HTTP request, for use in comparison operations.<br/> |
| [HttpComparison.Operators](TetraPak_AspNet_HttpComparison_Operators.md 'TetraPak.AspNet.HttpComparison.Operators') | Specifies recognized comparison operators.<br/> |
| [HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper') | Provides extension and convenience method for [Microsoft.AspNetCore.Http.HttpContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpContext 'Microsoft.AspNetCore.Http.HttpContext').<br/> |
| [HttpEnumOutcome&lt;T&gt;](TetraPak_AspNet_HttpEnumOutcome_T_.md 'TetraPak.AspNet.HttpEnumOutcome&lt;T&gt;') | Represents the outcome of a HTTP request.<br/> |
| [HttpOutcome&lt;T&gt;](TetraPak_AspNet_HttpOutcome_T_.md 'TetraPak.AspNet.HttpOutcome&lt;T&gt;') | Represents the outcome of a HTTP request.<br/> |
| [HttpQueryParameters](TetraPak_AspNet_HttpQueryParameters.md 'TetraPak.AspNet.HttpQueryParameters') | Represents HTTP query parameters.<br/> |
| [HttpQueryParametersHelper](TetraPak_AspNet_HttpQueryParametersHelper.md 'TetraPak.AspNet.HttpQueryParametersHelper') | Provides convenient methods for dealing with [HttpQueryParameters](TetraPak_AspNet_HttpQueryParameters.md 'TetraPak.AspNet.HttpQueryParameters').<br/> |
| [HttpRequestCancelledException](TetraPak_AspNet_HttpRequestCancelledException.md 'TetraPak.AspNet.HttpRequestCancelledException') | Reflects a situation where a HTTP request/response roundtrip was cancelled.<br/> |
| [HttpResponseMessageHelper](TetraPak_AspNet_HttpResponseMessageHelper.md 'TetraPak.AspNet.HttpResponseMessageHelper') | Provides convenient extension methods for [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')s.<br/> |
| [ResourceNotFoundException](TetraPak_AspNet_ResourceNotFoundException.md 'TetraPak.AspNet.ResourceNotFoundException') | Represents an issue where a requested resource was not found.<br/> |
| [RoutingHelper](TetraPak_AspNet_RoutingHelper.md 'TetraPak.AspNet.RoutingHelper') | Convenient extension methods for working with controllers and endpoints. <br/> |
| [TetraPakAuthConfig](TetraPak_AspNet_TetraPakAuthConfig.md 'TetraPak.AspNet.TetraPakAuthConfig') | OBSOLETE!<br/>Please use the [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') class instead.<br/> |
| [TetraPakClaimsTransformation](TetraPak_AspNet_TetraPakClaimsTransformation.md 'TetraPak.AspNet.TetraPakClaimsTransformation') | A basic (abstract) implementation of the [ITetraPakClaimsTransformation](TetraPak_AspNet_ITetraPakClaimsTransformation.md 'TetraPak.AspNet.ITetraPakClaimsTransformation') interface.<br/> |
| [TetraPakClaimsTransformationHelper](TetraPak_AspNet_TetraPakClaimsTransformationHelper.md 'TetraPak.AspNet.TetraPakClaimsTransformationHelper') | Provides convenience methods fo setting up claims transformation.<br/> |
| [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig') | Provides a code API to the main Tetra Pak section in the configuration.  <br/> |
| [TetraPakConfigDelegate](TetraPak_AspNet_TetraPakConfigDelegate.md 'TetraPak.AspNet.TetraPakConfigDelegate') | A partial implementation of the [ITetraPakConfigDelegate](TetraPak_AspNet_ITetraPakConfigDelegate.md 'TetraPak.AspNet.ITetraPakConfigDelegate') contract.<br/> |
| [TetraPakConfigHelper](TetraPak_AspNet_TetraPakConfigHelper.md 'TetraPak.AspNet.TetraPakConfigHelper') | Provides convenient helper methods for Tetra Pak configuration scenarios. <br/> |
| [TetraPakHttpClientProvider](TetraPak_AspNet_TetraPakHttpClientProvider.md 'TetraPak.AspNet.TetraPakHttpClientProvider') |  |
| [TetraPakJwtClaimsTransformation](TetraPak_AspNet_TetraPakJwtClaimsTransformation.md 'TetraPak.AspNet.TetraPakJwtClaimsTransformation') | Add this class to the DI configuration to automatically provide a Tetra Pak identity to any request.<br/>The class constructor also needs [AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData') and <br/>Please note that this is automatically done by calling [TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication#TetraPak_AspNet_Auth_TetraPakAuth_AddTetraPakWebClientAuthentication_Microsoft_Extensions_DependencyInjection_IServiceCollection_ 'TetraPak.AspNet.Auth.TetraPakAuth.AddTetraPakWebClientAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)').<br/> |

| Interfaces | |
| :--- | :--- |
| [IApiDataResponse](TetraPak_AspNet_IApiDataResponse.md 'TetraPak.AspNet.IApiDataResponse') |  |
| [IAuthorizationService](TetraPak_AspNet_IAuthorizationService.md 'TetraPak.AspNet.IAuthorizationService') | Classes implementing this interface are able to obtain client authorization,<br/>resulting in an [TetraPak.ActorToken](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ActorToken 'TetraPak.ActorToken') to be used in requests.   <br/> |
| [IHttpClientProvider](TetraPak_AspNet_IHttpClientProvider.md 'TetraPak.AspNet.IHttpClientProvider') | Classes implementing this interface can be used as a factory for obtaining [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')s.<br/> |
| [IMessageIdProvider](TetraPak_AspNet_IMessageIdProvider.md 'TetraPak.AspNet.IMessageIdProvider') | Classes implementing this interface are able to obtain/enforce a message id<br/>(used for tracking events related to a specific request/response roundtrip). <br/> |
| [ITetraPakClaimsTransformation](TetraPak_AspNet_ITetraPakClaimsTransformation.md 'TetraPak.AspNet.ITetraPakClaimsTransformation') | Classes implementing this code contract can be used as (custom) "claims transformers".  <br/> |
| [ITetraPakConfigDelegate](TetraPak_AspNet_ITetraPakConfigDelegate.md 'TetraPak.AspNet.ITetraPakConfigDelegate') | Classes implementing this contract can be passed as a delegate to customize several aspects<br/>of Tetra Pak related configuration. <br/> |

| Enums | |
| :--- | :--- |
| [ComparisonOperation](TetraPak_AspNet_ComparisonOperation.md 'TetraPak.AspNet.ComparisonOperation') | used to express a comparison operation.<br/> |
| [HttpRequestElement](TetraPak_AspNet_HttpRequestElement.md 'TetraPak.AspNet.HttpRequestElement') | Used to express a HTTP request element.<br/> |
| [ServiceScope](TetraPak_AspNet_ServiceScope.md 'TetraPak.AspNet.ServiceScope') | Can be used to specify a scope when configuring (DI) services. <br/> |
