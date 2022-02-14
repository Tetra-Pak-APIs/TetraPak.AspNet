#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiErrorResponseException Class
Reflects a [ApiErrorResponse](TetraPak_AspNet_ApiErrorResponse.md 'TetraPak.AspNet.ApiErrorResponse') as an exception.  
```csharp
public class ApiErrorResponseException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; ApiErrorResponseException  
### Properties
<a name='TetraPak_AspNet_ApiErrorResponseException_ErrorResponse'></a>
## ApiErrorResponseException.ErrorResponse Property
The error response containing the [ApiErrorResponse](TetraPak_AspNet_ApiErrorResponse.md 'TetraPak.AspNet.ApiErrorResponse').  
```csharp
private TetraPak.AspNet.ApiErrorResponse ErrorResponse { get; }
```
#### Property Value
[ApiErrorResponse](TetraPak_AspNet_ApiErrorResponse.md 'TetraPak.AspNet.ApiErrorResponse')
  
<a name='TetraPak_AspNet_ApiErrorResponseException_MessageId'></a>
## ApiErrorResponseException.MessageId Property
Gets any message id associated with the failed request.  
```csharp
public string? MessageId { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ApiErrorResponseException_Status'></a>
## ApiErrorResponseException.Status Property
Gets the error status element.  
```csharp
public string? Status { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ApiErrorResponseException_StatusCode'></a>
## ApiErrorResponseException.StatusCode Property
Gets the response HTTP status code as [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32').  
```csharp
public int StatusCode { get; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
<a name='TetraPak_AspNet_ApiErrorResponseException_Title'></a>
## ApiErrorResponseException.Title Property
Gets the error response title element.  
```csharp
public string Title { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
