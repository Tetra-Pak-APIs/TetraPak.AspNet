using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

#nullable enable

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
        string? _host;
        string? _basePath;
        string? _clientId;
        string? _clientSecret;
        MultiStringValue? _scope;
        // ReSharper restore NotAccessedField.Local

        Dictionary<string, ServiceEndpoint> _endpoints;
        List<Exception>? _issues;

        public bool IsValid => _issues is null;

        public IEnumerable<Exception>? GetIssues() => _issues;
        
        public IServiceAuthConfig ServiceAuthConfig { get; private set; }
        
        public IHttpServiceProvider HttpServiceProvider { get; private set; }

        public IConfiguration Configuration => ServiceAuthConfig.Configuration;

        public AmbientData AmbientData => ServiceAuthConfig.AmbientData;

        public IServiceAuthConfig ParentConfig => ServiceAuthConfig;

        /// <inheritdoc />
        public bool IsAuthIdentifier(string identifier) => TetraPakAuthConfig.CheckIsAuthIdentifier(identifier);

        internal TetraPakAuthConfig AuthConfig => ((ServiceAuthConfig) ServiceAuthConfig).AuthConfig;
        
        [StateDump]
        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.Inherited, 
                (string value, out GrantType grantType) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                        value = GrantType.Inherited.ToString();
                    
                    if (!TetraPakAuthConfig.TryParseEnum(value, out grantType))
                        throw new ConfigurationException($"Invalid auth mechanism: '{value}' ({ConfigPath}.{nameof(GrantType)})");

                    if (grantType == GrantType.Inherited)
                    {
                        grantType = ServiceAuthConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }

        [StateDump]
        public virtual string? ClientId
        {
            get
            {
                if (AuthConfig.IsDelegated)
                    return ServiceAuthConfig.GetClientIdAsync(new AuthContext(GrantType, this)).Result;
                
                return GetFromFieldThenSection<string>() 
                       ?? ServiceAuthConfig.GetClientIdAsync(new AuthContext(GrantType, this)).Result;
            }
            set => _clientId = value?.Trim() ?? null!;
        }

        [StateDump]
        public virtual string? ClientSecret
        {
            get
            {
                if (AuthConfig.IsDelegated)
                    return ServiceAuthConfig.GetClientSecretAsync(new AuthContext(GrantType, this)).Result;
                
                return GetFromFieldThenSection<string>() 
                       ?? ServiceAuthConfig.GetClientSecretAsync(new AuthContext(GrantType, this)).Result;
            }
            set => _clientSecret = value?.Trim() ?? null!;
        }

        [StateDump]
        public virtual MultiStringValue Scope
        {
            get
            {
                if (AuthConfig.IsDelegated)
                    return ServiceAuthConfig.GetScopeAsync(new AuthContext(GrantType, this)).Result;
                
                return GetFromFieldThenSection<MultiStringValue>() 
                       ?? ServiceAuthConfig.GetScopeAsync(new AuthContext(GrantType, this), MultiStringValue.Empty).Result;
            }
            set => _scope = value;
        }
        
        /// <inheritdoc />
        public Task<Outcome<string>> GetClientIdAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (AuthConfig.IsDelegated || string.IsNullOrWhiteSpace(_clientId))
                return AuthConfig.GetClientIdAsync(authContext, cancellationToken);

            return Task.FromResult(Outcome<string>.Success(_clientId));
        }

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientSecretAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (AuthConfig.IsDelegated || string.IsNullOrWhiteSpace(_clientSecret))
                return AuthConfig.GetClientSecretAsync(new AuthContext(GrantType, this));

            return Task.FromResult(Outcome<string>.Success(_clientSecret));
        }

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext, 
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null)
        {
            if (AuthConfig.IsDelegated || string.IsNullOrWhiteSpace(_scope))
                return AuthConfig.GetScopeAsync(new AuthContext(GrantType, this));

            return Task.FromResult(Outcome<MultiStringValue>.Success(_scope));
        }

        /// <inheritdoc />
        public string GetConfiguredValue(string key) => Section[key];

        /// <summary>
        ///   The default host address.
        /// </summary>
        [StateDump]
        public string? Host
        {
            get => GetFromFieldThenSection<string>(); 
            set => _host = value;
        }

        /// <summary>
        ///   A default base path.
        /// </summary>
        [StateDump]
        public string? BasePath
        {
            get => GetFromFieldThenSection<string>(); 
            set => _basePath = value!;
        }

        /// <summary>
        ///   Gets pre-configured client options. 
        /// </summary>
        public virtual HttpClientOptions ClientOptions => new() { AuthConfig = this };

        internal IBackendService? BackendService { get; set; }
        
        internal bool IsDelegated => AuthConfig.IsDelegated;

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
        public ServiceEndpoint GetEndpoint([CallerMemberName] string propertyName = null!) 
            =>
            getServiceEndpoint(propertyName);
        
        public ServiceEndpoint this[string endpointName] => getServiceEndpoint(endpointName);

        ServiceEndpoint getServiceEndpoint(string endpointName)
        {
            if (!_endpoints.TryGetValue(endpointName, out var endpoint))
            {
                if (_endpoints.Count == 0 && getServiceEndpointFromConfiguration(endpointName, out endpoint))
                    return endpoint;

                return ((ServiceAuthConfig) ServiceAuthConfig).GetInvalidEndpoint(
                    endpointName, 
                    new[]
                    {
                        new ArgumentOutOfRangeException(nameof(endpointName), $"Missing endpoint: {endpointName}")
                    });
            }

            return endpoint;
        }

        void addIssue(Exception exception)
        {
            _issues ??= new List<Exception>();
            _issues.Add(exception);
        }

        void validate(string sectionIdentifier)
        {
            if (ParentConfiguration == Section)
                return;
            
            if (!ParentConfiguration.ContainsKey(sectionIdentifier))
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
        
        bool getServiceEndpointFromConfiguration(string endpointName, out ServiceEndpoint? endpoint)
        {
            endpoint = null;
            if (ParentConfiguration is null)
                return false;

            var child = ParentConfiguration.GetChildren().FirstOrDefault(i => i.Key == endpointName);
            if (child is null)
                return false;

            endpoint = new ServiceEndpoint(child.Value).WithIdentity(endpointName, this).WithConfig(child);
            endpoint.SetBackendService(BackendService);
            return true;
        }

        Dictionary<string, ServiceEndpoint> initializeEndpoints()
        {
            var type = GetType();
            var children = Section!.GetChildren();
            var endpoints = new Dictionary<string, ServiceEndpoint>();
            foreach (var child in children)
            {
                var name = child.Key;
                if (isReservedIdentifier(name))
                    continue;

                var property = type.GetProperty(name);
                var stringValue = child.Value;
                ServiceEndpoint endpoint;
                if (stringValue is { })
                {
                    endpoint = new ServiceEndpoint(stringValue).WithIdentity(name, this).WithConfig(child);
                    addEndpoint(endpoint, property);
                    continue;
                }

                if (child.IsEmpty())
                    continue;
                
                endpoint = configureServiceEndpoint(child);
                addEndpoint(endpoint, property);
            }

            return endpoints;
            
            void addEndpoint(ServiceEndpoint url, PropertyInfo? property)
            {
                if (!endpoints.ContainsKey(url.Name))
                {
                    endpoints.Add(url.Name, url);
                    if (property?.CanWrite ?? false)
                    {
                        property.SetValue(this, url);
                    }
                    return;
                }
            
                var invalidUrl = ((ServiceAuthConfig) ServiceAuthConfig).GetInvalidEndpoint(url.Name, new[]
                {
                    new ConfigurationException($"Same endpoint was configured multiple times: {url.ConfigPath}")
                });
                endpoints[url.Name] = invalidUrl;
                property?.SetValue(this, invalidUrl);
            }
        }

        bool isReservedIdentifier(string name)
        {
            return name switch
            {
                nameof(Host) => true,
                nameof(BasePath) => true,
                 "this" => true,
                _ => ((ServiceAuthConfig) ServiceAuthConfig).IsAuthIdentifier(name)
            };
        }

        ServiceEndpoint configureServiceEndpoint(IConfigurationSection section)
        {
            var pathSection = section.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("path", StringComparison.InvariantCultureIgnoreCase));
            
            if (pathSection is null)
                return ((ServiceAuthConfig) ServiceAuthConfig).GetInvalidEndpoint(section.Key, new []
                {
                    new Exception("Missing endpoint 'Path' value")
                });

            var path = pathSection.Value;
            return new ServiceEndpoint(path).WithIdentity(section.Key, this).WithConfig(section);
        }

        public ServiceEndpoints(
            IServiceAuthConfig serviceAuthConfig, 
            IHttpServiceProvider httpServiceProvider,
            string serviceName)
        : base(serviceAuthConfig.Configuration, serviceAuthConfig.AmbientData.Logger, serviceName)
        {
            ServiceAuthConfig = serviceAuthConfig;
            HttpServiceProvider = httpServiceProvider;
            validate(serviceName);
            _endpoints = initializeEndpoints();
        }

        internal static ServiceEndpoints MakeTypedEndpoints(
            Type endpointsType,
            ServiceEndpoints configuredEndpoints)
        {
            var constructors = endpointsType.GetTypeInfo().DeclaredConstructors;
            foreach (var c in constructors)
            {
                var args = c.GetParameters();
                if (args.Length == 0)
                    return ((ServiceEndpoints) c.Invoke(null)).Initialize(configuredEndpoints);
            }

            throw new InvalidOperationException($"Failed to construct service endpoints {endpointsType}. Could not find a parameterless ctor");
        }

        internal ServiceEndpoints Initialize(ServiceEndpoints configuredEndpoints)
        {
            ServiceAuthConfig = configuredEndpoints.ServiceAuthConfig;
            BackendService = configuredEndpoints.BackendService;
            HttpServiceProvider = configuredEndpoints.HttpServiceProvider;
            _endpoints = configuredEndpoints._endpoints;
            return this;
        }

        /// <summary>
        ///   To be used by automatic initialization (see <see cref="TetraPakServiceHelper.AddTetraPakServices"/>).
        /// </summary>
#pragma warning disable 8618
        protected ServiceEndpoints()
        {
        }
#pragma warning restore 8618
    }
}