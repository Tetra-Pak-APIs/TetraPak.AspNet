using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Caching;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides ambient data to an ASP.NET Core/5+ project throughout a request/response roundtrip.
    /// </summary>
    public class AmbientData : IMessageIdProvider, IAccessTokenProvider, IIdentityTokenProvider
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        ///   Provides well-known identifiers to access ambient values.  
        /// </summary>
        public static class Keys
        {
            /// <summary>
            ///   Identifies an access token. 
            /// </summary>
            public const string AccessToken = "access_token";
            
            /// <summary>
            ///   Identifies an identity token. 
            /// </summary>
            public const string IdToken = "id_token";
            
            /// <summary>
            ///   Identifies a refresh token.
            /// </summary>
            public const string RefreshToken = "refresh_token";
            
            /// <summary>
            ///   Identifies an expiration time.
            /// </summary>
            public const string ExpiresAt = "expires_at";
            
            /// <summary>
            ///   Identifies a time-to-live value.
            /// </summary>
            public const string ExpiresIn = "expires_in";
            
            /// <summary>
            ///   Identifies a message id persisting throughout a request/response roundtrip. 
            /// </summary>
            public const string RequestMessageId = "api-flow-id";
        }

        /// <summary>
        ///   Gets the current <see cref="HttpContext"/> instance.
        /// </summary>
        public HttpContext HttpContext => _httpContextAccessor.HttpContext; 

        /// <summary>
        ///   Gets an auth config value. 
        /// </summary>
        public TetraPakAuthConfig AuthConfig { get; }

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        public ILogger Logger => AuthConfig.Logger;

        /// <summary>
        ///   Gets a ambient cache.
        /// </summary>
        public ITimeLimitedRepositories Cache { get; } // obsolete?

        /// <inheritdoc />
        public string GetMessageId(bool enforce = false) 
            => _httpContextAccessor.HttpContext?.Request.GetMessageId(AuthConfig, enforce);

        /// <inheritdoc />
        public Task<Outcome<ActorToken>> GetAccessTokenAsync(bool forceStandardHeader = false) 
            => _httpContextAccessor.HttpContext.GetAccessTokenAsync(AuthConfig, forceStandardHeader);

        /// <inheritdoc />
        public Task<Outcome<ActorToken>> GetIdTokenAsync() 
            => _httpContextAccessor.HttpContext.GetIdTokenAsync(AuthConfig);

        /// <summary>
        ///   Returns a value indicating whether the routed endpoint is an API endpoint (not a view).
        /// </summary>
        public bool IsApiEndpoint()
        {
            var context = _httpContextAccessor.HttpContext;
            var endpoint = context?.GetEndpoint();
            if (endpoint is null)
                return false;

            return false;
        }

        /// <summary>
        ///   Sets an ambient value.
        /// </summary>
        /// <param name="key">
        ///   Identifies the value to be added.
        /// </param>
        /// <param name="value">
        ///   The value to be added.
        /// </param>
        public void SetValue(string key, object value)
        {
            HttpContext.Items[key] = value;
        }

        /// <summary>
        ///   Indexer to get or set an ambient value.
        /// </summary>
        /// <param name="key">
        ///   Identifies the value.
        /// </param>
        public object this[string key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        /// <summary>
        ///   Gets an ambient value.
        /// </summary>
        /// <param name="key">
        ///   Identifies the value.
        /// </param>
        /// <param name="useDefault">
        ///   (optional)<br/>
        ///   A default value to be returned if the requested ambient value is not supported.  
        /// </param>
        /// <returns>
        ///   The requested value if present; otherwise <paramref name="useDefault"/> when specified,
        ///   otherwise <c>null</c>.
        /// </returns>
        public object GetValue(string key, object useDefault = null) => GetValue<object>(key, useDefault);

        /// <summary>
        ///   Gets an ambient value of a specified type.
        /// </summary>
        /// <param name="key">
        ///   Identifies the value.
        /// </param>
        /// <param name="useDefault">
        ///   (optional)<br/>
        ///   A default value to be returned if the requested ambient value is not supported.  
        /// </param>
        /// <typeparam name="T">
        ///   The type of value being requested.
        /// </typeparam>
        /// <returns>
        ///   The requested value if present; otherwise <paramref name="useDefault"/> when specified,
        ///   otherwise <c>default(T)</c>.
        /// </returns>
        public T GetValue<T>(string key, T useDefault = default) => HttpContext.GetValue(key, useDefault);

        /// <summary>
        ///   Initializes the <see cref="AmbientData"/> instance.
        /// </summary>
        /// <param name="authConfig">
        ///   The Tetra Pak auth configuration.
        /// </param>
        /// <param name="httpContextAccessor">
        ///   A <see cref="IHttpContextAccessor"/> that is required for many of the ambient data operations.
        /// </param>
        /// <param name="cache">
        ///   (optional)<br/>
        ///   A caching mechanism for public availability through the <see cref="AmbientData"/> instance.
        /// </param>
        public AmbientData(
            TetraPakAuthConfig authConfig,
            IHttpContextAccessor httpContextAccessor,
            ITimeLimitedRepositories cache = null)
        {
            AuthConfig = authConfig;
            _httpContextAccessor = httpContextAccessor;
            Cache = cache;
        }
    }
}