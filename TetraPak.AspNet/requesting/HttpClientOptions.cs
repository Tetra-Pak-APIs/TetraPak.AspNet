#nullable enable
using System.Net.Http;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Used to configure a <see cref="HttpClient"/> through a <see cref="IHttpClientProvider"/>.
    /// </summary>
    public class HttpClientOptions
    {
        internal string? MessageId { get; private set; }

        /// <summary>
        ///   Gets or sets a value specifying whether the requested <see cref="HttpClient"/> should be
        ///   transient (otherwise a singleton instance till be returned). 
        /// </summary>
        public bool IsClientTransient { get; set; }
        
        /// <summary>
        ///   Gets or sets an authentication header value to be used for the requested client.
        /// </summary>
        public ActorToken? ActorToken { get; set; }

        /// <summary>
        ///   Gets or sets an (optional) authorization service. When set this is an indicator that the
        ///   requested client should be automatically authorized as per the configured <see cref="AuthConfig"/>.   
        /// </summary>
        public IAuthorizationService? AuthorizationService { get; set; }
        
        /// <summary>
        ///   A custom <see cref="HttpMessageHandler"/> to be used by the requested <see cref="HttpClient"/>.
        /// </summary>
        public HttpMessageHandler? MessageHandler { get; set; }

        /// <summary>
        ///   Gets or sets the configuration required for authenticating the client. 
        /// </summary>
        public IServiceAuthConfig? AuthConfig { get; set; }

        internal HttpClientOptions WithMessageId(string messageId)
        {
            MessageId = messageId;
            return this;
        }

        /// <summary>
        ///   Fluid API for assigning the <see cref="ActorToken"/> property value.
        /// </summary>
        public HttpClientOptions WithAuthorization(ActorToken? authorization)
        {
            ActorToken = authorization;
            return this;
        }

        /// <summary>
        ///   (Fluid API)<br/>
        ///   Assigns the <see cref="AuthorizationService"/> and returns <c>this</c>.
        /// </summary>
        public HttpClientOptions WithAuthorizationService(IAuthorizationService authorizationService)
        {
            AuthorizationService = authorizationService;
            return this;
        }

        /// <summary>
        ///   Initializes the <see cref="HttpClientOptions"/>.
        /// </summary>
        /// <param name="isClientTransient">
        ///   Initializes <see cref="IsClientTransient"/>.
        /// </param>
        public HttpClientOptions(bool isClientTransient = true)
        {
            IsClientTransient = isClientTransient;
        }
    }
}