using System.Text.Json.Serialization;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Represents the response from a successful client credentials request
    ///   (see <see cref="IClientCredentialsService.AcquireTokenAsync"/>).
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    class ClientCredentialsResponseBody
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }
    }
}