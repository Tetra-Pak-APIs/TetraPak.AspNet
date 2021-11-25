#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet](TetraPak_AspNet.md 'TetraPak.AspNet')
## ServerConfigurationException Class
Thrown to reflect configuration issues.  
```csharp
public class ServerConfigurationException : TetraPak.AspNet.ServerException
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; [ServerException](TetraPak_AspNet_ServerException.md 'TetraPak.AspNet.ServerException') &#129106; ServerConfigurationException  
### Constructors
<a name='TetraPak_AspNet_ServerConfigurationException_ServerConfigurationException(string__System_Exception_)'></a>
## ServerConfigurationException.ServerConfigurationException(string?, Exception?) Constructor
Initializes the [ServerConfigurationException](TetraPak_AspNet_ServerConfigurationException.md 'TetraPak.AspNet.ServerConfigurationException').  
```csharp
public ServerConfigurationException(string? message=null, System.Exception? innerException=null);
```
#### Parameters
<a name='TetraPak_AspNet_ServerConfigurationException_ServerConfigurationException(string__System_Exception_)_message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(optional; default=[DefaultErrorMessage](TetraPak_AspNet_ServerConfigurationException.md#TetraPak_AspNet_ServerConfigurationException_DefaultErrorMessage 'TetraPak.AspNet.ServerConfigurationException.DefaultErrorMessage'))<br/>  
A message describing the server configuration issue.  
  
<a name='TetraPak_AspNet_ServerConfigurationException_ServerConfigurationException(string__System_Exception_)_innerException'></a>
`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
(optional)<br/>  
The exception that is the cause of the current exception.  
  
  
### Properties
<a name='TetraPak_AspNet_ServerConfigurationException_DefaultErrorMessage'></a>
## ServerConfigurationException.DefaultErrorMessage Property
(static property)<br/>  
Gets or sets a default error message to be used when no message is specified.  
```csharp
public static string DefaultErrorMessage { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
