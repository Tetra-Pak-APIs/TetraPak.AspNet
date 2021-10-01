#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api](TetraPak_AspNet_Api.md 'TetraPak.AspNet.Api')
## ServiceInvalidEndpoint Class
Represents a service endpoint with issues.  
The reason for such endpoints is to assist in creating meaningful error handling.  
```csharp
public class ServiceInvalidEndpoint : TetraPak.AspNet.Api.ServiceEndpoint,
TetraPak.AspNet.IMessageIdProvider
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ServiceEndpoint](TetraPak_AspNet_Api_ServiceEndpoint.md 'TetraPak.AspNet.Api.ServiceEndpoint') &#129106; ServiceInvalidEndpoint  

Implements [TetraPak.AspNet.IMessageIdProvider](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider 'TetraPak.AspNet.IMessageIdProvider')  
### Constructors
<a name='TetraPak_AspNet_Api_ServiceInvalidEndpoint_ServiceInvalidEndpoint(TetraPak_AspNet_AmbientData)'></a>
## ServiceInvalidEndpoint.ServiceInvalidEndpoint(AmbientData) Constructor
Initializes the [ServiceInvalidEndpoint](TetraPak_AspNet_Api_ServiceInvalidEndpoint.md 'TetraPak.AspNet.Api.ServiceInvalidEndpoint').  
This constructor is mainly intended for the use by the dependency injection services.   
```csharp
public ServiceInvalidEndpoint(TetraPak.AspNet.AmbientData ambientData);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceInvalidEndpoint_ServiceInvalidEndpoint(TetraPak_AspNet_AmbientData)_ambientData'></a>
`ambientData` [TetraPak.AspNet.AmbientData](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.AmbientData 'TetraPak.AspNet.AmbientData')  
Provides ambient data and configuration.  
  
  
### Methods
<a name='TetraPak_AspNet_Api_ServiceInvalidEndpoint_GetIssues()'></a>
## ServiceInvalidEndpoint.GetIssues() Method
Retrieves all issues found for the invalid service endpoint URL.  
```csharp
public System.Collections.Generic.IEnumerable<System.Exception> GetIssues();
```
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')s.  
  
<a name='TetraPak_AspNet_Api_ServiceInvalidEndpoint_GetMessageId(bool)'></a>
## ServiceInvalidEndpoint.GetMessageId(bool) Method
Retrieves a request message id if available.   
```csharp
public string GetMessageId(bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_Api_ServiceInvalidEndpoint_GetMessageId(bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
When set a message id will be generated and injected into the request/response context.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if a message id was available (or enforced); otherwise `null`.  

Implements [GetMessageId(bool)](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.AspNet.IMessageIdProvider.GetMessageId#TetraPak_AspNet_IMessageIdProvider_GetMessageId_System_Boolean_ 'TetraPak.AspNet.IMessageIdProvider.GetMessageId(System.Boolean)')  
  
