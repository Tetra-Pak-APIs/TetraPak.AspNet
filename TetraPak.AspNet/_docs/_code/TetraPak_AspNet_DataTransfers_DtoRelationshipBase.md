#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.DataTransfers](TetraPak_AspNet_DataTransfers.md 'TetraPak.AspNet.DataTransfers')
## DtoRelationshipBase Class
(abstract class)<br/>  
Represents a category of related resources.  
```csharp
public abstract class DtoRelationshipBase : TetraPak.DynamicEntities.DynamicEntity
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.DynamicEntities.DynamicEntity](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicEntity 'TetraPak.DynamicEntities.DynamicEntity') &#129106; DtoRelationshipBase  

Derived  
&#8627; [DtoHrefRelationship](TetraPak_AspNet_DataTransfers_DtoHrefRelationship.md 'TetraPak.AspNet.DataTransfers.DtoHrefRelationship')  
### Constructors
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_DtoRelationshipBase()'></a>
## DtoRelationshipBase.DtoRelationshipBase() Constructor
Initializes an empty [DtoRelationshipBase](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase')  
(intended for serialization).  
```csharp
public DtoRelationshipBase();
```
  
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_DtoRelationshipBase(string)'></a>
## DtoRelationshipBase.DtoRelationshipBase(string) Constructor
Initializes the [DtoRelationshipBase](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase').  
```csharp
protected DtoRelationshipBase(string type);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_DtoRelationshipBase(string)_type'></a>
`type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the relationship [Rel](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md#TetraPak_AspNet_DataTransfers_DtoRelationshipBase_Rel 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase.Rel').  
  
  
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_DtoRelationshipBase(string_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)'></a>
## DtoRelationshipBase.DtoRelationshipBase(string, HttpMethod[]) Constructor
Initializes the [DtoRelationshipBase](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase').  
```csharp
protected DtoRelationshipBase(string type, params Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[] verbs);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_DtoRelationshipBase(string_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_type'></a>
`type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the relationship [Rel](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md#TetraPak_AspNet_DataTransfers_DtoRelationshipBase_Rel 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase.Rel').  
  
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_DtoRelationshipBase(string_Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_verbs'></a>
`verbs` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
(optional)<br/>  
One or more HTTP methods supported by all related resources.  
  
  
### Properties
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_Rel'></a>
## DtoRelationshipBase.Rel Property
Describes the relationship.   
```csharp
public string Rel { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipBase_Verbs'></a>
## DtoRelationshipBase.Verbs Property
Gets or sets one or more HTTP verbs supported by the relationship(s).  
```csharp
public string[]? Verbs { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')
  
