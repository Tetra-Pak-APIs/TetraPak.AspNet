using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   Convenient methods for working with <see cref="AbstractHttpResponse"/>s.
    /// </summary>
    public static class AbstractHttpResponseHelper
    {
        /// <summary>
        ///   Constructs and returns a <see cref="AbstractHttpResponse"/> representation of a
        ///   <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="response">
        ///   The response to be represented as a <see cref="AbstractHttpResponse"/>.
        /// </param>
        /// <returns>
        ///   A <see cref="AbstractHttpResponse"/>
        /// </returns>
        public static async Task<AbstractHttpResponse> ToAbstractHttpResponseAsync(this HttpResponseMessage response)
            => new()
            {
                StatusCode = (int) response.StatusCode,
                Method = response.RequestMessage?.Method.Method!,
                Uri = response.RequestMessage?.RequestUri,
                Headers = response.Headers,
                Content = response.Content is {} ? await response.Content.ReadAsStreamAsync() : null 
            };

        /// <summary>
        ///   Constructs and returns a <see cref="AbstractHttpResponse"/> representation of a
        ///   <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="response">
        ///   The response to be represented as a <see cref="AbstractHttpResponse"/>.
        /// </param>
        /// <param name="request">
        ///   (optional)<br/>
        ///   A request (resulting in the response). 
        /// </param>
        /// <returns>
        ///   A <see cref="AbstractHttpResponse"/>
        /// </returns>
        public static AbstractHttpResponse ToAbstractHttpResponse(this HttpResponse response, AbstractHttpRequest? request)
            => new()
            {
                StatusCode = response.StatusCode,
                Method = request?.Method!,
                Uri = request?.Uri, 
                Headers = response.Headers.ToKeyValuePairs(),
                Content = response.Body
            };
        
        /// <summary>
        ///   Constructs and returns a <see cref="AbstractHttpResponse"/> representation of a
        ///   <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="response">
        ///   The response to be represented as a <see cref="AbstractHttpResponse"/>.
        /// </param>
        /// <param name="request">
        ///   (optional)<br/>
        ///   A request (resulting in the response). 
        /// </param>
        /// <returns>
        ///   A <see cref="AbstractHttpResponse"/>
        /// </returns>
        public static AbstractHttpResponse ToAbstractHttpResponse(this WebResponse response, AbstractHttpRequest? request = null)
        {
            return new AbstractHttpResponse()
            {
                StatusCode = response is HttpWebResponse webResponse ? (int)webResponse.StatusCode : 0,
                Method = request?.Method!,
                Uri = request?.Uri,
                Headers = response.Headers.ToKeyValuePairs(),
            };
        }
    }
}