using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   A specialized <see cref="ConfigurationSection"/> for named URLs.
    /// </summary>
    public class ServiceEndpoints : ConfigurationSection, 
        IServiceAuthConfig,
        IEnumerable<KeyValuePair<string, ServiceEndpoint>>
    {
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType; 
        string _host;
        string _basePath;
        string _clientId;
        string _clientSecret;
        MultiStringValue _scope;
        // ReSharper restore NotAccessedField.Local

        readonly Dictionary<string, ServiceEndpoint> _endpoints = new();
        List<Exception> _issues;

        public bool IsValid => _issues is null;

        public IEnumerable<Exception> GetIssues() => _issues;
        
        public ServicesAuthConfig ServicesAuthConfig { get; }

        internal AmbientData AmbientData => ServicesAuthConfig.AmbientData;

        internal TetraPakAuthConfig AuthConfig => ServicesAuthConfig.AuthConfig;
        
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
                        grantType = ServicesAuthConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }

        public virtual string ClientId
        {
            get => GetFromFieldThenSection<string>() ?? ServicesAuthConfig.ClientId;
            set => _clientId = value;
        }

        public virtual string ClientSecret
        {
            get => GetFromFieldThenSection<string>() ?? ServicesAuthConfig.ClientSecret;
            set => _clientSecret = value;
        }

        public virtual MultiStringValue Scope
        {
            get => GetFromFieldThenSection<MultiStringValue>() ?? ServicesAuthConfig.Scope;
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
        public virtual HttpClientOptions ClientOptions => new() { AuthConfig = this };

        internal IBackendService BackendService { get; set; }

        public IEnumerator<KeyValuePair<string, ServiceEndpoint>> GetEnumerator()
        {
            foreach (var (key, value) in _endpoints)
            {
                yield return new KeyValuePair<string, ServiceEndpoint>(key, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        ///   Gets a named endpoint. Intended to be called from endpoint properties getter.
        /// </summary>
        /// <param name="propertyName">
        ///   The (property) name of the endpoint.
        /// </param>
        /// <returns>
        ///   A <see cref="ServiceEndpoint"/> object on success,
        ///   or a <see cref="ServiceInvalidEndpoint"/> on failure.
        /// </returns>
        public ServiceEndpoint GetEndpoint([CallerMemberName] string propertyName = null) =>
            getServiceEndpoint(propertyName);
        
        public ServiceEndpoint this[string endpointName] => getServiceEndpoint(endpointName);

        ServiceEndpoint getServiceEndpoint(string endpointName)
        {
            if (!_endpoints.TryGetValue(endpointName, out var endpoint))
                return ServicesAuthConfig.GetInvalidEndpoint(
                    endpointName, 
                    new[] {new ArgumentOutOfRangeException(nameof(endpointName), $"Missing endpoint: {endpointName}")});

            return endpoint;
        }

        void addIssue(Exception exception)
        {
            _issues ??= new List<Exception>();
            _issues.Add(exception);
        }

        void validate(string sectionIdentifier)
        {
            if (ParentSection == Section)
                return;
            
            if (!ParentSection.ContainsKey(sectionIdentifier))
            {
                addIssue(new ConfigurationException($"Missing configuration section: {sectionIdentifier}"));
                return;
            }

            if (Section.IsEmpty())
            {
                addIssue(new ConfigurationException($"Configuration section: {sectionIdentifier} is empty"));
                return;
            }

            if (string.IsNullOrEmpty(Host))
            {
                addIssue(new ConfigurationException($"Missing configuration: {this}.{nameof(Host)}"));
            }
        }

        // static bool isEndpoint(PropertyInfo property) => typeof(ServiceEndpoint).IsAssignableFrom(property.PropertyType); obsolete

        void initializeEndpoints()
        {
            var type = GetType();
            var children = Section.GetChildren();
            foreach (var child in children)
            {
                var name = child.Key;
                if (isReservedIdentifier(name))
                    continue;

                var property = type.GetProperty(name);
                var stringValue = Section[name];
                ServiceEndpoint url;
                if (stringValue is { })
                {
                    url = new ServiceEndpoint(stringValue).WithIdentity(name, this);
                    addUrl(url, property);
                    continue;
                }

                var section = Section.GetSection(name);
                if (section is null || section.IsEmpty()) 
                    continue;
                
                url = configureServiceEndpoint(section);
                addUrl(url, property);
            }
        }

        bool isReservedIdentifier(string name)
        {
            return name switch
            {
                nameof(Host) => true,
                nameof(BasePath) => true,
                 "this" => true,
                _ => ServicesAuthConfig.IsAuthIdentifier(name)
            };
        }

        void addUrl(ServiceEndpoint url, PropertyInfo property)
        {
            if (!_endpoints.ContainsKey(url.Name))
            {
                _endpoints.Add(url.Name, url);
                if (property?.CanWrite ?? false)
                {
                    property.SetValue(this, url);
                }
                return;
            }
            
            var invalidUrl = ServicesAuthConfig.GetInvalidEndpoint(url.Name, new[]
            {
                new ConfigurationException($"Same endpoint was configured multiple times: {url.Path}")
            });
            _endpoints[url.Name] = invalidUrl;
            property?.SetValue(this, invalidUrl);
        }

        ServiceEndpoint configureServiceEndpoint(IConfigurationSection section)
        {
            var pathSection = section.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("path", StringComparison.InvariantCultureIgnoreCase));
            
            if (pathSection is null)
                return ServicesAuthConfig.GetInvalidEndpoint(section.Key, new []
                {
                    new Exception("Missing endpoint 'Path' value")
                });

            var path = pathSection.Value;

            var grantTypeSection = section.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("grantType", StringComparison.InvariantCultureIgnoreCase));
            var grantType = parseGrantType(grantTypeSection?.Value, GrantType.Inherited);
            var clientId = section.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("clientId", StringComparison.InvariantCultureIgnoreCase))?.Value;
            var clientSecret = section.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("clientSecret", StringComparison.InvariantCultureIgnoreCase))?.Value;
            var scope = section.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("scope", StringComparison.InvariantCultureIgnoreCase))?.Value;

            return new ServiceEndpoint(path).WithIdentity(section.Key, this)
                .WithConfig(grantType, clientId, clientSecret, scope);
        }

        static GrantType parseGrantType(string stringValue, GrantType useDefault)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
                return useDefault;

            return !Enum.TryParse<GrantType>(stringValue, out var grantType)
                ? useDefault
                : grantType;
        }
        
        public ServiceEndpoints(ServicesAuthConfig servicesAuthConfig, string sectionIdentifier = "Endpoints")
        : base(servicesAuthConfig.Section, servicesAuthConfig.Logger, sectionIdentifier)
        {
            ServicesAuthConfig = servicesAuthConfig;
            Path = $"{servicesAuthConfig.Path}:{sectionIdentifier}";
            validate(sectionIdentifier);
            initializeEndpoints();
        }
    }
}