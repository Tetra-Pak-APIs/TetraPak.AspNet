using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

// NOTE Disabled compiler warning about use of async with no await in body:
#pragma warning disable 1998

namespace TetraPak.AspNet.OpenIdConnect
{
    partial class DiscoveryDocument
    {
        static ReadDocumentPolicy s_readPolicy = ReadDocumentPolicy.All; // todo support cached document
        static string DefaultCacheFilePath => Path.Combine(Environment.CurrentDirectory, "_discovery_document.json");

        /// <summary>
        ///   Gets or sets a behavior for how to load the discovery document.
        ///   The value is a "flag" <see cref="Enum"/> value, allowing for fallbacks if one policy fails.
        /// </summary>
        /// <exception cref="ArgumentException">
        ///   Attempt to set value to <see cref="ReadDocumentPolicy.Configured"/> (this property _is_ the configured
        ///   value and, therefore, cannot itself be set to this value). 
        /// </exception>
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

        /// <summary>
        ///   Loads and returns the <see cref="DiscoveryDocument"/>, as per the requested behavior. 
        /// </summary>
        /// <param name="args">
        ///   Specifies behavior for reading the <see cref="DiscoveryDocument"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="DiscoveryDocument"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   Required configuration was not provided; such as <see cref="ReadDiscoveryDocumentArgs.MasterSourceUrl"/>
        ///   or <see cref="ReadDiscoveryDocumentArgs.AuthConfig"/>.
        /// </exception>
        /// <seealso cref="ReadDocumentPolicy"/>
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
        
        /// <summary>
        ///   Creates and returns a default <see cref="DiscoveryDocument"/>.
        /// </summary>
        /// <param name="authConfig">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <returns>
        ///   A <see cref="DiscoveryDocument"/> object.
        /// </returns>
        public static DiscoveryDocument GetDefault(TetraPakAuthConfig authConfig)
        {
            return GetDefault(authConfig.AuthDomain);
        }
        
        /// <summary>
        ///   Creates and returns a default <see cref="DiscoveryDocument"/>.
        /// </summary>
        /// <param name="issuer">
        ///   Initializes the token issuer endpoint (URL).   
        /// </param>
        /// <param name="supportedResponseType">
        ///   (optional)<br/>
        ///   Initializes the <see cref="ResponseTypesSupported"/> property.
        /// </param>
        /// <param name="supportedSubjectTypes">
        ///   (optional)<br/>
        ///   Initializes the <see cref="SubjectTypesSupported"/> property.
        /// </param>
        /// <param name="supportedGrantTypes">
        ///   (optional)<br/>
        ///   Initializes the <see cref="GrantTypesSupported"/> property.
        /// </param>
        /// <param name="supportedIdTokenSigningAlgValues">
        ///   (optional)<br/>
        ///   Initializes the <see cref="IdTokenSigningAlgValuesSupported"/> property.
        /// </param>
        /// <returns></returns>
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
                logger.Trace($"Successfully downloaded discovery document from {url}");
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

    /// <summary>
    ///   Specifies behavior for reading a <see cref="DiscoveryDocument"/>.
    /// </summary>
    public class ReadDiscoveryDocumentArgs
    {
        /// <summary>
        ///   Gets or sets the master (remote) source for the discovery document.
        /// </summary>
        public string MasterSourceUrl { get; set; }

        /// <summary>
        ///   Gets or sets a maximum allowed time for reading the <see cref="DiscoveryDocument"/>,
        ///   after which the operation will fail (and, potentially, fall back to some other source
        ///   as specified by the <see cref="Policy"/>).   
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        ///   Gets or sets a logging provider.
        /// </summary>
        public ILogger Logger { get; set; }
        
        /// <summary>
        ///   Gets or sets a (fallback) policy for reading a <see cref="DiscoveryDocument"/>.
        /// </summary>
        public ReadDocumentPolicy Policy { get; set; }

        /// <summary>
        ///   Gets or sets the Tetra Pak integration configuration.
        /// </summary>
        public TetraPakAuthConfig AuthConfig { get; set; }

        /// <summary>
        ///   Gets or sets a local (file) path for locally caching the <see cref="DiscoveryDocument"/>. 
        /// </summary>
        public string LocalCachePath { get; set; }

        /// <summary>
        ///   Creates default configuration for reading <see cref="DiscoveryDocument"/> from a master (remote) source.
        /// </summary>
        /// <param name="authConfig">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <param name="timeout">
        ///   Gets or sets a maximum allowed time for reading the <see cref="DiscoveryDocument"/>,
        ///   after which the operation will fail (and, potentially, fall back to some other source
        ///   as specified by the <see cref="Policy"/>).
        /// </param>
        /// <param name="fallbackPolicy">
        ///   A (fallback) policy for reading a <see cref="DiscoveryDocument"/>.
        /// </param>
        /// <param name="localCachePath">
        ///   A local (file) path for locally caching the <see cref="DiscoveryDocument"/>.
        /// </param>
        /// <returns>
        ///   A <see cref="ReadDiscoveryDocumentArgs"/> object.
        /// </returns>
        public static ReadDiscoveryDocumentArgs FromMasterSource(
            TetraPakAuthConfig authConfig,
            TimeSpan? timeout = null,
            ReadDocumentPolicy fallbackPolicy = ReadDocumentPolicy.All,
            string localCachePath = null)
        {
            return new ReadDiscoveryDocumentArgs
            {
                MasterSourceUrl = authConfig.DiscoveryDocumentUrl,
                                  // ?? throw new InvalidOperationException( obsolete
                                  //     "Cannot read discovery document from master source. "+
                                  //     "Configuration does not specify a URL for the discovery document"),
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

        /// <summary>
        ///    Creates default configuration for reading <see cref="DiscoveryDocument"/>.
        /// </summary>
        /// <param name="authConfig">
        ///    The Tetra Pak integration configuration.   
        /// </param>
        /// <returns>
        ///   A <see cref="ReadDiscoveryDocumentArgs"/> object.
        /// </returns>
        public static ReadDiscoveryDocumentArgs FromDefault(TetraPakAuthConfig authConfig)
        {
            return new ReadDiscoveryDocumentArgs
            {
                AuthConfig = authConfig,
                Logger = authConfig.Logger
            };
        }

        /// <summary>
        ///   Initializes the <see cref="ReadDiscoveryDocumentArgs"/>.
        /// </summary>
        /// <param name="logger">
        ///   A logger provider.
        /// </param>
        public ReadDiscoveryDocumentArgs(ILogger<ReadDiscoveryDocumentArgs> logger = null)
        {
            Logger = logger;
            Policy = ReadDocumentPolicy.Configured;
        }
    }

    /// <summary>
    ///   Used to specify a fallback policy to be used when reading a <see cref="DiscoveryDocument"/>.
    /// </summary>
    /// <seealso cref="DiscoveryDocument.ReadAsync"/>
    /// <seealso cref="ReadDiscoveryDocumentArgs"/>
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