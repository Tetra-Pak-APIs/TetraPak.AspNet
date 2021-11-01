using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Provides convenience- and extension methods to assist in the use of JavaScript Web Tokens (JWT). 
    /// </summary>
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
        ///   Tries parsing a <see cref="string"/> as a JWT token.
        /// </summary>
        /// <param name="stringValue">
        ///   The <see cref="string"/> to be parsed.
        /// </param>
        /// <param name="jwtSecurityToken">
        ///   On success; passes the <see cref="JwtSecurityToken"/> (<c>null</c> on failure). 
        /// </param>
        /// <param name="logger">
        ///   (optional)<br/>
        ///   A logger provider used for diagnostics purposes.
        /// </param>
        public static bool TryParseToJwtSecurityToken(
            this string stringValue,
            [NotNullWhen(true)] out JwtSecurityToken jwtSecurityToken, 
            ILogger logger = null)
        {
            jwtSecurityToken = null;
            if (stringValue is null)
                return false;

            var isBearer = stringValue.StartsWith(
                BearerToken.Qualifier, 
                StringComparison.InvariantCultureIgnoreCase);
            
            try
            {
                var token = isBearer ? stringValue[BearerToken.Qualifier.Length..].Trim() : stringValue.Trim();
                var handler = new JwtSecurityTokenHandler();
                jwtSecurityToken = handler.ReadJwtToken(token);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Failed when parsing JWT Security Token from string value: {stringValue}");
                return false;
            }
        }
    }
}