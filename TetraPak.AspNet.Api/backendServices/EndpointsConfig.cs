using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   A specialized <see cref="ConfigurationSection"/> for named URLs.
    /// </summary>
    public class EndpointsConfig : ConfigurationSection, IServiceAuthConfig, IEnumerable<KeyValuePair<string, BackendServiceEndpointUrl>>
    {
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType; 
        string _host;
        string _basePath;
        string _clientId;
        string _clientSecret;
        MultiStringValue _scope;
        // ReSharper restore NotAccessedField.Local
        
        protected override string SectionIdentifier { get; }
        
        public ServicesConfig ServicesConfig { get; }
        
        public string Path { get; }

        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.Inherited, 
                (string value, out GrantType grantType) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                        value = GrantType.Inherited.ToString();
                    
                    if (!TetraPakAuthConfig.TryParseEnum(value, out grantType))
                        throw new ConfigurationException($"Invalid auth mechanism: '{value}' ({Path}.{nameof(GrantType)})");

                    if (grantType == GrantType.Inherited)
                    {
                        grantType = ServicesConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }

        public virtual string ClientId
        {
            get => GetFromFieldThenSection<string>() ?? ServicesConfig.ClientId;
            set => _clientId = value;
        }

        public virtual string ClientSecret
        {
            get => GetFromFieldThenSection<string>() ?? ServicesConfig.ClientSecret;
            set => _clientSecret = value;
        }

        public virtual MultiStringValue Scope
        {
            get => GetFromFieldThenSection<MultiStringValue>() ?? ServicesConfig.Scope;
            set => _scope = value;
        }

        /// <summary>
        ///   The default host address.
        /// </summary>
        public string Host
        {
            get => GetFromFieldThenSection<string>(); 
            set => _host = value;
        }

        /// <summary>
        ///   A default base path.
        /// </summary>
        public string BasePath
        {
            get => GetFromFieldThenSection<string>(); 
            set => _basePath = value;
        }

        /// <summary>
        ///   Gets pre-configured client options. 
        /// </summary>
        public virtual HttpClientOptions ClientOptions => new HttpClientOptions { AuthConfig = this };

        public IEnumerator<KeyValuePair<string, BackendServiceEndpointUrl>> GetEnumerator()
        {
            var propertyArray = GetType().GetProperties().Where(i => 
                i.PropertyType == typeof(BackendServiceEndpointUrl)).ToArray();

            for (var i = 0; i < propertyArray.Length; i++)
            {
                var property = propertyArray[i];
                var value = (BackendServiceEndpointUrl) property.GetValue(this);
                if (value is null)
                {
                    Logger.Warning($"Unassigned endpoint: {Path}:{property.Name}");
                    continue;
                }
                
                yield return new KeyValuePair<string, BackendServiceEndpointUrl>(property.Name, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public EndpointsConfig(
            ServicesConfig servicesConfig, 
            ILogger<EndpointsConfig> logger, 
            string sectionIdentifier = "Endpoints")
        : base(servicesConfig.Configuration, logger, $"{servicesConfig.Path}:{sectionIdentifier}")
        {
            ServicesConfig = servicesConfig;
            SectionIdentifier = sectionIdentifier;
            if (string.IsNullOrEmpty(Host))
                throw new InvalidOperationException($"Missing configuration: {this}.{nameof(Host)}");
            
            Path = $"{servicesConfig.Path}:{sectionIdentifier}";
        }
    }
}