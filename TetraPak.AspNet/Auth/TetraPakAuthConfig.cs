using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TetraPak.AspNet.OpenIdConnect;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakAuthConfig : TetraPak.Configuration.ConfigurationSection
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
        
        protected override string SectionIdentifier => "Auth-TetraPak"; 
        protected const string SectionJwtBearerValidationIdentifier = "ValidateJwtBearer"; 
        
        string _authorityUrl;
        string _tokenIssuerUrl;
        string _userInfoUrl;
        string _clientId;
        string _clientSecret;
        string _callbackPath;
        string _authDomain;
        string _authorizationHeader;
        bool? _isPkceUsed;
        int? _refreshThresholdSeconds;
        static  DiscoveryDocument s_discoveryDocument;
        TaskCompletionSource<DiscoveryDocument> _masterSourceTcs;
        
        /// <summary>
        ///   Gets configuration for how to validate JWT tokens.  
        /// </summary>
        public JwtBearerValidationConfig JwtBearerValidation { get; }
        
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

        /// <summary>
        ///   Gets or sets the name of the header used to obtain the token to be used for authorizing the actor.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///   An invalid/empty value was assigned.
        /// </exception>
        public string AuthorizationHeader
        {
            get => _authorizationHeader ?? Section[nameof(AuthorizationHeader)] ?? HeaderNames.Authorization;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value),
                        $"{nameof(AuthorizationHeader)} must be a valid identifier");

                _authorizationHeader = value;
            }
        }
    
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
            // ReSharper disable once UnusedMember.Global
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
        public string AuthorityUrl
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
        ///   Gets a configured client id.
        /// </summary>
        public string ClientId
        {
            get => _clientId ?? Section [nameof(ClientId)];
            set => _clientId = value;
        }

        /// <summary>
        ///   Gets a configured client secret.
        /// </summary>
        [RestrictedValue]
        public string ClientSecret
        {
            get => _clientSecret ?? Section [nameof(ClientSecret)];
            set => _clientSecret = value;
        }

        /// <summary>
        ///  Gets or sets a value specifying whether PKCE is to be used where applicable.
        /// </summary>
        public bool IsPkceUsed
        {
            get => _isPkceUsed ?? parseBool(Section[nameof(IsPkceUsed)]);
            set => _isPkceUsed = value;
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
            get => _refreshThresholdSeconds ?? parseInt(Section[nameof(RefreshThreshold)]);
            set => _refreshThresholdSeconds = value;
        }

        static bool parseBool(string s, bool useDefault = false)
        {
            return string.IsNullOrWhiteSpace(s) 
                ? useDefault 
                : bool.TryParse(s, out var b) 
                    ? b 
                    : useDefault;
        }
        
        static int parseInt(string s, int useDefault = 0)
        {
            useDefault = Math.Abs(useDefault);
            return string.IsNullOrWhiteSpace(s) 
                ? useDefault 
                : int.TryParse(s, out var result) 
                    ? result 
                    : useDefault;
        }

        /// <summary>
        ///   Gets a configured callback path, or the default one (<see cref="DefaultCallbackPath"/>).  
        /// </summary>
        public string CallbackPath
        {
            get => _callbackPath ?? Section[nameof(CallbackPath)] ?? DefaultCallbackPath;
            set => _callbackPath = value;
        }
        
        /// <summary>
        ///   Specifies the source for identity claims (see <see cref="TetraPakIdentitySource"/>).
        /// </summary>
        public TetraPakIdentitySource IdentitySource { get; set; }

        /// <summary>
        ///   Gets or sets a scope of identity claims to be requested while authenticating the identity.
        ///   When omitted a default scope will be used. 
        /// </summary>
        public string[] Scope { get; set; } 

        void logSettings()
        {
            if (Logger is null)
                return;
            
            var sb = new StringBuilder();
            foreach (var property in GetType().GetProperties())
            {
                var jsonProperty = property.GetCustomAttribute<JsonPropertyNameAttribute>();
                var isRestricted = property.GetCustomAttribute<RestrictedValueAttribute>() is { }; 
                var key = jsonProperty?.Name ?? property.Name;
                var value = isRestricted ? "**********" : property.GetValue(this);
                sb.AppendLine($"  {key}: {getValue(value)}");
            }
            Logger.LogInformation("Auth Configuration:\n{Configuration}", sb.ToString());

            static string getValue(object value)
            {
                if (value is string s)
                    return s;

                return value.IsCollectionOf<string>(out var items) 
                    ? items.ConcatCollection(" ") 
                    : value?.ToString();
            }
        }
        
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
                        // var args = ReadDiscoveryDocumentArgs.FromDefault(this); // nisse (just test with Default for now; I'm in a hurry getting it to work for Pardot -JR)                        

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
                        logSettings();
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

//         void initDiscoveryDocument(bool refreshDiscoveryDocument) obsolete
//         {
// #pragma warning disable 4014
//             if (s_discoveryDocument is null || refreshDiscoveryDocument)
//                 discoverAsync();
// #pragma warning restore 4014
//         }
        
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
            _isPkceUsed = true;
            if (loadDiscoveryDocument)
            {
                discoverAsync();
            }
        }
    }
}