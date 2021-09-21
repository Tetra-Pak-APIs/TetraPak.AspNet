#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## QueryParametersHelper Class
```csharp
public static class QueryParametersHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; QueryParametersHelper  
### Methods
<a name='TetraPak_AspNet_QueryParametersHelper_ToUrlQueryParameters(System_Collections_Generic_IDictionary_string_string__bool)'></a>
## QueryParametersHelper.ToUrlQueryParameters(IDictionary&lt;string,string&gt;, bool) Method
Builds a URL formed query parameters string from a dictionary key-value collection.   
```csharp
public static string ToUrlQueryParameters(this System.Collections.Generic.IDictionary<string,string> self, bool qualify=false);
```
#### Parameters
<a name='TetraPak_AspNet_QueryParametersHelper_ToUrlQueryParameters(System_Collections_Generic_IDictionary_string_string__bool)_self'></a>
`self` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
A dictionary containing the key-value pairs.  
  
<a name='TetraPak_AspNet_QueryParametersHelper_ToUrlQueryParameters(System_Collections_Generic_IDictionary_string_string__bool)_qualify'></a>
`qualify` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`false`)<br/>  
Specifies whether to prefixing the query parameters [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') with a '?' qualifier.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A URL formed query parameters string.  
  
