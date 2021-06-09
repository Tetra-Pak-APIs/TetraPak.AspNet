using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TetraPak.AspNet.Api.Auth.TokenExchange;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Identity;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth
{
    /// <summary>
    ///   
    /// </summary>
    public class TetraPakWebApiClaimsTransformation : TetraPakClaimsTransformation
    {
        readonly ITokenExchangeService _tokenExchangeService;
        
        protected override async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken)
        {
            try
            {
                var accessTokenOutcome = await base.OnGetAccessTokenAsync(cancellationToken);
                if (!accessTokenOutcome)
                    return accessTokenOutcome;

                // todo Support caching TX tokens
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
                return Outcome<ActorToken>.Success(exchangedToken);
            }
            catch (Exception ex)
            {
                Logger.Error(new Exception($"Claims transformation failure: {ex.Message}", ex));
                throw;
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