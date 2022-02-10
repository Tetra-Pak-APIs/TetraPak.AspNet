using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Debugging;
using TetraPak.Caching;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    /// <summary>
    ///   Use this service for easy token exchange.
    /// </summary>
    public class TetraPakTokenExchangeGrantService : ITokenExchangeGrantService, IMessageIdProvider
    {
        readonly IHttpClientProvider _httpClientProvider;
        readonly IHttpContextAccessor _httpContextAccessor;

        const string CacheRepository = CacheRepositories.Tokens.TokenExchange;

        HttpContext? HttpContext => _httpContextAccessor.HttpContext;

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        ILogger? Logger => TetraPakConfig.Logger;

        /// <summary>
        ///   Gets the auth configuration code API.
        /// </summary>
        TetraPakConfig TetraPakConfig { get; }

        ITimeLimitedRepositories? Cache => TetraPakConfig.Cache;

        /// <inheritdoc />
        public string? GetMessageId(bool enforce = false) => TetraPakConfig.AmbientData.GetMessageId();

        
        
        /// <inheritdoc />
        public async Task<Outcome<TokenExchangeResponse>> ExchangeAccessTokenAsync(
            Credentials credentials,
            ActorToken subjectToken,
            bool forceAuthorization = false,
            CancellationToken? cancellationToken = null)
        {
            // todo Consider breaking up this method (it's too big) 
            if (subjectToken.IsSystemIdentityToken())
                return Outcome<TokenExchangeResponse>.Fail(this.TokenExchangeNotSupportedForSystemIdentity());
            
            var cachedOutcome = forceAuthorization ? Outcome<TokenExchangeResponse>.Fail() : await getCached(subjectToken);
            if (cachedOutcome)
                return cachedOutcome;

            var clientOutcome = await _httpClientProvider.GetHttpClientAsync();
            if (!clientOutcome)
                return Outcome<TokenExchangeResponse>.Fail(
                    HttpServerException.InternalServerError(
                        "Token exchange service failed to obtain a HTTP client (see inner exception)",
                        clientOutcome.Exception));

            using var client = clientOutcome.Value!;
            if (credentials is not BasicAuthCredentials basicAuthCredentials)
            {
                basicAuthCredentials = new BasicAuthCredentials(credentials.Identity, credentials.Secret);
            }
                
            client.DefaultRequestHeaders.Authorization = basicAuthCredentials.ToAuthenticationHeaderValue();
            try
            {
                var discoOutcome = await TetraPakConfig.GetDiscoveryDocumentAsync();
                if (!discoOutcome)
                    return Outcome<TokenExchangeResponse>.Fail(
                        HttpServerException.InternalServerError(
                            "Failed to obtain an OIDC discovery document", clientOutcome.Exception));

                var discoveryDocument = discoOutcome.Value!;
                var form = new TokenExchangeArgs(
                    credentials, 
                    subjectToken, 
                    "urn:ietf:params:oauth:token-type:id_token");
                var ct = cancellationToken ?? CancellationToken.None;
                var request = new HttpRequestMessage(HttpMethod.Post, discoveryDocument.TokenEndpoint)
                {
                    Content = new FormUrlEncodedContent(form.ToDictionary()!)
                };
                var messageId = HttpContext?.Request.GetMessageId(TetraPakConfig);
                var sb = Logger?.IsEnabled(LogLevel.Trace) ?? false
                    ? await (await request.ToGenericHttpRequestAsync()).ToStringBuilderAsync(
                        new StringBuilder(), 
                        () => TraceHttpRequestOptions.Default(messageId)
                            .WithInitiator(this, HttpDirection.Out)
                            .WithDefaultHeaders(client.DefaultRequestHeaders))
                    : null;

                var response = await client.SendAsync(request, ct);
                
                if (sb is { })
                {
                    sb.AppendLine();
                    await (await response.ToGenericHttpResponseAsync()).ToStringBuilderAsync(sb);
                    Logger.Trace(sb.ToString());
                }
                
                if (!response.IsSuccessStatusCode)
                {
                    var ex = new HttpServerException(response);
#if NET5_0_OR_GREATER                    
                    var body = await response.Content.ReadAsStringAsync(ct);
#else
                    var body = await response.Content.ReadAsStringAsync();
#endif
                    Logger.Error(ex, $"Token exchange failure. Tetra Pak response:\n        {body}", GetMessageId());
                    return Outcome<TokenExchangeResponse>.Fail(ex);
                }

#if NET5_0_OR_GREATER
                var stream = await response.Content.ReadAsStreamAsync(ct);
#else
                var stream = await response.Content.ReadAsStreamAsync();
#endif
                var responseBody =
                    await JsonSerializer.DeserializeAsync<TokenExchangeResponse>(stream, cancellationToken: ct);

                await cache(form.SubjectToken, responseBody!);
                return Outcome<TokenExchangeResponse>.Success(responseBody!);
            }
            catch (Exception ex)
            {
                return Outcome<TokenExchangeResponse>.Fail(HttpServerException.InternalServerError(
                    "Unhandled internal token exchange error (see inner exception)", 
                    ex));
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
            await Cache.AddOrUpdateAsync(CacheRepository, accessToken.Identity, response, lifespan);
        }

        /// <summary>
        ///   Initializes the <see cref="TetraPakTokenExchangeGrantService"/>.
        /// </summary>
        /// <param name="config">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <param name="httpClientProvider">
        ///   A HttpClient factory.
        /// </param>
        /// <param name="httpContextAccessor">
        ///   Provides access to the current request/response <see cref="HttpContext"/>. 
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="config"/> was unassigned.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///   Any parameter was <c>null</c>.
        /// </exception>
        public TetraPakTokenExchangeGrantService(
            TetraPakConfig config,
            IHttpClientProvider httpClientProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            TetraPakConfig = config ?? throw new ArgumentNullException(nameof(config));
            _httpClientProvider = httpClientProvider ?? throw new ArgumentNullException(nameof(httpClientProvider));
            _httpContextAccessor = httpContextAccessor;
        }
    }
}