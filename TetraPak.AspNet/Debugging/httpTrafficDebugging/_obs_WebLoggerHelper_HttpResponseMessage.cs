// using System;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Logging;
//
// #nullable enable
//
// namespace TetraPak.AspNet.Debugging
// {
//     partial class WebLoggerHelper // HttpResponseMessage
//     {
//         // /// <summary>
//         // ///   Builds a textual representation of the <see cref="HttpResponseMessage"/> obsolete
//         // ///   using a <see cref="ToStringBuilderAsync(TetraPak.AspNet.Debugging.AbstractHttpRequest,System.Text.StringBuilder,System.Func{TetraPak.AspNet.Debugging.TraceRequestOptions}?)"/>.
//         // /// </summary>
//         // /// <param name="response">
//         // ///   The <see cref="HttpResponseMessage"/> to be textually represented.
//         // /// </param>
//         // /// <param name="stringBuilder">
//         // ///   The <see cref="ToStringBuilderAsync(TetraPak.AspNet.Debugging.AbstractHttpRequest,System.Text.StringBuilder,System.Func{TetraPak.AspNet.Debugging.TraceRequestOptions}?)"/> to be used.
//         // /// </param>
//         // /// <param name="options">
//         // ///   (optional)<br/>
//         // ///   Specifying how to build the textual representation of the <see cref="HttpResponseMessage"/>.
//         // /// </param>
//         // /// <returns>
//         // ///   A <see cref="StringBuilder"/> that contains the textual representation
//         // ///   of the <see cref="HttpResponseMessage"/>.
//         // /// </returns>
//         // public static async Task<StringBuilder> ToStringBuilderAsync(
//         //     this HttpResponseMessage? response,
//         //     StringBuilder stringBuilder,
//         //     TraceRequestOptions options)
//         // {
//         //     if (response is null)
//         //         return stringBuilder;
//         //     
//         //     stringBuilder.Append((int) response.StatusCode);
//         //     stringBuilder.Append(' ');
//         //     stringBuilder.AppendLine(response.StatusCode.ToString());
//         //     addHeaders(stringBuilder, response.Headers, null);
//         //     await addBody();
//         //     return stringBuilder;
//         //
//         //     async Task addBody()
//         //     {
//         //         if (options.AsyncBodyFactory is { })
//         //         {
//         //             stringBuilder.AppendLine();
//         //             stringBuilder.AppendLine(await options.AsyncBodyFactory());
//         //             return;
//         //         }
//         //
//         //         var stream = await response.Content.ReadAsStreamAsync();
//         //         var lengthOutcome = await stream.GetLengthAsync(options.ForceTraceBody);
//         //         var length = lengthOutcome.Value;
//         //         if (length == 0)
//         //             return;
//         //
//         //         var body = await stream.getRawBodyStringAsync(Encoding.UTF8, options);
//         //         if (body.Length == 0)
//         //             return;
//         //         
//         //         stringBuilder.AppendLine();
//         //         stringBuilder.AppendLine(body);
//         //     }
//         // }
//     }
// }