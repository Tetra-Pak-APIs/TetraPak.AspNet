using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   A specialized <see cref="ConfigurationSection"/> for named URLs.
    /// </summary>
    public class ServiceEndpoints : ConfigurationSection, 
        IServiceAuthConfig,
        IEnumerable<KeyValuePair<string, ServiceEndpointUrl>>
    {
        // ReSharper disable NotAccessedField.Local
        GrantType? _grantType; 
        string _host;
        string _basePath;
        string _clientId;
        string _clientSecret;
        MultiStringValue _scope;
        // ReSharper restore NotAccessedField.Local

        readonly Dictionary<string, ServiceEndpointUrl> _urls = new();
        List<Exception> _issues;

        public bool IsValid => _issues is null;

        public IEnumerable<Exception> GetIssues() => _issues;
        
        public ServicesAuthConfig ServicesAuthConfig { get; }

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

        public IEnumerator<KeyValuePair<string, ServiceEndpointUrl>> GetEnumerator()
        {
            var propertyArray = GetType().GetProperties().Where(i => 
                i.PropertyType == typeof(ServiceEndpointUrl)).ToArray();

            for (var i = 0; i < propertyArray.Length; i++)
            {
                var property = propertyArray[i];
                if (property.IsIndexer())
                    continue;
                
                var value = (ServiceEndpointUrl) property.GetValue(this);
                if (value is null)
                {
                    Logger.Warning($"Unassigned endpoint: {Path}:{property.Name}");
                    continue;
                }
                
                yield return new KeyValuePair<string, ServiceEndpointUrl>(property.Name, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ServiceEndpointUrl this[string endpointName] => getServiceEndpointUrl(endpointName);

        ServiceEndpointUrl getServiceEndpointUrl(string endpointName)
        {
            var property = GetType().GetProperties().FirstOrDefault(i => i.Name == endpointName && isEndpointUrl(i));
            if (property is { })
                return (ServiceEndpointUrl) property.GetValue(this);
            
            if (!IsValid)
                return ServicesAuthConfig.GetInvalidEndpointUrl(endpointName, GetIssues());

            if (_urls.TryGetValue(endpointName, out var endpointUrl))
                return endpointUrl;
                
            var value = Section[endpointName];
            if (string.IsNullOrWhiteSpace(value))
                ServicesAuthConfig.GetInvalidEndpointUrl(
                    endpointName, 
                    new[] {new FormatException("Missing url value")});
                
            try
            {
                endpointUrl = value;
                endpointUrl.SetBackendService(BackendService);
                _urls.Add(endpointName, endpointUrl);
                return endpointUrl;
            }
            catch (Exception ex)
            {
                return ServicesAuthConfig.GetInvalidEndpointUrl(
                    endpointName, 
                    new[] { new FormatException($"Invalid url: {value}") });
            }
        }

        void addIssue(Exception exception)
        {
            _issues ??= new List<Exception>();
            _issues.Add(exception);
        }

        void validate(string sectionIdentifier)
        {
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

        static bool isEndpointUrl(PropertyInfo property) => typeof(ServiceEndpointUrl).IsAssignableFrom(property.PropertyType);

        void initializeServiceEndpointProperties()
        {
            // initialize endpoint properties ...
            var endpointProperties = GetType().GetProperties()
                .Where(isEndpointUrl);
            foreach (var property in endpointProperties)
            {
                if (property.IsIndexer())
                    continue;
                
                var path = $"{Path}:{property.Name}";
                if (!property.CanWrite)
                {
                    Logger.Error(new InvalidOperationException($"Service Endpoint URL property {GetType()}.{property.Name} cannot be set. No setter found"));
                    continue;
                }
                
                var stringValue = Section[property.Name];
                if (stringValue is null)
                {
                    var issue = new ConfigurationException($"Missing endpoint configuration: {path}");
                    var invalidUrl = ServicesAuthConfig.GetInvalidEndpointUrl(property.Name, new[] {issue});
                    property.SetValue(this, invalidUrl);
                    continue;
                }

                var url = new ServiceEndpointUrl(stringValue);
                property.SetValue(this, url);
            }
        }

        public ServiceEndpoints(ServicesAuthConfig servicesAuthConfig, string sectionIdentifier = "Endpoints")
        : base(servicesAuthConfig.Section, servicesAuthConfig.Logger, sectionIdentifier)
        {
            ServicesAuthConfig = servicesAuthConfig;
            Path = $"{servicesAuthConfig.Path}:{sectionIdentifier}";
            validate(sectionIdentifier);
            initializeServiceEndpointProperties();
        }
    }
}