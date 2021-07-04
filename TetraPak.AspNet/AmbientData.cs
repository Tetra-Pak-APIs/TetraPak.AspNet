using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Caching;

namespace TetraPak.AspNet
{
    public class AmbientData
    {
        readonly TetraPakAuthConfig _authConfig;
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

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        public ILogger Logger => _authConfig.Logger;

        /// <summary>
        ///   Gets a ambient cache.
        /// </summary>
        public ITimeLimitedRepositories Cache { get; }

        /// <summary>
        ///   Gets a standardized value used for referencing a unique request. 
        /// </summary>
        /// <param name="enforce">
        ///   (optional; default=<c>false</c>)<br/>
        ///   When set, a random unique string will be generated and attached to the request.  
        /// </param>
        /// <returns>
        ///   A unique <see cref="string"/> value. 
        /// </returns>
        public string GetMessageId(bool enforce = false) 
            => _httpContextAccessor.HttpContext?.Request.GetMessageId(_authConfig, enforce);

        public Task<Outcome<ActorToken>> GetAccessTokenAsync(TetraPakAuthConfig authConfig) 
            => _httpContextAccessor.HttpContext.GetAccessTokenAsync(authConfig);

        // public Outcome<ActorToken> GetAccessToken()
        // {
        //     return _httpContextAccessor.HttpContext.GetAccessToken();
        //     // return _httpContextAccessor.HttpContext.Items.TryGetValue(Keys.AccessToken, out var obj) && obj is string token obsolete
        //     //     ? Outcome<string>.Success(token)
        //     //     : Outcome<string>.Fail(new ArgumentOutOfRangeException());
        // }
        
        public Task<Outcome<ActorToken>> GetIdTokenAsync(TetraPakAuthConfig authConfig) 
            => _httpContextAccessor.HttpContext.GetIdTokenAsync(authConfig);

        // public Outcome<ActorToken> GetIdToken()
        // {
        //     return _httpContextAccessor.HttpContext.GetIdToken();
        //     // return _httpContextAccessor.HttpContext.Items.TryGetValue(Keys.IdToken, out var obj) && obj is string token obsolete
        //     //     ? Outcome<string>.Success(token)
        //     //     : Outcome<string>.Fail(new ArgumentOutOfRangeException());
        // }
        
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
            _authConfig = authConfig;
            _httpContextAccessor = httpContextAccessor;
            Cache = cache;
        }
    }

    public static class ClaimsIdentityExtensions
    {
        public static string FirstName(this ClaimsIdentity self)
        {
            return self.Claims.FirstOrDefault(i => i.Type == ClaimTypes.GivenName)?.Value;
        }
       
        public static string LastName(this ClaimsIdentity self)
        {
            return self.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Surname)?.Value;
        }

        public static string Email(this ClaimsIdentity self)
        {
            return self.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Email)?.Value;
        }
    }
}