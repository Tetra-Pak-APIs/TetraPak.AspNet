#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Diagnostics](TetraPak_AspNet_Diagnostics.md 'TetraPak.AspNet.Diagnostics').[ServiceDiagnostics](TetraPak_AspNet_Diagnostics_ServiceDiagnostics.md 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics')
## ServiceDiagnostics.GetValues(string) Method
Returns all values, optionally filtered with a [prefix](TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetValues(string).md#TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetValues(string)_prefix 'TetraPak.AspNet.Diagnostics.ServiceDiagnostics.GetValues(string).prefix') pattern.  
```csharp
public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,object>> GetValues(string prefix=null);
```
#### Parameters
<a name='TetraPak_AspNet_Diagnostics_ServiceDiagnostics_GetValues(string)_prefix'></a>
`prefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional)<br />  
A prefix pattern for filtering result.  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of [System.Collections.Generic.KeyValuePair&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2').  
