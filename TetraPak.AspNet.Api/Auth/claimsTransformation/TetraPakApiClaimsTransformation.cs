using System;
using System.Threading;
using System.Threading.Tasks;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Identity;
using TetraPak.Caching;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Performs automatic claims transformation but ensures the access token used to
    ///   call the user information service gets exchanged (necessary for APIs).
    ///   (See <see cref="TetraPakClaimsTransformation"/> for more details).
    /// </summary>
    /// <example>
    ///   <code>
    ///   public void ConfigureServices(IServiceCollection services)
    ///   {
    ///       :
    ///       services.AddTetraPakWebApiClaimsTransformation();
    ///       :
    ///   }
    ///   </code>
    /// </example> 
    public class TetraPakApiClaimsTransformation : TetraPakClaimsTransformation
    {
        const string CacheRepository = CacheRepositories.Tokens.Identity;
        
        readonly ITokenExchangeService _tokenExchangeService;

        ITimeLimitedRepositories Cache => AuthConfig.Cache;
        
        /// <inheritdoc />
        protected override async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken)
        {
            try
            {
                var accessTokenOutcome = await base.OnGetAccessTokenAsync(cancellationToken);
                if (!accessTokenOutcome)
                    return accessTokenOutcome;
                
                // try getting a cached exchanged token ... 
                var accessToken = accessTokenOutcome.Value;
                var cachedOutcome = await getCachedIdentityTokenAsync(accessToken);
                if (cachedOutcome)
                    return cachedOutcome;
                
                // exchange token for 
                var ccOutcome = await GetClientCredentials();
                if (!ccOutcome)
                    return Outcome<ActorToken>.Fail(ccOutcome.Exception);

                var credentials = new BasicAuthCredentials(ccOutcome.Value!.Identity, ccOutcome.Value.Secret);

                var bearerToken = accessTokenOutcome.Value as BearerToken;
                var isBearerToken = bearerToken is { };
                var subjectToken = isBearerToken
                    ? bearerToken.Value
                    : accessTokenOutcome.Value!.ToString();
                var txOutcome = await _tokenExchangeService.ExchangeAccessTokenAsync(
                    credentials, 
                    subjectToken, 
                    cancellationToken);

                if (!txOutcome || !ActorToken.TryParse(txOutcome.Value!.AccessToken, out var actorToken))
                    throw txOutcome.Exception;

                var exchangedToken = isBearerToken
                    ? new BearerToken(actorToken.Identity, false)
                    : actorToken;
                
                // cache exchanged token and return it ...
                await cacheTokenExchangeAsync(accessToken, exchangedToken);
                return Outcome<ActorToken>.Success(exchangedToken);
            }
            catch (Exception ex)
            {
                ex = new Exception($"Claims transformation failure: {ex.Message}", ex);
                Logger.Error(ex);
                return Outcome<ActorToken>.Fail(ex);
            }
        }

        async Task<Outcome<ActorToken>> getCachedIdentityTokenAsync(ActorToken accessToken)
        {
            if (Cache is null)
                return Outcome<ActorToken>.Fail(new Exception("Caching is not supported"));

            return await Cache.GetAsync<ActorToken>(CacheRepository, accessToken);
        }

        async Task cacheTokenExchangeAsync(ActorToken accessToken, ActorToken exchangedToken)
        {
            if (Cache is { })
            {
                await Cache.AddOrUpdateAsync(
                    CacheRepository, 
                    accessToken,
                    exchangedToken);
            }
        }

        /// <summary>
        ///   Initializes the <see cref="TetraPakApiClaimsTransformation"/> instance.
        /// </summary>
        /// <param name="authConfig">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <param name="userInformation">
        ///   Used internally to obtain user information.
        /// </param>
        /// <param name="tokenExchangeService">
        ///   User internally to support the token exchange auth flow,
        ///   which is necessary when consuming user information from the Tetra Pak Auth Services. 
        /// </param>
        /// <param name="clientCredentialsProvider">
        ///   Used internally to obtain client credentials.
        /// </param>
        public TetraPakApiClaimsTransformation(
            TetraPakAuthConfig authConfig,
            TetraPakUserInformation userInformation, 
            ITokenExchangeService tokenExchangeService,
            IClientCredentialsProvider clientCredentialsProvider = null) 
        : base(authConfig, userInformation, clientCredentialsProvider)
        {
            _tokenExchangeService = tokenExchangeService;
        }
    }
}