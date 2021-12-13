﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using TetraPak.Serialization;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides convenient methods for dealing with standard Tetra Pak error responses. 
    /// </summary>
    public static class ApiErrorResponseHelper
    {
        /// <summary>
        ///   Transforms an object's properties and values into a dictionary.
        /// </summary>
        /// <param name="self">
        ///   The object being transformed into a dictionary.
        /// </param>
        /// <param name="options">
        ///   (optional; default = <see cref="DictionaryTransformationOptions.Default"/>
        ///   Options to control the transformation.
        /// </param>
        /// <returns>
        ///   A <see cref="IDictionary{TKey,TValue}"/> object.
        /// </returns>
        public static IDictionary<string, object> ToDictionary(
            this object self, 
            DictionaryTransformationOptions? options = null)
        {
            options ??= DictionaryTransformationOptions.Default;
            var properties = self.GetType().GetProperties().ToArray();
            var dictionary = new Dictionary<string, object>();
            
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                if (property.IsIndexer())
                    continue;
                
                var value = property.CanRead
                    ? property.GetValue(self)
                    : null;
            
                if (options.IgnoreNullValues && value is null)
                    continue;
            
                var jsonPropertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>();
                var key = jsonPropertyName is { } 
                    ? jsonPropertyName.Name 
                    : property.Name.ToJsonKeyFormat(options.KeyFormat);

                if (value is { } && options.TransformChildren)
                {
                    value = value.ToDictionary(options);
                }
                dictionary.Add(key, value!);
            }

            return dictionary;
        }
    }
}