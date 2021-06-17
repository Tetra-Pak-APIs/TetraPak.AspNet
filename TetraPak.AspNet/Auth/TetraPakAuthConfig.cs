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
    public class TetraPakAuthConfig : ConfigurationSection
    {
        static readonly object s_syncRoot = new();
        static readonly string[] s_defaultScope = { "general", "profile", "email", "openid" };

        const string KeyAuthorityUrl = "KeyAuthorityUrl";
        const string KeyTokenIssuerUrl = "TokenIssuerUrl";
        const string KeyUserInfoUrl = "UserInfoUrl";
        const string KeyIdentitySource = nameof(IdentitySource);
        const string KeyScope = "Scope";
        const string DefaultCallbackPath = "/auth-callback";
        const string SourceKeyIdToken = "id_token";
        const string SourceKeyApi = "api";
        
        protected override string SectionIdentifier => "TetraPak"; 
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
        ///   Gets or sets the name of the header used to obtain the request reference id.
        ///   The default value is <see cref="AmbientData.Keys.RequestReferenceId"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///   An invalid/empty value was assigned.
        /// </exception>
        public string RequestReferenceIdHeader
        {
            get => GetFromFieldThenSection(AmbientData.Keys.RequestReferenceId);
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value),
                        $"{nameof(RequestReferenceIdHeader)} must be a valid identifier");

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

        // /// <summary>
        // ///   Gets or sets a value specifying whether to always cache the token used to build the identity. obsolete
        // /// </summary>
        // /// <remarks>
        // ///   In the configuration section this value can be expressed either as seconds (an integer),
        // ///   like so: <c>"CacheIdentityTokenLifetime": "150"</c>, or as a time span value (hh:mm:ss),
        // ///   like this: <c>"CacheIdentityTokenLifetime": "00:02:30"</c>.
        // /// </remarks>
        // /// <see cref="TetraPakClaimsTransformation"/>
        // public TimeSpan? CacheIdentityTokenLifetime => Caching.GetRepositoryConfig("IdentityTokens")?.LifeSpan;

        /// <summary>
        ///   Gets a value indicating whether the configured authorization header is a custom one
        ///   (default is <see cref="HeaderNames.Authorization"/>).
        /// </summary>
        /// <seealso cref="AuthorizationHeader"/>
        public bool IsCustomAuthorizationHeader => AuthorizationHeader != HeaderNames.Authorization;
    
        /// <summary>
        ///   Gets the current runtime environment (DEV, TEST, PROD ...).
        ///   The value is a <see cref="runtimeEnvironment"/> enum value. 
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

        // static bool parseBool(string s, bool useDefault = false)
        // {
        //     return string.IsNullOrWhiteSpace(s) 
        //         ? useDefault 
        //         : bool.TryParse(s, out var b) 
        //             ? b 
        //             : useDefault;
        // }
        //
        // static int parseInt(string s, int useDefault = 0)
        // {
        //     useDefault = Math.Abs(useDefault);
        //     return string.IsNullOrWhiteSpace(s) 
        //         ? useDefault 
        //         : int.TryParse(s, out var result) 
        //             ? result 
        //             : useDefault;
        // }

        /// <summary>
        ///   Gets or sets a scope of identity claims to be requested while authenticating the identity.
        ///   When omitted a default scope will be used. 
        /// </summary>
        public string[] Scope { get; }

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

        static RuntimeEnvironment? runtimeEnvironment()
        {
            var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!string.IsNullOrEmpty(environment))
                return mapEnvironment(environment);
            
            environment = System.Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            return !string.IsNullOrEmpty(environment) 
                ? mapEnvironment(environment)
                : null;
        }
        
        static RuntimeEnvironment? mapEnvironment(string environment)
        {
            return Enum.TryParse<RuntimeEnvironment>(environment, true, out var result)
                ? result
                : null;
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
        
        string[] parseScope()
        {
            var scope = Section.GetList<string>(KeyScope, Logger);
            if (scope is null || scope.Count == 0)
                return s_defaultScope;

            if (scope.All(i => !i.Equals("openid", StringComparison.InvariantCultureIgnoreCase)))
            {
                scope.Add("openid");
            }

            return scope.ToArray();
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
        public TetraPakAuthConfig(
            IConfiguration configuration,
            // ReSharper disable once SuggestBaseTypeForParameter
            ILogger<TetraPakAuthConfig> logger,
            bool loadDiscoveryDocument = false,
            string sectionIdentifier = null) 
        : base(configuration, logger, sectionIdentifier)
        {
            var s = Section["Environment"];
            Environment = s is { } 
                ? Enum.Parse<RuntimeEnvironment>(s) 
                : runtimeEnvironment() ?? RuntimeEnvironment.Production;
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
}