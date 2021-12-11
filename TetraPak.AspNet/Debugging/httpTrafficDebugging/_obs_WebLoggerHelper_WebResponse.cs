// using System;
// using System.Net;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Logging;
//
// #nullable enable
//
// namespace TetraPak.AspNet.Debugging
// {
//     partial class WebLoggerHelper // WebResponse
//     {
//         // /// <summary>
//         // ///   Traces a <see cref="WebResponse"/> in the logs. obsolete
//         // /// </summary>
//         // /// <param name="logger">
//         // ///   The logger provider.
//         // /// </param>
//         // /// <param name="response">
//         // ///   The response to be traced.
//         // /// </param>
//         // /// <param name="includeBody">
//         // ///   (optional; default=<c>false</c>)<br/>
//         // ///   Specifies whether to also include the response body.
//         // /// </param>
//         // /// <seealso cref="TraceAsync(ILogger?,WebResponse?,Func{WebResponse?,Task{string}}?)"/>
//         // public static async Task TraceAsync(
//         //     this ILogger? logger,
//         //     WebResponse? response,
//         //     bool? includeBody = false)
//         // {
//         //     await traceAsync(logger, response, includeBody!.Value ? defaultWebResponseBodyHandler! : null);
//         // }
//         
//         // static async Task<string> defaultWebResponseBodyHandler(WebResponse response)
//         // {
//         //     try
//         //     {
//         //         var stream = response.GetResponseStream();
//         //         using var r = new StreamReader(stream); 
//         //         return await r.ReadToEndAsync();
//         //     }
//         //     catch
//         //     {
//         //         return "*** ERROR : Body could not be streamed *** ";
//         //     }
//         // }
//     }
// }