using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace TetraPak.AspNet
{
    public class AmbientData
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public static class Keys
        {
            public const string AccessToken = "access_token";
            public const string IdToken = "id_token";
        }

        public Outcome<string> TryGetAccessToken()
        {
            return _httpContextAccessor.HttpContext.Items.TryGetValue(Keys.AccessToken, out var obj) && obj is string token
                ? Outcome<string>.Success(token)
                : Outcome<string>.Fail(new ArgumentOutOfRangeException());
        }
        
        public Outcome<string> TryGetIdToken()
        {
            return _httpContextAccessor.HttpContext.Items.TryGetValue(Keys.IdToken, out var obj) && obj is string token
                ? Outcome<string>.Success(token)
                : Outcome<string>.Fail(new ArgumentOutOfRangeException());
        }
        
        public AmbientData(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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

    }
}