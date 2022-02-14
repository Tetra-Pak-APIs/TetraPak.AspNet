#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## HttpServerConfigurationException Class
Thrown to reflect configuration issues.  
```csharp
public class HttpServerConfigurationException : TetraPak.AspNet.HttpServerException
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; [HttpServerException](TetraPak_AspNet_HttpServerException.md 'TetraPak.AspNet.HttpServerException') &#129106; HttpServerConfigurationException  
### Constructors
<a name='TetraPak_AspNet_HttpServerConfigurationException_HttpServerConfigurationException(string__System_Exception_)'></a>
## HttpServerConfigurationException.HttpServerConfigurationException(string?, Exception?) Constructor
Initializes the [HttpServerConfigurationException](TetraPak_AspNet_HttpServerConfigurationException.md 'TetraPak.AspNet.HttpServerConfigurationException').  
```csharp
public HttpServerConfigurationException(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_HttpServerConfigurationException_HttpServerConfigurationException(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[DefaultErrorMessage](TetraPak_AspNet_HttpServerConfigurationException.md#TetraPak_AspNet_HttpServerConfigurationException_DefaultErrorMessage 'TetraPak.AspNet.HttpServerConfigurationException.DefaultErrorMessage'))<br/>  
A message describing the server configuration issue.  
  
<a name='TetraPak_AspNet_HttpServerConfigurationException_HttpServerConfigurationException(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
  
### Properties
<a name='TetraPak_AspNet_HttpServerConfigurationException_DefaultErrorMessage'></a>
## HttpServerConfigurationException.DefaultErrorMessage Property
(static property)<br/>  
Gets or sets a default error message to be used when no message is specified.  
```csharp
public static string DefaultErrorMessage { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
