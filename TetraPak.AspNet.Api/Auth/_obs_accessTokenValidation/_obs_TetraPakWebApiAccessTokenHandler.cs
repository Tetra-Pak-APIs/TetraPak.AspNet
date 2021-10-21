// using System;
// using System.Text.Encodings.Web;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using TetraPak.AspNet.Auth;
// using TetraPak.AspNet.Identity;
// using TetraPak.Logging;
//
// namespace TetraPak.AspNet.Api.Auth
// {
//     /// <summary>
//     ///   Performs basic Tetra Pak issued access token validation while also supporting
//     ///   token exchange before the call to the user information service.
//     /// </summary>
//     // ReSharper disable once ClassNeverInstantiated.Global
//     public class TetraPakWebApiAccessTokenAuthenticationHandler : TetraPakAccessTokenAuthenticationHandler
//     {
//         // const string CacheRepository = Caching.Tokens. "ExchangedTokens"; obsolete
//
//         readonly IClientCredentialsProvider _clientCredentialsProvider;
//         readonly ITokenExchangeService _tokenExchangeService;
//
//         protected override async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var accessTokenOutcome = await base.OnGetAccessTokenAsync(cancellationToken);
//                 if (!accessTokenOutcome)
//                     return accessTokenOutcome;
//                 
//                 // try getting a cached exchanged token ...  obsolete
//                 // var accessToken = accessTokenOutcome.Value;
//                 // var cachedOutcome = await getCachedExchangedTokenAsync(accessToken);
//                 // if (cachedOutcome)
//                 //     return cachedOutcome;
//                 
//                 // exchange token for 
//                 var clientCredentials = await OnGetClientCredentials();
//                 if (!clientCredentials.IsValidFor(GrantType.TokenExchange))
//                 {
//                     var ex = new ConfigurationException("Token cannot be validated due to misconfigured client credentials");
//                     Logger.Warning(ex.Message);
//                     return Outcome<ActorToken>.Fail(ex);
//                 }
//                     
//                 var credentials = new BasicAuthCredentials(clientCredentials.Identity, clientCredentials.Secret);
//                 var bearerToken = accessTokenOutcome.Value as BearerToken;
//                 var isBearerToken = bearerToken is { };
//                 var subjectToken = isBearerToken
//                     ? bearerToken.Value
//                     : accessTokenOutcome.Value!.ToString();
//                 var txOutcome = await _tokenExchangeService.ExchangeAccessTokenAsync(
//                     credentials, 
//                     subjectToken, 
//                     cancellationToken);
//
//                 if (!txOutcome || !ActorToken.TryParse(txOutcome.Value!.AccessToken, out var actorToken))
//                 {
//                     Logger.Debug(txOutcome.Exception.Message);
//                     return Outcome<ActorToken>.Fail(txOutcome.Exception);
//                 }
//
//                 var exchangedToken = isBearerToken
//                     ? new BearerToken(actorToken.Identity, false)
//                     : actorToken;
//                 
//                 // // cache exchanged token and return it ...
//                 // await cacheTokenExchangeAsync(accessToken, exchangedToken); obsolete
//                 return Outcome<ActorToken>.Success(exchangedToken);
//             }
//             catch (Exception ex)
//             {
//                 var messageId = AmbientData.GetMessageId(true);
//                 ex = new Exception($"Access token validation failed: {ex.Message}", ex);
//                 Logger.Error(ex, messageId);
//                 return Outcome<ActorToken>.Fail(ex);
//             }
//         }
//         
//         protected virtual async Task<Credentials> OnGetClientCredentials()
//         {
//             if (_clientCredentialsProvider is { })
//                 return await _clientCredentialsProvider.GetClientCredentialsAsync();
//
//             if (Config.ClientId is null)
//                 throw new InvalidOperationException("Failed obtaining client id from configuration");
//             
//             return new Credentials(Config.ClientId, Config.ClientSecret);
//         }
//         
//         // async Task<Outcome<ActorToken>> getCachedExchangedTokenAsync(ActorToken accessToken) obsolete
//         // {
//         //     if (AmbientData.Cache is null)
//         //         return Outcome<ActorToken>.Fail(new Exception("Caching is not supported"));
//         //
//         //     return await AmbientData.Cache.GetAsync<ActorToken>(CacheRepository, accessToken);
//         // }
//         //
//         // async Task cacheTokenExchangeAsync(ActorToken accessToken, ActorToken exchangedToken)
//         // {
//         //     if (AmbientData.Cache is { })
//         //     {
//         //         await AmbientData.Cache.AddOrUpdateAsync(
//         //             CacheRepository, 
//         //             accessToken,
//         //             exchangedToken);
//         //     }
//         // }
//
//         public TetraPakWebApiAccessTokenAuthenticationHandler(
//             IOptionsMonitor<ValidateTetraPakAccessTokenSchemeOptions> options, 
//             ILoggerFactory logger, 
//             UrlEncoder encoder, 
//             ISystemClock clock, 
//             TetraPakConfig config, 
//             // AmbientData ambientData, obsolete
//             UserInformationProvider userInformationProvider,
//             ITokenExchangeService tokenExchangeService,
//             IClientCredentialsProvider clientCredentialsProvider = null) 
//         : base(options, logger, encoder, clock, config, userInformationProvider)
//         {
//             _clientCredentialsProvider = clientCredentialsProvider;
//             _tokenExchangeService = tokenExchangeService;
//         }
//     }
// }