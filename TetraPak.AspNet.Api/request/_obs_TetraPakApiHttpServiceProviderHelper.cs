// using System;
// using System.Net.Http;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.DependencyInjection; obsolete
// using TetraPak.AspNet.Api.Auth;
//
// #nullable enable
//
// namespace TetraPak.AspNet.Api
// {
//     public static class TetraPakApiHttpServiceProviderHelper
//     {
//         static readonly object s_syncRoot = new(); 
//         static bool s_isServicesAdded;
//         static IHttpClientProvider? s_singleton;
//         static Func<HttpClientOptions,HttpClient>? s_singletonClientFactory;
//         static HttpClientOptions? s_singletonClientOptions;
//
//         public static IServiceCollection AddTetraPakHttpServiceProviders(
//             this IServiceCollection collection,
//             Func<HttpClientOptions,HttpClient>? singletonClientFactory = null, 
//             HttpClientOptions? singletonClientOptions = null)
//         {
//             collection.AddTetraPakConfiguration();
//             collection.AddTetraPakTokenExchangeService();
//             collection.AddTetraPakClientCredentialsService();
//             lock (s_syncRoot)
//             {
//                 if (s_isServicesAdded)
//                     return collection;
//
//                 s_singletonClientFactory = singletonClientFactory;
//                 s_singletonClientOptions = singletonClientOptions;
//                 // collection.AddSingleton(getHttpServiceProvider);
//                 collection.AddSingleton(getHttpClientProvider);
//                 collection.AddSingleton(getMessageIdProvider);
//                 s_isServicesAdded = true;
//                 return collection;
//             }
//
//             IHttpServiceProvider getHttpServiceProvider(IServiceProvider p)
//             {
//                 lock (s_syncRoot)
//                 {
//                     if (s_singleton is { })
//                         return s_singleton;
//
//                     s_singleton = new TetraPakApiHttpServiceProvider(
//                         p.GetRequiredService<IHttpContextAccessor>(),
//                         p.GetRequiredService<TetraPakApiConfig>(),
//                         p.GetRequiredService<IAuthorizationService>(),
//                         s_singletonClientFactory,
//                         s_singletonClientOptions);
//                     return s_singleton;
//                 }
//             }
//
//             IHttpClientProvider getHttpClientProvider(IServiceProvider p) 
//             {
//                 lock (s_syncRoot)
//                 {
//                     if (s_singleton is { })
//                         return s_singleton;
//
//                     s_singleton = new TetraPakApiHttpServiceProvider(
//                         p.GetRequiredService<IHttpContextAccessor>(),
//                         p.GetRequiredService<TetraPakApiConfig>(),
//                         p.GetRequiredService<IAuthorizationService>(),
//                         s_singletonClientFactory,
//                         s_singletonClientOptions);
//                     return s_singleton;
//                 }
//             }
//
//             IMessageIdProvider getMessageIdProvider(IServiceProvider p) => getHttpServiceProvider(p);
//         }
//     }
// }