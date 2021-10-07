#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.OpenIdConnect](TetraPak_AspNet_OpenIdConnect.md 'TetraPak.AspNet.OpenIdConnect')
## ReadDiscoveryDocumentArgs Class
Specifies behavior for reading a [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
```csharp
public class ReadDiscoveryDocumentArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ReadDiscoveryDocumentArgs  
### Constructors
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_ReadDiscoveryDocumentArgs(Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_)'></a>
## ReadDiscoveryDocumentArgs.ReadDiscoveryDocumentArgs(ILogger&lt;ReadDiscoveryDocumentArgs&gt;) Constructor
Initializes the [ReadDiscoveryDocumentArgs](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs').  
```csharp
public ReadDiscoveryDocumentArgs(Microsoft.Extensions.Logging.ILogger<TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs> logger=null);
```
#### Parameters
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_ReadDiscoveryDocumentArgs(Microsoft_Extensions_Logging_ILogger_TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_)_logger'></a>
`logger` [Microsoft.Extensions.Logging.ILogger&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger-1 'Microsoft.Extensions.Logging.ILogger`1')[ReadDiscoveryDocumentArgs](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger-1 'Microsoft.Extensions.Logging.ILogger`1')  
A logger provider.  
  
  
### Properties
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_Config'></a>
## ReadDiscoveryDocumentArgs.Config Property
Gets or sets the Tetra Pak integration configuration.  
```csharp
public TetraPak.AspNet.TetraPakConfig Config { get; set; }
```
#### Property Value
[TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_LocalCachePath'></a>
## ReadDiscoveryDocumentArgs.LocalCachePath Property
Gets or sets a local (file) path for locally caching the [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').   
```csharp
public string LocalCachePath { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_Logger'></a>
## ReadDiscoveryDocumentArgs.Logger Property
Gets or sets a logging provider.  
```csharp
public Microsoft.Extensions.Logging.ILogger Logger { get; set; }
```
#### Property Value
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft.Extensions.Logging.ILogger')
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_MasterSourceUrl'></a>
## ReadDiscoveryDocumentArgs.MasterSourceUrl Property
Gets or sets the master (remote) source for the discovery document.  
```csharp
public string MasterSourceUrl { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_Policy'></a>
## ReadDiscoveryDocumentArgs.Policy Property
Gets or sets a (fallback) policy for reading a [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
```csharp
public TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy Policy { get; set; }
```
#### Property Value
[ReadDocumentPolicy](TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy.md 'TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy')
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_Timeout'></a>
## ReadDiscoveryDocumentArgs.Timeout Property
Gets or sets a maximum allowed time for reading the [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument'),  
after which the operation will fail (and, potentially, fall back to some other source  
as specified by the [Policy](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md#TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_Policy 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs.Policy')).     
```csharp
public System.Nullable<System.TimeSpan> Timeout { get; set; }
```
#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
  
### Methods
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_FromDefault(TetraPak_AspNet_TetraPakConfig)'></a>
## ReadDiscoveryDocumentArgs.FromDefault(TetraPakConfig) Method
Creates default configuration for reading [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
```csharp
public static TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs FromDefault(TetraPak.AspNet.TetraPakConfig config);
```
#### Parameters
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_FromDefault(TetraPak_AspNet_TetraPakConfig)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.     
  
#### Returns
[ReadDiscoveryDocumentArgs](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs')  
A [ReadDiscoveryDocumentArgs](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs') object.  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_FromMasterSource(TetraPak_AspNet_TetraPakConfig_System_Nullable_System_TimeSpan__TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_string)'></a>
## ReadDiscoveryDocumentArgs.FromMasterSource(TetraPakConfig, Nullable&lt;TimeSpan&gt;, ReadDocumentPolicy, string) Method
Creates default configuration for reading [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument') from a master (remote) source.  
```csharp
public static TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs FromMasterSource(TetraPak.AspNet.TetraPakConfig config, System.Nullable<System.TimeSpan> timeout=null, TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy fallbackPolicy=TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy.All, string localCachePath=null);
```
#### Parameters
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_FromMasterSource(TetraPak_AspNet_TetraPakConfig_System_Nullable_System_TimeSpan__TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_string)_config'></a>
`config` [TetraPakConfig](TetraPak_AspNet_TetraPakConfig.md 'TetraPak.AspNet.TetraPakConfig')  
The Tetra Pak integration configuration.  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_FromMasterSource(TetraPak_AspNet_TetraPakConfig_System_Nullable_System_TimeSpan__TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_string)_timeout'></a>
`timeout` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
Gets or sets a maximum allowed time for reading the [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument'),  
after which the operation will fail (and, potentially, fall back to some other source  
as specified by the [Policy](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md#TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_Policy 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs.Policy')).  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_FromMasterSource(TetraPak_AspNet_TetraPakConfig_System_Nullable_System_TimeSpan__TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_string)_fallbackPolicy'></a>
`fallbackPolicy` [ReadDocumentPolicy](TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy.md 'TetraPak.AspNet.OpenIdConnect.ReadDocumentPolicy')  
A (fallback) policy for reading a [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
  
<a name='TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs_FromMasterSource(TetraPak_AspNet_TetraPakConfig_System_Nullable_System_TimeSpan__TetraPak_AspNet_OpenIdConnect_ReadDocumentPolicy_string)_localCachePath'></a>
`localCachePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A local (file) path for locally caching the [DiscoveryDocument](TetraPak_AspNet_OpenIdConnect_DiscoveryDocument.md 'TetraPak.AspNet.OpenIdConnect.DiscoveryDocument').  
  
#### Returns
[ReadDiscoveryDocumentArgs](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs')  
A [ReadDiscoveryDocumentArgs](TetraPak_AspNet_OpenIdConnect_ReadDiscoveryDocumentArgs.md 'TetraPak.AspNet.OpenIdConnect.ReadDiscoveryDocumentArgs') object.  
  
