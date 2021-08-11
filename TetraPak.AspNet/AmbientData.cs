using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Caching;

namespace TetraPak.AspNet
{
    public class AmbientData : IMessageIdProvider, IAccessTokenProvider
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public static class Keys
        {
            public const string AccessToken = "access_token";
            public const string IdToken = "id_token";
            public const string RefreshToken = "refresh_token";
            public const string ExpiresAt = "expires_at";
            public const string ExpiresIn = "expires_in";
            public const string RequestMessageId = "api-flow-id";
        }

        public TetraPakAuthConfig AuthConfig { get; }

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        public ILogger Logger => AuthConfig.Logger;

        /// <summary>
        ///   Gets a ambient cache.
        /// </summary>
        public ITimeLimitedRepositories Cache { get; }

        /// <inheritdoc />
        public string GetMessageId(bool enforce = false) 
            => _httpContextAccessor.HttpContext?.Request.GetMessageId(AuthConfig, enforce);

        public Task<Outcome<ActorToken>> GetAccessTokenAsync(bool forceStandardHeader = false) 
            => _httpContextAccessor.HttpContext.GetAccessTokenAsync(AuthConfig, forceStandardHeader);

        public Task<Outcome<ActorToken>> GetIdTokenAsync(TetraPakAuthConfig authConfig) 
            => _httpContextAccessor.HttpContext.GetIdTokenAsync(authConfig);

        public HttpContext HttpContext => _httpContextAccessor.HttpContext; 

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

        public void SetValue(string key, object value)
        {
            HttpContext.Items[key] = value;
        }

        public object this[string key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        public object GetValue(string key, object useDefault = null) => GetValue<object>(key, useDefault);

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

    public static class ClaimsIdentityExtensions
    {
        public static string FirstName(this ClaimsIdentity self, bool trimStringQualifiers = true)
            => claimValue(self, ClaimTypes.GivenName, trimStringQualifiers);
       
        public static string LastName(this ClaimsIdentity self, bool trimStringQualifiers = true)
            => claimValue(self, ClaimTypes.Surname, trimStringQualifiers);

        public static string Email(this ClaimsIdentity self, bool trimStringQualifiers = true)
            => claimValue(self, ClaimTypes.Email, trimStringQualifiers);

        static string claimValue(ClaimsIdentity self, string key, bool trimStringQualifiers = true)
        {
            var value = self.Claims.FirstOrDefault(i => i.Type == key)?.Value;
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return trimStringQualifiers
                ? value.Trim('\"')
                : value;
        }
    }
}