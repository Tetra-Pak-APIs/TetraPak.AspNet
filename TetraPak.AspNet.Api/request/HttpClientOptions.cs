using System.Net.Http;
using System.Net.Http.Headers;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Used to configure a <see cref="HttpClient"/> through a <see cref="IHttpClientProvider"/>.
    /// </summary>
    public class HttpClientOptions
    {
        /// <summary>
        ///   Gets or sets a value specifying whether the requested <see cref="HttpClient"/> should be
        ///   transient (otherwise a singleton instance till be returned). 
        /// </summary>
        public bool IsClientTransient { get; set; }
        
        /// <summary>
        ///   Gets or sets an authentication header value to be used for the requested client.
        /// </summary>
        public AuthenticationHeaderValue Authentication { get; set; }

        /// <summary>
        ///   A custom <see cref="HttpMessageHandler"/> to be used by the requested <see cref="HttpClient"/>.
        /// </summary>
        public HttpMessageHandler MessageHandler { get; set; }

        public HttpClientOptions(bool isClientTransient = true)
        {
            IsClientTransient = isClientTransient;
        }
    }
}