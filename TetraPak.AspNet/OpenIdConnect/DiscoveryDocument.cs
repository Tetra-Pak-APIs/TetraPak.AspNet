using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TetraPak.AspNet.OpenIdConnect
{
    /// <summary>
    ///   Represents the important parts of an OIDC discovery document
    ///   (see: https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata).
    /// </summary>
    public partial class DiscoveryDocument
    {
        /// <summary>
        ///   The default path for a well known open id discovery document (a.k.a 'metadata document').
        /// </summary>
        public const string DefaultPath = "/.well-known/openid-configuration";
        
        /// <summary>
        ///  The default authority endpoint for a well known open id discovery document (a.k.a 'metadata document').  
        /// </summary>
        public const string DefaultAuthorizationPath = "/oauth2/authorize";

        /// <summary>
        ///  The default token issuer endpoint for a well known open id discovery document (a.k.a 'metadata document').  
        /// </summary>
        public const string DefaultTokenPath = "/oauth2/token";

        /// <summary>
        ///  The default user information endpoint for a well known open id discovery document (a.k.a 'metadata document').  
        /// </summary>
        public const string DefaultUserInfoPath = "/idp/userinfo";
        
        /// <summary>
        ///  The default JWT keys endpoint for a well known open id discovery document (a.k.a 'metadata document').  
        /// </summary>
        public const string DefaultJwksPath = "/jwks";
        
        /// <summary>
        ///   Gets or sets the token issuer URL.
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        ///   Gets or sets the authority endpoint.
        /// </summary>
        [JsonPropertyName("authorization_endpoint")]
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        ///   Gets or sets the token issuer endpoint.
        /// </summary>
        [JsonPropertyName("token_endpoint")]
        public string TokenEndpoint { get; set; }

        /// <summary>
        ///   Gets or sets the user information endpoint.
        /// </summary>
        [JsonPropertyName("userinfo_endpoint")]
        public string UserInformationEndpoint { get; set; }

        /// <summary>
        ///   Gets or sets the JWT keys endpoint.
        /// </summary>
        [JsonPropertyName("jwks_uri")]
        public string JwksUri { get; set; }

        /// <summary>
        ///   Gets or sets the supported types of responses.
        /// </summary>
        [JsonPropertyName("response_types_supported")]
        public IEnumerable<string> ResponseTypesSupported { get; set; }

        /// <summary>
        ///   Gets or sets the supported types subject types.
        /// </summary>
        [JsonPropertyName("subject_types_supported")]
        public IEnumerable<string> SubjectTypesSupported { get; set; }

        /// <summary>
        ///   Gets or sets the supported scope.
        /// </summary>
        [JsonPropertyName("scopes_supported")]
        public IEnumerable<string> ScopesSupported { get; set; }

        /// <summary>
        ///   Gets or sets the supported grant types.
        /// </summary>
        [JsonPropertyName("grant_types_supported")]
        public IEnumerable<string> GrantTypesSupported { get; set; }

        /// <summary>
        ///   Gets or sets a collection of hashing algorithms supported.
        /// </summary>
        [JsonPropertyName("id_token_signing_alg_values_supported")]
        public IEnumerable<string> IdTokenSigningAlgValuesSupported { get; set; }
   }
}