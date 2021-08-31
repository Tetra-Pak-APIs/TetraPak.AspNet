using System.Net.Http;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Used to configure a <see cref="HttpClient"/> through a <see cref="IHttpServiceProvider"/>.
    /// </summary>
    public class HttpClientOptions
    {
        internal string MessageId { get; private set; }
        
        /// <summary>
        ///   Gets or sets a value specifying whether the requested <see cref="HttpClient"/> should be
        ///   transient (otherwise a singleton instance till be returned). 
        /// </summary>
        public bool IsClientTransient { get; set; }
        
        /// <summary>
        ///   Gets or sets an authentication header value to be used for the requested client.
        /// </summary>
        public ActorToken Authorization { get; set; }

        /// <summary>
        ///   A custom <see cref="HttpMessageHandler"/> to be used by the requested <see cref="HttpClient"/>.
        /// </summary>
        public HttpMessageHandler MessageHandler { get; set; }

        /// <summary>
        ///   Gets or sets the configuration required for authenticating the client. 
        /// </summary>
        public IServiceAuthConfig AuthConfig { get; set; }

        internal HttpClientOptions WithMessageId(string messageId)
        {
            MessageId = messageId;
            return this;
        }

        /// <summary>
        ///   Fluid API for assigning the <see cref="Authorization"/> property value.
        /// </summary>
        public HttpClientOptions WithAuthorization(ActorToken authorization)
        {
            Authorization = authorization;
            return this;
        }

        public HttpClientOptions(bool isClientTransient = true)
        {
            IsClientTransient = isClientTransient;
        }
    }
}