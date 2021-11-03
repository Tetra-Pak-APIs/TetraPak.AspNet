using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.Caching;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    /// <summary>
    ///   Use this service for easy token exchange.
    /// </summary>
    public class TetraPakTokenExchangeGrantService : ITokenExchangeGrantService, IMessageIdProvider
    {
        readonly IHttpClientProvider _httpClientProvider;

        const string CacheRepository = CacheRepositories.Tokens.TokenExchange;

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        protected ILogger? Logger => Config.Logger;

        /// <summary>
        ///   Gets the auth configuration code API.
        /// </summary>
        protected TetraPakConfig Config { get; }

        ITimeLimitedRepositories? Cache => Config.Cache;

        /// <inheritdoc />
        public string? GetMessageId(bool enforce = false) => Config.AmbientData.GetMessageId();

        /// <inheritdoc />
        public async Task<Outcome<TokenExchangeResponse>> ExchangeAccessTokenAsync(
            Credentials credentials, 
            ActorToken accessToken,
            CancellationToken cancellationToken)
        {
            // todo Consider simplifying this. It started out with the assumption that "exchangeAsync" would ... 
            //      need to be used by several methods but it's only used by this one so no real reason
            //      splitting this method into two and using a special TokenExchangeArgs class to tokenize the parameters
            var args = new TokenExchangeArgs(
                credentials, 
                accessToken, 
                "urn:ietf:params:oauth:token-type:id_token");
            return await exchangeAsync(args, cancellationToken);
        }

        async Task<Outcome<TokenExchangeResponse>> exchangeAsync(
            TokenExchangeArgs args, 
            CancellationToken cancellationToken)
        {
            var cachedOutcome = await getCached(args.SubjectToken);
            if (cachedOutcome)
                return cachedOutcome;

            var clientOutcome = await _httpClientProvider.GetHttpClientAsync();
            if (!clientOutcome)
                return Outcome<TokenExchangeResponse>.Fail(
                    new ConfigurationException(
                        "Token exchange service failed to obtain a HTTP client (see inner exception)", 
                        clientOutcome.Exception));

            using var client = clientOutcome.Value!;
            var credentials = args.Credentials;
            if (credentials is not BasicAuthCredentials basicAuthCredentials)
            {
                basicAuthCredentials = new BasicAuthCredentials(credentials.Identity, credentials.Secret);
            }
                
            client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
            try
            {
                var discoOutcome = await Config.GetDiscoveryDocumentAsync();
                if (!discoOutcome)
                    return Outcome<TokenExchangeResponse>.Fail(
                        new ConfigurationException("Failed to obtain an OIDC discovery document"));

                var discoveryDocument = discoOutcome.Value!;
                var dictionary = args.ToDictionary();
                var response = await client.PostAsync(
                    discoveryDocument.TokenEndpoint, 
                    new FormUrlEncodedContent(dictionary), 
                    cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var ex = new HttpException(response);
                    var body = await response.Content.ReadAsStringAsync(); // obsolete?
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

                await cache(args.SubjectToken, responseBody!);
                return Outcome<TokenExchangeResponse>.Success(responseBody!);
            }
            catch (Exception ex)
            {
                return Outcome<TokenExchangeResponse>.Fail(ex);
            }
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        async Task<Outcome<TokenExchangeResponse>> getCached(ActorToken accessToken)
        {
            if (Cache is null)
                return Outcome<TokenExchangeResponse>.Fail(new Exception($"Caching is not supported"));
                
            var key = accessToken.Identity;
            return await Cache.GetAsync<TokenExchangeResponse>(CacheRepository, key);
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        async Task cache(ActorToken accessToken, TokenExchangeResponse response)
        {
            if (Cache is null)
                return;

            var lifespan = response.GetLifespan();
            await Cache.AddAsync(CacheRepository, accessToken.Identity, response, lifespan);
        }

        // /// <inheritdoc /> obsolete
        // public virtual AuthenticationHeaderValue OnGetAuthorizationFrom(TokenExchangeResponse tokenExchangeResponse)
        // {
        //     var accessToken = tokenExchangeResponse.AccessToken;
        //     return new AuthenticationHeaderValue("Bearer", accessToken);
        // }

        /// <summary>
        ///   Initializes the <see cref="TetraPakTokenExchangeGrantService"/>.
        /// </summary>
        /// <param name="config">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <param name="httpClientProvider">
        ///   A HttpClient factory.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="config"/> was unassigned.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///   Any parameter was <c>null</c>.
        /// </exception>
        public TetraPakTokenExchangeGrantService(TetraPakConfig config, IHttpClientProvider httpClientProvider)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            _httpClientProvider = httpClientProvider ?? throw new ArgumentNullException(nameof(httpClientProvider));
        }
    }
}