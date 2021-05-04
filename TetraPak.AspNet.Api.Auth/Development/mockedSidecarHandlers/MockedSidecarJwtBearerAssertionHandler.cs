using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api.Auth.Development
{
    public class MockedSidecarJwtBearerAssertionHandler : MockedSidecarHandler
    {
        protected override Task<bool> OnHandle()
        {
            Context.Request.Headers[HeaderNames.Authorization] = $"Bearer {issueJwt()}";
            return Task.FromResult(false);
        }
        
        string issueJwt()
        {
            var options = (SidecarJwtBearerAssertionOptions) Options;
            var tokenHandler = new JwtSecurityTokenHandler();
            // var tokenClaims = new Claim[claims?.Count ?? 0 + 1]; todo support configured claims
            // tokenClaims[0] = new Claim(ClaimTypes.Name, actorId);
            // if (claims is {})
            // {
            //     var i = 0;
            //     foreach (var (key, value) in claims)
            //     {
            //         tokenClaims[++i] = new Claim(key, value);
            //     }
            // }

            var claimsIdentity = Context.User.Claims.Any()
                ? new ClaimsIdentity(Context.User.Claims)
                : new GenericIdentity("john.doe@tetrapak.com");
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = options.GetIssuer(Context),
                IssuedAt =  DateTime.Now,
                Subject = claimsIdentity,
                NotBefore = DateTime.UtcNow,
                Audience = getAudience(options),
                Expires = DateTime.Now.Add(options.TokenLifetime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(options.TokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(descriptor);
            if (!string.IsNullOrWhiteSpace(options.KeyId))
            {
                token.Header.Add("kid", options.KeyId);
            }
            Log?.Debug($"Issues JWT token for audience '{descriptor.Audience}' " + 
                       $"(expires {descriptor.Expires?.ToString(CultureInfo.InvariantCulture)})");
            return tokenHandler.WriteToken(token);
        }
        
        string getAudience(SidecarJwtBearerAssertionOptions options)
        {
            if (!string.IsNullOrEmpty(options.Audience))
                return options.Audience;

            var emailClaim = Context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
            if (emailClaim is { })
                return emailClaim.Value;

            return Context.User.Identity?.Name ?? Context.User.ToString();
        }
    }
}