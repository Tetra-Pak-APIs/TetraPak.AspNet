#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
## AmbientData.GetMessageId(bool) Method
Retrieves a request message id if available.   
```csharp
public string GetMessageId(bool enforce=false);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_GetMessageId(bool)_enforce'></a>
`enforce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br />  
When set a message id will be generated and injected into the request/response context.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if a message id was available (or enforced); otherwise `null`.  

Implements [GetMessageId(bool)](TetraPak_AspNet_IMessageIdProvider_GetMessageId(bool).md 'TetraPak.AspNet.IMessageIdProvider.GetMessageId(bool)')  
