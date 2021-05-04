using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tetrapak;
using TetraPak.Auth.OpenIdConnect;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Provides access to the main Tetra Pak authorization section in the configuration.  
    /// </summary>
    public class TetraPakAuthConfig : Tetrapak.Configuration.ConfigurationSection
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
        
        string _authorityUrl;
        string _tokenIssuerUrl;
        string _userInfoUrl;
        string _clientId;
        string _clientSecret;
        string _callbackPath;
        string _authDomain;
        static  DiscoveryDocument s_discoveryDocument;
        TaskCompletionSource<DiscoveryDocument> _discoverAsyncTcs;
        
        /// <summary>
        ///   Gets configuration for how to validate JWT tokens.  
        /// </summary>
        public JwtBearerValidationConfig JwtBearerValidation { get; }
        
        // /// <summary>
        // ///   Gets configuration for how to obtain identity information.  obsolete
        // /// </summary>
        // public TetraPakIdentityConfig Identity { get; }

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
                    
                if (_discoverAsyncTcs is null)
                    return _authorityUrl ?? defaultUrl("/oauth2/authorize");

                var outcome = _discoverAsyncTcs.AwaitResult();
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
        public string ClientSecret
        {
            get => _clientSecret ?? Section [nameof(ClientSecret)];
            set => _clientSecret = value;
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
        
            bool waitForDownload;
            lock (s_syncRoot)
            {
                waitForDownload = _discoverAsyncTcs is { };
            }

            // ReSharper disable InconsistentlySynchronizedField
            if (waitForDownload)
                return _discoverAsyncTcs.Task;
            
            _discoverAsyncTcs = new TaskCompletionSource<DiscoveryDocument>();
            // ReSharper restore InconsistentlySynchronizedField

            Task.Run(async () =>
            {
                try
                {
                    using (Logger?.BeginScope("Downloading Tetra Pak Auth configuration from discovery document"))
                    {
                        var outcome = await DiscoveryDocument.LoadAsync(DiscoveryDocumentUrl, Logger
#if DEBUG
                            , TimeSpan.FromSeconds(5)
#endif
                            );
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

            return _discoverAsyncTcs.Task;
            
            DiscoveryDocument done(DiscoveryDocument discoveryDocument)
            {
                // ReSharper disable once InconsistentlySynchronizedField
                s_discoveryDocument = discoveryDocument;
                _discoverAsyncTcs.SetResult(discoveryDocument);
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

        void initDiscoveryDocument(bool refreshDiscoveryDocument)
        {
#pragma warning disable 4014
            if (s_discoveryDocument is null || refreshDiscoveryDocument)
                discoverAsync();
#pragma warning restore 4014
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
        ///   A <see cref="IConfiguration"/> instance.
        /// </param>
        /// <param name="logger">
        ///   A <see cref="ILogger"/>.
        /// </param>
        /// <param name="refreshDiscoveryDocument">
        ///   (optional; default=<c>true</c>)<br/>
        ///   When set, the instance will automatically ensure the discovery 
        /// </param>
        /// <param name="sectionIdentifier">
        ///   (optional; default=<see cref="SectionIdentifier"/>)<br/>
        ///   A custom configuration section identifier. 
        /// </param>
        public TetraPakAuthConfig(
            IConfiguration configuration, 
            ILogger<TetraPakAuthConfig> logger,
            bool refreshDiscoveryDocument = false,
            string sectionIdentifier = null) 
        : base(configuration, logger, sectionIdentifier)
        {
            var s = Section["Environment"];
            Environment = s is { } 
                ? Enum.Parse<RuntimeEnvironment>(s) 
                : runtimeEnvironment() ?? RuntimeEnvironment.Production;
            initDiscoveryDocument(refreshDiscoveryDocument);
            JwtBearerValidation = new JwtBearerValidationConfig(Section, logger);
            IdentitySource = parseIdentitySource();
            Scope = parseScope();
        }
    }
}