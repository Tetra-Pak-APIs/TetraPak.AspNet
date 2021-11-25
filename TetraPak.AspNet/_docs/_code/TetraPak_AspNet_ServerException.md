#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ServerException Class
An exception that codifies the issue using a standard HTTP status code.  
Very suitable for many server related exceptions.  
(see: <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status">list of HTTP status codes</a>).  
```csharp
public class ServerException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; ServerException  

Derived  
&#8627; [ServerConfigurationException](TetraPak_AspNet_ServerConfigurationException.md 'TetraPak.AspNet.ServerConfigurationException')  
### Constructors
<a name='TetraPak_AspNet_ServerException_ServerException(string_System_Net_HttpStatusCode_System_Exception_)'></a>
## ServerException.ServerException(string, HttpStatusCode, Exception?) Constructor
Initializes the [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') with a [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode').  
```csharp
internal ServerException(string message, System.Net.HttpStatusCode statusCode, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_ServerException(string_System_Net_HttpStatusCode_System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
An error message that explains the reason for the exception.  
  
<a name='TetraPak_AspNet_ServerException_ServerException(string_System_Net_HttpStatusCode_System_Exception_)_statusCode'></a>
`statusCode` [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')  
The [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode') to be assigned.  
  
<a name='TetraPak_AspNet_ServerException_ServerException(string_System_Net_HttpStatusCode_System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
  
<a name='TetraPak_AspNet_ServerException_ServerException(System_Net_Http_HttpResponseMessage_string__System_Exception_)'></a>
## ServerException.ServerException(HttpResponseMessage, string?, Exception?) Constructor
Initializes the [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') with a [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage').  
Please note that this also assigns the [StatusCode](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_StatusCode 'TetraPak.AspNet.ServerException.StatusCode').  
```csharp
public ServerException(System.Net.Http.HttpResponseMessage response, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_ServerException(System_Net_Http_HttpResponseMessage_string__System_Exception_)_response'></a>
`response` [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')  
The [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') to be assigned.   
  
<a name='TetraPak_AspNet_ServerException_ServerException(System_Net_Http_HttpResponseMessage_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
An error message that explains the reason for the exception.  
  
<a name='TetraPak_AspNet_ServerException_ServerException(System_Net_Http_HttpResponseMessage_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
  
<a name='TetraPak_AspNet_ServerException_ServerException(System_Net_HttpStatusCode_System_Exception_)'></a>
## ServerException.ServerException(HttpStatusCode, Exception?) Constructor
Initializes the [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') with a [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode').  
```csharp
internal ServerException(System.Net.HttpStatusCode statusCode, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_ServerException(System_Net_HttpStatusCode_System_Exception_)_statusCode'></a>
`statusCode` [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')  
The [System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode') to be assigned.  
  
<a name='TetraPak_AspNet_ServerException_ServerException(System_Net_HttpStatusCode_System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
  
### Properties
<a name='TetraPak_AspNet_ServerException_Response'></a>
## ServerException.Response Property
A [System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage'). This value might not have been assigned.  
```csharp
public System.Net.Http.HttpResponseMessage? Response { get; }
```
#### Property Value
[System.Net.Http.HttpResponseMessage](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage')
  
<a name='TetraPak_AspNet_ServerException_StatusCode'></a>
## ServerException.StatusCode Property
Gets the HTTP status code  
(see: <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status">list of HTTP status codes</a>).  
```csharp
public System.Net.HttpStatusCode StatusCode { get; }
```
#### Property Value
[System.Net.HttpStatusCode](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpStatusCode 'System.Net.HttpStatusCode')
  
### Methods
<a name='TetraPak_AspNet_ServerException_BadGateway(string__System_Exception_)'></a>
## ServerException.BadGateway(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server, while acting as a gateway or proxy,  
received an invalid response from the upstream server.  
```csharp
public static TetraPak.AspNet.ServerException BadGateway(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_BadGateway(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_BadGateway(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_BadRequest(string__System_Exception_)'></a>
## ServerException.BadRequest(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect a bad request.  
```csharp
public static TetraPak.AspNet.ServerException BadRequest(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_BadRequest(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_BadRequest(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_Conflict(string__System_Exception_)'></a>
## ServerException.Conflict(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate a request conflict with  
current state of the target resource.  
```csharp
public static TetraPak.AspNet.ServerException Conflict(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_Conflict(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_Conflict(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_ExpectationFailed(string__System_Exception_)'></a>
## ServerException.ExpectationFailed(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the expectation  
given in the request's `Expect` header could not be met.  
```csharp
public static TetraPak.AspNet.ServerException ExpectationFailed(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_ExpectationFailed(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_ExpectationFailed(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_FailedDependency(string__System_Exception_)'></a>
## ServerException.FailedDependency(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the request failed  
due to failure of a previous request.  
```csharp
public static TetraPak.AspNet.ServerException FailedDependency(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_FailedDependency(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_FailedDependency(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_Forbidden(string__System_Exception_)'></a>
## ServerException.Forbidden(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect that  
the actor does not have access to the requested resource(s).  
```csharp
public static TetraPak.AspNet.ServerException Forbidden(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_Forbidden(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_Forbidden(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_Gone(string__System_Exception_)'></a>
## ServerException.Gone(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that access to the target resource is no longer  
available at the origin server and that this condition is likely to be permanent.  




  
If you don't know whether this condition is temporary or permanent,  
a 404 status code should be used instead.  
```csharp
public static TetraPak.AspNet.ServerException Gone(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_Gone(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_Gone(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_InternalServerError(string__System_Exception_)'></a>
## ServerException.InternalServerError(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server encountered an unexpected condition  
that prevented it from fulfilling the request.  




  
This error response is a generic "catch-all" response. Usually, this indicates the server cannot  
find a better 5xx error code to response. Sometimes, server administrators log error responses like  
the 500 status code with more details about the request to prevent the error from happening  
again in the future.  
```csharp
public static TetraPak.AspNet.ServerException InternalServerError(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_InternalServerError(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_InternalServerError(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_LengthRequired(string__System_Exception_)'></a>
## ServerException.LengthRequired(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server refuses to accept the request  
without a defined `Content-Length` header.  




  
If you don't know whether this condition is temporary or permanent,  
a 404 status code should be used instead.  
```csharp
public static TetraPak.AspNet.ServerException LengthRequired(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_LengthRequired(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_LengthRequired(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_Locked(string__System_Exception_)'></a>
## ServerException.Locked(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the resource that is being accessed is locked.  
```csharp
public static TetraPak.AspNet.ServerException Locked(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_Locked(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_Locked(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_MethodNotAllowed(System_Collections_Generic_IEnumerable_string__string__System_Exception_)'></a>
## ServerException.MethodNotAllowed(IEnumerable&lt;string&gt;, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect a situation where  
the request method is known by the server but is not supported by the target resource.  
```csharp
public static TetraPak.AspNet.ServerException MethodNotAllowed(System.Collections.Generic.IEnumerable<string> allowedMethods, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_MethodNotAllowed(System_Collections_Generic_IEnumerable_string__string__System_Exception_)_allowedMethods'></a>
`allowedMethods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A list of allowed HTTP methods.  
  
<a name='TetraPak_AspNet_ServerException_MethodNotAllowed(System_Collections_Generic_IEnumerable_string__string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_MethodNotAllowed(System_Collections_Generic_IEnumerable_string__string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_MisdirectedRequest(string__System_Exception_)'></a>
## ServerException.MisdirectedRequest(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server is not able to produce a response.  
This can be sent by a server that is not configured to produce responses for the combination of scheme  
and authority that are included in the request URI.  
```csharp
public static TetraPak.AspNet.ServerException MisdirectedRequest(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_MisdirectedRequest(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_MisdirectedRequest(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_NotAcceptable(string__System_Exception_)'></a>
## ServerException.NotAcceptable(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect a situation where  
the server cannot or is unwilling to produce a response matching the request's list of acceptable  
values, as defined in the content negotiation headers (Accept, Accept-Encoding, Accept-Language).  
```csharp
public static TetraPak.AspNet.ServerException NotAcceptable(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_NotAcceptable(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_NotAcceptable(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_NotFound(string__System_Exception_)'></a>
## ServerException.NotFound(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect a situation where resource(s) was not found.  
```csharp
public static TetraPak.AspNet.ServerException NotFound(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_NotFound(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_NotFound(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_DateTime_string__System_Exception_)'></a>
## ServerException.NotImplemented(DateTime, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server does not support the functionality  
required to fulfill the request.  




  
This status can also send a `Retry-After` header, telling the requester when to check back to see if the  
functionality is supported by then.  




`501` is the appropriate response when the server does not recognize the request method and is  
incapable of supporting it for any resource. The only methods that servers are required to support  
(and therefore that must not return `501`) are `GET` and `HEAD`.  


  
If the server does recognize the method, but intentionally does not support it,  
the appropriate response is `405 Method Not Allowed`.  
```csharp
public static TetraPak.AspNet.ServerException NotImplemented(System.DateTime retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_DateTime_string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
Specifies a date/time to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_DateTime_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_DateTime_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [NotImplemented(Nullable&lt;TimeSpan&gt;, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_NotImplemented(System_Nullable_System_TimeSpan__string__System_Exception_) 'TetraPak.AspNet.ServerException.NotImplemented(System.Nullable&lt;System.TimeSpan&gt;, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_Nullable_System_TimeSpan__string__System_Exception_)'></a>
## ServerException.NotImplemented(Nullable&lt;TimeSpan&gt;, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server does not support the functionality  
required to fulfill the request.  




  
This status can also send a `Retry-After` header, telling the requester when to check back to see if the  
functionality is supported by then.  




`501` is the appropriate response when the server does not recognize the request method and is  
incapable of supporting it for any resource. The only methods that servers are required to support  
(and therefore that must not return `501`) are `GET` and `HEAD`.  


  
If the server does recognize the method, but intentionally does not support it,  
the appropriate response is `405 Method Not Allowed`.  
```csharp
public static TetraPak.AspNet.ServerException NotImplemented(System.Nullable<System.TimeSpan> retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_Nullable_System_TimeSpan__string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional; pass `null` if not needed)<br/>  
Specifies a timespan to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_Nullable_System_TimeSpan__string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_NotImplemented(System_Nullable_System_TimeSpan__string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [NotImplemented(DateTime, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_NotImplemented(System_DateTime_string__System_Exception_) 'TetraPak.AspNet.ServerException.NotImplemented(System.DateTime, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_PreconditionFailed(string__System_Exception_)'></a>
## ServerException.PreconditionFailed(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate hat access to the target resource has been denied.  
This happens with conditional requests on methods other than `GET` or `HEAD` when the condition  
defined by the `If-Unmodified-Since` or `If-None-Match headers` is not fulfilled.  
In that case, the request, usually an upload or a modification of a resource,  
cannot be made and this error response is sent back.   
```csharp
public static TetraPak.AspNet.ServerException PreconditionFailed(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_PreconditionFailed(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_PreconditionFailed(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_PreconditionRequired(string__System_Exception_)'></a>
## ServerException.PreconditionRequired(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server requires the request to be conditional.  




  
Typically, this means that a required precondition header, such as `If-Match`, is missing.  




  
When a precondition header is not matching the server side state,  
the response should be `412 Precondition Failed`.   
```csharp
public static TetraPak.AspNet.ServerException PreconditionRequired(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_PreconditionRequired(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_PreconditionRequired(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_ProxyAuthenticationRequired(string__System_Exception_)'></a>
## ServerException.ProxyAuthenticationRequired(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect a situation where  
the server cannot or is unwilling to produce a response matching the request's list of acceptable  
values, as defined in the content negotiation headers (Accept, Accept-Encoding, Accept-Language).  
```csharp
public static TetraPak.AspNet.ServerException ProxyAuthenticationRequired(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_ProxyAuthenticationRequired(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_ProxyAuthenticationRequired(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_RequestedRangeNotSatisfiable(ulong_string__System_Exception_)'></a>
## ServerException.RequestedRangeNotSatisfiable(ulong, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server cannot serve the requested ranges. The  
most likely reason is that the document doesn't contain such ranges, or that the Range header value,  
though syntactically correct, doesn't make sense.  




  
The `416` response message contains a `Content-Range` indicating an unsatisfied range  
(that is a `'*'`) followed by a `'/'` and the current length of the resource.  
E.g. `Content-Range: bytes */12777`



  
Faced with this error, browsers usually either abort the operation  
(for example, a download will be considered as non-resumable) or ask for the whole document again.  
```csharp
public static TetraPak.AspNet.ServerException RequestedRangeNotSatisfiable(ulong unsatisfiedRange, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_RequestedRangeNotSatisfiable(ulong_string__System_Exception_)_unsatisfiedRange'></a>
`unsatisfiedRange` [System.UInt64](https://docs.microsoft.com/en-us/dotnet/api/System.UInt64 'System.UInt64')  
The unsatisfied length.  
  
<a name='TetraPak_AspNet_ServerException_RequestedRangeNotSatisfiable(ulong_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestedRangeNotSatisfiable(ulong_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(bool_string__System_Exception_)'></a>
## ServerException.RequestEntityTooLarge(bool, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the request entity is larger than limits  
defined by server; the server might close the connection or return a `Retry-After` header field.  
```csharp
public static TetraPak.AspNet.ServerException RequestEntityTooLarge(bool closeConnection, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(bool_string__System_Exception_)_closeConnection'></a>
`closeConnection` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Specifies whether to also send back a `Connection: close` header to client.  
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(bool_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(bool_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [RequestEntityTooLarge(TimeSpan, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_TimeSpan_string__System_Exception_) 'TetraPak.AspNet.ServerException.RequestEntityTooLarge(System.TimeSpan, string?, System.Exception?)')
- [RequestEntityTooLarge(DateTime, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_DateTime_string__System_Exception_) 'TetraPak.AspNet.ServerException.RequestEntityTooLarge(System.DateTime, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_DateTime_string__System_Exception_)'></a>
## ServerException.RequestEntityTooLarge(DateTime, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the request entity is larger than limits  
defined by server; the server might close the connection or return a `Retry-After` header field.  
```csharp
public static TetraPak.AspNet.ServerException RequestEntityTooLarge(System.DateTime retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_DateTime_string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
Specifies a date/time to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_DateTime_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_DateTime_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [RequestEntityTooLarge(bool, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_RequestEntityTooLarge(bool_string__System_Exception_) 'TetraPak.AspNet.ServerException.RequestEntityTooLarge(bool, string?, System.Exception?)')
- [RequestEntityTooLarge(TimeSpan, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_TimeSpan_string__System_Exception_) 'TetraPak.AspNet.ServerException.RequestEntityTooLarge(System.TimeSpan, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_TimeSpan_string__System_Exception_)'></a>
## ServerException.RequestEntityTooLarge(TimeSpan, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the request entity is larger than limits  
defined by server; the server might close the connection or return a `Retry-After` header field.  
```csharp
public static TetraPak.AspNet.ServerException RequestEntityTooLarge(System.TimeSpan retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_TimeSpan_string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
Specifies a timespan to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_TimeSpan_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_TimeSpan_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [RequestEntityTooLarge(bool, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_RequestEntityTooLarge(bool_string__System_Exception_) 'TetraPak.AspNet.ServerException.RequestEntityTooLarge(bool, string?, System.Exception?)')
- [RequestEntityTooLarge(DateTime, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_RequestEntityTooLarge(System_DateTime_string__System_Exception_) 'TetraPak.AspNet.ServerException.RequestEntityTooLarge(System.DateTime, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_RequestHeaderFieldsTooLarge(System_Collections_Generic_IEnumerable_string___string__System_Exception_)'></a>
## ServerException.RequestHeaderFieldsTooLarge(IEnumerable&lt;string&gt;?, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate the user has sent too many requests in a given amount  
of time ("rate limiting").  




  
A `Retry-After` header might be included to this response indicating how long to wait before  
making a new request.  
```csharp
public static TetraPak.AspNet.ServerException RequestHeaderFieldsTooLarge(System.Collections.Generic.IEnumerable<string>? tooLongHeaders, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_RequestHeaderFieldsTooLarge(System_Collections_Generic_IEnumerable_string___string__System_Exception_)_tooLongHeaders'></a>
`tooLongHeaders` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
(optional; pass `null` if not needed)<br/>  
Specifies one or more headers causing the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestHeaderFieldsTooLarge(System_Collections_Generic_IEnumerable_string___string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestHeaderFieldsTooLarge(System_Collections_Generic_IEnumerable_string___string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [TooManyRequests(DateTime, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_TooManyRequests(System_DateTime_string__System_Exception_) 'TetraPak.AspNet.ServerException.TooManyRequests(System.DateTime, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_RequestTimeout(string__System_Exception_)'></a>
## ServerException.RequestTimeout(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect a situation where the server would like to shut down  
this unused connection. It is sent on an idle connection by some servers,  
even without any previous request by the client.  
```csharp
public static TetraPak.AspNet.ServerException RequestTimeout(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_RequestTimeout(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestTimeout(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_RequestUriTooLong(string__System_Exception_)'></a>
## ServerException.RequestUriTooLong(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the URI requested by the client is longer than  
the server is willing to interpret.  




  
There are a few rare conditions when this might occur:  


<list type="bullet">  
  
on>  
  when a client has improperly converted a POST request to a GET request with long query information,  
  </description>  
  
  
on>  
  when the client has descended into a loop of redirection (for example, a redirected URI prefix that points to a suffix of itself),  
  </description>  
  
  
on>  
  or when the server is under attack by a client attempting to exploit potential security holes.  
  </description>  
  
```csharp
public static TetraPak.AspNet.ServerException RequestUriTooLong(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_RequestUriTooLong(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_RequestUriTooLong(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_DateTime_string__System_Exception_)'></a>
## ServerException.ServiceUnavailable(DateTime, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server does not support the functionality  
required to fulfill the request.  




  
This status can also send a `Retry-After` header, telling the requester when to check back to see if the  
functionality is supported by then.  




`501` is the appropriate response when the server does not recognize the request method and is  
incapable of supporting it for any resource. The only methods that servers are required to support  
(and therefore that must not return `501`) are `GET` and `HEAD`.  


  
If the server does recognize the method, but intentionally does not support it,  
the appropriate response is `405 Method Not Allowed`.  
```csharp
public static TetraPak.AspNet.ServerException ServiceUnavailable(System.DateTime retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_DateTime_string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
Specifies a date/time to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_DateTime_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_DateTime_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [NotImplemented(Nullable&lt;TimeSpan&gt;, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_NotImplemented(System_Nullable_System_TimeSpan__string__System_Exception_) 'TetraPak.AspNet.ServerException.NotImplemented(System.Nullable&lt;System.TimeSpan&gt;, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_Nullable_System_TimeSpan__string__System_Exception_)'></a>
## ServerException.ServiceUnavailable(Nullable&lt;TimeSpan&gt;, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server does not support the functionality  
required to fulfill the request.  




  
This status can also send a `Retry-After` header, telling the requester when to check back to see if the  
functionality is supported by then.  




`501` is the appropriate response when the server does not recognize the request method and is  
incapable of supporting it for any resource. The only methods that servers are required to support  
(and therefore that must not return `501`) are `GET` and `HEAD`.  


  
If the server does recognize the method, but intentionally does not support it,  
the appropriate response is `405 Method Not Allowed`.  
```csharp
public static TetraPak.AspNet.ServerException ServiceUnavailable(System.Nullable<System.TimeSpan> retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_Nullable_System_TimeSpan__string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional; pass `null` if not needed)<br/>  
Specifies a timespan to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_Nullable_System_TimeSpan__string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_ServiceUnavailable(System_Nullable_System_TimeSpan__string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [ServiceUnavailable(DateTime, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_ServiceUnavailable(System_DateTime_string__System_Exception_) 'TetraPak.AspNet.ServerException.ServiceUnavailable(System.DateTime, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_DateTime_string__System_Exception_)'></a>
## ServerException.TooManyRequests(DateTime, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate the user has sent too many requests in a given amount  
of time ("rate limiting").  




  
A `Retry-After` header might be included to this response indicating how long to wait before  
making a new request.  
```csharp
public static TetraPak.AspNet.ServerException TooManyRequests(System.DateTime retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_DateTime_string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
Specifies a date/time to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_DateTime_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_DateTime_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [TooManyRequests(Nullable&lt;TimeSpan&gt;, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_TooManyRequests(System_Nullable_System_TimeSpan__string__System_Exception_) 'TetraPak.AspNet.ServerException.TooManyRequests(System.Nullable&lt;System.TimeSpan&gt;, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_Nullable_System_TimeSpan__string__System_Exception_)'></a>
## ServerException.TooManyRequests(Nullable&lt;TimeSpan&gt;, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate the user has sent too many requests in a given amount  
of time ("rate limiting").  




  
A `Retry-After` header might be included to this response indicating how long to wait before  
making a new request.  
```csharp
public static TetraPak.AspNet.ServerException TooManyRequests(System.Nullable<System.TimeSpan> retryAfter, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_Nullable_System_TimeSpan__string__System_Exception_)_retryAfter'></a>
`retryAfter` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
(optional; pass `null` if not needed)<br/>  
Specifies a timespan to be sent back with the `Retry-After` header.  
  
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_Nullable_System_TimeSpan__string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_TooManyRequests(System_Nullable_System_TimeSpan__string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [TooManyRequests(DateTime, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_TooManyRequests(System_DateTime_string__System_Exception_) 'TetraPak.AspNet.ServerException.TooManyRequests(System.DateTime, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_ToString()'></a>
## ServerException.ToString() Method
Creates and returns a string representation of the current exception.
```csharp
public override string ToString();
```
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string representation of the current exception.
  
<a name='TetraPak_AspNet_ServerException_Unauthorized(string__System_Exception_)'></a>
## ServerException.Unauthorized(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to reflect an unauthorized request.  
```csharp
public static TetraPak.AspNet.ServerException Unauthorized(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_Unauthorized(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_Unauthorized(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_UnavailableForLegalReasons(string_bool_string__System_Exception_)'></a>
## ServerException.UnavailableForLegalReasons(string, bool, string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate the user has sent too many requests in a given amount  
of time ("rate limiting").  




  
A `Retry-After` header might be included to this response indicating how long to wait before  
making a new request.  
```csharp
public static TetraPak.AspNet.ServerException UnavailableForLegalReasons(string authorityUrl, bool isBlockedBy, string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_UnavailableForLegalReasons(string_bool_string__System_Exception_)_authorityUrl'></a>
`authorityUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A URL to an authority to be referenced.  
  
<a name='TetraPak_AspNet_ServerException_UnavailableForLegalReasons(string_bool_string__System_Exception_)_isBlockedBy'></a>
`isBlockedBy` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Specifies whether the authority is blocking the request. Pass `true` if the "`ref="blocked-by"`"  
flag is to be added to the [authorityUrl](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_UnavailableForLegalReasons(string_bool_string__System_Exception_)_authorityUrl 'TetraPak.AspNet.ServerException.UnavailableForLegalReasons(string, bool, string?, System.Exception?).authorityUrl').   
  
<a name='TetraPak_AspNet_ServerException_UnavailableForLegalReasons(string_bool_string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_UnavailableForLegalReasons(string_bool_string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
#### See Also
- [TooManyRequests(DateTime, string?, Exception?)](TetraPak_AspNet_ServerException.md#TetraPak_AspNet_ServerException_TooManyRequests(System_DateTime_string__System_Exception_) 'TetraPak.AspNet.ServerException.TooManyRequests(System.DateTime, string?, System.Exception?)')
  
<a name='TetraPak_AspNet_ServerException_UnprocessableEntity(string__System_Exception_)'></a>
## ServerException.UnprocessableEntity(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server understands the content type of the  
request entity, and the syntax of the request entity is correct,  
but it was unable to process the contained instructions.   
```csharp
public static TetraPak.AspNet.ServerException UnprocessableEntity(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_UnprocessableEntity(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_UnprocessableEntity(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
<a name='TetraPak_AspNet_ServerException_UnsupportedMediaType(string__System_Exception_)'></a>
## ServerException.UnsupportedMediaType(string?, Exception?) Method
Produces a [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') to indicate that the server refuses to accept the request because  
the payload format is in an unsupported format.  




  
The format problem might be due to the request's indicated `Content-Type` or `Content-Encoding`,  
or as a result of inspecting the data directly.   
```csharp
public static TetraPak.AspNet.ServerException UnsupportedMediaType(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerException_UnsupportedMediaType(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Describes the problem.  
  
<a name='TetraPak_AspNet_ServerException_UnsupportedMediaType(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
#### Returns
[ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException')  
A [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException').  
  
