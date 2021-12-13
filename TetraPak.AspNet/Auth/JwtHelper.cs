using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
            this string? stringValue,
            [NotNullWhen(true)] out JwtSecurityToken? jwtSecurityToken, 
            ILogger? logger = null)
        {
            jwtSecurityToken = null!;
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

        /// <summary>
        ///   Examines a string and returns a value that indicates whether it is a security token that
        ///   represents a system identity (as opposed to an identity supported by an identity provider).
        ///   This is often the case when the client is an autonomous service, such as a web job,
        ///   that was authorized via a Client Credential Grant. 
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the string is a token that represents a system identity; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        ///   This information is needed by the <see cref="TetraPakJwtClaimsTransformation"/> service so as
        ///   to not waste time on trying to obtain identity claims from Tetra Pak's User Information services.
        /// </remarks>
        /// <seealso cref="IsSystemIdentityToken(ActorToken)"/>
        public static bool IsSystemIdentityToken(this string stringValue) 
            => stringValue.TryParseToJwtSecurityToken(out var jwt) && isSystemIdentityToken(jwt);

        /// <summary>
        ///   Examines a token and returns a value that indicates whether the token represents a system identity
        ///   (as opposed to an identity supported by an identity provider). This is often the case when the
        ///   client is an autonomous service, such as a web job, that was authorized via a Client Credential Grant. 
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the token represents a system identity; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        ///   This information is needed by the <see cref="TetraPakJwtClaimsTransformation"/> service so as
        ///   to not waste time on trying to obtain identity claims from Tetra Pak's User Information services.
        /// </remarks>
        /// <seealso cref="IsSystemIdentityToken(string)"/>
        public static bool IsSystemIdentityToken(this ActorToken actorToken) 
            => isSystemIdentityToken(actorToken.ToJwtSecurityToken());

        static bool isSystemIdentityToken(JwtSecurityToken? jwt)
        {
            if (jwt is null)
                return false;
                
            const StringComparison Comparison = StringComparison.InvariantCultureIgnoreCase;
            var userTypeClaim = jwt.Claims.FirstOrDefault(i => i.Type.Equals("userType", Comparison));
            return userTypeClaim is { } && userTypeClaim.Value.Equals("system", Comparison);
        }
    }
}