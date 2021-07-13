using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    public static class JwtHelper
    {
        /// <summary>
        ///   Builds and returns a string representing a (decoded) JWT security token.
        /// </summary>
        public static string ToDebugString(this JwtSecurityToken jwt)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"kid: {jwt.Header["kid"]}");
            sb.AppendLine($"typ: {jwt.Header["typ"]}");
            sb.AppendLine($"alg: {jwt.Header["alg"]}");
            sb.AppendLine("-------------------");
            foreach (var claim in jwt.Claims)
            {
                sb.AppendLine($"{claim.Type}: {claim.Value}");
            }

            return sb.ToString();
        }

        /// <summary>
        ///   Gets the expiration time for a <see cref="JwtSecurityToken"/>. 
        /// </summary>
        /// <param name="jwt">
        ///   The <see cref="JwtSecurityToken"/>.
        /// </param>
        /// <returns>
        ///   A <see cref="DateTime"/> value if the <paramref name="jwt"/> contains an "exp" claim;
        ///   otherwise <c>null</c>. 
        /// </returns>
        public static DateTime? Expires(this JwtSecurityToken jwt) => jwt.Payload.Exp?.EpochToDateTime();

        /// <summary>
        ///   Parses a JWT token and returns a <see cref="JwtSecurityToken"/> from the content.
        /// </summary>
        public static bool TryParseToJwtSecurityToken(this string s, out JwtSecurityToken jwtSecurityToken, ILogger logger = null)
        {
            jwtSecurityToken = null;
            if (s is null)
                return false;

            var isBearer = s.StartsWith(
                BearerToken.Qualifier, 
                StringComparison.InvariantCultureIgnoreCase);
            
            try
            {
                var token = isBearer ? s[BearerToken.Qualifier.Length..].Trim() : s.Trim();
                var handler = new JwtSecurityTokenHandler();
                jwtSecurityToken = handler.ReadJwtToken(token);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Failed when parsing JWT Security Token from string value: {s}");
                return false;
            }
        }
    }
}