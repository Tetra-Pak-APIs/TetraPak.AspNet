#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpQuery Class
Represents HTTP query parameters.  
```csharp
public class HttpQuery :
System.Collections.Generic.IDictionary<string, string?>,
System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, string?>>,
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string?>>,
System.Collections.IEnumerable,
TetraPak.IStringValue
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpQuery  

Implements [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2'), [System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [TetraPak.IStringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.IStringValue 'TetraPak.IStringValue')  
### Constructors
<a name='TetraPak_AspNet_HttpQuery_HttpQuery()'></a>
## HttpQuery.HttpQuery() Constructor
Initializes (empty) query parameters.   
```csharp
public HttpQuery();
```
  
<a name='TetraPak_AspNet_HttpQuery_HttpQuery(string_)'></a>
## HttpQuery.HttpQuery(string?) Constructor
Initializes the [HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery') from a textual representation.  
```csharp
public HttpQuery(string? queryParameters);
```
#### Parameters
<a name='TetraPak_AspNet_HttpQuery_HttpQuery(string_)_queryParameters'></a>
`queryParameters` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
  
### Fields
<a name='TetraPak_AspNet_HttpQuery_Assign'></a>
## HttpQuery.Assign Field
The HTTP query parameter collection value (pair) assignment symbol.  
```csharp
private const char Assign = =;
```
#### Field Value
[System.Char](https://docs.microsoft.com/en-us/dotnet/api/System.Char 'System.Char')
  
<a name='TetraPak_AspNet_HttpQuery_Qualifier'></a>
## HttpQuery.Qualifier Field
The HTTP query parameter collection qualifier symbol.  
```csharp
public const char Qualifier = ?;
```
#### Field Value
[System.Char](https://docs.microsoft.com/en-us/dotnet/api/System.Char 'System.Char')
  
<a name='TetraPak_AspNet_HttpQuery_Separator'></a>
## HttpQuery.Separator Field
The HTTP query parameter collection value (pair) separator symbol.  
```csharp
public const char Separator = &;
```
#### Field Value
[System.Char](https://docs.microsoft.com/en-us/dotnet/api/System.Char 'System.Char')
  
### Properties
<a name='TetraPak_AspNet_HttpQuery_Count'></a>
## HttpQuery.Count Property
Gets the number of elements contained in the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1').
```csharp
public int Count { get; }
```
#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Implements [Count](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1.Count 'System.Collections.Generic.ICollection`1.Count')  
  
<a name='TetraPak_AspNet_HttpQuery_IsReadOnly'></a>
## HttpQuery.IsReadOnly Property
Gets a value indicating whether the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') is read-only.
```csharp
public bool IsReadOnly { get; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Implements [IsReadOnly](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1.IsReadOnly 'System.Collections.Generic.ICollection`1.IsReadOnly')  
  
<a name='TetraPak_AspNet_HttpQuery_Keys'></a>
## HttpQuery.Keys Property
Gets an [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') containing the keys of the [System.Collections.Generic.IDictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2').
```csharp
public System.Collections.Generic.ICollection<string> Keys { get; }
```
#### Property Value
[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')

Implements [Keys](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2.Keys 'System.Collections.Generic.IDictionary`2.Keys')  
  
<a name='TetraPak_AspNet_HttpQuery_StringValue'></a>
## HttpQuery.StringValue Property
Gets the query parameter's textual representation.   
```csharp
public string StringValue { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [StringValue](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.IStringValue.StringValue 'TetraPak.IStringValue.StringValue')  
  
<a name='TetraPak_AspNet_HttpQuery_Values'></a>
## HttpQuery.Values Property
Gets an [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') containing the values in the [System.Collections.Generic.IDictionary&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2').
```csharp
public System.Collections.Generic.ICollection<string?> Values { get; }
```
#### Property Value
[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')

Implements [Values](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2.Values 'System.Collections.Generic.IDictionary`2.Values')  
  
### Methods
<a name='TetraPak_AspNet_HttpQuery_Clear()'></a>
## HttpQuery.Clear() Method
Removes all items from the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1').
```csharp
public void Clear();
```
#### Exceptions
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
The [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') is read-only.

Implements [Clear()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1.Clear 'System.Collections.Generic.ICollection`1.Clear')  
  
<a name='TetraPak_AspNet_HttpQuery_GetEnumerator()'></a>
## HttpQuery.GetEnumerator() Method
Returns an enumerator that iterates through the collection.
```csharp
public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string,string?>> GetEnumerator();
```
#### Returns
[System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')  
An enumerator that can be used to iterate through the collection.

Implements [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1.GetEnumerator 'System.Collections.Generic.IEnumerable`1.GetEnumerator'), [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable.GetEnumerator 'System.Collections.IEnumerable.GetEnumerator')  
  
<a name='TetraPak_AspNet_HttpQuery_OnParse(string_)'></a>
## HttpQuery.OnParse(string?) Method
Invoked to parse a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') into a   
```csharp
protected virtual System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,string?>> OnParse(string? stringValue);
```
#### Parameters
<a name='TetraPak_AspNet_HttpQuery_OnParse(string_)_stringValue'></a>
`stringValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to be parsed.  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of [System.Collections.Generic.KeyValuePair&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2'), representing the key/value pairs  
found in the [stringValue](TetraPak_AspNet_HttpQuery.md#TetraPak_AspNet_HttpQuery_OnParse(string_)_stringValue 'TetraPak.AspNet.HttpQuery.OnParse(string?).stringValue').  
  
<a name='TetraPak_AspNet_HttpQuery_ToString()'></a>
## HttpQuery.ToString() Method
Returns a string that represents the current object.
```csharp
public override string ToString();
```
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string that represents the current object.
  
<a name='TetraPak_AspNet_HttpQuery_ToString(bool)'></a>
## HttpQuery.ToString(bool) Method
Returns a string that represents the current object, while specifying whether to include  
the query qualifier character ([Qualifier](TetraPak_AspNet_HttpQuery.md#TetraPak_AspNet_HttpQuery_Qualifier 'TetraPak.AspNet.HttpQuery.Qualifier')).  
```csharp
public string ToString(bool includeQualifier);
```
#### Parameters
<a name='TetraPak_AspNet_HttpQuery_ToString(bool)_includeQualifier'></a>
`includeQualifier` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Specifies whether to prepend the result with the [Qualifier](TetraPak_AspNet_HttpQuery.md#TetraPak_AspNet_HttpQuery_Qualifier 'TetraPak.AspNet.HttpQuery.Qualifier') symbol.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') that represents the current object.  
  
### Operators
<a name='TetraPak_AspNet_HttpQuery_op_Implicitstring_(TetraPak_AspNet_HttpQuery_)'></a>
## HttpQuery.implicit operator string?(HttpQuery?) Operator
Implicitly converts a [HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery') object  
into its [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') representation.  
```csharp
public static string? implicit operator string?(TetraPak.AspNet.HttpQuery? queryParameters);
```
#### Parameters
<a name='TetraPak_AspNet_HttpQuery_op_Implicitstring_(TetraPak_AspNet_HttpQuery_)_queryParameters'></a>
`queryParameters` [HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery')  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='TetraPak_AspNet_HttpQuery_op_ImplicitTetraPak_AspNet_HttpQuery(string)'></a>
## HttpQuery.implicit operator HttpQuery(string) Operator
Implicitly converts a string representation of HTTP query parameters into  
a [HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery') object.   
```csharp
public static TetraPak.AspNet.HttpQuery implicit operator HttpQuery(string s);
```
#### Parameters
<a name='TetraPak_AspNet_HttpQuery_op_ImplicitTetraPak_AspNet_HttpQuery(string)_s'></a>
`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[HttpQuery](TetraPak_AspNet_HttpQuery.md 'TetraPak.AspNet.HttpQuery')  
  