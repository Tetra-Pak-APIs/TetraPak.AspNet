#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.DataTransfers](TetraPak_AspNet_DataTransfers.md 'TetraPak.AspNet.DataTransfers')
## DtoHrefRelationship Class
Reflects a category of related resources, represented as URLs.  
```csharp
public class DtoHrefRelationship : TetraPak.AspNet.DataTransfers.DtoRelationshipBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.DynamicEntities.DynamicEntity](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicEntity 'TetraPak.DynamicEntities.DynamicEntity') &#129106; [DtoRelationshipBase](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase') &#129106; DtoHrefRelationship  
### Constructors
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_System_Collections_Generic_IEnumerable_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)'></a>
## DtoHrefRelationship.DtoHrefRelationship(string, IEnumerable&lt;DtoRelationshipLocator&gt;, HttpMethod[]) Constructor
Initializes the [DtoHrefRelationship](TetraPak_AspNet_DataTransfers_DtoHrefRelationship.md 'TetraPak.AspNet.DataTransfers.DtoHrefRelationship').  
```csharp
public DtoHrefRelationship(string type, System.Collections.Generic.IEnumerable<TetraPak.AspNet.DataTransfers.DtoRelationshipLocator> href, params Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[] verbs);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_System_Collections_Generic_IEnumerable_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_type'></a>
`type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the relationship [Rel](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md#TetraPak_AspNet_DataTransfers_DtoRelationshipBase_Rel 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase.Rel').  
  
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_System_Collections_Generic_IEnumerable_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_href'></a>
`href` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Initializes the [Href](TetraPak_AspNet_DataTransfers_DtoHrefRelationship.md#TetraPak_AspNet_DataTransfers_DtoHrefRelationship_Href 'TetraPak.AspNet.DataTransfers.DtoHrefRelationship.Href').  
  
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_System_Collections_Generic_IEnumerable_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_verbs'></a>
`verbs` [Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod 'Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
(optional)<br/>  
One or more HTTP methods supported by all [href](TetraPak_AspNet_DataTransfers_DtoHrefRelationship.md#TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_System_Collections_Generic_IEnumerable_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__Microsoft_AspNetCore_Server_Kestrel_Core_Internal_Http_HttpMethod__)_href 'TetraPak.AspNet.DataTransfers.DtoHrefRelationship.DtoHrefRelationship(string, System.Collections.Generic.IEnumerable&lt;TetraPak.AspNet.DataTransfers.DtoRelationshipLocator&gt;, Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod[]).href').  
  
  
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__)'></a>
## DtoHrefRelationship.DtoHrefRelationship(string, DtoRelationshipLocator[]) Constructor
Initializes the [DtoHrefRelationship](TetraPak_AspNet_DataTransfers_DtoHrefRelationship.md 'TetraPak.AspNet.DataTransfers.DtoHrefRelationship').  
```csharp
public DtoHrefRelationship(string type, params TetraPak.AspNet.DataTransfers.DtoRelationshipLocator[] locators);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__)_type'></a>
`type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes the relationship [Rel](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md#TetraPak_AspNet_DataTransfers_DtoRelationshipBase_Rel 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase.Rel').  
  
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_DtoHrefRelationship(string_TetraPak_AspNet_DataTransfers_DtoRelationshipLocator__)_locators'></a>
`locators` [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
Initializes the [Href](TetraPak_AspNet_DataTransfers_DtoHrefRelationship.md#TetraPak_AspNet_DataTransfers_DtoHrefRelationship_Href 'TetraPak.AspNet.DataTransfers.DtoHrefRelationship.Href').  
  
  
### Properties
<a name='TetraPak_AspNet_DataTransfers_DtoHrefRelationship_Href'></a>
## DtoHrefRelationship.Href Property
Gets or sets one or more related resource locators.   
```csharp
public System.Collections.Generic.IEnumerable<TetraPak.AspNet.DataTransfers.DtoRelationshipLocator> Href { get; set; }
```
#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
  
