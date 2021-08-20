#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
## AmbientData.GetValue(string, object) Method
Gets an ambient value.  
```csharp
public object GetValue(string key, object useDefault=null);
```
#### Parameters
<a name='TetraPak_AspNet_AmbientData_GetValue(string_object)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value.  
  
<a name='TetraPak_AspNet_AmbientData_GetValue(string_object)_useDefault'></a>
`useDefault` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
(optional)<br />  
A default value to be returned if the requested ambient value is not supported.    
  
#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The requested value if present; otherwise [useDefault](TetraPak_AspNet_AmbientData_GetValue(string_object).md#TetraPak_AspNet_AmbientData_GetValue(string_object)_useDefault 'TetraPak.AspNet.AmbientData.GetValue(string, object).useDefault') when specified,  
otherwise `null`.  
