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
        ///   or <see cref="ReadDiscoveryDocumentArgs.TetraPakConfig"/>.
        /// </exception>
        /// <seealso cref="ReadDocumentPolicy"/>
        public static async Task<Outcome<DiscoveryDocument>> ReadAsync(ReadDiscoveryDocumentArgs args)
        {
            var policy = args.Policy == ReadDocumentPolicy.Configured ? ReadPolicy : args.Policy;
            if ((policy & ReadDocumentPolicy.Master) == ReadDocumentPolicy.Master)
            {
                if (args.MasterSourceUrl is null)
                    throw new InvalidOperationException($"Cannot read discovery document from master source. Missing {nameof(ReadDiscoveryDocumentArgs.MasterSourceUrl)}");
                
                var outcome = await readMasterAsync(args.MasterSourceUrl, args.Logger, args.Timeout, args.GetMessageId());
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
                if (args.TetraPakConfig is null)
                    throw new InvalidOperationException($"Cannot read discovery document from master source. Missing {nameof(ReadDiscoveryDocumentArgs.TetraPakConfig)}");
                    
                return Outcome<DiscoveryDocument>.Success(GetDefault(args.TetraPakConfig));
            }

            return Outcome<DiscoveryDocument>.Fail(new Exception($"Could not read {typeof(DiscoveryDocument)} (policy={args.Policy})"));
        }
        
        /// <summary>
        ///   Creates and returns a default <see cref="DiscoveryDocument"/>.
        /// </summary>
        /// <param name="config">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <returns>
        ///   A <see cref="DiscoveryDocument"/> object.
        /// </returns>
        public static DiscoveryDocument GetDefault(TetraPakConfig config)
        {
            return GetDefault(config.AuthDomain);
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
        
        static async Task<Outcome<DiscoveryDocument>> readMasterAsync(string url,
            ILogger? logger = null,
            TimeSpan? timeout = null, 
            string? messageId = null)
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
                    logger.Warning(() => 
                        $"Failed to download discovery document. Status: {(int) response.StatusCode} {response.ReasonPhrase}");
                    return Outcome<DiscoveryDocument>.Fail();
                }

                var stream = await response.Content.ReadAsStreamAsync();
                var discoveryDocument = await JsonSerializer.DeserializeAsync<DiscoveryDocument>(stream);
                logger.Trace($"Successfully downloaded discovery document from {url}", messageId);
                return Outcome<DiscoveryDocument>.Success(discoveryDocument!);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to download discovery document", messageId);
                return Outcome<DiscoveryDocument>.Fail(new Exception("Failed to download discovery document", ex));
            }
        }

        static async Task<Outcome<DiscoveryDocument>> readCachedAsync(ILogger? logger, TimeSpan? timeout)
        {
            throw new NotImplementedException(); // todo support cached discovery document
        }

        void cache(string? path = null)
        {
            throw new NotImplementedException(); // todo support cached discovery document
        }
    }
}