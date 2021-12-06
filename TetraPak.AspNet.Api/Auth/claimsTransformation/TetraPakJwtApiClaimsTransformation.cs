using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Performs automatic claims transformation but ensures the access token used to
    ///   call the user information service gets exchanged (necessary for APIs).
    ///   (See <see cref="TetraPakJwtClaimsTransformation"/> for more details).
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
    public class TetraPakJwtApiClaimsTransformation : TetraPakJwtClaimsTransformation
    {
        const string CacheRepository = CacheRepositories.Tokens.Identity;
        
        protected ITokenExchangeGrantService TokenExchangeGrantService { get; private set; }

        
        /// <inheritdoc />
        protected override async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken)
        {
            try
            {
                var accessTokenOutcome = await base.OnGetAccessTokenAsync(cancellationToken);
                if (!accessTokenOutcome)
                    return accessTokenOutcome;

                var token = accessTokenOutcome.Value;
                if (token!.IsSystemIdentityToken())
                {
                    var error = ServerException.BadRequest("Claims transformation not supported for system identity");
                    Logger.Warning(error.Message, GetMessageId());
                    return Outcome<ActorToken>.Fail();
                }
                
                // try getting a cached exchanged token ... 
                var accessToken = accessTokenOutcome.Value;
                var cachedOutcome = await getCachedIdentityTokenAsync(accessToken);
                if (cachedOutcome)
                    return cachedOutcome;
                
                // authorize using token exchange (replace token with TX outcome) ...  
                var ccOutcome = await GetClientCredentials();
                if (!ccOutcome)
                    return Outcome<ActorToken>.Fail(ccOutcome.Exception);

                var credentials = new BasicAuthCredentials(ccOutcome.Value!.Identity, ccOutcome.Value.Secret);

                var bearerToken = accessTokenOutcome.Value as BearerToken;
                var isBearerToken = bearerToken is { };
                var subjectToken = isBearerToken
                    ? bearerToken.Value
                    : accessTokenOutcome.Value!.ToString();
                var txOutcome = await TokenExchangeGrantService.ExchangeAccessTokenAsync(
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
                ex = ServerException.InternalServerError($"Claims transformation failure: {ex.Message}", ex);
                Logger.Error(ex, GetMessageId());
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

        internal override void OnInitialize(IServiceProvider provider)
        {
            base.OnInitialize(provider);
            TokenExchangeGrantService = provider.GetRequiredService<ITokenExchangeGrantService>();
        }
    }
}