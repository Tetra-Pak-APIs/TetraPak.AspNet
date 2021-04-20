// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
//
// namespace tetrapak.api.common.request failed_experiment
// {
//     public static class HttpClientProviderHelper
//     {
//         public static IServiceCollection AddLoggedRoundtrips(this IServiceCollection c, LogLevel logLevel = LogLevel.Debug)
//         {
//             return c.AddSingleton<IHttpClientProvider>(p =>
//             {
//                 var provider = new EventfulHttpClientProvider();
//                 provider.Requesting += async (clientProvider, roundtrip) =>
//                 {
//                     if (!(clientProvider is IApiLoggerProvider loggerProvider))
//                         return;
//
//                     var logger = loggerProvider.GetLogger();
//                     var method = roundtrip.Request.Method;
//                     if (method == HttpMethod.Get || method == HttpMethod.Delete)
//                     {
//                         logger.Log(logLevel, ">>>>>>>\n{Method} {RequestUri}\n\n{Headers}\n>>>>>>>\n", 
//                             roundtrip.Request.Method,
//                             roundtrip.Request.RequestUri,
//                             roundtrip.Request.HeadersToString());
//                         return;
//                     }
//                     logger.Log(logLevel, ">>>>>>>\n{Method} {RequestUri}\n\n{Headers}{Body}\n>>>>>>>\n", 
//                         roundtrip.Request.Method,
//                         roundtrip.Request.RequestUri,
//                         roundtrip.Request.HeadersToString(),
//                         await roundtrip.Request.BodyToStringAsync());
//                 };
//                 return provider;
//             });
//         }
//     }
//
//     public static class HttpRoundtripExtension
//     {
//         public static string HeadersToString(this HttpRequestMessage self, int addLineFeedsOnSuccess = 2)
//         {
//             var sb = new StringBuilder();
//             foreach (var (key, value) in self.Headers)
//             {
//                 sb.AppendLine($"{key}: {value}");
//             }
//
//             if (addLineFeedsOnSuccess == 0 || sb.Length == 0) 
//                 return sb.ToString();
//             
//             for (var i = 0; i < addLineFeedsOnSuccess; i++)
//             {
//                 sb.AppendLine();
//             }
//             return sb.ToString();
//         }
//         
//         public static Task<string> BodyToStringAsync(this HttpRequestMessage self)
//         {
//             return self.Content is null ? Task.FromResult(string.Empty) : self.Content.ReadAsStringAsync();
//         }
//
//     }
// }