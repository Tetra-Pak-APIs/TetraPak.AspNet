// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Text.Json;
// using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
// using TetraPak.DynamicEntities;
// using TetraPak.Serialization;
//
// namespace TetraPak.AspNet.Identity
// {
//     [JsonConverter(typeof(DynamicEntityJsonConverter<ObjectStringValue>))]
//     public class ObjectStringValue : DynamicEntity, IStringValue
//     {
//         public const char PrefixQualifier = '{';  
//         public const char SuffixQualifier = '}';  
//         
//         public string StringValue { get; }
//
//         public static implicit operator string(ObjectStringValue value) => value.StringValue;
//
//         public static bool TryConvertJsonElementToDictionary(JsonElement jsonElement, out IDictionary<string,object> dictionary)
//         {
//             dictionary = null;
//             if (jsonElement.ValueKind != JsonValueKind.Object)
//                 return false;
//
//             var objectEnumerator = jsonElement.EnumerateObject();
//             dictionary = new Dictionary<string, object>();
//             foreach (var jsonProperty in objectEnumerator)
//             {
//                 dictionary[jsonProperty.Name] = parseJsonElement(jsonProperty.Value);
//             }
//             return tryBuildDictionary(jsonElement, out dictionary);
//             
//         }
//
//         static bool tryBuildDictionary(JsonElement jsonElement, out IDictionary<string,object> dictionary)
//         {
//             switch (jsonElement.ValueKind)
//             {
//                 case JsonValueKind.Undefined:
//                     return "(undefined)";
//                         
//                 case JsonValueKind.Object:
//                     var objectEnumerator = jsonElement.EnumerateObject();
//                     var dictionary = new Dictionary<string, string>();
//                     foreach (var jsonProperty in objectEnumerator)
//                     {
//                         dictionary[jsonProperty.Name] = parseJsonElement(jsonProperty.Value);
//                     }
//
//                     var objectStringValue = new ObjectStringValue(dictionary);
//                     return objectStringValue;
//                     
//                 case JsonValueKind.Array:
//                     var stringsArray = new string[jsonElement.GetArrayLength()];
//                     var arrayEnumerator = jsonElement.EnumerateArray();
//                     var i = 0;
//                     foreach (var arrayElement in arrayEnumerator)
//                     {
//                         stringsArray[i++] = parseJsonElement(arrayElement);
//                     }
//
//                     return new MultiStringValue(stringsArray);
//
//                 case JsonValueKind.String:
//                 case JsonValueKind.Number:
//                 case JsonValueKind.True:
//                 case JsonValueKind.False:
//                 case JsonValueKind.Null:
//                     return jsonElement.GetRawText();
//
//                 default:
//                     throw new ArgumentOutOfRangeException();
//             }
//
//
//         }
//
//         public ObjectStringValue(string stringValue)
//         {
//             IEnumerable<KeyValuePair<string, object>> pairs;
//             if (!tryParse(stringValue, out pairs))
//                 throw new FormatException($"Invalid {typeof(ObjectStringValue)} format");
//         }
//
//         public ObjectStringValue(params KeyValuePair<string, object>[] pairs)
//         : this(new ObjectStringValueOptions(), pairs)
//         {
//         }
//
//         public ObjectStringValue(ObjectStringValueOptions options, params KeyValuePair<string,object>[] pairs)
//         {
//             var sb = new StringBuilder();
//             sb.Append(PrefixQualifier);
//             var last = pairs.Length - 1;
//             for (var i = 0; i < pairs.Length; i++)
//             {
//                 var key = pairs[i].Key;
//                 var value = pairs[i].Value;
//                 this[key] = value;
//                 sb.Append(key);
//                 sb.Append(options.Assignment);
//                 sb.Append(value);
//                 if (i != last)
//                 {
//                     sb.Append(options.Separator);
//                 }
//             }
//
//             sb.Append(SuffixQualifier);
//             StringValue = sb.ToString();
//         }
//         
//         public ObjectStringValue(object obj)
//         : this(toKeyValuePairs(obj))
//         {
//         }
//
//         static KeyValuePair<string,object>[] toKeyValuePairs(object obj)
//         {
//             if (obj is null)
//                 throw new ArgumentNullException(nameof(obj));
//             
//             if (obj.IsCollectionOf<KeyValuePair<string, string>>(out var stringPairs))
//                 return stringPairs.Select(i => new KeyValuePair<string, object>(i.Key, i.Value)).ToArray();
//             
//             if (obj.IsCollectionOf<KeyValuePair<string, object>>(out var objPairs))
//                 return objPairs.ToArray();
//             
//             if (obj is KeyValuePair<string, object>[] pairs)
//                 return pairs;
//
//             var dictionary = new Dictionary<string, object>();
//             try
//             {
//                 var sb = new StringBuilder();
//                 var properties = obj.GetType().GetProperties().Where(i => i.CanRead).ToArray();
//                 for (var i = 0; i < properties.Length; i++)
//                 {
//                     var property = properties[i];
//                     if (property.IsIndexer())
//                         continue;
//                     
//                     dictionary[property.Name] = property.GetValue(obj);
//                 }
//
//                 return dictionary.ToArray();
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex);
//                 throw;
//             }
//         }
//     }
//
//     public class ObjectStringValueOptions
//     {
//         const string DefaultAssignment = ": ";
//         const string DefaultSeparator = ", ";
//         
//         string _assignment = DefaultAssignment;
//         string _separator = DefaultSeparator;
//
//         public string Assignment
//         {
//             get => _assignment;
//             set => _assignment = string.IsNullOrEmpty(value) ? DefaultAssignment : value;
//         }
//
//         public string Separator
//         {
//             get => _separator;
//             set => _separator = string.IsNullOrEmpty(value) ? DefaultSeparator : value;
//         }
//     }
//     
// }