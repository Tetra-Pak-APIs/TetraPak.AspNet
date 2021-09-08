using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using TetraPak.DynamicEntities;
using TetraPak.Serialization;

namespace TetraPak.AspNet
{
    [Serializable, JsonConverter(typeof(DynamicEntityJsonConverter<ApiErrorResponse>))]
    public class ApiErrorResponse  : DynamicEntity
    {
        [JsonIgnore]
        public int StatusCode => parseHttpStatusCode();
        
        [JsonPropertyName("title")]
        public string Title //{ get; set; }
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonPropertyName("description")]
        public object Description // { get; set; }
        {
            get => Get<object>();
            set => Set(value);
        }

        [JsonPropertyName("messageId")]
        public string MessageId // { get; set; }
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonPropertyName("type")]
        public string Type // { get; set; }
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonPropertyName("status")]
        public string Status // { get; set; }
        {
            get => Get<string>();
            set => Set(value);
        }

        public ApiErrorResponse(string title, string messageId)
        {
            Title = title;
            if (messageId is { })
            {
                MessageId = messageId;
            }
        }
        
        public ApiErrorResponse(string title, object description, string messageId)
        {
            Title = title;
            Description = description;
            if (messageId is { })
            {
                MessageId = messageId;
            }
        }

        int parseHttpStatusCode()
        {
            if (int.TryParse(Status, out var code))
                return code;

            if (Enum.TryParse<HttpStatusCode>(Status, out var httpStatusCode))
                return (int)httpStatusCode;

            return (int) System.Net.HttpStatusCode.InternalServerError;
        }
    }

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
        public static IDictionary<string, object> ToDictionary(this object self, DictionaryTransformationOptions options = null)
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
                    : property.Name.ToJsonKeyFormat(options.KeyTransformationFormat);

                if (value is { } && options.TransformChildren)
                {
                    value = value.ToDictionary(options);
                }
                dictionary.Add(key, value);
            }

            return dictionary;
        }
    }

    public class DictionaryTransformationOptions
    {
        public KeyTransformationFormat KeyTransformationFormat { get; set; } = KeyTransformationFormat.CamelCase;

        public bool IgnoreNullValues { get; set; }

        public bool TransformChildren { get; set; } = false;

        public static DictionaryTransformationOptions Default => new();
    }
}