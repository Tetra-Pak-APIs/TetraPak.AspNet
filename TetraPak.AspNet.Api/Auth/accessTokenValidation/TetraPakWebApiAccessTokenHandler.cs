using System;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Identity;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   Performs basic Tetra Pak issued access token validation while also supporting
    ///   token exchange before the call to the user information service.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TetraPakWebApiAccessTokenAuthenticationHandler : TetraPakAccessTokenAuthenticationHandler
    {
        const string CacheRepository = "ExchangedAccessTokens";

        readonly IClientCredentialsProvider _clientCredentialsProvider;
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
                var cachedOutcome = await getCachedExchangedTokenAsync(accessToken);
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
                    return Outcome<ActorToken>.Fail(txOutcome.Exception);

                var exchangedToken = isBearerToken
                    ? new BearerToken(actorToken.Identity, false)
                    : actorToken;
                
                // cache exchanged token and return it ...
                await cacheTokenExchangeAsync(accessToken, exchangedToken);
                return Outcome<ActorToken>.Success(exchangedToken);
            }
            catch (Exception ex)
            {
                Logger.Error(new Exception($"Claims transformation failure: {ex.Message}", ex));
                throw;
            }
        }
        
        protected virtual async Task<Credentials> OnGetClientCredentials()
        {
            if (_clientCredentialsProvider is { })
                return await _clientCredentialsProvider.GetClientCredentialsAsync();

            if (AuthConfig.ClientId is null)
                throw new InvalidOperationException("Failed obtaining client id from configuration");
            
            return new Credentials(AuthConfig.ClientId, AuthConfig.ClientSecret);
        }
        
        async Task<Outcome<ActorToken>> getCachedExchangedTokenAsync(ActorToken accessToken)
        {
            if (AmbientData.Cache is null)
                return Outcome<ActorToken>.Fail(new Exception("Caching is not supported"));

            return await AmbientData.Cache.GetAsync<ActorToken>(CacheRepository, accessToken);
        }

        async Task cacheTokenExchangeAsync(ActorToken accessToken, ActorToken exchangedToken)
        {
            if (AmbientData.Cache is { })
            {
                await AmbientData.Cache.AddOrUpdateAsync(
                    CacheRepository, 
                    accessToken,
                    exchangedToken);
            }
        }

        public TetraPakWebApiAccessTokenAuthenticationHandler(
            IOptionsMonitor<ValidateTetraPakAccessTokenSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock, 
            TetraPakAuthConfig authConfig, 
            AmbientData ambientData, 
            UserInformationProvider userInformationProvider,
            ITokenExchangeService tokenExchangeService,
            IClientCredentialsProvider clientCredentialsProvider = null) 
        : base(options, logger, encoder, clock, authConfig, ambientData, userInformationProvider)
        {
            _clientCredentialsProvider = clientCredentialsProvider;
            _tokenExchangeService = tokenExchangeService;
        }
    }
}