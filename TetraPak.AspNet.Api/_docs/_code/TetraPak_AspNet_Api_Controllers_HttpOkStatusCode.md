#### [TetraPak.AspNet.Api](index.md 'index')
### [TetraPak.AspNet.Api.Controllers](TetraPak_AspNet_Api_Controllers.md 'TetraPak.AspNet.Api.Controllers')
## HttpOkStatusCode Enum
Contains the values of successful status codes defined for HTTP.  
```csharp
public enum HttpOkStatusCode

```
#### Fields
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_Accepted'></a>
`Accepted` 202  
The request has been received but not yet acted upon. It is noncommittal,  
since there is no way in HTTP to later send an asynchronous response indicating  
the outcome of the request.  
It is intended for cases where another process or server handles the request, or for batch processing.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_AlreadyReported'></a>
`AlreadyReported` 208  
Used inside a <dav:propstat> response element to avoid repeatedly enumerating  
the internal members of multiple bindings to the same collection.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_Auto'></a>
`Auto` -1  
Indicates that the HTTP status code should be resolved automatically (see IHttpOkStatusResolver)   
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_Created'></a>
`Created` 201  
The request succeeded, and a new resource created as a result.  
This is typically the response sent after POST requests, or some PUT requests.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_IMUsed'></a>
`IMUsed` 226  
The server has fulfilled a GET request for the resource, and the response is a representation  
of the result of one or more instance-manipulations applied to the current instance.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_MultiStatus'></a>
`MultiStatus` 207  
Conveys information about multiple resources,  
for situations where multiple status codes might be appropriate.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_NoContent'></a>
`NoContent` 204  
There is no content to send for this request, but the headers may be useful.  
The user agent may update its cached headers for this resource with the new ones.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_NonAuthoritativeInformation'></a>
`NonAuthoritativeInformation` 203  
This response code means the returned metadata is not exactly the same as is available  
from the origin server, but is collected from a local or a third-party copy.  
This is mostly used for mirrors or backups of another resource.  
Except for that specific case, the 200 OK response is preferred to this status.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_OK'></a>
`OK` 200  
The request succeeded. The result meaning of "success" depends on the HTTP method:  
<list type="table">  
  
od</term>  
on>Description</description>  
>  
  
  
      GET  
    </term>  
on>  
      The resource has been fetched and transmitted in the message body.  
    </description>  
  
  
  
      HEAD  
    </term>  
on>  
      The representation headers are included in the response without any message body.  
    </description>  
  
  
  
      PUT, POST PATCH  
    </term>  
on>  
      The resource describing the result of the action is transmitted in the message body.  
    </description>  
  
  
  
      TRACE  
    </term>  
on>  
      The message body contains the request message as received by the server.  
    </description>  
  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_PartialContent'></a>
`PartialContent` 206  
This response code is used when the [System.Net.HttpRequestHeader.Range](https://docs.microsoft.com/en-us/dotnet/api/System.Net.HttpRequestHeader.Range 'System.Net.HttpRequestHeader.Range') header is sent from the client  
to request only part of a resource.  
  
<a name='TetraPak_AspNet_Api_Controllers_HttpOkStatusCode_ResetContent'></a>
`ResetContent` 205  
Tells the user agent to reset the document which sent this request.  
  
