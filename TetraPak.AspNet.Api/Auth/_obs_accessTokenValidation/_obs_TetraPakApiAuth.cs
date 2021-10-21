// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.DependencyInjection.Extensions;
// using TetraPak.AspNet.Auth;
// using TetraPak.AspNet.Identity;
//
// namespace TetraPak.AspNet.Api.Auth
// {
//     partial class TetraPakApiAuth
//     {
//         /// <summary>
//         ///   Configures a basic authentication scheme for Tetra Pak minted access tokens.
//         /// </summary>
//         /// <param name="services">
//         ///   The dependency injection service collection.
//         /// </param>
//         /// <returns>
//         ///   
//         /// </returns>
//         public static IServiceCollection AddTetraPakApiAccessTokenAuthentication(this IServiceCollection services)
//         {
//             services.TryAddTransient<UserInformationProvider>();
//             services.TryAddSingleton<ITokenExchangeService,TetraPakTokenExchangeService>();
//             services.AddAuthentication(options =>
//                 {
//                     options.DefaultScheme = TetraPakAccessTokenAuthenticationDefaults.AuthenticationScheme;
//                 })
//                 .AddScheme<ValidateTetraPakAccessTokenSchemeOptions,TetraPakWebApiAccessTokenAuthenticationHandler>(
//                     TetraPakAccessTokenAuthenticationDefaults.AuthenticationScheme, _ => { });
//
//             return services;
//         }
//     }
// }