using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.diagnostics;
using TetraPak.AspNet.Diagnostics;
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
        IAccessTokenProvider,
        IHttpClientProvider,
        IAuthorizationService,
        ITetraPakDiagnosticsProvider,
        IEnumerable<KeyValuePair<string, ServiceEndpoint>>
    {
        internal const string DefaultPath = "/"; 
        
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
        MultiStringValue? _methods;
        bool? _trimHostInResponses;

        /// <summary>
        ///   Gets the Tetra Pak integration configuration.
        /// </summary>
        public TetraPakConfig TetraPakConfig { get; }
        
        /// <summary>
        ///   Returns a value indicating whether the collection of endpoints are valid as a whole (no issues found).
        /// </summary>
        /// <seealso cref="GetIssues"/>
        public bool IsValid => _issues is null;

        /// <summary>
        ///   Gets all issues found during initialization (typically related to configuration).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Exception>? GetIssues() => _issues;
        
        /// <summary>
        ///   Gets the service auth configuration.
        /// </summary>
        public IServiceAuthConfig ServiceAuthConfig { get; private set; }

        internal IHttpClientProvider HttpClientProvider { get; set; }
        
        internal IAuthorizationService AuthorizationService { get; set; }
        
        /// <summary>
        ///   Gets a globally available <see cref="IConfiguration"/> instance.
        /// </summary>
        public IConfiguration Configuration => ServiceAuthConfig.Configuration;

        /// <summary>
        ///   Gets an <see cref="AmbientData"/> object.
        /// </summary>
        public AmbientData AmbientData => ServiceAuthConfig.AmbientData;

        /// <summary>
        ///   Gets the parent configuration level.
        /// </summary>
        public IServiceAuthConfig ParentConfig => ServiceAuthConfig;

        /// <inheritdoc />
        public bool IsAuthIdentifier(string identifier) => TetraPakConfig.CheckIsAuthIdentifier(identifier);

        internal TetraPakConfig Config => ((ServiceAuthConfig) ServiceAuthConfig).Config;

        internal CancellationToken? ContextCancellationToken => AmbientData.HttpContext?.RequestAborted;
        
        /// <inheritdoc />
        public Task<Outcome<HttpClient>> GetHttpClientAsync(HttpClientOptions? options = null,
            CancellationToken? cancellationToken = null)
            => HttpClientProvider.GetHttpClientAsync(options, cancellationToken);

        /// <inheritdoc />
        public Task<Outcome<ActorToken>> GetAccessTokenAsync(bool forceStandardHeader = false)
            => AmbientData.GetAccessTokenAsync(forceStandardHeader); 

        /// <inheritdoc />
        public Task<Outcome<ActorToken>> AuthorizeAsync(HttpClientOptions options, CancellationToken? cancellationToken = null) 
            => AuthorizationService.AuthorizeAsync(options, cancellationToken);

        /// <summary>
        ///   Gets or sets the type of grant used for request authorization.
        /// </summary>
        /// <exception cref="ServerConfigurationException">
        ///   The configured value was incorrect (could not be parsed into <see cref="GrantType"/>).
        /// </exception>
        [StateDump]
        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.Inherited, 
                (string? value, out GrantType grantType) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                        value = GrantType.Inherited.ToString();
                    
                    if (!TetraPakConfig.TryParseEnum(value, out grantType))
                        throw new ServerConfigurationException($"Invalid auth mechanism: '{value}' ({ConfigPath}.{nameof(GrantType)})");

                    if (grantType == GrantType.Inherited)
                    {
                        grantType = ServiceAuthConfig.GrantType;
                    }

                    return true;
                });
            set => _grantType = value;
        }

        /// <summary>
        ///   Gets or sets a client identity to be submitted when requesting authorization.
        /// </summary>
        [StateDump]
        public virtual string? ClientId
        {
            get
            {
                if (Config.IsDelegated)
                    return ServiceAuthConfig.GetClientIdAsync(new AuthContext(GrantType, this)).Result!;
                
                return GetFromFieldThenSection<string>() 
                       ?? ServiceAuthConfig.GetClientIdAsync(new AuthContext(GrantType, this)).Result!;
            }
            set => _clientId = value?.Trim() ?? null!;
        }

        /// <summary>
        ///   Gets or sets a client secret to be submitted when requesting authorization.
        /// </summary>
        [StateDump, RestrictedValue(DisclosureLogLevel = LogLevel.Debug)]
        public virtual string? ClientSecret
        {
            get
            {
                if (Config.IsDelegated)
                    return ServiceAuthConfig.GetClientSecretAsync(new AuthContext(GrantType, this)).Result!;
                
                return GetFromFieldThenSection<string>() 
                       ?? ServiceAuthConfig.GetClientSecretAsync(new AuthContext(GrantType, this)).Result!;
            }
            set => _clientSecret = value?.Trim() ?? null!;
        }

        /// <summary>
        ///   Gets or sets a scope to be requested for authorization.
        /// </summary>
        [StateDump]
        public virtual MultiStringValue Scope
        {
            get
            {
                if (Config.IsDelegated)
                    return ServiceAuthConfig.GetScopeAsync(new AuthContext(GrantType, this)).Result!;
                
                return GetFromFieldThenSection<MultiStringValue>() 
                       ?? ServiceAuthConfig.GetScopeAsync(new AuthContext(GrantType, this), MultiStringValue.Empty).Result!;
            }
            set => _scope = value;
        }
        
        /// <inheritdoc />
        public Task<Outcome<string>> GetClientIdAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (Config.IsDelegated || string.IsNullOrWhiteSpace(_clientId))
                return Config.GetClientIdAsync(authContext, cancellationToken);

            return Task.FromResult(Outcome<string>.Success(_clientId));
        }

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientSecretAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (Config.IsDelegated || string.IsNullOrWhiteSpace(_clientSecret))
                return Config.GetClientSecretAsync(new AuthContext(GrantType, this));

            return Task.FromResult(Outcome<string>.Success(_clientSecret));
        }

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext, 
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null)
        {
            if (Config.IsDelegated || string.IsNullOrWhiteSpace(_scope))
                return Config.GetScopeAsync(new AuthContext(GrantType, this));

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
        ///   Gets a value that specifies whether to always remove the host element from relationship URLs
        ///   based on this endpoint. If not specified in configuration the value will fall back to the
        ///   configuration service level (the endpoint "parent" section). 
        /// </summary>
        [StateDump]
        public bool TrimHostInResponses
        {
            get => _trimHostInResponses ?? TetraPakConfig.TrimHostInResponses;
            set => _trimHostInResponses = value;
        }

        /// <summary>
        ///   Gets pre-configured client options. 
        /// </summary>
        public virtual HttpClientOptions ClientOptions => new() { AuthConfig = this };

        internal IBackendService? BackendService { get; set; }
        
        internal bool IsDelegated => Config.IsDelegated;
        
        
        /// <summary>
        ///   Gets or sets a (comma separated) list of allowed HTTP methods.
        /// </summary>
        [StateDump]
        public virtual MultiStringValue? Methods
        {
            get => GetFromFieldThenSection<string>() 
                   ?? ServiceAuthConfig.GetClientSecretAsync(new AuthContext(GrantType, this)).Result!;
            set => _methods = value;
        }

        public void DiagnosticsStartTimer(string timerKey) => AmbientData.HttpContext?.GetDiagnostics()?.StartTimer(timerKey);

        public void DiagnosticsEndTimer(string timerKey) => AmbientData.HttpContext?.GetDiagnostics()?.GetElapsedMs(timerKey);

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
        public ServiceEndpoint GetEndpoint([CallerMemberName] string propertyName = null!) 
            =>
            getServiceEndpoint(propertyName);
        
        /// <summary>
        ///   Gets a named endpoint (<see cref="ServiceEndpoint"/>).
        /// </summary>
        /// <param name="endpointName">
        ///   The name of the endpoint.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="endpointName"/> was unassigned (<c>null</c> or just whitespace).
        /// </exception>
        public ServiceEndpoint this[string endpointName] => getServiceEndpoint(endpointName);

        ServiceEndpoint getServiceEndpoint(string? endpointName)
        {
            if (string.IsNullOrWhiteSpace(endpointName))
                throw new ArgumentNullException(nameof(endpointName));
                
            if (_endpoints.TryGetValue(endpointName, out var endpoint)) 
                return endpoint;
            
            if (_endpoints.Count == 0 && getServiceEndpointFromConfiguration(endpointName, out endpoint))
                return endpoint!;

            return ((ServiceAuthConfig) ServiceAuthConfig).GetInvalidEndpoint(
                endpointName, 
                new[]
                {
                    new ArgumentOutOfRangeException(nameof(endpointName), $"Missing endpoint: {endpointName}")
                });
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
                addIssue(new ServerConfigurationException($"Missing configuration section: {sectionIdentifier}"));
                return;
            }

            if (Section.IsEmpty())
            {
                addIssue(new ServerConfigurationException($"Configuration section: {sectionIdentifier} is empty"));
                return;
            }

            if (string.IsNullOrEmpty(Host))
            {
                addIssue(new ServerConfigurationException($"Missing configuration: {this}.{nameof(Host)}"));
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

            endpoint = new ServiceEndpoint(child.Value)
                .WithIdentity(endpointName, this)
                .WithConfig(TetraPakConfig, child);
            endpoint.SetBackendService(BackendService!);
            return true;
        }

        Dictionary<string, ServiceEndpoint> initialize(TetraPakConfig tetraPakConfig)
        {
            var type = GetType();
            var children = Section!.GetChildren();
            var endpoints = new Dictionary<string, ServiceEndpoint>();
            string name;
            PropertyInfo? property;
            ServiceEndpoint endpoint;
            foreach (var child in children)
            {
                name = child.Key;
                if (isReservedIdentifier(name))
                    continue;

                property = type.GetProperty(name);
                var stringValue = child.Value;
                if (stringValue is { })
                {
                    endpoint = new ServiceEndpoint(stringValue)
                        .WithIdentity(name, this)
                        .WithConfig(tetraPakConfig, child);
                    addEndpoint(endpoint);
                    continue;
                }

                if (child.IsEmpty())
                    continue;
                
                endpoint = configureServiceEndpoint(child);
                addEndpoint(endpoint);
            }

            if (endpoints.Any()) 
                return endpoints;
            
            // the service is just one endpoint (URL) ...
            name = Section.Key;
            if (!Uri.TryCreate(Section.Value, UriKind.Absolute, out var uri))
                throw new ServerConfigurationException($"Invalid backend service value: {Section.Value} (expected absolute URI)");

            Host = $"{uri.Scheme}://{uri.Authority}";
            BasePath = uri.AbsolutePath;
            property = type.GetProperty(name);
            endpoint = new ServiceEndpoint(DefaultPath)
                .WithIdentity(Section.Key, this)
                .WithConfig(tetraPakConfig, Section);
            addEndpoint(endpoint);

            return endpoints;
            
            void addEndpoint(ServiceEndpoint url)
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
                    new ServerConfigurationException($"Same endpoint was configured multiple times: {url.ConfigPath}")
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
            return new ServiceEndpoint(path)
                .WithIdentity(section.Key, this)
                .WithConfig(TetraPakConfig, section);
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
            AuthorizationService = configuredEndpoints.AuthorizationService;
            HttpClientProvider = configuredEndpoints.HttpClientProvider;
            Host = configuredEndpoints.Host;
            BasePath = configuredEndpoints.BasePath;
            Section = configuredEndpoints.Section;
            _endpoints = configuredEndpoints._endpoints;
            return this;
        }

        /// <summary>
        ///   Initializes the <see cref="ServiceEndpoint"/>.
        /// </summary>
        /// <param name="tetraPakConfig">
        ///   Initializes <see cref="TetraPakConfig"/>.
        /// </param>
        /// <param name="serviceAuthConfig">
        ///   Initializes <see cref="ServiceAuthConfig"/>.
        /// </param>
        /// <param name="httpHttpClientProvider">
        ///   A Http Client factory.
        /// </param>
        /// <param name="authorizationService">
        ///   Allows client authorization.
        /// </param>
        /// <param name="section">
        ///   The service configuration section.
        /// </param>
        internal ServiceEndpoints(
            TetraPakConfig tetraPakConfig,
            IServiceAuthConfig serviceAuthConfig, 
            IHttpClientProvider httpHttpClientProvider,
            IAuthorizationService authorizationService,
            IConfigurationSection section)
        : base(serviceAuthConfig.Configuration, serviceAuthConfig.AmbientData.Logger, section.Key)
        {
            AuthorizationService = authorizationService;
            TetraPakConfig = tetraPakConfig; 
            ServiceAuthConfig = serviceAuthConfig;
            HttpClientProvider = httpHttpClientProvider;
            var serviceName = section.Key;
            validate(serviceName);
            _endpoints = initialize(tetraPakConfig);
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