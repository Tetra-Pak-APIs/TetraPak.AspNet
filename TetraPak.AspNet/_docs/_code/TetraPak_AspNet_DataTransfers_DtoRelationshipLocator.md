#### [TetraPak.AspNet](index.md 'index')
### [TetraPak.AspNet.DataTransfers](TetraPak_AspNet_DataTransfers.md 'TetraPak.AspNet.DataTransfers')
## DtoRelationshipLocator Class
Represents an individual related resource and how to access it.    
```csharp
public class DtoRelationshipLocator : TetraPak.DynamicEntities.DynamicEntity
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TetraPak.DynamicEntities.DynamicEntity](https://docs.microsoft.com/en-us/dotnet/api/TetraPak.DynamicEntities.DynamicEntity 'TetraPak.DynamicEntities.DynamicEntity') &#129106; DtoRelationshipLocator  
### Constructors
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_DtoRelationshipLocator()'></a>
## DtoRelationshipLocator.DtoRelationshipLocator() Constructor
Initializes an empty [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator'). (mainly intended for serialization).  
```csharp
public DtoRelationshipLocator();
```
  
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_DtoRelationshipLocator(string_string___)'></a>
## DtoRelationshipLocator.DtoRelationshipLocator(string, string[]?) Constructor
Initializes the [DtoRelationshipLocator](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator').  
```csharp
public DtoRelationshipLocator(string uri, string[]? verbs);
```
#### Parameters
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_DtoRelationshipLocator(string_string___)_uri'></a>
`uri` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Initializes [Uri](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md#TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_Uri 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator.Uri').  
  
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_DtoRelationshipLocator(string_string___)_verbs'></a>
`verbs` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
Initializes [Verbs](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md#TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_Verbs 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator.Verbs').  
  
  
### Properties
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_Uri'></a>
## DtoRelationshipLocator.Uri Property
The locator (URI) used to access the related resource.  
```csharp
public string Uri { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
  
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_Verbs'></a>
## DtoRelationshipLocator.Verbs Property
Gets or sets one or more HTTP methods (verbs) supported by the endpoint ([Uri](TetraPak_AspNet_DataTransfers_DtoRelationshipLocator.md#TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_Uri 'TetraPak.AspNet.DataTransfers.DtoRelationshipLocator.Uri')).  
This can also be specified by the parent level ([Verbs](TetraPak_AspNet_DataTransfers_DtoRelationshipBase.md#TetraPak_AspNet_DataTransfers_DtoRelationshipBase_Verbs 'TetraPak.AspNet.DataTransfers.DtoRelationshipBase.Verbs')).  
```csharp
public string[]? Verbs { get; set; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')
  
### Methods
<a name='TetraPak_AspNet_DataTransfers_DtoRelationshipLocator_ToString()'></a>
## DtoRelationshipLocator.ToString() Method
Returns a string that represents the current object.
```csharp
public override string ToString();
```
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string that represents the current object.
  
