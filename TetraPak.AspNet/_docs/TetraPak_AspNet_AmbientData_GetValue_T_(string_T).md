#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet').[AmbientData](TetraPak_AspNet_AmbientData.md 'TetraPak.AspNet.AmbientData')
## AmbientData.GetValue&lt;T&gt;(string, T) Method
Gets an ambient value of a specified type.  
```csharp
public T GetValue<T>(string key, T useDefault=default(T));
```
#### Type parameters
<a name='TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_T'></a>
`T`  
The type of value being requested.  
  
#### Parameters
<a name='TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Identifies the value.  
  
<a name='TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_useDefault'></a>
`useDefault` [T](TetraPak_AspNet_AmbientData_GetValue_T_(string_T).md#TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_T 'TetraPak.AspNet.AmbientData.GetValue&lt;T&gt;(string, T).T')  
(optional)<br />  
A default value to be returned if the requested ambient value is not supported.    
  
#### Returns
[T](TetraPak_AspNet_AmbientData_GetValue_T_(string_T).md#TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_T 'TetraPak.AspNet.AmbientData.GetValue&lt;T&gt;(string, T).T')  
The requested value if present; otherwise [useDefault](TetraPak_AspNet_AmbientData_GetValue_T_(string_T).md#TetraPak_AspNet_AmbientData_GetValue_T_(string_T)_useDefault 'TetraPak.AspNet.AmbientData.GetValue&lt;T&gt;(string, T).useDefault') when specified,  
otherwise `default()`.  
