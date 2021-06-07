using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    public class AmbientData
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public static class Keys
        {
            public const string AccessToken = "access_token";
            public const string IdToken = "id_token";
            public const string RefreshToken = "refresh_token";
            public const string ExpiresAt = "expires_at";
            public const string ExpiresIn = "expires_in";
        }

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
        
        public AmbientData(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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