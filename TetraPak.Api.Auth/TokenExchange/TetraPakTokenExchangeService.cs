using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.Auth;
using TetraPak.Auth.OpenIdConnect;

namespace TetraPak.Api.Auth.TokenExchange
{
    public class TetraPakTokenExchangeService : ITokenExchangeService
    {
        readonly DiscoveryDocument _discovery;

        protected ILogger<TetraPakTokenExchangeService> Logger { get; }

        /// <inheritdoc />
        public Task<Outcome<TokenExchangeResponse>> ExchangeAccessTokenAsync(Credentials credentials, string accessToken, CancellationToken cancellationToken)
        {
            var args = new TokenExchangeArgs(credentials, accessToken, "urn:ietf:params:oauth:token-type:id_token");
            return ExchangeAsync(args, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Outcome<TokenExchangeResponse>> ExchangeAsync(
            TokenExchangeArgs args, 
            CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            if (!(args.Credentials is BasicAuthCredentials basicAuthCredentials))
                return Outcome<TokenExchangeResponse>.Fail(
                    new InvalidOperationException($"Tetra Pak token exchange expects credentials to be of type {typeof(BasicAuthCredentials)}"));
                
            client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
            try
            {
                var dictionary = args.ToDictionary();
                var content = new FormUrlEncodedContent(dictionary);
                var response = await client.PostAsync(
                    _discovery.TokenEndpoint, 
                    content, 
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
#if NET5_0_OR_GREATER
                    var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
#else                    
                    var errorContent = await response.Content.ReadAsStringAsync();
#endif
                    var statusCode = ((int) response.StatusCode).ToString();
                    var ex = new Exception($"Call failed with status: {statusCode} {response.ReasonPhrase}. {errorContent}");
                    Logger?.LogError(ex, "Token exchange failure");
                    return Outcome<TokenExchangeResponse>.Fail(ex);
                }

#if NET5_0_OR_GREATER
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
#else
                var stream = await response.Content.ReadAsStreamAsync();
#endif
                var responseBody =
                    await JsonSerializer.DeserializeAsync<TokenExchangeResponse>(stream,
                        cancellationToken: cancellationToken);
                return Outcome<TokenExchangeResponse>.Success(responseBody);
            }
            catch (Exception ex)
            {
                return Outcome<TokenExchangeResponse>.Fail(ex);
            }
        }

        /// <inheritdoc />
        public virtual AuthenticationHeaderValue OnGetAuthorizationFrom(TokenExchangeResponse tokenExchangeResponse)
        {
            var accessToken = tokenExchangeResponse.AccessToken;
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public TetraPakTokenExchangeService(DiscoveryDocument discovery, ILogger<TetraPakTokenExchangeService> logger)
        {
            _discovery = discovery ?? throw new ArgumentNullException(nameof(discovery));
            Logger = logger;
        }

    }
}