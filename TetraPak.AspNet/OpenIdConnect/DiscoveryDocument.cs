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
        ///   The default path for a well known open id discovery document (a.k.a 'metadata document')
        /// </summary>
        public const string DefaultPath = "/.well-known/openid-configuration";
        public const string DefaultAuthorizationPath = "/oauth2/authorize";
        public const string DefaultTokenPath = "/oauth2/token";
        public const string DefaultUserInfoPath = "/idp/userinfo";
        public const string DefaultJwksPath = "/jwks";
        
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("authorization_endpoint")]
        public string AuthorizationEndpoint { get; set; }

        [JsonPropertyName("token_endpoint")]
        public string TokenEndpoint { get; set; }

        [JsonPropertyName("userinfo_endpoint")]
        public string UserInformationEndpoint { get; set; }

        [JsonPropertyName("jwks_uri")]
        public string JwksUri { get; set; }

        [JsonPropertyName("response_types_supported")]
        public IEnumerable<string> ResponseTypesSupported { get; set; }

        [JsonPropertyName("subject_types_supported")]
        public IEnumerable<string> SubjectTypesSupported { get; set; }

        [JsonPropertyName("scopes_supported")]
        public IEnumerable<string> ScopesSupported { get; set; }

        [JsonPropertyName("grant_types_supported")]
        public IEnumerable<string> GrantTypesSupported { get; set; }

        [JsonPropertyName("id_token_signing_alg_values_supported")]
        public IEnumerable<string> IdTokenSigningAlgValuesSupported { get; set; }
   }
}