using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;


namespace TetraPak.AspNet.OpenIdConnect
{
    partial class DiscoveryDocument
    {
        static ReadDocumentPolicy s_readPolicy = ReadDocumentPolicy.All; // todo support cached document
        static string DefaultCacheFilePath => Path.Combine(Environment.CurrentDirectory, "_discovery_document.json");

        public static ReadDocumentPolicy ReadPolicy
        {
            get => s_readPolicy;
            set
            {
                if (value == ReadDocumentPolicy.Configured)
                    throw new ArgumentException($"The configured fallback policy cannot itself be set to {value}");
                
                s_readPolicy = value;
            }
        }

        public static async Task<Outcome<DiscoveryDocument>> ReadAsync(ReadDiscoveryDocumentArgs args)
        {
            var policy = args.Policy == ReadDocumentPolicy.Configured ? ReadPolicy : args.Policy;
            if ((policy & ReadDocumentPolicy.Master) == ReadDocumentPolicy.Master)
            {
                if (args.MasterSourceUrl is null)
                    throw new InvalidOperationException($"Cannot read discovery document from master source. Missing {nameof(ReadDiscoveryDocumentArgs.MasterSourceUrl)}");
                
                var outcome = await readMasterAsync(args.MasterSourceUrl, args.Logger, args.Timeout);
                if (outcome)
                    return outcome;
            }

            if ((policy & ReadDocumentPolicy.Cached) == ReadDocumentPolicy.Cached)
            {
                var outcome = await readCachedAsync(args.Logger, args.Timeout);
                if (outcome)
                    return outcome;
            }

            if ((policy & ReadDocumentPolicy.Default) == ReadDocumentPolicy.Default)
            {
                if (args.AuthConfig is null)
                    throw new InvalidOperationException($"Cannot read discovery document from master source. Missing {nameof(ReadDiscoveryDocumentArgs.AuthConfig)}");
                    
                return Outcome<DiscoveryDocument>.Success(GetDefault(args.AuthConfig));
            }

            return Outcome<DiscoveryDocument>.Fail(new Exception($"Could not read {typeof(DiscoveryDocument)} (policy={args.Policy})"));
        }
        
        public static DiscoveryDocument GetDefault(TetraPakAuthConfig authConfig)
        {
            return GetDefault(authConfig.AuthDomain);
        }
        
        public static DiscoveryDocument GetDefault(
            string issuer,
            string supportedResponseType = "code", 
            string supportedSubjectTypes = "openid, profile, email, groups, domain", 
            string supportedGrantTypes = "authorization_code, refresh_token, urn:ietf:params:oauth:grant-type:token-exchange", 
            string supportedIdTokenSigningAlgValues = "RS256")
        {
            var document = new DiscoveryDocument
            {
                Issuer = issuer,
                AuthorizationEndpoint = $"{issuer}{DefaultAuthorizationPath}",
                TokenEndpoint = $"{issuer}{DefaultTokenPath}",
                UserInformationEndpoint = $"{issuer}{DefaultUserInfoPath}",
                JwksUri = $"{issuer}{DefaultJwksPath}",
            };
            if (!string.IsNullOrWhiteSpace(supportedResponseType))
            {
                document.ResponseTypesSupported = new MultiStringValue(supportedResponseType).Items;
            }
            if (!string.IsNullOrWhiteSpace(supportedSubjectTypes))
            {
                document.SubjectTypesSupported = new MultiStringValue(supportedSubjectTypes).Items;
            }
            if (!string.IsNullOrWhiteSpace(supportedGrantTypes))
            {
                document.GrantTypesSupported = new MultiStringValue(supportedGrantTypes).Items;
            }
            if (!string.IsNullOrWhiteSpace(supportedIdTokenSigningAlgValues))
            {
                document.IdTokenSigningAlgValuesSupported = new MultiStringValue(supportedIdTokenSigningAlgValues).Items;
            }

            return document;
        }
        
        static async Task<Outcome<DiscoveryDocument>> readMasterAsync(
            string url,
            ILogger logger = null,
            TimeSpan? timeout = null)
        {
            try
            {
                using var client = new HttpClient();
                if (timeout.HasValue)
                {
                    client.Timeout = timeout.Value;
                }
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    logger.Warning($"Failed to download discovery document. Status: {(int) response.StatusCode} {response.ReasonPhrase}");
                    return Outcome<DiscoveryDocument>.Fail();
                }

                var stream = await response.Content.ReadAsStreamAsync();
                var discoveryDocument = await JsonSerializer.DeserializeAsync<DiscoveryDocument>(stream);
                logger.Debug($"Successfully downloaded discovery document from {url}");
                return Outcome<DiscoveryDocument>.Success(discoveryDocument);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to download discovery document");
                return Outcome<DiscoveryDocument>.Fail(new Exception("Failed to download discovery document", ex));
            }
        }

        static async Task<Outcome<DiscoveryDocument>> readCachedAsync(ILogger logger, TimeSpan? timeout)
        {
            throw new NotImplementedException(); // todo support cached discovery document
        }

        void cache(string path = null)
        {
            throw new NotImplementedException(); // todo support cached discovery document
        }
    }

    public class ReadDiscoveryDocumentArgs
    {
        public string MasterSourceUrl { get; set; }

        public TimeSpan? Timeout { get; set; }

        public ILogger Logger { get; set; }
        
        public ReadDocumentPolicy Policy { get; set; }

        public TetraPakAuthConfig AuthConfig { get; set; }

        public string LocalCachePath { get; set; }

        public static ReadDiscoveryDocumentArgs FromMasterSource(
            TetraPakAuthConfig authConfig,
            TimeSpan? timeout = null,
            ReadDocumentPolicy fallbackPolicy = ReadDocumentPolicy.All,
            string localCachePath = null)
        {
            return new()
            {
                MasterSourceUrl = authConfig.DiscoveryDocumentUrl 
                                  ?? throw new InvalidOperationException(
                                      "Cannot read discovery document from master source. "+
                                      "Configuration does not specify a URL for the discovery document"),
                Logger = authConfig.Logger,
                AuthConfig = authConfig,
                Timeout = timeout,
                Policy = fallbackPolicy,
                LocalCachePath = string.IsNullOrWhiteSpace(localCachePath) 
                    ? defaultLocalCachePath()
                    : localCachePath
            };
        }

        static string defaultLocalCachePath()
        {
            return "./_discoveryDocument.json";
        }

        public static ReadDiscoveryDocumentArgs FromDefault(TetraPakAuthConfig authConfig)
        {
            return new ReadDiscoveryDocumentArgs
            {
                AuthConfig = authConfig,
                Logger = authConfig.Logger
            };
        }

        public ReadDiscoveryDocumentArgs(ILogger<ReadDiscoveryDocumentArgs> logger = null)
        {
            Logger = logger;
            Policy = ReadDocumentPolicy.Configured;
        }
    }

    [Flags]
    public enum ReadDocumentPolicy
    {
        /// <summary>
        ///   No fallback allowed; reading document will fail.
        /// </summary>
        None = 0,
        
        /// <summary>
        ///   Try reading from master source, such as a remote service.
        /// </summary>
        Master = 1,
        
        /// <summary>
        ///   Fallback to cached document.
        /// </summary>
        Cached = 2,
        
        /// <summary>
        ///   Fallback to default document.
        /// </summary>
        Default = 4,
        
        /// <summary>
        ///   All fallback policies are supported.
        /// </summary>
        All = Master | Cached | Default,
        
        /// <summary>
        ///   Use configured fallback policy.
        /// </summary>
        Configured = 16
    }
}