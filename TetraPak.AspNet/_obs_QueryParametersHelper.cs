// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
//
// #nullable enable
//
// namespace TetraPak.AspNet
// {
//     public static class QueryParametersHelper
//     {
//         /// <summary>
//         ///   Builds a URL formed query parameters string from a dictionary key-value collection.  obsolete
//         /// </summary>
//         /// <param name="self">
//         ///   A dictionary containing the key-value pairs.
//         /// </param>
//         /// <param name="qualify">
//         ///   (optional; default=<c>false</c>)<br/>
//         ///   Specifies whether to prefixing the query parameters <see cref="string"/> with a '?' qualifier.
//         /// </param>
//         /// <returns>
//         ///   A URL formed query parameters string.
//         /// </returns>
//         public static string ToUrlQueryParameters(this IDictionary<string, string>? self, bool qualify = false)
//         {
//             if (!(self?.Any() ?? false))
//                 return string.Empty;
//
//             var sb = new StringBuilder();
//             if (qualify)
//             {
//                 sb.Append('?');
//             }
//             var pairs = self.ToArray();
//             var pair = pairs[0];
//             sb.Append(pair.Key);
//             sb.Append('=');
//             sb.Append(pair.Value);
//             for (var i = 1; i < pairs.Length; i++)
//             {
//                 sb.Append('&');
//                 pair = pairs[i];
//                 sb.Append(pair.Key);
//                 sb.Append('=');
//                 sb.Append(pair.Value);
//             }
//
//             return sb.ToString();
//         }
//     }
// }