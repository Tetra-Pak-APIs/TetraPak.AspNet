#nullable enable
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Convenient methods for working with <see cref="AbstractHttpRequest"/>s.
    /// </summary>
    public static class AbstractHttpRequestHelper
    {
        /// <summary>
        ///   Constructs and returns a <see cref="AbstractHttpRequest"/> representation of a
        ///   <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="request">
        ///   The request to be represented as a <see cref="AbstractHttpRequest"/>.
        /// </param>
        /// <returns>
        ///   A <see cref="AbstractHttpRequest"/>
        /// </returns>
        public static async Task<AbstractHttpRequest> ToAbstractHttpRequestAsync(this HttpRequestMessage request)
            => new()
            {
                Method = request.Method.Method,
                Uri = request.RequestUri,
                Headers = request.Headers,
                Content = request.Content is {} ? await request.Content.ReadAsStreamAsync() : null 
            };

        /// <summary>
        ///   Constructs and returns a <see cref="AbstractHttpRequest"/> representation of a
        ///   <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="request">
        ///   The request to be represented as a <see cref="AbstractHttpRequest"/>.
        /// </param>
        /// <returns>
        ///   A <see cref="AbstractHttpRequest"/>
        /// </returns>
        public static AbstractHttpRequest ToAbstractHttpRequestAsync(this HttpRequest request)
            => new()
            {
                Method = request.Method,
                Uri = request.GetUri(),
                Headers = request.Headers.ToKeyValuePairs(),
                Content = request.Body
            };
        
        /// <summary>
        ///   Constructs and returns a <see cref="AbstractHttpRequest"/> representation of a
        ///   <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="request">
        ///   The request to be represented as a <see cref="AbstractHttpRequest"/>.
        /// </param>
        /// <returns>
        ///   A <see cref="AbstractHttpRequest"/>
        /// </returns>
        public static AbstractHttpRequest ToAbstractHttpRequestAsync(this HttpWebRequest request)
            => new()
            {
                Method = request.Method,
                Uri = request.RequestUri,
                Headers = request.Headers.ToKeyValuePairs(),
                Content = request.GetRequestStream()
            };
        
        /// <summary>
        ///   Constructs and returns the textual representation of the <see cref="HttpRequest"/>'s URI (if any). 
        /// </summary>
        /// <param name="request">
        ///   The <see cref="HttpRequest"/> to obtain the URI from.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> representation of the request's URI, if any; otherwise <c>null</c>.
        /// </returns>
        public static Uri? GetUri(this HttpRequest? request)
        {
            var uri = request is {}
                ? $"{request.Host}{request.PathBase}{request.QueryString}" // nisse (check outcome of this concat)
                : null;
            return uri is { } ? new Uri(uri) : null;
        }
    }
}