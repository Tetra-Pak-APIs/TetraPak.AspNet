using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class TetraPakTokenExchangeService : ITokenExchangeService, IMessageIdProvider
    {
        const string CacheRepository = CacheRepositories.Tokens.TokenExchange;

        readonly AmbientData _ambientData;

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        protected ILogger Logger => _ambientData.Logger;

        protected TetraPakApiAuthConfig AuthConfig =>  (TetraPakApiAuthConfig) _ambientData.AuthConfig;

        /// <inheritdoc />
        public string GetMessageId(bool enforce = false) => _ambientData.GetMessageId();

        /// <inheritdoc />
        public async Task<Outcome<TokenExchangeResponse>> ExchangeAccessTokenAsync(
            Credentials credentials, 
            ActorToken accessToken,
            CancellationToken cancellationToken)
        {
            var cachedOutcome = await getCached(credentials);
            if (cachedOutcome)
                return cachedOutcome;

            var args = new TokenExchangeArgs(
                credentials, 
                accessToken, 
                "urn:ietf:params:oauth:token-type:id_token");
            return await ExchangeAsync(args, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Outcome<TokenExchangeResponse>> ExchangeAsync(
            TokenExchangeArgs args, 
            CancellationToken cancellationToken)
        {
            var cachedOutcome = await getCached(args.Credentials);
            if (cachedOutcome)
                return cachedOutcome;
            
            using var client = new HttpClient();
            if (args.Credentials is not BasicAuthCredentials basicAuthCredentials)
                return Outcome<TokenExchangeResponse>.Fail(
                    new InvalidOperationException(
                        $"Tetra Pak token exchange expects credentials to be of type {typeof(BasicAuthCredentials)}"));
                
            client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
            try
            {
                var discovery = await AuthConfig.GetDiscoveryDocumentAsync();
                var dictionary = args.ToDictionary();
                var response = await client.PostAsync(
                    discovery.TokenEndpoint, 
                    new FormUrlEncodedContent(dictionary), 
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var ex = new HttpException(response);
                    Logger.Error(ex, "Token exchange failure", GetMessageId());
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

                await cache(args.Credentials, responseBody);
                return Outcome<TokenExchangeResponse>.Success(responseBody);
            }
            catch (Exception ex)
            {
                return Outcome<TokenExchangeResponse>.Fail(ex);
            }
        }

        async Task<Outcome<TokenExchangeResponse>> getCached(Credentials credentials)
        {
            if (_ambientData.Cache is null)
                return Outcome<TokenExchangeResponse>.Fail(new Exception($"Caching is not supported"));
                
            var key = credentials.Identity;
            return await _ambientData?.Cache?.GetAsync<TokenExchangeResponse>(CacheRepository, key);
        }

        async Task cache(Credentials credentials, TokenExchangeResponse response)
        {
            if (_ambientData.Cache is null)
                return;

            var lifespan = response.GetLifespan();
            await _ambientData.Cache.AddAsync(CacheRepository, credentials.Identity, response, lifespan);
        }

        /// <inheritdoc />
        public virtual AuthenticationHeaderValue OnGetAuthorizationFrom(TokenExchangeResponse tokenExchangeResponse)
        {
            var accessToken = tokenExchangeResponse.AccessToken;
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public TetraPakTokenExchangeService(AmbientData ambientData)
        {
            _ambientData = ambientData  ?? throw new ArgumentNullException(nameof(ambientData));
            if (_ambientData.AuthConfig is not TetraPakApiAuthConfig)
                throw new ConfigurationException($"The configuration carried by {nameof(ambientData)} should be {typeof(TetraPakApiAuthConfig)}");
        }
    }
}