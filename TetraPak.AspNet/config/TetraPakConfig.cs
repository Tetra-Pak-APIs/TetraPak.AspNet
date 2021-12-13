using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.OpenIdConnect;
using TetraPak.Caching;
using TetraPak.Logging;
using TetraPak.SecretsManagement;
using ConfigurationSection = TetraPak.Configuration.ConfigurationSection;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   OBSOLETE!
    ///   Please use the <see cref="TetraPakConfig"/> class instead.
    /// </summary>
    [Obsolete("This class is being deprecated. Please use TetraPakConfig")]
    public class TetraPakAuthConfig : TetraPakConfig
    {
        /// <summary>
        ///   OBSOLETE!
        ///   Please use the <see cref="TetraPakConfig"/> class instead.
        /// </summary>
        public TetraPakAuthConfig(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
    
    /// <summary>
    ///   Provides a code API to the main Tetra Pak section in the configuration.  
    /// </summary>
    /// <seealso cref="ITetraPakConfigDelegate"/>
    public class TetraPakConfig : ConfigurationSection, IServiceAuthConfig
    {
        /// <summary>
        ///   The default root configuration section name for Tetra Pak configuration. 
        /// </summary>
        public static string DefaultSectionIdentifier { get; set; } = "TetraPak";
        
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

        // NOTE: These fields are referenced through reflection (see GetFromFieldThenSection method) 
        // ReSharper disable NotAccessedField.Local
        bool? _isMessageIdEnabled;
        string? _clientId;
        string? _clientSecret;
        string? _callbackPath;
        string? _authorizationHeader;
        string? _identityTokenHeader;
        string? _requestReferenceIdHeader;
        bool? _isCachingAllowed;
        TimeSpan? _defaultCachingLifetime;
        bool? _isPkceUsed;
        bool? _enableDiagnostics;
#pragma warning disable 169
        MultiStringValue? _scope; // todo Why is this field being warned about not being used while others doesn't?
#pragma warning restore 169
        GrantType _method;
        // ReSharper restore NotAccessedField.Local
        string? _authorityUrl;
        string? _tokenIssuerUrl;
        string? _userInfoUrl;
        string? _authDomain;
        int? _refreshThresholdSeconds;
        bool? _trimHostInResponses;
        static  DiscoveryDocument? s_discoveryDocument;
        TaskCompletionSource<DiscoveryDocument?>? _masterSourceTcs;
        ProductInfoHeaderValue? _sdkVersion;

        /// <summary>
        ///   Gets a (DI) service locator.
        /// </summary>
        protected IServiceProvider ServiceProvider { get; }

        internal IServiceProvider GetServiceProvider() => ServiceProvider;

        /// <summary>
        ///   Gets logging configuration.  
        /// </summary>
        public TetraPakLoggingConfiguration Logging { get; }
        
        /// <summary>
        ///   Gets JWT validation options.  
        /// </summary>
        public JwtBearerAssertionConfig JwtBearerAssertion { get; }
        
        /// <summary>
        ///   Gets the <see cref="IConfiguration"/> used to populate this object.
        /// </summary>
        public IConfiguration Configuration { get; }
        
        /// <summary>
        ///   Gets a configuration delegate.
        /// </summary>
        protected ITetraPakConfigDelegate? ConfigDelegate { get; }

        /// <summary>
        ///   Gets a time limited repository to be used for caching (if available).
        /// </summary>
        public ITimeLimitedRepositories? Cache => ServiceProvider.GetService<ITimeLimitedRepositories>();

        /// <inheritdoc />
        [JsonIgnore]
        public AmbientData AmbientData => ServiceProvider.GetRequiredService<AmbientData>();

        /// <inheritdoc />
        public IServiceAuthConfig ParentConfig => null!;
        
        /// <summary>
        ///   Examines a textual identifier and returns a value to indicate whether it is considered
        ///   one of the identifiers reserved for 'auth' purposes.
        /// </summary>
        /// <param name="identifier">
        ///   The textual identifier being examined.
        /// </param>
        /// <returns>
        ///   <c>true</c> if <paramref name="identifier"/> is considered a reserved 'auth' identifier;
        ///   otherwise <c>false</c>.
        /// </returns>
        /// <seealso cref="IsAuthIdentifier"/>
        public static bool CheckIsAuthIdentifier(string identifier)
        {
            return identifier switch
            {
                nameof(ConfigPath) => true,
                nameof(GrantType) => true,
                nameof(ClientId) => true,
                nameof(ClientSecret) => true,
                nameof(Scope) => true,
                _ => false
            };
        }

        /// <inheritdoc />
        public bool IsAuthIdentifier(string identifier) => CheckIsAuthIdentifier(identifier);
        
        /// <inheritdoc />
        protected override FieldInfo? OnGetField(string fieldName, bool inherited = false)
        {
            var field = GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            return field ?? base.OnGetField(fieldName, inherited);
        }

        /// <summary>
        ///   Configuration section specifying caching strategies. 
        /// </summary>
        public SimpleCacheConfig Caching { get; }

        /// <summary>
        ///   Gets or sets the name of the header used to obtain the token to be used for authorizing the actor.
        ///   The default value is <see cref="HeaderNames.Authorization"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///   An invalid/empty value was assigned.
        /// </exception>
        /// <seealso cref="IsCustomAuthorizationHeader"/>
        [StateDump]
        public string AuthorizationHeader
        {
            get => GetFromFieldThenSection(HeaderNames.Authorization)!; 
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
        [StateDump]
        public string? IdentityTokenHeader
        {
            get => GetFromFieldThenSection(AmbientData.Keys.IdToken);
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
        ///   The default value is <see cref="TetraPak.AspNet.AmbientData.Keys.RequestMessageId"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///   An invalid/empty value was assigned.
        /// </exception>
        [StateDump]
        public string? RequestMessageIdHeader
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
        [StateDump]
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
        [StateDump]
        public TimeSpan DefaultCachingLifetime
        {
            get => GetFromFieldThenSection(TimeSpan.FromMinutes(10));
            set => _defaultCachingLifetime = value;
        }

        /// <summary>
        ///   Gets or sets a value specifying whether to enable service diagnostics.
        /// </summary>
        public bool EnableDiagnostics
        {
            get => GetFromFieldThenSection(false); 
            set => _enableDiagnostics = value;
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
        [StateDump]
        public RuntimeEnvironment Environment { get; }

        /// <summary>
        ///   Gets the domain element of the authority URI.
        /// </summary>
        [StateDump]
        public string AuthDomain
        {
            get
            {
                if (_authDomain is { })
                    return _authDomain;

                return Environment switch
                {
                    TetraPak.RuntimeEnvironment.Production => "https://api.tetrapak.com",
                    TetraPak.RuntimeEnvironment.Migration => "https://api-mig.tetrapak.com",
                    TetraPak.RuntimeEnvironment.Development => "https://api-dev.tetrapak.com",
                    TetraPak.RuntimeEnvironment.Sandbox => "https://api-sb.tetrapak.com",
                    _ => throw new NotSupportedException($"Unsupported runtime environment: {Environment}")
                };
            }
            set => _authDomain = value;
        }
        
        /// <summary>
        ///   Gets the resource locator for the well-known OIDC discovery document.
        /// </summary>
        [StateDump]
        public string DiscoveryDocumentUrl => Section![nameof(DiscoveryDocumentUrl)] 
                                              ?? $"{AuthDomain}{DiscoveryDocument.DefaultPath}";

        /// <summary>
        ///   Gets the resource locator for the authority.
        /// </summary>
        [StateDump]
        public string? AuthorityUrl
        {
            get
            {
                if (_authorityUrl is { })
                    return _authorityUrl;
                    
                if (_masterSourceTcs is null)
                    return _authorityUrl ?? defaultUrl("/oauth2/authorize");

                var outcome = _masterSourceTcs.AwaitResult();
                return outcome
                    ? outcome.Value?.AuthorizationEndpoint ?? string.Empty
                    : string.Empty;
            }
        }

        /// <summary>
        ///   Gets the resource locator for the token issuer endpoint.  
        /// </summary>
        [StateDump]
        public string TokenIssuerUrl => _tokenIssuerUrl ?? defaultUrl("/oauth2/token");

        /// <summary>
        ///     Gets the resource locator for the user information query endpoint. 
        /// </summary>
        [StateDump]
        public string UserInformationUrl => _tokenIssuerUrl ?? defaultUrl("/idp/userinfo");
        
        /// <summary>
        ///   Indicates whether the authority domain has been assigned (intended mainly for testing purposes).
        /// </summary>
        internal bool IsAuthDomainAssigned => !string.IsNullOrWhiteSpace(_authDomain);

        /// <summary>
        ///   Gets or sets a value to enable/disable the automatic use of a unique id to track
        ///   a specific request/response. This value is <c>true</c> by default.
        /// </summary>
        /// <remarks>
        ///   <a href="https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/blob/master/README.md#message-id">
        ///   You can read more about the message id concept here.
        ///   </a>
        /// </remarks>
        public bool IsMessageIdEnabled
        {
            get => GetFromFieldThenSection(true);
            set => _isMessageIdEnabled = value;
        }

        /// <inheritdoc />
        [StateDump]
        public virtual GrantType GrantType
        {
            get => GetFromFieldThenSection(GrantType.None, 
                (string? value, out GrantType grantType) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        grantType = GrantType.None;
                        return true;
                    }
                    
                    if (!TryParseEnum(value, out grantType) || grantType == GrantType.Inherited)
                        throw new ServerConfigurationException($"Invalid auth method: '{value}' ({DefaultSectionIdentifier}.{nameof(GrantType)})");

                    return true;
                });
            set => _method = value;
        }

        /// <summary>
        ///   Gets a configured client id at this configuration level.
        /// </summary>
        /// <see cref="GetClientIdAsync"/>
        [StateDump]
        public virtual string? ClientId
        {
            get
            {
                var outcome = GetClientIdAsync(new AuthContext(GrantType, this)).Result;
                return outcome.Value;
            }
            set => _clientId = value;
        }

        /// <summary>
        ///   Gets a configured client secret at this configuration level.
        /// </summary>
        /// <seealso cref="GetClientSecretAsync"/>
        [StateDump, RestrictedValue(DisclosureLogLevel = LogLevel.Debug)]
        public virtual string? ClientSecret
        {
            get
            {
                var outcome = GetClientSecretAsync(new AuthContext(GrantType, this)).Result;
                return outcome ? outcome.Value : null;
            }
            set => _clientSecret = value;
        }
        
        /// <summary>
        ///   Gets or sets a scope of identity claims, a this configuration level,
        ///   to be requested while authenticating the identity. When omitted a default scope will be used. 
        /// </summary>
        /// <seealso cref="GetScopeAsync"/>
        [StateDump]
        public MultiStringValue Scope 
        {
            get
            {
                var outcome = GetScopeAsync(new AuthContext(GrantType, this), MultiStringValue.Empty).Result;
                return outcome ? outcome.Value! : throw new ServerConfigurationException("Scope could not be resolved");
            }
            set => _clientSecret = value;
        }

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientIdAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null) => OnGetClientIdAsync(authContext, cancellationToken);

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientSecretAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null) => OnGetClientSecretAsync(authContext, cancellationToken);

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext, 
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null) => OnGetScopeAsync(authContext, useDefault, cancellationToken);

        /// <inheritdoc />
        public string? GetConfiguredValue(string key) => Section![key];

        /// <summary>
        ///   Gets a client id.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables operation cancellation.
        /// </param>
        protected virtual async Task<Outcome<string>> OnGetClientIdAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken)
        {
            if (ConfigDelegate is null)
            {
                var value = GetFromFieldThenSection<string>(propertyName: nameof(ClientId));
                return value is { }
                    ? Outcome<string>.Success(value)
                    : Outcome<string>.Fail(new ServerConfigurationException("Client id could not be resolved"));
            }
            
            var outcome = await ConfigDelegate.GetClientCredentialsAsync(authContext, cancellationToken);
            return outcome
                ? Outcome<string>.Success(outcome.Value!.Identity)
                : Outcome<string>.Fail(outcome.Exception);
        }

        /// <summary>
        ///   Gets a client secret.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Enables operation cancellation.
        /// </param>
        protected virtual async Task<Outcome<string>> OnGetClientSecretAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken)
        {
            if (ConfigDelegate is null)
            {
                var secret = GetFromFieldThenSection<string>(propertyName: nameof(ClientSecret));
                return secret is {} 
                    ? Outcome<string>.Success(secret)
                    : Outcome<string>.Fail(new ServerConfigurationException("Client secret could not be resolved"));
            }
            
            var outcome = await ConfigDelegate.GetClientCredentialsAsync(authContext, cancellationToken);
            return outcome
                ? Outcome<string>.Success(outcome.Value!.Secret)
                : Outcome<string>.Fail(outcome.Exception);
        }

        /// <summary>
        ///   Gets a auth scope.
        /// </summary>
        /// <param name="authContext">
        ///   Details the auth context in which the (confidential) client secrets are requested.
        /// </param>
        /// <param name="useDefault">
        ///   (optional)<br/>
        ///   Specifies a default value to be returned if scope cannot be resolved.
        /// </param>
        /// <param name="cancellationToken">
        ///   (optional)<br/>
        ///   Cancellation token for cancellation the operation.
        /// </param>
        protected virtual async Task<Outcome<MultiStringValue>> OnGetScopeAsync(
            AuthContext authContext, 
            MultiStringValue? useDefault = null,
            CancellationToken? cancellationToken = null)
        {
            if (ConfigDelegate is null)
            {
                var scope = GetFromFieldThenSection<MultiStringValue>(propertyName: nameof(Scope));
                if (scope is {})
                    return Outcome<MultiStringValue>.Success(scope);

                return useDefault is { }
                    ? Outcome<MultiStringValue>.Success(useDefault)
                    : Outcome<MultiStringValue>.Fail(new Exception($"Cannot resolve scope"));
            }
            
            var outcome = await ConfigDelegate.GetScopeAsync(authContext, cancellationToken);
            if (outcome)
                return outcome;
            
            return useDefault is { }
                ? Outcome<MultiStringValue>.Success(useDefault)
                : throw outcome.Exception;
        }

        /// <summary>
        ///  Gets or sets a value specifying whether PKCE is to be used where applicable.
        /// </summary>
        [StateDump]
        public bool IsPkceUsed
        {
            get => GetFromFieldThenSection<bool>(); // _isPkceUsed ?? parseBool(Section[nameof(IsPkceUsed)]);
            set => _isPkceUsed = value;
        }
        
        /// <summary>
        ///   Gets a configured callback path, or the default one (<see cref="DefaultCallbackPath"/>).  
        /// </summary>
        [StateDump]
        public string? CallbackPath
        {
            get => GetFromFieldThenSection(DefaultCallbackPath);
            set => _callbackPath = value?.Trim();
        }
        
        /// <summary>
        ///   Gets a value that specifies whether to always remove the host element from relationship URLs
        ///   based on this endpoint. If not specified in configuration the value will fall back to the
        ///   configuration service level (the endpoint "parent" section). 
        /// </summary>
        [StateDump]
        public bool TrimHostInResponses 
        {
            get => GetFromFieldThenSection(true);
            set => _trimHostInResponses = value;
        }
        
        /// <summary>
        ///   Specifies the source for identity claims (see <see cref="TetraPakIdentitySource"/>),
        ///   such as <see cref="TetraPakIdentitySource.RemoteService"/> or <see cref="TetraPakIdentitySource.IdToken"/>).
        /// </summary>
        [StateDump]
        public TetraPakIdentitySource IdentitySource { get; }
        
        // ReSharper restore UnusedMember.Global
        
        internal string GetSectionIdentifier() => SectionIdentifier;
        
        /// <summary>
        ///   Gets the "well known" OIDC discovery document. The document will be downloaded and cached as needed.  
        /// </summary>
        /// <returns>
        ///   A <see cref="DiscoveryDocument"/>.
        /// </returns>
        public async Task<Outcome<DiscoveryDocument>> GetDiscoveryDocumentAsync()
        {
            if (s_discoveryDocument is { })
                return Outcome<DiscoveryDocument>.Success(s_discoveryDocument); 
                
            s_discoveryDocument = await discoverAsync();
            return s_discoveryDocument is not null
                ? Outcome<DiscoveryDocument>.Success(s_discoveryDocument)
                : Outcome<DiscoveryDocument>.Fail(new Exception("Could not download OIDC discovery document")); 
        }

        string defaultUrl(string path) => $"{AuthDomain}{path}";

        /// <summary>
        ///   An alternative method of getting the authority URL from the discovery document, allowing for
        ///   the document to be refreshed online.
        /// </summary>
        /// <returns>
        ///   The authority resource locator.
        /// </returns>
        public async Task<string?> GetAuthorityUrlAsync()
        {
            var url = _authorityUrl ?? Section![KeyAuthorityUrl];
            if (url is {})
                return url;

            var discoOutcome = await GetDiscoveryDocumentAsync();
            return discoOutcome
                ? discoOutcome.Value!.AuthorizationEndpoint
                : null;
        }

        /// <summary>
        ///   An alternative method of getting the token issuer endpoint URL from the discovery document, allowing for
        ///   the document to be refreshed online.
        /// </summary>
        /// <returns>
        ///   The token issuer endpoint resource locator.
        /// </returns>
        public async Task<string?> GetTokenIssuerUrlAsync()
        {
            var url = _tokenIssuerUrl ?? Section![KeyTokenIssuerUrl];
            if (url is {})
                return url;

            var discoOutcome = await GetDiscoveryDocumentAsync();
            return discoOutcome
                ? discoOutcome.Value!.TokenEndpoint
                : null;
        }

        /// <summary>
        ///   An alternative method of getting the user information URL from the discovery document, allowing for
        ///   the document to be refreshed online.
        /// </summary>
        /// <returns>
        ///   The user information resource locator.
        /// </returns>
        public async Task<string?> GetUserInformationUrlAsync()
        {
            var url = _userInfoUrl ?? Section![KeyUserInfoUrl];
            if (url is {})
                return url;

            var discoOutcome = await GetDiscoveryDocumentAsync();
            return discoOutcome
                ? discoOutcome.Value!.UserInformationEndpoint
                : null;
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
        ///   Setting this value might be a good idea to account for response times in requests.
        ///   The value is expected to be a positive integer.
        ///   Negative values will automatically be converted to positive values. 
        /// </para>
        /// </remarks>
        [StateDump]
        public int RefreshThreshold
        {
            get => _refreshThresholdSeconds ?? Section.GetValue<int>(nameof(RefreshThreshold));
            set => _refreshThresholdSeconds = value;
        }

        /// <summary>
        ///   Returns a <see cref="ProductInfoHeaderValue"/> to reflect the current SDK version.
        /// </summary>
        [StateDump]
        public ProductInfoHeaderValue SdkVersion
        {
            get
            {
                if (_sdkVersion is { })
                    return _sdkVersion;

                _sdkVersion = OnGetSdkVersion();
                return _sdkVersion;
            }
        }

        /// <summary>
        ///   Invoked internally to produce the SDK version.
        /// </summary>
        /// <returns>
        ///   A <see cref="ProductInfoHeaderValue"/> object.
        /// </returns>
        /// <remarks>
        ///   This method will only be invoked once.  
        /// </remarks>
        protected virtual ProductInfoHeaderValue OnGetSdkVersion()
        {
            var asm = typeof(TetraPakConfig).Assembly;
            var v = asm.GetName().Version!;
            
#if NET5_0_OR_GREATER
            return new ProductInfoHeaderValue(asm.GetName().Name!, $"{v.Major}.{v.Minor}.{v.Build}");
#else
            return new ProductInfoHeaderValue(asm.GetName().Name, $"{v.Major}.{v.Minor}.{v.Build}");
#endif
        }

        /// <summary>
        ///   Parses a configured <see cref="Enum"/> value and returns the result.
        /// </summary>
        /// <param name="stringValue">
        ///   The <see cref="string"/> value found in the configuration.
        /// </param>
        /// <param name="useDefault">
        ///   A default value to be used when <paramref name="stringValue"/> is unassigned
        ///   or cannot be successfully parsed. 
        /// </param>
        /// <typeparam name="TEnum">
        ///   The (<see cref="Enum"/>) value to be expected.
        /// </typeparam>
        /// <returns>
        ///   The <see cref="Enum"/> value represented by the <paramref name="stringValue"/>,
        ///   or <paramref name="useDefault"/> if <paramref name="stringValue"/> was unassigned or
        ///   could not be successfully parsed. 
        /// </returns>
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
        ///   Gets the current runtime environment name.
        /// </summary>
        [StateDump]
        public static string RuntimeEnvironment
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
        public static bool IsDevelopment => RuntimeEnvironment == "Development";

        internal bool IsDelegated => ConfigDelegate is not null;

        Task<DiscoveryDocument?> discoverAsync()
        {
            // ensures that the discovery document gets refreshed. If called a second time (from a different thread);
            // then just wait for the download process to finish by using a TaskCompletionSource (TCS)
        
            bool waitForMasterSource;
            lock (s_syncRoot)
            {
                waitForMasterSource = _masterSourceTcs is not null;
            }

            // ReSharper disable InconsistentlySynchronizedField
            if (waitForMasterSource)
                return _masterSourceTcs!.Task;
            
            _masterSourceTcs = new TaskCompletionSource<DiscoveryDocument>()!;
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

                        var discoveryDocument = outcome.Value!;
                        _authorityUrl = discoveryDocument.AuthorizationEndpoint;
                        _tokenIssuerUrl = discoveryDocument.TokenEndpoint;
                        _userInfoUrl = discoveryDocument.UserInformationEndpoint;
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
            
            DiscoveryDocument? done(DiscoveryDocument? discoveryDocument)
            {
                s_discoveryDocument = discoveryDocument;
                _masterSourceTcs.SetResult(discoveryDocument);
                _masterSourceTcs = null;
                return discoveryDocument;
            }
        }

        /// <summary>
        ///   Invoked from ctor to resolve the runtime environment.
        /// </summary>
        /// <param name="configuredValue">
        ///   The configured <see cref="string"/> value to be resolved.
        /// </param>
        /// <returns>
        ///   A resolved <see cref="TetraPak.RuntimeEnvironment"/> value.
        /// </returns>
        protected virtual RuntimeEnvironment OnResolveRuntimeEnvironment(string configuredValue)
        {
            var environment = ConfigDelegate?.ResolveConfiguredEnvironment(configuredValue);
            if (environment is {} && environment != TetraPak.RuntimeEnvironment.Unknown)
                return environment.Value;

            return ResolveRuntimeEnvironment(configuredValue);
        }

        internal static RuntimeEnvironment ResolveRuntimeEnvironment(string? configuredValue)
        {
            return configuredValue is { } 
                ? Enum.Parse<RuntimeEnvironment>(configuredValue) 
                : resolve() ?? TetraPak.RuntimeEnvironment.Production;
            
            static RuntimeEnvironment? resolve()
            {
                var stringValue = RuntimeEnvironment;
                return string.IsNullOrWhiteSpace(stringValue)
                    ? null
                    : Enum.TryParse<RuntimeEnvironment>(stringValue, true, out var result)
                        ? result
                        : null;
            }
        }
        
        RuntimeEnvironment resolveRuntimeEnvironment() => OnResolveRuntimeEnvironment(Section!["Environment"]);

        TetraPakIdentitySource parseIdentitySource(TetraPakIdentitySource useDefault = TetraPakIdentitySource.IdToken)
        {
            var s = Section![KeyIdentitySource];
            if (s is null)
                return useDefault;
                
            if (s.Equals(SourceKeyIdToken, StringComparison.OrdinalIgnoreCase))
            {
                s = nameof(TetraPakIdentitySource.IdToken);
            }
            else if (s.Equals(SourceKeyApi))
            {
                s = nameof(TetraPakIdentitySource.RemoteService);
            }
            return !string.IsNullOrWhiteSpace(s) && Enum.TryParse<TetraPakIdentitySource>(s, out var eSource)
                ? eSource
                : useDefault;
        }
        
        MultiStringValue parseScope()
        {
            // todo allow config delegate to resolve scope 
            var scope = Section!.GetList<string>(KeyScope, Logger);
            if (scope.Count == 0)
                return s_defaultScope;

            if (scope.All(i => !i.Equals("openid", StringComparison.InvariantCultureIgnoreCase)))
            {
                scope.Add("openid");
            }

            return new MultiStringValue(scope.ToArray());
        }
        
        /// <summary>
        ///   Initializes a Tetra Pak authorization configuration instance. 
        /// </summary>
        /// <param name="serviceProvider">
        ///   A service locator.
        /// </param>
        public TetraPakConfig(IServiceProvider serviceProvider) 
        : base(
            serviceProvider.GetRequiredService<IConfiguration>(), 
            serviceProvider.GetService<ILogger<TetraPakConfig>>(), 
            DefaultSectionIdentifier)
        {
            SectionIdentifier = DefaultSectionIdentifier;
            ServiceProvider = serviceProvider;
            Configuration = serviceProvider.GetRequiredService<IConfiguration>();
            ConfigDelegate = ServiceProvider.GetService<ITetraPakConfigDelegate>();
            if (ConfigDelegate is TetraPakConfigDelegate tetraPakConfigDelegate)
            {
                tetraPakConfigDelegate.WithTetraPakConfig(this);
            }
            else
            {
                var secretsProvider = ServiceProvider.GetService<ITetraPakSecretsProvider>();
                ConfigDelegate = new TetraPakConfigDelegate(secretsProvider).WithTetraPakConfig(this);
            }
            Environment = resolveRuntimeEnvironment(); // just avoiding calling a virtual method from ctor
            var logger = serviceProvider.GetService<ILogger<TetraPakConfig>>();
            Logging = new TetraPakLoggingConfiguration(Section!, logger);
            JwtBearerAssertion = new JwtBearerAssertionConfig(Section!, logger);
            IdentitySource = parseIdentitySource();
            Scope = parseScope();
            Caching = new SimpleCacheConfig(null, Section, logger, nameof(Caching));
            _isPkceUsed = true;
        }
    }
}