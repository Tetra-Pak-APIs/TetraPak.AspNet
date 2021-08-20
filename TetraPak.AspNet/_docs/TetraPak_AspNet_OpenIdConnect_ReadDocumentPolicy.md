#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.OpenIdConnect](TetraPak_AspNet_OpenIdConnect.md 'TetraPak.AspNet.OpenIdConnect')
## ReadDocumentPolicy Enum
```csharp
public enum ReadDocumentPolicy

```
#### Fields
<a name='TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_All'></a>
`All` 7  
All fallback policies are supported.  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_Cached'></a>
`Cached` 2  
Fallback to cached document.  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_Configured'></a>
`Configured` 16  
Use configured fallback policy.  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_Default'></a>
`Default` 4  
Fallback to default document.  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_Master'></a>
`Master` 1  
Try reading from master source, such as a remote service.  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_None'></a>
`None` 0  
No fallback allowed; reading document will fail.  
  
