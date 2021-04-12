using System;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tetrapak;
using TetraPak.Api.Auth;
using TetraPak.Auth.OpenIdConnect;
using TetraPak.Logging;

namespace TetraPak.AspNet.Configuration
{
    public class TetraPakAuthConfig
    {
        const string KeySection = "Auth-TetraPak";
        // const string KeyDiscoveryDocumentUrl = "DiscoveryDocumentUrl"; obsolete
        const string KeyAuthorityUrl = "KeyAuthorityUrl";
        const string KeyTokenIssuerUrl = "TokenIssuerUrl";
        const string KeyUserInfoUrl = "UserInfoUrl";

        protected IConfigurationSection Section { get; }
        
        readonly ILogger<TetraPakAuthConfig> _logger;
        readonly AuthConfigAutomaticDiscoveryStrategy _discoveryStrategy;
        string[] _scope;
        string _authorityUrl;
        string _tokenIssuerUrl;
        string _userInfoUrl;
        bool _validateLifetime = true;
        string _authDomain;
        DiscoveryDocument _discoveryDocument;

        public bool IsInitialized { get; private set; }
        
        protected async Task<DiscoveryDocument> GetDiscoveryDocumentAsync()
        {
            if (_discoveryDocument is { })
                return _discoveryDocument; 
                
            _discoveryDocument = await discoverAsync();
            return _discoveryDocument;
        }
    
        public RuntimeEnvironment Environment { get; }

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
        
        public string DiscoveryDocumentUrl => Section[nameof(DiscoveryDocumentUrl)] 
                                              ?? $"{AuthDomain}{DiscoveryDocument.DefaultPath}";
        
        public async Task<string> GetAuthorityUrlAsync()
        {
            var url = _authorityUrl ?? Section[KeyAuthorityUrl];
            if (url is {})
                return url;

            var document = await GetDiscoveryDocumentAsync();
            return document.AuthorizationEndpoint;
        }

        public async Task<string> GetTokenIssuerUrlAsync()
        {
            var url = _tokenIssuerUrl ?? Section[KeyTokenIssuerUrl];
            if (url is {})
                return url;

            var document = await GetDiscoveryDocumentAsync();
            return document.TokenEndpoint;
        }

        public async Task<string> GetUserInformationUrlAsync()
        {
            var url = _userInfoUrl ?? Section[KeyUserInfoUrl];
            if (url is {})
                return url;

            var document = await GetDiscoveryDocumentAsync();
            return document.UserInfoEndpoint;
        }

        public bool ValidateLifetime => Section.GetNullableBool(nameof(ValidateLifetime)) ?? _validateLifetime; 

        public string[] Scope => _scope ?? Section["Scope"]?.Split(" ");

        public bool IsAuthDomainAssigned => !string.IsNullOrWhiteSpace(_authDomain);

        public TetraPakAuthConfig WithScope(params string[] scope)
        {
            _scope = scope;
            return this;
        }

        void logSettings()
        {
            if (_logger is null)
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
            _logger.LogInformation("Auth Configuration:\n{Configuration}", sb.ToString());

            static string getValue(object value)
            {
                if (value is string s)
                    return s;

                return value.IsCollectionOf<string>(out var items) 
                    ? items.ConcatCollection(" ") 
                    : value?.ToString();
            }
        }
        
        async Task<DiscoveryDocument> discoverAsync()
        {
            using (_logger?.BeginScope("Downloading Tetra Pak Auth configuration from discovery document"))
            {
                var outcome = await DiscoveryDocument.LoadAsync(DiscoveryDocumentUrl);
                if (!outcome)
                {
                    _logger?.Error(outcome.Exception, "Could not download discovery document");
                    IsInitialized = _discoveryStrategy == AuthConfigAutomaticDiscoveryStrategy.SafeDiscovery;
                    return null;
                }

                var discoveryDocument = outcome.Value;
                _authorityUrl = discoveryDocument.AuthorizationEndpoint;
                _tokenIssuerUrl = discoveryDocument.TokenEndpoint;
                _userInfoUrl = discoveryDocument.UserInfoEndpoint;
                logSettings();
                IsInitialized = true;
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
                : (RuntimeEnvironment?) null;
        }

        protected TetraPakAuthConfig(IConfigurationSection section)
        {
            Section = section;
        }
    }
}