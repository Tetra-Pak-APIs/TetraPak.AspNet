#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ApiChunkedMetadata Class
Derived from [ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata') to add "chunked" meta data attributes.  
```csharp
public class ApiChunkedMetadata : TetraPak.AspNet.ApiMetadata
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ApiMetadata](TetraPak_AspNet_ApiMetadata.md 'TetraPak.AspNet.ApiMetadata') &#129106; ApiChunkedMetadata  
### Constructors
<a name='TetraPak_AspNet_ApiChunkedMetadata_ApiChunkedMetadata(TetraPak_ReadChunk_int)'></a>
## ApiChunkedMetadata.ApiChunkedMetadata(ReadChunk, int) Constructor
Initializes the [ApiChunkedMetadata](TetraPak_AspNet_ApiChunkedMetadata.md 'TetraPak.AspNet.ApiChunkedMetadata') object.  
```csharp
public ApiChunkedMetadata(TetraPak.ReadChunk chunk, int total=-1);
```
#### Parameters
<a name='TetraPak_AspNet_ApiChunkedMetadata_ApiChunkedMetadata(TetraPak_ReadChunk_int)_chunk'></a>
`chunk` [TetraPak.ReadChunk](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.ReadChunk 'TetraPak.ReadChunk')  
Initializes the [Count](TetraPak_AspNet_ApiChunkedMetadata.md#TetraPak_AspNet_ApiChunkedMetadata_Count 'TetraPak.AspNet.ApiChunkedMetadata.Count') and [Skip](TetraPak_AspNet_ApiChunkedMetadata.md#TetraPak_AspNet_ApiChunkedMetadata_Skip 'TetraPak.AspNet.ApiChunkedMetadata.Skip') values.  
  
<a name='TetraPak_AspNet_ApiChunkedMetadata_ApiChunkedMetadata(TetraPak_ReadChunk_int)_total'></a>
`total` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Initializes the [Total](TetraPak_AspNet_ApiMetadata.md#TetraPak_AspNet_ApiMetadata_Total 'TetraPak.AspNet.ApiMetadata.Total') value.  
  
  
### Properties
<a name='TetraPak_AspNet_ApiChunkedMetadata_Count'></a>
## ApiChunkedMetadata.Count Property
The number of items in the chunk.   
```csharp
public int Count { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
<a name='TetraPak_AspNet_ApiChunkedMetadata_Skip'></a>
## ApiChunkedMetadata.Skip Property
The number of items skipped from the total to produce the chunk  
```csharp
public int Skip { get; set; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
  
