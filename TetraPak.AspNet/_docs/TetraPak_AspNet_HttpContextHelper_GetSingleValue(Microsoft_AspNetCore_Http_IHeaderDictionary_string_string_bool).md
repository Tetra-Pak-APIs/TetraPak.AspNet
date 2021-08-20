#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[HttpContextHelper](TetraPak_AspNet_HttpContextHelper.md 'TetraPak.AspNet.HttpContextHelper')
## HttpContextHelper.GetSingleValue(IHeaderDictionary, string, string, bool) Method
Gets (and, optionally, sets) a single header value.  
```csharp
public static string GetSingleValue(this Microsoft.AspNetCore.Http.IHeaderDictionary dictionary, string key, string useDefault, bool setDefault=false);
```
#### Parameters
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_dictionary'></a>
`dictionary` [Microsoft.AspNetCore.Http.IHeaderDictionary](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.IHeaderDictionary 'Microsoft.AspNetCore.Http.IHeaderDictionary')  
The header dictionary to get (set) value from.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the header value.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_useDefault'></a>
`useDefault` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br />  
A default value to be used if one cannot be found in the header dictionary.  
  
<a name='TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_setDefault'></a>
`setDefault` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`); only applies if [useDefault](TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool).md#TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_useDefault 'TetraPak.AspNet.HttpContextHelper.GetSingleValue(Microsoft.AspNetCore.Http.IHeaderDictionary, string, string, bool).useDefault') is assigned)<br />  
When set, the [useDefault](TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool).md#TetraPak_AspNet_HttpContextHelper_GetSingleValue(Microsoft_AspNetCore_Http_IHeaderDictionary_string_string_bool)_useDefault 'TetraPak.AspNet.HttpContextHelper.GetSingleValue(Microsoft.AspNetCore.Http.IHeaderDictionary, string, string, bool).useDefault') value will automatically be added to the header dictionary,  
affecting the request.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A (single) [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value.  
