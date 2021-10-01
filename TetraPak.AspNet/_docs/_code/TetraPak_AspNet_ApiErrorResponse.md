#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiErrorResponse Class
Represents a standard Tetra Pak API error response (body).   
```csharp
public class ApiErrorResponse : TetraPak.DynamicEntities.DynamicEntity
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.DynamicEntities.DynamicEntity](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicEntity 'TetraPak.DynamicEntities.DynamicEntity') &#129106; ApiErrorResponse  
### Constructors
<a name='TetraPak_AspNet_ApiErrorResponse_ApiErrorResponse(string_object_string)'></a>
## ApiErrorResponse.ApiErrorResponse(string, object, string) Constructor
Initializes the [ApiErrorResponse](TetraPak_AspNet_ApiErrorResponse.md 'TetraPak.AspNet.ApiErrorResponse').  
```csharp
public ApiErrorResponse(string title, object description, string messageId);
```
#### Parameters
<a name='TetraPak_AspNet_ApiErrorResponse_ApiErrorResponse(string_object_string)_title'></a>
`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the [Title](TetraPak_AspNet_ApiErrorResponse.md#TetraPak_AspNet_ApiErrorResponse_Title 'TetraPak.AspNet.ApiErrorResponse.Title') property.  
  
<a name='TetraPak_AspNet_ApiErrorResponse_ApiErrorResponse(string_object_string)_description'></a>
`description` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Initializes the [Description](TetraPak_AspNet_ApiErrorResponse.md#TetraPak_AspNet_ApiErrorResponse_Description 'TetraPak.AspNet.ApiErrorResponse.Description') property.  
  
<a name='TetraPak_AspNet_ApiErrorResponse_ApiErrorResponse(string_object_string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the [MessageId](TetraPak_AspNet_ApiErrorResponse.md#TetraPak_AspNet_ApiErrorResponse_MessageId 'TetraPak.AspNet.ApiErrorResponse.MessageId') property.  
  
  
<a name='TetraPak_AspNet_ApiErrorResponse_ApiErrorResponse(string_string)'></a>
## ApiErrorResponse.ApiErrorResponse(string, string) Constructor
Initializes the [ApiErrorResponse](TetraPak_AspNet_ApiErrorResponse.md 'TetraPak.AspNet.ApiErrorResponse').  
```csharp
public ApiErrorResponse(string title, string messageId);
```
#### Parameters
<a name='TetraPak_AspNet_ApiErrorResponse_ApiErrorResponse(string_string)_title'></a>
`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the [Title](TetraPak_AspNet_ApiErrorResponse.md#TetraPak_AspNet_ApiErrorResponse_Title 'TetraPak.AspNet.ApiErrorResponse.Title') property.  
  
<a name='TetraPak_AspNet_ApiErrorResponse_ApiErrorResponse(string_string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the [MessageId](TetraPak_AspNet_ApiErrorResponse.md#TetraPak_AspNet_ApiErrorResponse_MessageId 'TetraPak.AspNet.ApiErrorResponse.MessageId') property.  
  
  
### Properties
<a name='TetraPak_AspNet_ApiErrorResponse_Description'></a>
## ApiErrorResponse.Description Property
Gets the error response description.  
```csharp
public object Description { get; set; }
```
#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')
  
<a name='TetraPak_AspNet_ApiErrorResponse_MessageId'></a>
## ApiErrorResponse.MessageId Property
Gets any message id associated with the failed request.  
```csharp
public string MessageId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ApiErrorResponse_Status'></a>
## ApiErrorResponse.Status Property
Gets the error status element.  
```csharp
public string Status { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ApiErrorResponse_StatusCode'></a>
## ApiErrorResponse.StatusCode Property
Gets the response HTTP status code as [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32').  
```csharp
public int StatusCode { get; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
<a name='TetraPak_AspNet_ApiErrorResponse_Title'></a>
## ApiErrorResponse.Title Property
Gets the error response title element.  
```csharp
public string Title { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ApiErrorResponse_Type'></a>
## ApiErrorResponse.Type Property
Gets the standardized error type.  
```csharp
public string Type { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
