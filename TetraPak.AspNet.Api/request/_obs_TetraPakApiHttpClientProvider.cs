// using System;
// using System.Net.Http;
// using System.Threading;
// using System.Threading.Tasks;
// using TetraPak.AspNet.diagnostics;
// using TetraPak.AspNet.Diagnostics;
//
// #nullable enable
//
// namespace TetraPak.AspNet.Api
// {
//     /// <summary>
//     ///   Implements base functionality for providing HTTP clients
//     ///   to be used when consuming configured backend services. 
//     /// </summary>
//     // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
//     public class TetraPakApiHttpClientProvider : TetraPakHttpClientProvider, ITetraPakDiagnosticsProvider obsolete
//     {
//         void ITetraPakDiagnosticsProvider.DiagnosticsStartTimer(string timerKey) =>
//             GetDiagnostics()?.StartTimer(timerKey);
//
//         void ITetraPakDiagnosticsProvider.DiagnosticsEndTimer(string timerKey) =>
//             GetDiagnostics()?.GetElapsedMs(timerKey);
//
//         protected ServiceDiagnostics? GetDiagnostics() => HttpContext?.GetDiagnostics();
//
//         protected override async Task<Outcome<ActorToken>> OnAuthorizeClientAsync(
//             HttpClientOptions options,
//             CancellationToken? cancellationToken = null)
//         {
//             if (options.AuthorizationService is null)
//                 return Outcome<ActorToken>.Fail(
//                     new InvalidOperationException("No authorization service was specified"));
//                 
//             return await options.AuthorizationService.AuthorizeAsync(options, cancellationToken);
//         }
//
//         public TetraPakApiHttpClientProvider(
//             TetraPakConfig tetraPakConfig,
//             Func<HttpClientOptions,HttpClient>? singletonClientFactory = null, 
//             HttpClientOptions? singletonClientOptions = null) 
//         : base(tetraPakConfig, singletonClientFactory, singletonClientOptions)
//         {
//         }
//     }
// }