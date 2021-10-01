#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiDataResponse&lt;T&gt; Class
Represents a standardized Tetra Pak API data response.  
```csharp
public class ApiDataResponse<T>
```
#### Type parameters
<a name='TetraPak_AspNet_ApiDataResponse_T__T'></a>
`T`  
The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') of data included in response [Data](TetraPak_AspNet_ApiDataResponse_T_.md#TetraPak_AspNet_ApiDataResponse_T__Data 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;.Data') block.  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApiDataResponse&lt;T&gt;  
### Constructors
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(System_Collections_Generic_IEnumerable_T__int_int_string)'></a>
## ApiDataResponse&lt;T&gt;.ApiDataResponse(IEnumerable&lt;T&gt;, int, int, string) Constructor
Initializes the [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;').   
```csharp
public ApiDataResponse(System.Collections.Generic.IEnumerable<T> data, int skip=-1, int total=-1, string messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(System_Collections_Generic_IEnumerable_T__int_int_string)_data'></a>
`data` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](TetraPak_AspNet_ApiDataResponse_T_.md#TetraPak_AspNet_ApiDataResponse_T__T 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of items to be included in the response data block.  
  
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(System_Collections_Generic_IEnumerable_T__int_int_string)_skip'></a>
`skip` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
(optional)<br/>  
Initializes the meta data "count" value ([Count](TetraPak_AspNet_ApiChunkedMetadata.md#TetraPak_AspNet_ApiChunkedMetadata_Count 'TetraPak.AspNet.ApiChunkedMetadata.Count')).  
  
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(System_Collections_Generic_IEnumerable_T__int_int_string)_total'></a>
`total` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Initialises the meta data "total" value ([Total](TetraPak_AspNet_ApiMetadata.md#TetraPak_AspNet_ApiMetadata_Total 'TetraPak.AspNet.ApiMetadata.Total')).  
  
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(System_Collections_Generic_IEnumerable_T__int_int_string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
Initializes thw [messageId](https://docs.microsoft.com/en-us/dotnet/api/messageId 'messageId') property.  
  
  
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(TetraPak_EnumOutcome_T__int_string)'></a>
## ApiDataResponse&lt;T&gt;.ApiDataResponse(EnumOutcome&lt;T&gt;, int, string) Constructor
Initializes the [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;') object from an [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') object.   
```csharp
public ApiDataResponse(TetraPak.EnumOutcome<T> outcome, int totalCount=-1, string messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(TetraPak_EnumOutcome_T__int_string)_outcome'></a>
`outcome` [TetraPak.EnumOutcome&lt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')[T](TetraPak_AspNet_ApiDataResponse_T_.md#TetraPak_AspNet_ApiDataResponse_T__T 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.EnumOutcome-1 'TetraPak.EnumOutcome`1')  
The [TetraPak.Outcome&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.Outcome-1 'TetraPak.Outcome`1') object, carrying the data to be included in response.  
  
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(TetraPak_EnumOutcome_T__int_string)_totalCount'></a>
`totalCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
(optional)<br/>  
Initializes the [Total](TetraPak_AspNet_ApiMetadata.md#TetraPak_AspNet_ApiMetadata_Total 'TetraPak.AspNet.ApiMetadata.Total') value.   
  
<a name='TetraPak_AspNet_ApiDataResponse_T__ApiDataResponse(TetraPak_EnumOutcome_T__int_string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br/>  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
  
### Properties
<a name='TetraPak_AspNet_ApiDataResponse_T__Data'></a>
## ApiDataResponse&lt;T&gt;.Data Property
The response data block.   
```csharp
public System.Collections.Generic.IEnumerable<T> Data { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](TetraPak_AspNet_ApiDataResponse_T_.md#TetraPak_AspNet_ApiDataResponse_T__T 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
<a name='TetraPak_AspNet_ApiDataResponse_T__Meta'></a>
## ApiDataResponse&lt;T&gt;.Meta Property
The response meta data block.   
```csharp
public TetraPak.AspNet.ApiMetadata Meta { get; set; }
```
#### Property Value
[ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata')
  
### Methods
<a name='TetraPak_AspNet_ApiDataResponse_T__Empty(string)'></a>
## ApiDataResponse&lt;T&gt;.Empty(string) Method
Creates and returns an empty [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;') object.  
```csharp
public static TetraPak.AspNet.ApiDataResponse<T> Empty(string messageId=null);
```
#### Parameters
<a name='TetraPak_AspNet_ApiDataResponse_T__Empty(string)_messageId'></a>
`messageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A unique string value for tracking a request/response (mainly for diagnostics purposes).  
  
#### Returns
[TetraPak.AspNet.ApiDataResponse&lt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;')[T](TetraPak_AspNet_ApiDataResponse_T_.md#TetraPak_AspNet_ApiDataResponse_T__T 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;.T')[&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;')  
A [ApiDataResponse&lt;T&gt;](TetraPak_AspNet_ApiDataResponse_T_.md 'TetraPak.AspNet.ApiDataResponse&lt;T&gt;') object.  
  
