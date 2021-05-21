using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace TetraPak.AspNet.Api
{
    public class Endpoints : ConfigSection, IEnumerable<KeyValuePair<string, EndpointUrl>>
    {
        public string Host { get; set; }

        public string BasePath { get; set; }

        protected override void OnSetProperty(PropertyInfo property, object value)
        {
            if (value is string stringValue && property.PropertyType.IsAssignableFrom(typeof(EndpointUrl)))
            {
                value = new EndpointUrl(stringValue);
            }
            base.OnSetProperty(property, value);
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Endpoints(IConfiguration configuration, string sectionId = "Endpoints")
        : base(configuration, sectionId)
        {
        }
    }

    public static class EndpointsConfigExtensions
    {
        public static Uri GetUri(this Endpoints self, string path) 
            => new Uri($"{self.Host}{self.BasePath}{path}");
        
        public static void SetBackendService(this Endpoints self, IBackendService backendService)
        {
            foreach (var (propertyName, endpointUrl)  in self)
            {
                endpointUrl.SetBackendService(backendService);
            }
        }
    }
    
}