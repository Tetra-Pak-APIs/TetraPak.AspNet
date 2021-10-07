using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
    public class TetraPakTokenExchangeService : ITokenExchangeService, IMessageIdProvider
    {
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
                var discoOutcome = await Config.GetDiscoveryDocumentAsync();
                if (!discoOutcome)
                    return Outcome<TokenExchangeResponse>.Fail(
                        new ConfigurationException("Failed to obtain an OIDC discovery document"));

                var discoveryDocument = discoOutcome.Value;
                var dictionary = args.ToDictionary();
                var response = await client.PostAsync(
                    discoveryDocument!.TokenEndpoint, 
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

                await cache(args.Credentials, responseBody!);
                return Outcome<TokenExchangeResponse>.Success(responseBody!);
            }
            catch (Exception ex)
            {
                return Outcome<TokenExchangeResponse>.Fail(ex);
            }
        }

        async Task<Outcome<TokenExchangeResponse>> getCached(Credentials credentials)
        {
            if (Cache is null)
                return Outcome<TokenExchangeResponse>.Fail(new Exception($"Caching is not supported"));
                
            var key = credentials.Identity;
            return await Cache.GetAsync<TokenExchangeResponse>(CacheRepository, key);
        }

        async Task cache(Credentials credentials, TokenExchangeResponse response)
        {
            if (Cache is null)
                return;

            var lifespan = response.GetLifespan();
            await Cache.AddAsync(CacheRepository, credentials.Identity, response, lifespan);
        }

        /// <inheritdoc />
        public virtual AuthenticationHeaderValue OnGetAuthorizationFrom(TokenExchangeResponse tokenExchangeResponse)
        {
            var accessToken = tokenExchangeResponse.AccessToken;
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }

        /// <summary>
        ///   Initializes the <see cref="TetraPakTokenExchangeService"/>.
        /// </summary>
        /// <param name="config">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="config"/> was unassigned.
        /// </exception>
        /// <exception cref="ConfigurationException">
        ///   The <see cref="AmbientData.Config"/> instance was not of type <see cref="TetraPakApiConfig"/>.
        /// </exception>
        public TetraPakTokenExchangeService(TetraPakConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }
    }
}