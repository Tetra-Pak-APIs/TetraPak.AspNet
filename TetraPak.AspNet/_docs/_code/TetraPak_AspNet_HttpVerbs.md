#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpVerbs Class
Provides [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') constants for standard HTTP methods.  
```csharp
public static class HttpVerbs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpVerbs  
### Fields
<a name='TetraPak_AspNet_HttpVerbs_Connect'></a>
## HttpVerbs.Connect Field
The HTTP 'CONNECT' method identifier.   
```csharp
public const string Connect = CONNECT;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Custom'></a>
## HttpVerbs.Custom Field
The HTTP 'CUSTOM' method identifier.   
```csharp
public const string Custom = CUSTOM;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Delete'></a>
## HttpVerbs.Delete Field
The HTTP 'DELETE' method identifier.   
```csharp
public const string Delete = DELETE;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Get'></a>
## HttpVerbs.Get Field
The HTTP 'GET' method identifier.   
```csharp
public const string Get = GET;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Head'></a>
## HttpVerbs.Head Field
The HTTP 'HEAD' method identifier.   
```csharp
public const string Head = HEAD;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Options'></a>
## HttpVerbs.Options Field
The HTTP 'OPTIONS' method identifier.   
```csharp
public const string Options = OPTIONS;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Patch'></a>
## HttpVerbs.Patch Field
The HTTP 'PATCH' method identifier.   
```csharp
public const string Patch = PATCH;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Post'></a>
## HttpVerbs.Post Field
The HTTP 'POST' method identifier.   
```csharp
public const string Post = POST;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Put'></a>
## HttpVerbs.Put Field
The HTTP 'PUT' method identifier.   
```csharp
public const string Put = PUT;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_HttpVerbs_Trace'></a>
## HttpVerbs.Trace Field
The HTTP 'TRACE' method identifier.   
```csharp
public const string Trace = TRACE;
```
#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
### Methods
<a name='TetraPak_AspNet_HttpVerbs_DefaultToGetVerb(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod___)'></a>
## HttpVerbs.DefaultToGetVerb(HttpMethod[]?) Method
Examines a collection of [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') items and returns it if one or  
more items are found; otherwise returns a collection containing the [Get](TetraPak_AspNet_HttpVerbs.md#TetraPak_AspNet_HttpVerbs_Get 'TetraPak.AspNet.HttpVerbs.Get') HTTP method.   
```csharp
public static string[] DefaultToGetVerb(this Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[]? methods);
```
#### Parameters
<a name='TetraPak_AspNet_HttpVerbs_DefaultToGetVerb(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod___)_methods'></a>
`methods` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The collection of [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') items to be examined.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') array containing the resulting HTTP verbs.  
  
<a name='TetraPak_AspNet_HttpVerbs_DefaultToVerbs(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod____string__)'></a>
## HttpVerbs.DefaultToVerbs(HttpMethod[]?, string[]) Method
Examines a collection of [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') items and returns it if one or  
more items are found; otherwise returns a specified default collection of HTTP verbs.   
```csharp
public static string[] DefaultToVerbs(this Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[]? methods, params string[] defaultVerbs);
```
#### Parameters
<a name='TetraPak_AspNet_HttpVerbs_DefaultToVerbs(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod____string__)_methods'></a>
`methods` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The collection of [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') items to be examined.  
  
<a name='TetraPak_AspNet_HttpVerbs_DefaultToVerbs(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod____string__)_defaultVerbs'></a>
`defaultVerbs` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
One or more default verbs to be returned if no [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod') are assigned  
([methods](TetraPak_AspNet_HttpVerbs.md#TetraPak_AspNet_HttpVerbs_DefaultToVerbs(Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod____string__)_methods 'TetraPak.AspNet.HttpVerbs.DefaultToVerbs(Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[]?, string[]).methods') is `null` or empty).  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') array containing the resulting HTTP verbs.  
  
