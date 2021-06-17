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
    public class EndpointsConfig : ConfigurationSection, IEnumerable<KeyValuePair<string, BackendServiceEndpointUrl>>
    {
        // ReSharper disable NotAccessedField.Local
        BackendServiceAuthenticationMechanism? _authenticationMechanism;
        // ReSharper restore NotAccessedField.Local
        
        protected override string SectionIdentifier { get; }

        /// <summary>
        ///   The default host address.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        ///   A default base path.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        ///   Gets or sets a value specifying how to authenticate this service when consuming the backend service.
        ///   Default is <see cref="BackendServiceAuthenticationMechanism.TokenExchange"/>.
        /// </summary>
        public BackendServiceAuthenticationMechanism AuthenticationMechanism
        {
            get => GetFromFieldThenSection(BackendServiceAuthenticationMechanism.TokenExchange);
            set => _authenticationMechanism = value;
        }
        
        void setProperty(PropertyInfo property, object value)
        {
            if (value is string stringValue && property.PropertyType.IsAssignableFrom(typeof(BackendServiceEndpointUrl)))
            {
                value = new BackendServiceEndpointUrl(stringValue);
            }
            if (property.PropertyType == typeof(string))
            {
                property.SetValue(this, value);
                return;
            }
            
            var obj = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(this, obj);
        }

        public IEnumerator<KeyValuePair<string, BackendServiceEndpointUrl>> GetEnumerator()
        {
            var propertyArray = GetType().GetProperties().Where(i => 
                i.PropertyType == typeof(BackendServiceEndpointUrl)).ToArray();

            for (var i = 0; i < propertyArray.Length; i++)
            {
                var property = propertyArray[i];
                var value = (BackendServiceEndpointUrl) property.GetValue(this);
                yield return new KeyValuePair<string, BackendServiceEndpointUrl>(property.Name, value);
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
}