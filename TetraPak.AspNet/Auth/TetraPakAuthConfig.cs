using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Debugging;
using TetraPak.AspNet.OpenIdConnect;
using TetraPak.Caching;
using TetraPak.Logging;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakAuthConfig : ConfigurationSection, IServiceAuthConfig
    {
        public const string Identifier = "TetraPak";
        
        static readonly object s_syncRoot = new();
        static readonly MultiStringValue s_defaultScope = new(new []{ "general", "profile", "email", "openid" });

        const string KeyAuthorityUrl = "KeyAuthorityUrl";
        const string KeyTokenIssuerUrl = "TokenIssuerUrl";
        const string KeyUserInfoUrl = "UserInfoUrl";
        const string KeyIdentitySource = nameof(IdentitySource);
        const string KeyScope = "Scope";
        const string DefaultCallbackPath = "/auth-callback";
        const string SourceKeyIdToken = "id_token";
        const string SourceKeyApi = "api";
        
        protected override string SectionIdentifier => Identifier;
        protected const string SectionJwtBearerValidationIdentifier = "ValidateJwtBearer";
        
        // ReSharper disable NotAccessedField.Local
        // NOTE: These fields are referenced through reflection (see GetFromFieldThenSection method) 
        string _clientId;
        string _clientSecret;
        string _callbackPath;
        string _authorizationHeader;
        string _identityTokenHeader;
        string _requestReferenceIdHeader;
        bool? _isCachingAllowed;
        TimeSpan? _defaultCachingLifetime;
        bool? _isPkceUsed;
        MultiStringValue _scope;
        GrantType _method;
        // ReSharper restore NotAccessedField.Local
        string _authorityUrl;
        string _tokenIssuerUrl;
        string _userInfoUrl;
        string _authDomain;
        int? _refreshThresholdSeconds;
        static  DiscoveryDocument s_discoveryDocument;
        TaskCompletionSource<DiscoveryDocument> _masterSourceTcs;

        // ReSharper disable UnusedMember.Global
        
        /// <summary>
        ///   Gets configuration for how to validate JWT tokens.  
        /// </summary>
        public JwtBearerValidationConfig JwtBearerValidation { get; }
        
        public IConfiguration Configuration { get; }
        
        protected override FieldInfo OnGetField(string fieldName)
        {
            var field = GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            return field ?? base.OnGetField(fieldName);
        }

        public SimpleCacheConfig Caching { get; }

        /// <summary>
        ///   Gets or sets the name of the header used to obtain the token to be used for authorizing the actor.
        ///   The default value is <see cref="HeaderNames.Authorization"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///   An invalid/empty value was assigned.
        /// </exception>
        /// <seealso cref="IsCustomAuthorizationHeader"/>
        public string AuthorizationHeader
        {
            get => GetFromFieldThenSection(HeaderNames.Authorization); 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value),
                        $"{nameof(AuthorizationHeader)} must be a valid identifier");

                _authorizationHeader = value;
            }
        }

        /// <summary>
        ///   Gets or sets the name of the header used to obtain the token to be used for authorizing the actor.
        ///   The default value is <see cref="HeaderNames.Authorization"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///   An invalid/empty value was assigned.
        /// </exception>
        /// <seealso cref="IsCustomAuthorizationHeader"/>
        public string IdentityTokenHeader
        {
            get => GetFromFieldThenSection(AmbientData.Keys.IdToken); // _identityTokenHeader ?? Section[nameof(IdentityTokenHeader)] ?? AmbientData.Keys.IdToken; obsolete
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value),
                        $"{nameof(IdentityTokenHeader)} must be a valid identifier");

                _identityTokenHeader = value;
            }
        }

        /// <summary>
        ///   Gets or sets the name of the header used to obtain the request message id.
        ///   The default value is <see cref="AmbientData.Keys.RequestMessageId"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///   An invalid/empty value was assigned.
        /// </exception>
        public string RequestMessageIdHeader
        {
            get => GetFromFieldThenSection(AmbientData.Keys.RequestMessageId);
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value),
                        $"{nameof(RequestMessageIdHeader)} must be a valid identifier");

                _requestReferenceIdHeader = value;
            }
        }

        /// <summary>
        ///   Gets or sets a <see cref="bool"/> value specifying whether auth data (such as tokens or identity)
        ///   can be automatically cached.
        /// </summary>
        /// <seealso cref="DefaultCachingLifetime"/>
        public bool IsCachingAllowed
        {
            get => GetFromFieldThenSection(true);
            set => _isCachingAllowed = value;
        }

        /// <summary>
        ///   Gets or sets a <see cref="TimeSpan"/> value specifying the default lifetime of cached auth data.
        ///   This value is only consumed by the auth framework when <see cref="IsCachingAllowed"/> is set. 
        /// </summary>
        /// <seealso cref="IsCachingAllowed"/>
        public TimeSpan DefaultCachingLifetime
        {
            get => GetFromFieldThenSection(TimeSpan.FromMinutes(10));
            set => _defaultCachingLifetime = value;
        }

        /// <summary>
        ///   Gets a value indicating whether the configured authorization header is a custom one
        ///   (default is <see cref="HeaderNames.Authorization"/>).
        /// </summary>
        /// <seealso cref="AuthorizationHeader"/>
        public bool IsCustomAuthorizationHeader => AuthorizationHeader != HeaderNames.Authorization;
    
        /// <summary>
        ///   Gets the current runtime environment (DEV, TEST, PROD ...).
        ///   The value is a <see cref="resolveRuntimeEnvironment"/> enum value. 
        /// </summary>
        public RuntimeEnvironment Environment { get; }

        /// <summary>
        ///   Gets the domain element of the authority URI.
        /// </summary>
        public string AuthDomain
        {
            get
            {
                if (_authDomain is { })
                    return _authDomain;

                return Environment switch
                {
                    RuntimeEnvironment.Production => "https://api.tetrapak.com",
                    RuntimeEnvironment.Migration => "https://api-mig.tetrapak.com",
                    RuntimeEnvironment.Development => "https://api-dev.tetrapak.com",
                    RuntimeEnvironment.Sandbox => "https://api-sb.tetrapak.com",
                    _ => throw new NotSupportedException($"Unsupported runtime environment: {Environment}")
                };
            }
            set => _authDomain = value;
        }
        
        /// <summary>
        ///   Gets the resource locator for the well-known OIDC discovery document.
        /// </summary>
        public string DiscoveryDocumentUrl => Section[nameof(DiscoveryDocumentUrl)] 
                                              ?? $"{AuthDomain}{DiscoveryDocument.DefaultPath}";

        /// <summary>
        ///   Gets the resource locator for the authority.
        /// </summary>
        public  string AuthorityUrl
        {
            get
            {
                if (_authorityUrl is { })
                    return _authorityUrl;
                    
                if (_masterSourceTcs is null)
                    return _authorityUrl ?? defaultUrl("/oauth2/authorize");

                var outcome = _masterSourceTcs.AwaitResult();
                return outcome
                    ? outcome.Value?.AuthorizationEndpoint
                    : string.Empty;
            }
        }

        /// <summary>
        ///   Gets the resource locator for the token issuer endpoint.  
        /// </summary>
        public string TokenIssuerUrl => _tokenIssuerUrl ?? defaultUrl("/oauth2/token");

        /// <summary>
        ///     Gets the resource locator for the user information query endpoint. 
        /// </summary>
        public string UserInformationUrl => _tokenIssuerUrl ?? defaultUrl("/idp/userinfo");
        
        /// <summary>
        ///   Indicates whether the authority domain has been assigned (intended mainly for testing purposes).
        /// </summary>
        internal bool IsAuthDomainAssigned => !string.IsNullOrWhiteSpace(_authDomain);

        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.None, 
                (string value, out GrantType grantType) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        grantType = GrantType.None;
                        return true;
                    }
                    
                    if (!TryParseEnum(value, out grantType) || grantType == GrantType.Inherited)
                        throw new ConfigurationException($"Invalid auth method: '{value}' ({Identifier}.{nameof(GrantType)})");

                    return true;
                });
            set => _method = value;
        }

        /// <summary>
        ///   Gets a configured client id.
        /// </summary>
        public virtual string ClientId
        {
            get => GetFromFieldThenSection<string>();
            set => _clientId = value;
        }

        /// <summary>
        ///   Gets a configured client secret.
        /// </summary>
        [RestrictedValue]
        public virtual string ClientSecret
        {
            get => GetFromFieldThenSection<string>();
            set => _clientSecret = value;
        }

        /// <summary>
        ///  Gets or sets a value specifying whether PKCE is to be used where applicable.
        /// </summary>
        public bool IsPkceUsed
        {
            get => GetFromFieldThenSection<bool>(); // _isPkceUsed ?? parseBool(Section[nameof(IsPkceUsed)]);
            set => _isPkceUsed = value;
        }
        
        /// <summary>
        ///   Gets a configured callback path, or the default one (<see cref="DefaultCallbackPath"/>).  
        /// </summary>
        public string CallbackPath
        {
            get => GetFromFieldThenSection(DefaultCallbackPath);
            set => _callbackPath = value;
        }
        
        /// <summary>
        ///   Specifies the source for identity claims (see <see cref="TetraPakIdentitySource"/>),
        ///   such as <see cref="TetraPakIdentitySource.Api"/> or <see cref="TetraPakIdentitySource.IdToken"/>).
        /// </summary>
        public TetraPakIdentitySource IdentitySource { get; set; }
        
        // ReSharper restore UnusedMember.Global
        
        internal string GetSectionIdentifier() => SectionIdentifier;
        
        /// <summary>
        ///   Gets the "well known" OIDC discovery document. The document will be downloaded and cached as needed.  
        /// </summary>
        /// <returns>
        ///   A <see cref="DiscoveryDocument"/>.
        /// </returns>
        public async Task<DiscoveryDocument> GetDiscoveryDocumentAsync()
        {
            if (s_discoveryDocument is { })
                return s_discoveryDocument; 
                
            s_discoveryDocument = await discoverAsync();
            return s_discoveryDocument;
        }

        string defaultUrl(string path) => $"{AuthDomain}{path}";

        /// <summary>
        ///   An alternative method of getting the authority URL from the discovery document, allowing for
        ///   the document to be refreshed online.
        /// </summary>
        /// <returns>
        ///   The authority resource locator.
        /// </returns>
        public async Task<string> GetAuthorityUrlAsync()
        {
            var url = _authorityUrl ?? Section[KeyAuthorityUrl];
            if (url is {})
                return url;

            var document = await GetDiscoveryDocumentAsync();
            return document.AuthorizationEndpoint;
        }

        /// <summary>
        ///   An alternative method of getting the token issuer endpoint URL from the discovery document, allowing for
        ///   the document to be refreshed online.
        /// </summary>
        /// <returns>
        ///   The token issuer endpoint resource locator.
        /// </returns>
        public async Task<string> GetTokenIssuerUrlAsync()
        {
            var url = _tokenIssuerUrl ?? Section[KeyTokenIssuerUrl];
            if (url is {})
                return url;

            var document = await GetDiscoveryDocumentAsync();
            return document.TokenEndpoint;
        }

        /// <summary>
        ///   An alternative method of getting the user information URL from the discovery document, allowing for
        ///   the document to be refreshed online.
        /// </summary>
        /// <returns>
        ///   The user information resource locator.
        /// </returns>
        public async Task<string> GetUserInformationUrlAsync()
        {
            var url = _userInfoUrl ?? Section[KeyUserInfoUrl];
            if (url is {})
                return url;

            var document = await GetDiscoveryDocumentAsync();
            return document.UserInformationEndpoint;
        }

        /// <summary>
        ///   Gets or sets the threshold time (in seconds) used for calculating when it is time
        ///   to refresh the access token when a refresh token was provided.
        /// </summary>
        /// <remarks>
        /// <para>
        ///   The refresh threshold value is specified in seconds. When a token is validated for its
        ///   TTL (time to live) this value is subtracted from the actual expiration time to calculate
        ///   the remaining TTL. When the TTL is zero or negative, and a refresh token is available,
        ///   a Refresh Flow will automatically be initiated to obtain a new access token.
        /// </para>
        /// <para>
        ///   Setting this value to a positive value
        ///   (negative values will automatically be converted to positive values)
        ///   might be a good idea to account for response times in requests. 
        /// </para>
        /// </remarks>
        public int RefreshThreshold
        {
            get => _refreshThresholdSeconds ?? Section.GetValue<int>(nameof(RefreshThreshold)); // parseInt(Section[nameof(RefreshThreshold)]);
            set => _refreshThresholdSeconds = value;
        }

        public static TEnum ParseEnum<TEnum>(string stringValue, TEnum useDefault = default) 
        where TEnum : struct
        {
            if (string.IsNullOrWhiteSpace(stringValue))
                return useDefault;

            return Enum.TryParse<TEnum>(stringValue.TrimWhitespace(), out var value)
                ? value
                : useDefault;
        }

        /// <summary>
        ///   Converts the string representation of the name or numeric value of one or more enumerated constants
        ///   to an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="stringValue">
        ///   The case-insensitive string representation of the enumeration name or underlying value to convert.
        /// </param>
        /// <param name="value">
        ///   When this method returns, result contains an object of type <typeparamref name="TEnum"/> whose
        ///   value is represented by value if the parse operation succeeds.
        ///   If the parse operation fails, result contains the default value of the underlying type of TEnum.
        ///   Note that this value need not be a member of the TEnum enumeration.
        ///   This parameter is passed uninitialized.
        /// </param>
        /// <typeparam name="TEnum">
        ///   The enumeration type to which to convert value.
        /// </typeparam>
        /// <returns>
        ///   <c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseEnum<TEnum>(string stringValue, out TEnum value) 
        where TEnum : struct
        {
            value = default;
            return !string.IsNullOrWhiteSpace(stringValue) && Enum.TryParse(stringValue.TrimWhitespace(), true, out value);
        }

        /// <summary>
        ///   Gets or sets a scope of identity claims to be requested while authenticating the identity.
        ///   When omitted a default scope will be used. 
        /// </summary>
        public MultiStringValue Scope
        {
            get => GetFromFieldThenSection<MultiStringValue>();
            set => _scope = value;
        }

        /// <summary>
        ///   Gets the current runtime environment name.
        /// </summary>
        public static string ProcessEnvironment
        {
            get
            {
                var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
                if (string.IsNullOrEmpty(environment))
                {
                    environment = System.Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT", EnvironmentVariableTarget.Process);
                }

                if (string.IsNullOrEmpty(environment))
                {
                    environment = "Production";
                }

                return environment;
            }
        }

        /// <summary>
        ///   Gets a value indicating whether the host is run in a development environment.  
        /// </summary>
        public static bool IsDevelopment => ProcessEnvironment == "Development";

        Task<DiscoveryDocument> discoverAsync()
        {
            // ensures that the discovery document gets refreshed. If called a second time (from a different thread);
            // then just wait for the download process to finish by using a TaskCompletionSource (TCS)
        
            bool waitForMasterSource;
            lock (s_syncRoot)
            {
                waitForMasterSource = _masterSourceTcs is { };
            }

            // ReSharper disable InconsistentlySynchronizedField
            if (waitForMasterSource)
                return _masterSourceTcs.Task;
            
            _masterSourceTcs = new TaskCompletionSource<DiscoveryDocument>();
            // ReSharper restore InconsistentlySynchronizedField

            Task.Run(async () =>
            {
                try
                {
                    using (Logger?.BeginScope("Downloading Tetra Pak Auth configuration from discovery document"))
                    {

                        var args = ReadDiscoveryDocumentArgs.FromMasterSource(this 
#if DEBUG
                            , TimeSpan.FromSeconds(5)
#endif
                            );
                        var outcome = await DiscoveryDocument.ReadAsync(args);
                        if (!outcome)
                        {
                            Logger?.Error(outcome.Exception, "Could not download discovery document");
                            return done(null);
                        }

                        var discoveryDocument = outcome.Value;
                        _authorityUrl = discoveryDocument.AuthorizationEndpoint;
                        _tokenIssuerUrl = discoveryDocument.TokenEndpoint;
                        _userInfoUrl = discoveryDocument.UserInformationEndpoint;
                        Logger.Debug(this);
                        return done(discoveryDocument);
                    }
                }
                catch (Exception ex)
                {
                    Logger?.Error(ex, "Could not download discovery document");
                    done(null);
                    throw;
                }
            });

            return _masterSourceTcs.Task;
            
            DiscoveryDocument done(DiscoveryDocument discoveryDocument)
            {
                // ReSharper disable once InconsistentlySynchronizedField
                s_discoveryDocument = discoveryDocument;
                _masterSourceTcs.SetResult(discoveryDocument);
                _masterSourceTcs = null;
                return discoveryDocument;
            }
        }

        /// <summary>
        ///   Invoked from ctor to resolve the runtime environment.
        /// </summary>
        /// <param name="configuredStringValue">
        ///   The configured <see cref="string"/> value to be resolved.
        /// </param>
        /// <param name="configDelegate">
        ///   (optional)<br/>
        ///   A custom delegate to be allowed to affect the result.
        /// </param>
        /// <returns>
        ///   A resolved <see cref="RuntimeEnvironment"/> value.
        /// </returns>
        protected virtual RuntimeEnvironment OnResolveRuntimeEnvironment(
            string configuredStringValue,
            ITetraPakAuthConfigDelegate configDelegate)
        {
            var environment = configDelegate?.ResolveConfiguredEnvironment(configuredStringValue);
            if (environment is {} && environment != RuntimeEnvironment.Unknown)
                return environment.Value;
            
            return configuredStringValue is { } 
                ? Enum.Parse<RuntimeEnvironment>(configuredStringValue) 
                : resolve() ?? RuntimeEnvironment.Production;
            
            static RuntimeEnvironment? resolve()
            {
                var stringValue = ProcessEnvironment;
                return string.IsNullOrWhiteSpace(stringValue)
                    ? null
                    : Enum.TryParse<RuntimeEnvironment>(stringValue, true, out var result)
                        ? result
                        : null;
            }
        }
        
        RuntimeEnvironment resolveRuntimeEnvironment(ITetraPakAuthConfigDelegate configDelegate)
        {
            return OnResolveRuntimeEnvironment(Section["Environment"], configDelegate);
        }

        TetraPakIdentitySource parseIdentitySource(TetraPakIdentitySource useDefault = TetraPakIdentitySource.Api)
        {
            var s = Section[KeyIdentitySource];
            if (s is null)
                return useDefault;
                
            if (s.Equals(SourceKeyIdToken, StringComparison.OrdinalIgnoreCase))
            {
                s = nameof(TetraPakIdentitySource.IdToken);
            }
            else if (s.Equals(SourceKeyApi))
            {
                s = nameof(TetraPakIdentitySource.Api);
            }
            return !string.IsNullOrWhiteSpace(s) && Enum.TryParse<TetraPakIdentitySource>(s, out var eSource)
                ? eSource
                : useDefault;
        }
        
        MultiStringValue parseScope()
        {
            var scope = Section.GetList<string>(KeyScope, Logger);
            if (scope is null || scope.Count == 0)
                return s_defaultScope;

            if (scope.All(i => !i.Equals("openid", StringComparison.InvariantCultureIgnoreCase)))
            {
                scope.Add("openid");
            }

            return new MultiStringValue(scope.ToArray());
        }
        
        protected void InitializeProperties(IConfiguration configuration) 
        {
            var properties = GetType().GetProperties();
            foreach (var property in properties.Where(i => i.CanWrite))
            {
                var value = configuration[property.Name];
                if (value is null)
                    continue;
        
                OnSetProperty(property, value);
            }
        }
        
        protected virtual void OnSetProperty(PropertyInfo property, object value) 
        {
            if (property.PropertyType == typeof(string))
            {
                property.SetValue(this, value);
                return;
            }
            
            var obj = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(this, obj);
        }

        /// <summary>
        ///   Initializes a Tetra Pak authorization configuration instance. 
        /// </summary>
        /// <param name="configuration">
        ///     A <see cref="IConfiguration"/> instance.
        /// </param>
        /// <param name="logger">
        ///     A <see cref="ILogger"/>.
        /// </param>
        /// <param name="loadDiscoveryDocument">
        ///     (optional; default = <c>false</c>)<br/>
        ///     Specifies whether to automatically load the (remote) discovery document.
        ///     <seealso cref="GetDiscoveryDocumentAsync"/>
        /// </param>
        /// <param name="sectionIdentifier">
        ///     (optional; default=<see cref="SectionIdentifier"/>)<br/>
        ///     A custom configuration section identifier. 
        /// </param>
        /// <param name="configDelegate">
        ///   (optional)<br/>
        ///   A delegate instance for custom configuration behavior.
        /// </param>
        public TetraPakAuthConfig(
            IConfiguration configuration,
            // ReSharper disable once SuggestBaseTypeForParameter
            ILogger<TetraPakAuthConfig> logger, 
            bool loadDiscoveryDocument = false,
            string sectionIdentifier = null,
            ITetraPakAuthConfigDelegate configDelegate = null) 
        : base(configuration, logger, sectionIdentifier)
        {
            Configuration = configuration;

            var nisse = Section.GetChildren();
            
            Environment = resolveRuntimeEnvironment(configDelegate);
            JwtBearerValidation = new JwtBearerValidationConfig(Section, logger, SectionJwtBearerValidationIdentifier);
            IdentitySource = parseIdentitySource();
            Scope = parseScope();
            Caching = new SimpleCacheConfig(null, Section, logger, nameof(Caching));
            _isPkceUsed = true;
            if (loadDiscoveryDocument)
            {
                discoverAsync();
            }
        }
    }

    public interface ITetraPakAuthConfigDelegate
    {
        /// <summary>
        ///   Called to resolve the configured (or null, when un-configured) runtime environment.
        /// </summary>
        /// <param name="stringValue">The <see cref="string"/> representation of the configured value.</param>
        /// <returns>
        ///   A resolved <see cref="RuntimeEnvironment"/> value.
        /// </returns>
        RuntimeEnvironment ResolveConfiguredEnvironment(string stringValue);
    }
}