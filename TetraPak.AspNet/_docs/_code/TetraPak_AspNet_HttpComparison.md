#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpComparison Class
A string compatible (criteria) expression for use with HTTP requests.  
```csharp
public class HttpComparison : TetraPak.StringValueBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.StringValueBase](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.StringValueBase 'TetraPak.StringValueBase') &#129106; HttpComparison  
### Constructors
<a name='TetraPak_AspNet_HttpComparison_HttpComparison(string_)'></a>
## HttpComparison.HttpComparison(string?) Constructor
Initializes the [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison').   
```csharp
public HttpComparison(string? value);
```
#### Parameters
<a name='TetraPak_AspNet_HttpComparison_HttpComparison(string_)_value'></a>
`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A textual representation of a [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison') value.  
  
  
### Properties
<a name='TetraPak_AspNet_HttpComparison_Element'></a>
## HttpComparison.Element Property
Gets the element ([Headers](TetraPak_AspNet_HttpComparison_Elements.md#TetraPak_AspNet_HttpComparison_Elements_Headers 'TetraPak.AspNet.HttpComparison.Elements.Headers') or [Query](TetraPak_AspNet_HttpComparison_Elements.md#TetraPak_AspNet_HttpComparison_Elements_Query 'TetraPak.AspNet.HttpComparison.Elements.Query'))  
references in the operation.   
```csharp
public TetraPak.AspNet.HttpRequestElement Element { get; set; }
```
#### Property Value
[HttpRequestElement](TetraPak_AspNet_HttpRequestElement.md 'TetraPak.AspNet.HttpRequestElement')
  
<a name='TetraPak_AspNet_HttpComparison_Key'></a>
## HttpComparison.Key Property
Identifies an item from the specified [Element](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Element 'TetraPak.AspNet.HttpComparison.Element'),  
to be used for comparison with [Value](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Value 'TetraPak.AspNet.HttpComparison.Value').   
```csharp
public string? Key { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpComparison_Operation'></a>
## HttpComparison.Operation Property
Specifies the comparative operator.  
```csharp
public TetraPak.AspNet.ComparisonOperation Operation { get; set; }
```
#### Property Value
[ComparisonOperation](TetraPak_AspNet_ComparisonOperation.md 'TetraPak.AspNet.ComparisonOperation')
#### See Also
- [ComparisonOperation](TetraPak_AspNet_ComparisonOperation.md 'TetraPak.AspNet.ComparisonOperation')
  
<a name='TetraPak_AspNet_HttpComparison_Value'></a>
## HttpComparison.Value Property
Gets the value to be matched with the specified [Key](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Key 'TetraPak.AspNet.HttpComparison.Key').   
```csharp
public string? Value { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_HttpComparison_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)'></a>
## HttpComparison.IsMatch(HttpRequest, StringComparison) Method
Executes the  specified operation and returns a value indicating a match.   
```csharp
public bool IsMatch(Microsoft.AspNetCore.Http.HttpRequest request, System.StringComparison comparison=System.StringComparison.InvariantCulture);
```
#### Parameters
<a name='TetraPak_AspNet_HttpComparison_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') to be matched by the operation.  
  
<a name='TetraPak_AspNet_HttpComparison_IsMatch(Microsoft_AspNetCore_Http_HttpRequest_System_StringComparison)_comparison'></a>
`comparison` [System.StringComparison](https://docs.microsoft.com/en-us/dotnet/api/System.StringComparison 'System.StringComparison')  
(optional; default=[System.StringComparison.InvariantCulture](https://docs.microsoft.com/en-us/dotnet/api/System.StringComparison.InvariantCulture 'System.StringComparison.InvariantCulture'))<br/>  
Specifies how to match the [Value](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Value 'TetraPak.AspNet.HttpComparison.Value') ([Element](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Element 'TetraPak.AspNet.HttpComparison.Element') and [Key](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Key 'TetraPak.AspNet.HttpComparison.Key')  
are always case-insensitive.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [ItemValue(HttpRequest)](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_ItemValue(Microsoft_AspNetCore_Http_HttpRequest) 'TetraPak.AspNet.HttpComparison.ItemValue(Microsoft.AspNetCore.Http.HttpRequest)') matches [Value](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Value 'TetraPak.AspNet.HttpComparison.Value');  
              otherwise `false`.  
            
  
<a name='TetraPak_AspNet_HttpComparison_ItemValue(Microsoft_AspNetCore_Http_HttpRequest)'></a>
## HttpComparison.ItemValue(HttpRequest) Method
Gets the item's value (identified by [Key](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Key 'TetraPak.AspNet.HttpComparison.Key')) from a request.  
```csharp
public string? ItemValue(Microsoft.AspNetCore.Http.HttpRequest request);
```
#### Parameters
<a name='TetraPak_AspNet_HttpComparison_ItemValue(Microsoft_AspNetCore_Http_HttpRequest)_request'></a>
`request` [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')  
The [Microsoft.AspNetCore.Http.HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Http.HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest')
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') value if the item can be found in the specified [Element](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Element 'TetraPak.AspNet.HttpComparison.Element');  
otherwise `null`.  
  
<a name='TetraPak_AspNet_HttpComparison_OnParse(string_)'></a>
## HttpComparison.OnParse(string?) Method
Overrides base method to resolve [Element](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Element 'TetraPak.AspNet.HttpComparison.Element'), [Key](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Key 'TetraPak.AspNet.HttpComparison.Key') and [Value](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_Value 'TetraPak.AspNet.HttpComparison.Value').  
```csharp
protected override string? OnParse(string? stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_HttpComparison_OnParse(string_)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [stringValue](TetraPak_AspNet_HttpComparison.md#TetraPak_AspNet_HttpComparison_OnParse(string_)_stringValue 'TetraPak.AspNet.HttpComparison.OnParse(string?).stringValue') if parsing is successful; otherwise `null`.  
  
### Operators
<a name='TetraPak_AspNet_HttpComparison_op_ImplicitTetraPak_AspNet_HttpComparison(string_)'></a>
## HttpComparison.implicit operator HttpComparison(string?) Operator
Implicit type cast operation [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') => [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison').   
```csharp
public static TetraPak.AspNet.HttpComparison implicit operator HttpComparison(string? stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_HttpComparison_op_ImplicitTetraPak_AspNet_HttpComparison(string_)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The textual representation of a [HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison') value.  
  
#### Returns
[HttpComparison](TetraPak_AspNet_HttpComparison.md 'TetraPak.AspNet.HttpComparison')  
  
