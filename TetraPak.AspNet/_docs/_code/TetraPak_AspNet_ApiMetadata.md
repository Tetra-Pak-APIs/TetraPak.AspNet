#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiMetadata Class
Used as the meta data block in [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;').   
```csharp
public class ApiMetadata
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiMetadata  

Derived  
&#8627; [ApiChunkedMetadata](TetraPak_AspNet_ApiChunkedMetadata.md 'TetraPak.AspNet.ApiChunkedMetadata')  
### Constructors
<a name='TetraPak_AspNet_ApiMetadata_ApiMetadata()'></a>
## ApiMetadata.ApiMetadata() Constructor
Initializes an empty [ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata') object.   
```csharp
public ApiMetadata();
```
  
<a name='TetraPak_AspNet_ApiMetadata_ApiMetadata(int)'></a>
## ApiMetadata.ApiMetadata(int) Constructor
Initializes a [ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata') object and sets the [Total](TetraPak_AspNet_ApiMetadata.md#TetraPak_AspNet_ApiMetadata_Total 'TetraPak.AspNet.ApiMetadata.Total') value.  
```csharp
public ApiMetadata(int total);
```
#### Parameters
<a name='TetraPak_AspNet_ApiMetadata_ApiMetadata(int)_total'></a>
`total` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
  
  
### Properties
<a name='TetraPak_AspNet_ApiMetadata_Format'></a>
## ApiMetadata.Format Property
Gets a data response format version.    
```csharp
public string Format { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ApiMetadata_MessageId'></a>
## ApiMetadata.MessageId Property
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
```csharp
public string MessageId { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_ApiMetadata_Total'></a>
## ApiMetadata.Total Property
The totally number of items available to query  
(actual data returned is often only a part of available data).   
```csharp
public int Total { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
### Methods
<a name='TetraPak_AspNet_ApiMetadata_WithMessageId(string)'></a>
## ApiMetadata.WithMessageId(string) Method
Fluent API to assign the [MessageId](TetraPak_AspNet_ApiMetadata.md#TetraPak_AspNet_ApiMetadata_MessageId 'TetraPak.AspNet.ApiMetadata.MessageId') property.   
```csharp
public TetraPak.AspNet.ApiMetadata WithMessageId(string messageId);
```
#### Parameters
<a name='TetraPak_AspNet_ApiMetadata_WithMessageId(string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The message id value.  
  
#### Returns
[ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata')  
`this` object.  
            
  
