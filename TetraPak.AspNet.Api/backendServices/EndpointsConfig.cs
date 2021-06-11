using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   A specialized <see cref="ConfigurationSection"/> for named URLs.
    /// </summary>
    public class EndpointsConfig : ConfigurationSection, IEnumerable<KeyValuePair<string, EndpointUrl>>
    {
        protected override string SectionIdentifier { get; }

        /// <summary>
        ///   The default host address.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        ///   A default base path.
        /// </summary>
        public string BasePath { get; set; }
        
        void setProperty(PropertyInfo property, object value)
        {
            if (value is string stringValue && property.PropertyType.IsAssignableFrom(typeof(EndpointUrl)))
            {
                value = new EndpointUrl(stringValue);
            }
            if (property.PropertyType == typeof(string))
            {
                property.SetValue(this, value);
                return;
            }
            
            var obj = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(this, obj);
        }

        public IEnumerator<KeyValuePair<string, EndpointUrl>> GetEnumerator()
        {
            var propertyArray = GetType().GetProperties().Where(i => 
                i.PropertyType == typeof(EndpointUrl)).ToArray();

            for (var i = 0; i < propertyArray.Length; i++)
            {
                var property = propertyArray[i];
                var value = (EndpointUrl) property.GetValue(this);
                yield return new KeyValuePair<string, EndpointUrl>(property.Name, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        void assignProperties(IConfiguration configuration)
        {
            var properties = GetType().GetProperties();
            foreach (var property in properties.Where(i => i.CanWrite))
            {
                var value = configuration[property.Name];
                if (value is null)
                    continue;
        
                setProperty(property, value);
            }
        }

        public EndpointsConfig(IConfiguration configuration, ILogger logger, string sectionIdentifier = "Endpoints")
        : base(configuration, logger, sectionIdentifier)
        {
            SectionIdentifier = sectionIdentifier;
            if (string.IsNullOrEmpty(Host))
                throw new InvalidOperationException($"Missing configuration: {this}.{nameof(Host)}");
            
            assignProperties(Section);
        }
    }

    public static class EndpointsConfigExtensions
    {
        public static Uri GetUri(this EndpointsConfig self, string path) 
            => new Uri($"{self.Host}{self.BasePath}{path}");
        
        public static void SetBackendService(this EndpointsConfig self, IBackendService backendService)
        {
            foreach (var (propertyName, endpointUrl)  in self)
            {
                endpointUrl.SetBackendService(backendService);
            }
        }
    }
    
}