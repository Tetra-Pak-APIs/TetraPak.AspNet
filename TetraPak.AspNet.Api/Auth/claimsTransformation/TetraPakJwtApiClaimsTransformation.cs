using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
    public sealed class TetraPakJwtApiClaimsTransformation : TetraPakJwtClaimsTransformation
    {
        const string CacheRepository = CacheRepositories.Tokens.Identity;
        
#pragma warning disable CS8618
        // note: Always gets initialized from OnInitialize
        ITokenExchangeGrantService TokenExchangeGrantService { get; set; } 
#pragma warning restore CS8618

        
        /// <inheritdoc />
        protected override async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken)
        {
            var messageId = GetMessageId();
            try
            {
                var accessTokenOutcome = await base.OnGetAccessTokenAsync(cancellationToken);
                if (!accessTokenOutcome)
                    return accessTokenOutcome;

                var token = accessTokenOutcome.Value;
                if (token!.IsSystemIdentityToken())
                {
                    var error = HttpServerException.BadRequest("Claims transformation not supported for system identity");
                    Logger.Warning(error.Message, messageId);
                    return Outcome<ActorToken>.Fail();
                }
                
                // try getting a cached exchanged token ... 
                var accessToken = accessTokenOutcome.Value!;
                var cachedOutcome = await getCachedIdentityTokenAsync(accessToken);
                if (cachedOutcome)
                    return cachedOutcome;
                
                // authorize using token exchange (replace token with TX outcome) ...  
                var ccOutcome = await GetClientCredentials();
                if (!ccOutcome)
                    return Outcome<ActorToken>.Fail(ccOutcome.Exception);

                if (string.IsNullOrEmpty(ccOutcome.Value!.Secret))
                    return Outcome<ActorToken>.Fail(new Exception("Claims transformation failure: No client was provisioned"));
                    
                var credentials = new BasicAuthCredentials(ccOutcome.Value!.Identity, ccOutcome.Value.Secret);
                var bearerToken = accessTokenOutcome.Value as BearerToken;
                var isBearerToken = bearerToken is { };
                var subjectToken = isBearerToken
                    ? bearerToken!.Value
                    : accessTokenOutcome.Value!.ToString();
                var txOutcome = await TokenExchangeGrantService.ExchangeAccessTokenAsync(
                    credentials, 
                    subjectToken!, 
                    false,
                    cancellationToken);

                if (!txOutcome || !ActorToken.TryParse(txOutcome.Value!.AccessToken!, out var actorToken))
                    return Outcome<ActorToken>.Fail(
                        new Exception($"Claims transformation failure during token exchange: {txOutcome.Exception.Message}. "+
                                      $"Please enable '{nameof(LogLevel.Trace)}' for more information"));
                
                var exchangedToken = isBearerToken
                    ? new BearerToken(actorToken.Identity, false)
                    : actorToken;
                
                // cache exchanged token and return it ...
                await cacheTokenExchangeAsync(accessToken, exchangedToken);
                return Outcome<ActorToken>.Success(exchangedToken);
            }
            catch (Exception ex)
            {
                ex = HttpServerException.InternalServerError($"Claims transformation failure: {ex.Message}", ex);
                Logger.Error(ex, messageId);
                return Outcome<ActorToken>.Fail(ex);
            }
        }

        async Task<Outcome<ActorToken>> getCachedIdentityTokenAsync(ActorToken accessToken)
        {
            if (Cache is null)
                return Outcome<ActorToken>.Fail(new Exception("Caching is not supported"));

            return await Cache.GetAsync<ActorToken>(CacheRepository, accessToken!);
        }

        async Task cacheTokenExchangeAsync(ActorToken accessToken, ActorToken exchangedToken)
        {
            if (Cache is { })
            {
                await Cache.AddOrUpdateAsync(
                    CacheRepository, 
                    accessToken!,
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