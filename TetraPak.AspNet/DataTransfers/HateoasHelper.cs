using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using TetraPak.DynamicEntities;

namespace TetraPak.AspNet.DataTransfers
{
    /// <summary>
    ///   Provides convenient helper methods for working with the HATEOAS classes.
    /// </summary>
    public static class HateoasHelper
    {
        /// <summary>
        ///   Constructs and returns a relationship locator for the current endpoint.
        /// </summary>
        /// <param name="self">
        ///   The extended controller.
        /// </param>
        /// <param name="methods">
        ///   (optional)<br/>
        ///   One or more HTTP verbs that are supported by the endpoint.
        /// </param>
        /// <returns>
        ///   A <see cref="DtoRelationshipLocator"/>.
        /// </returns>
        public static DtoRelationshipLocator GetRelLocatorForSelf(this ControllerBase self, params HttpMethod[] methods)
        {
            var url = BuildPath(self.Url.RouteUrl(self.RouteData.Values));
            return new DtoRelationshipLocator(url, methods.DefaultToGetVerb());
        }

        /// <summary>
        ///   Constructs and returns a relationship locator for a specified action.
        /// </summary>
        /// <param name="self">
        ///   The extended controller.
        /// </param>
        /// <param name="action">
        ///   The name of the action method.
        /// </param>
        /// <param name="methods">
        ///   (optional)<br/>
        ///   One or more HTTP verbs that are supported by the endpoint.
        /// </param>
        /// <returns>
        ///   A <see cref="DtoRelationshipLocator"/>.
        /// </returns>
        public static DtoRelationshipLocator GetRelLocatorForAction(
            this ControllerBase self, 
            string action, 
            params HttpMethod[] methods)
        {
            var url = BuildPath(self.Url.Action(action));
            return new DtoRelationshipLocator(url, methods.DefaultToGetVerb());
        }

        /// <summary>
        ///   Constructs and returns a relationship locator for a controller type's default action.
        /// </summary>
        /// <param name="self">
        ///   The extended controller.
        /// </param>
        /// <returns>
        ///   A <see cref="DtoRelationshipLocator"/>.
        /// </returns>
        public static DtoRelationshipLocator GetRelLocatorForDefaultAction<TController>(
            this ControllerBase self)
            where TController : ControllerBase
        {
            return self.GetRelLocatorForDefaultAction<TController>(Array.Empty<HttpMethod>());
        }

        /// <summary>
        ///   Constructs and returns a relationship locator for a controller type's default action.
        /// </summary>
        /// <param name="self">
        ///   The extended controller.
        /// </param>
        /// <param name="methods">
        ///   One or more HTTP verbs that are supported by the endpoint.
        /// </param>
        /// <returns>
        ///   A <see cref="DtoRelationshipLocator"/>.
        /// </returns>
        public static DtoRelationshipLocator GetRelLocatorForDefaultAction<TController>(
            this ControllerBase self, 
            params HttpMethod[] methods)
            where TController : ControllerBase
        {
            var defaultGetAction = ControllerHelper.DefaultGetAction<TController>();
            if (defaultGetAction is null)
                throw new Exception($"Cannot find default action for controller {typeof(TController)}");
            
            return self.GetRelLocatorsForAction<TController>(
                defaultGetAction.Name, 
                Array.Empty<string>(), 
                null, 
                methods);
        }

        /// <summary>
        ///   Constructs and returns a relationship locator for a controller action while also specifying resource keys.
        /// </summary>
        /// <param name="self">
        ///   The extended controller.
        /// </param>
        /// <param name="action">
        ///   The name of the action method.
        /// </param>
        /// <param name="keys">
        ///   One or more resource keys (ids), needed to locate the resource.
        /// </param>
        /// <returns>
        ///   A <see cref="DtoRelationshipLocator"/>.
        /// </returns>
        public static DtoRelationshipLocator GetRelLocatorsForAction<TController>(
            this ControllerBase self, 
            string action, 
            params string[] keys)
            where TController : ControllerBase 
        => self.GetRelLocatorsForAction<TController>(action, keys, null, Array.Empty<HttpMethod>());

        /// <summary>
        ///   Constructs and returns a relationship locator for a controller action
        ///   while also specifying resource keys, a HTTP query, and HTTP verbs.
        /// </summary>
        /// <param name="self">
        ///   The extended controller.
        /// </param>
        /// <param name="action">
        ///   The name of the action method.
        /// </param>
        /// <param name="keys">
        ///   One or more resource keys (ids), needed to locate the resource.
        /// </param>
        /// <param name="query">
        ///   A HTTP query to be added to the resource locator URI.
        /// </param>
        /// <param name="methods">
        ///   One or more HTTP verbs that are supported by the resource endpoint.
        /// </param>
        /// <returns>
        ///   A <see cref="DtoRelationshipLocator"/>.
        /// </returns>
        public static DtoRelationshipLocator GetRelLocatorsForAction<TController>(
            this ControllerBase self, string action, string[] keys, HttpQuery? query, HttpMethod[] methods)
            where TController : ControllerBase
        {
            var path = BuildPath(self.Url.Action(action, typeof(TController).GetControllerName()), keys, query);
            return new DtoRelationshipLocator(path, methods.DefaultToGetVerb());
        }
        
        /// <summary>
        ///   (fluent API)<br/>
        ///   Appends keys to the <see cref="DtoRelationshipLocator"/> and
        ///   returns a new <see cref="DtoRelationshipLocator"/>.
        /// </summary>
        public static DtoRelationshipLocator WithKeys(this DtoRelationshipLocator locator, params string[] keys)
        {
            var path = ((FilePath)locator.Uri).Push(keys);
            return new DtoRelationshipLocator(path!, locator.Verbs) { Parent = locator.Parent };
        }

        /// <summary>
        ///   Builds a generic path from a base path and resource keys.
        /// </summary>
        /// <param name="path">
        ///   The base path.
        /// </param>
        /// <param name="keys">
        ///   One or more resource keys to be added to the base path.
        /// </param>
        /// <returns>
        ///   A textual (<see cref="string"/>) path.
        /// </returns>
        public static string BuildPath(string path, params string[] keys) => BuildPath(path, keys, null);

        /// <summary>
        ///   Builds a generic path from a base path and HTTP a query.
        /// </summary>
        /// <param name="path">
        ///   The base path.
        /// </param>
        /// <param name="query">
        ///   The HTTP query to be added to the path.
        /// </param>
        /// <returns>
        ///   A textual (<see cref="string"/>) path.
        /// </returns>
        public static string BuildPath(string path, HttpQuery query) => BuildPath(path, null, query);
        
        /// <summary>
        ///   Builds a generic path from a base path, resource keys and and a HTTP query.
        /// </summary>
        /// <param name="path">
        ///   The base path.
        /// </param>
        /// <param name="keys">
        ///   One or more resource keys to be added to the base path.
        /// </param>
        /// <param name="query">
        ///   The HTTP query to be added to the path.
        /// </param>
        /// <returns>
        ///   A textual (<see cref="string"/>) path.
        /// </returns>
        public static string BuildPath(string path, string[]? keys, HttpQuery? query)
        {
            if ((!keys?.Any() ?? true) && query.IsEmpty())
                return path.EnsurePrefix(FilePath.UnixSeparator);

            var sb = new StringBuilder(path);
            for (var i = 0; i < keys!.Length; i++)
            {
                sb.Append(FilePath.UnixSeparator);
                sb.Append(keys[i]);
            }

            if (!query?.IsEmpty() ?? false)
            {
                sb.Append(query.ToString(true));
            }

            return sb.ToString();
        }

        /* spike (probably we're scrapping it - coders can use a better mapper lib anyway)
        
        static readonly IDictionary<Type, DtoMap> s_dtoMaps = new Dictionary<Type, DtoMap>();
        public static T MapToDataTransferObject<T>(this object entity, DataTransferMapOptions<T> options)
        where T : DataTransferObject
        {
            DtoMap? dtoMap;
            lock (s_dtoMaps)
            {
                if (!s_dtoMaps.TryGetValue(entity.GetType(), out dtoMap))
                {
                    s_dtoMaps.Add(entity.GetType(), dtoMap = DtoMap.BuildMap(entity.GetType(), typeof(T)));
                }
            }

            return dtoMap.ConstructDto(entity, options);
        }

        class DtoMap
        {
            readonly IDictionary<PropertyInfo, string> _propertyToKeyIndex;

            internal static DtoMap BuildMap(IReflect source, IReflect target, bool strict = false)
            {
                const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;

                var index = new Dictionary<PropertyInfo, string>();
                var sourceProperties = source.GetProperties(Flags).Where(i => i.CanRead).ToArray();
                for (var i = 0; i < sourceProperties.Length; i++)
                {
                    var sourceProperty = sourceProperties[i];
                    var key = getKey(sourceProperty);
                    if (strict && !existInTarget(key))
                        continue;

                    index[sourceProperty] = key;
                }

                return new DtoMap(index);
                
                static string getKey(MemberInfo property)
                {
                    var jsonName = property.GetCustomAttribute<JsonPropertyNameAttribute>();
                    return jsonName is null
                        ? property.Name.ToCamelCaseIdentifier() 
                        : jsonName.Name;
                }
                
                bool existInTarget(string key)
                {
                    var targetProperty = target.GetProperties(Flags).FirstOrDefault(i => getKey(i) == key);
                    return targetProperty is { };
                }
            }

            DtoMap(IDictionary<PropertyInfo, string> index)
            {
                _propertyToKeyIndex = index;
            }

            internal T ConstructDto<T>(object source, DataTransferMapOptions<T> options) 
            where T : DataTransferObject
            {
                throw new NotImplementedException();
                
                var dto = constructDto();
                var pairs = _propertyToKeyIndex.ToArray();
                for (var i = 0; i < pairs.Length; i++)
                {
                    var property = pairs[i].Key;
                    var key = pairs[i].Value;
                    var value = property.GetValue(source);
                    if (value is null)
                    {
                        if (!options.IgnoreNullValues)
                        {
                            dto.SetValue<object>(key, null!);
                        }
                        continue;
                    }
                    
                    
                }

                T constructDto() => options.DtoFactory is { } 
                    ? options.DtoFactory(source) 
                    : Activator.CreateInstance<T>();

            }
        }
        */
    }
}