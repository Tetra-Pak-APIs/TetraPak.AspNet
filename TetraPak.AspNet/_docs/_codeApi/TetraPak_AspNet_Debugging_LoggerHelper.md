#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.Debugging](TetraPak_AspNet_Debugging.md 'TetraPak.AspNet.Debugging')
## LoggerHelper Class
Contains convenience/extension methods to assist with logging.   
```csharp
public static class LoggerHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LoggerHelper  
### Methods
<a name='TetraPak_AspNet_Debugging_LoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_DependencyInjection_IServiceCollection_bool)'></a>
## LoggerHelper.DebugAssembliesInUse(IServiceCollection, bool) Method
Logs all assemblies currently in use by the process. This method is intended to be called  
at a very early stage, where DI hasn't yet been fully set up, such as from the Program class  
in a web application.  
```csharp
public static void DebugAssembliesInUse(this Microsoft.Extensions.DependencyInjection.IServiceCollection c, bool justOnce=true);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_LoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_DependencyInjection_IServiceCollection_bool)_c'></a>
`c` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')  
A [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection'), used to set up DI.  
  
<a name='TetraPak_AspNet_Debugging_LoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_DependencyInjection_IServiceCollection_bool)_justOnce'></a>
`justOnce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br />  
Specifies whether to ignore logging if this method has already been invoked once by the process.  
This is to help avoiding littering the log files with the same information multiple times.  
  
  
<a name='TetraPak_AspNet_Debugging_LoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_Logging_ILogger_bool)'></a>
## LoggerHelper.DebugAssembliesInUse(ILogger, bool) Method
Logs all assemblies currently in use by the process.  
```csharp
public static void DebugAssembliesInUse(this Microsoft.Extensions.Logging.ILogger logger, bool justOnce=true);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_LoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_Logging_ILogger_bool)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
A logger provider.  
  
<a name='TetraPak_AspNet_Debugging_LoggerHelper_DebugAssembliesInUse(Microsoft_Extensions_Logging_ILogger_bool)_justOnce'></a>
`justOnce` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
(optional; default=`true`)<br />  
Specifies whether to ignore logging if this method has already been invoked once by the process.  
This is to help avoiding littering the log files with the same information multiple times.  
  
  
<a name='TetraPak_AspNet_Debugging_LoggerHelper_GetLowestLogLevel(Microsoft_Extensions_Logging_ILogger)'></a>
## LoggerHelper.GetLowestLogLevel(ILogger) Method
Gets the lowest [Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel') defined for the logger provider.   
```csharp
public static Microsoft.Extensions.Logging.LogLevel GetLowestLogLevel(this Microsoft.Extensions.Logging.ILogger logger);
```
#### Parameters
<a name='TetraPak_AspNet_Debugging_LoggerHelper_GetLowestLogLevel(Microsoft_Extensions_Logging_ILogger)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')  
The logger provider.  
  
#### Returns
[Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel')  
A [Microsoft.Extensions.Logging.LogLevel](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel 'Microsoft.Extensions.Logging.LogLevel') value.  
  
