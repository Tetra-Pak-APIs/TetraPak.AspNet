// using System;
// using System.Linq;
// using System.Net;
// using System.Security.Claims;
// using System.Text.Encodings.Web;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.DependencyInjection.Extensions;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using TetraPak.AspNet.Identity;
//
// namespace TetraPak.AspNet.Auth
// {
//     partial class TetraPakAuth
//     {
//         public static IServiceCollection AddTetraPakWebClientAccessTokenValidation(this IServiceCollection services)
//         {
//             services.TryAddTransient<UserInformationProvider>();
//             services.AddAuthentication((options =>
//             {
//                 options.DefaultScheme = TetraPakAccessTokenAuthenticationDefaults.AuthenticationScheme;
//             }))
//             .AddScheme<ValidateTetraPakAccessTokenSchemeOptions,TetraPakAccessTokenAuthenticationHandler>(
//                 TetraPakAccessTokenAuthenticationDefaults.AuthenticationScheme,
//                 _ => { });
//
//             return services;
//         }
//     }
//
//     public class TetraPakAccessTokenAuthenticationDefaults
//     {
//         public const string AuthenticationScheme = "TetraPakAccessToken";
//     }
//
//     public class ValidateTetraPakAccessTokenSchemeOptions : AuthenticationSchemeOptions 
//     {
//     }
//     
//     public class TetraPakAccessTokenAuthenticationHandler : AuthenticationHandler<ValidateTetraPakAccessTokenSchemeOptions>
//     {
//         readonly UserInformationProvider _userInformationProvider;
//         public TetraPakConfig Config { get; }
//
//         public AmbientData AmbientData => Config.AmbientData;
//
//         protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//         {
//             var cancellationToken = new CancellationToken();
//             var accessTokenOutcome = await OnGetAccessTokenAsync(cancellationToken);
//             if (!accessTokenOutcome)
//                 return AuthenticateResult.Fail(accessTokenOutcome.Exception);
//
//             var accessToken = accessTokenOutcome.Value;
//             try
//             {
//                 var userInformation = await _userInformationProvider.GetUserInformationAsync(accessToken);
//                 var claims = userInformation.ToDictionary().Select(
//                     pair => new Claim(pair.Key, pair.Value));
//                 var identity = new ClaimsIdentity(claims);
//                 var principal = new ClaimsPrincipal(identity);
//                 var ticket = new AuthenticationTicket(principal,
//                     TetraPakAccessTokenAuthenticationDefaults.AuthenticationScheme);
//                 return AuthenticateResult.Success(ticket);
//             }
//             catch (WebException ex)
//             {
//                 if (ex.Status != WebExceptionStatus.ProtocolError || ex.Response is not HttpWebResponse webResponse)
//                     return AuthenticateResult.Fail(ex);
//
//                 return AuthenticateResult.Fail(webResponse.StatusCode == HttpStatusCode.Unauthorized 
//                     ? $"Unauthorized: {webResponse.StatusCode}" 
//                     : "Unauthorized");
//             }
//             catch (Exception ex)
//             {
//                 return AuthenticateResult.Fail(ex);
//             }
//         }
//
//         protected virtual Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken)
//         {
//             return AmbientData.GetAccessTokenAsync();
//         }
//
//         public TetraPakAccessTokenAuthenticationHandler(
//             IOptionsMonitor<ValidateTetraPakAccessTokenSchemeOptions> options, 
//             ILoggerFactory logger, 
//             UrlEncoder encoder, 
//             ISystemClock clock,
//             TetraPakConfig config,
//             // AmbientData ambientData, obsolete
//             UserInformationProvider userInformationProvider)
//         : base(options, logger, encoder, clock)
//         {
//             Config = config;
//             _userInformationProvider = userInformationProvider;
//         }
//     }
// }