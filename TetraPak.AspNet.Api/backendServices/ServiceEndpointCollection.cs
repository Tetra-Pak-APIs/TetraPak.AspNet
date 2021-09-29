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
    public class ServiceEndpointCollection : ConfigurationSection, 
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

        readonly Dictionary<string, ServiceEndpoint> _endpoints = new();
        List<Exception>? _issues;

        /// <summary>
        ///   Gets a value indicating that the endpoints (configuration) is valid (no unresolved issues where found).
        /// </summary>
        /// <seealso cref="GetIssues"/>
        public bool IsValid => _issues is null;

        /// <summary>
        ///   Gets a collection of unresolved issues found for the endpoints. 
        /// </summary>
        /// <returns>
        ///   A collection of <see cref="Exception"/>, or <c>null</c>.
        /// </returns>
        /// <seealso cref="IsValid"/>
        public IEnumerable<Exception>? GetIssues() => _issues;
        
        /// <summary>
        ///   Gets the service auth configuration.
        /// </summary>
        public IServiceAuthConfig ServiceAuthConfig { get; private set; }

        /// <inheritdoc />
        public IConfiguration Configuration => ServiceAuthConfig.Configuration;

        /// <inheritdoc />
        public AmbientData AmbientData => ServiceAuthConfig.AmbientData;

        /// <inheritdoc />
        public IServiceAuthConfig ParentConfig => ServiceAuthConfig;

        internal TetraPakAuthConfig AuthConfig => ((ServiceAuthConfig) ServiceAuthConfig).AuthConfig;
        
        /// <summary>
        ///   Gets or sets the grant type (a.k.a. OAuth "flow") used at this configuration level.
        /// </summary>
        /// <exception cref="ConfigurationException"></exception>
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

        /// <summary>
        ///   Gets or sets a configured client id at this configuration level.
        /// </summary>
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

        /// <summary>
        ///   Gets or sets a configured client secret at this configuration level.
        /// </summary>
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

        /// <summary>
        ///   Gets or sets a scope of identity claims, a this configuration level,
        ///   to be requested while authenticating the identity. When omitted a default scope will be used.
        /// </summary>
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
        public string GetConfiguredValue(string key) => Section![key];

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

        internal IBackendService BackendService { get; set; }
        
        internal bool IsDelegated => AuthConfig.IsDelegated;

        /// <inheritdoc />
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
        public ServiceEndpoint GetEndpoint([CallerMemberName] string propertyName = null!) =>
            getServiceEndpoint(propertyName);
        
        /// <summary>
        ///   Gets a named <see cref="ServiceEndpoint"/>.
        /// </summary>
        /// <param name="endpointName">
        ///   The name of the requested <see cref="ServiceEndpoint"/>.
        /// </param>
        public ServiceEndpoint this[string endpointName] => getServiceEndpoint(endpointName);

        ServiceEndpoint getServiceEndpoint(string endpointName)
        {
            if (!_endpoints.TryGetValue(endpointName, out var endpoint))
                return ((ServiceAuthConfig) ServiceAuthConfig).GetInvalidEndpoint(
                    endpointName, 
                    new[]
                    {
                        new ArgumentOutOfRangeException(nameof(endpointName), $"Missing endpoint: {endpointName}")
                    });

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

        void initializeEndpoints()
        {
            var type = GetType();
            var children = Section!.GetChildren();
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

        void addEndpoint(ServiceEndpoint url, PropertyInfo? property)
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
            
            var invalidUrl = ((ServiceAuthConfig) ServiceAuthConfig).GetInvalidEndpoint(url.Name, new[]
            {
                new ConfigurationException($"Same endpoint was configured multiple times: {url.ConfigPath}")
            });
            _endpoints[url.Name] = invalidUrl;
            property?.SetValue(this, invalidUrl);
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

        /// <summary>
        ///   Called during object initialization (from ctor) to initialize all endpoints from the
        ///   service's configuration (<paramref name="serviceAuthConfig"/>).
        /// </summary>
        /// <param name="serviceAuthConfig">
        ///   Provides access to the service configuration.
        /// </param>
        /// <param name="sectionIdentifier">
        ///   Identifies the service configuration section.
        /// </param>
        protected virtual void OnInitializeEndpoints(IServiceAuthConfig serviceAuthConfig, string sectionIdentifier)
        {
            ServiceAuthConfig = serviceAuthConfig;
            validate(sectionIdentifier);
            initializeEndpoints();
        }

        void initialize(IServiceAuthConfig serviceAuthConfig, string sectionIdentifier)
        {
            OnInitializeEndpoints(serviceAuthConfig, sectionIdentifier);
        }
        
#pragma warning disable 8618
        /// <summary>
        ///   Initializes the <see cref="ServiceEndpointCollection"/>.
        /// </summary>
        /// <param name="serviceAuthConfig">
        ///   Provides access to the service configuration.
        /// </param>
        /// <param name="sectionIdentifier">
        ///   Identifies the service configuration section.
        /// </param>
        public ServiceEndpointCollection(IServiceAuthConfig serviceAuthConfig, string sectionIdentifier = "Endpoints")
        : base(serviceAuthConfig.Configuration, serviceAuthConfig.AmbientData.Logger, sectionIdentifier)
        {
            initialize(serviceAuthConfig, sectionIdentifier);
        }
#pragma warning restore 8618

        internal class UntypedServiceEndpointCollection : ServiceEndpointCollection
        {
            protected override void OnInitializeEndpoints(IServiceAuthConfig serviceAuthConfig, string sectionIdentifier)
            {
                SetSection(ParentConfiguration as IConfigurationSection);
                base.OnInitializeEndpoints(serviceAuthConfig, sectionIdentifier);
            }

            public UntypedServiceEndpointCollection(
                IServiceAuthConfig serviceAuthConfig, 
                string sectionIdentifier = "Endpoints") 
            : base(serviceAuthConfig, sectionIdentifier)
            {
            }
        }
    }
}