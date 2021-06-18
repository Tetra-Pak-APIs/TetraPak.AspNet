using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Implementors of this interface are able to acquire a token using the
    ///   OAuth Client Credentials grant. 
    /// </summary>
    public interface IClientCredentialsService
    {
        /// <summary>
        ///   Requests a token using the OAuth Client Credentials grant.   
        /// </summary>
        /// <param name="cancellationToken">
        ///   A cancellation token.
        /// </param>
        /// <param name="clientCredentials">
        ///   (optional)<br/>
        ///   Specifies client credentials.
        /// </param>
        /// <param name="scope">
        ///   (optional)<br/>
        ///   Scope to be requested for the authorization.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> instance indicating success/failure, and the requested token
        ///   when successful; otherwise an <see cref="Exception"/>.
        /// </returns>
        Task<Outcome<ClientCredentialsResponse>> AcquireTokenAsync(
            CancellationToken cancellationToken,
            Credentials clientCredentials = null,
            MultiStringValue scope = null);
    }

    public class ClientCredentialsResponse
    {
        public ActorToken AccessToken { get; }

        public TimeSpan ExpiresIn { get; }

        public MultiStringValue Scope { get; }

        internal static Outcome<ClientCredentialsResponse> TryParse(ClientCredentialsResponseBody body)
        {
            var accessToken = string.IsNullOrWhiteSpace(body.TokenType)
                ? body.AccessToken
                : $"{body.TokenType} {body.AccessToken}";
            if (!ActorToken.TryParse(accessToken, out var actorToken))
                return Outcome<ClientCredentialsResponse>.Fail(
                    new FormatException($"Failed while parsing access_token: {accessToken}"));

            var expiresIn = TimeSpan.Zero;
            if (!string.IsNullOrWhiteSpace(body.ExpiresIn))
            {
                if (!int.TryParse(body.ExpiresIn, out var seconds))
                    return Outcome<ClientCredentialsResponse>.Fail(
                        new FormatException($"Failed while parsing expires_in: {body.ExpiresIn}"));
                expiresIn = TimeSpan.FromSeconds(seconds);
            }

            if (string.IsNullOrWhiteSpace(body.Scope))
                return Outcome<ClientCredentialsResponse>.Success(new ClientCredentialsResponse(
                    accessToken, expiresIn, null));

            if (!MultiStringValue.TryParse(body.Scope, out var scope))
                return Outcome<ClientCredentialsResponse>.Fail(
                    new FormatException($"Failed while parsing expires_in: {body.ExpiresIn}"));

            return Outcome<ClientCredentialsResponse>.Success(new ClientCredentialsResponse(
                accessToken, expiresIn, scope));
        }
        
        ClientCredentialsResponse(ActorToken accessToken, TimeSpan expiresIn, MultiStringValue scope)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            Scope = scope;
        }
    }
    
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