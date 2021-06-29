using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Identity;
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
    public class TetraPakWebApiClaimsTransformation : TetraPakClaimsTransformation
    {
        const string IdentityTokenCache = "IdentityTokens";
        
        readonly ITokenExchangeService _tokenExchangeService;
        
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
                var clientCredentials = await OnGetClientCredentials();
                var credentials = new BasicAuthCredentials(clientCredentials.Identity, clientCredentials.Secret);

                var bearerToken = accessTokenOutcome.Value as BearerToken;
                var isBearerToken = bearerToken is { };
                var subjectToken = isBearerToken
                    ? bearerToken.Value
                    : accessTokenOutcome.Value.ToString();
                var txOutcome = await _tokenExchangeService.ExchangeAccessTokenAsync(
                    credentials, 
                    subjectToken, 
                    cancellationToken);

                if (!txOutcome || !ActorToken.TryParse(txOutcome.Value.AccessToken, out var actorToken))
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
            if (AmbientData.Cache is null)
                return Outcome<ActorToken>.Fail(new Exception("Caching is not supported"));

            return await AmbientData.Cache.GetAsync<ActorToken>(IdentityTokenCache, accessToken);
        }

        async Task cacheTokenExchangeAsync(ActorToken accessToken, ActorToken exchangedToken)
        {
            if (AmbientData.Cache is { })
            {
                await AmbientData.Cache.AddOrUpdateAsync(
                    IdentityTokenCache, 
                    accessToken,
                    exchangedToken);
            }
        }

        public TetraPakWebApiClaimsTransformation(
            AmbientData ambientData, 
            TetraPakApiAuthConfig authConfig, 
            TetraPakUserInformation userInformation, 
            IHttpContextAccessor httpContextAccessor,
            ITokenExchangeService tokenExchangeService,
            IClientCredentialsProvider clientCredentialsProvider = null) 
        : base(ambientData, authConfig, userInformation, httpContextAccessor, clientCredentialsProvider)
        {
            _tokenExchangeService = tokenExchangeService;
        }
    }
}