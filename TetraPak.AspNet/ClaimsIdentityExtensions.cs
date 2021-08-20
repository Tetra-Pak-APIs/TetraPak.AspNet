using System.Linq;
using System.Security.Claims;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Convenient extension methods for obtaining typical claims from a <see cref="ClaimsIdentity"/> value.
    /// </summary>
    public static class ClaimsIdentityExtensions
    {
        /// <summary>
        ///   Gets the first name claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsIdentity"/> instance.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The first name claim when supported.
        /// </returns>
        public static string FirstName(this ClaimsIdentity self, bool trimStringQualifiers = true)
            => claimValue(self, ClaimTypes.GivenName, trimStringQualifiers);
       
        /// <summary>
        ///   Gets the last name claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsIdentity"/> instance.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The last name claim when supported.
        /// </returns>
        public static string LastName(this ClaimsIdentity self, bool trimStringQualifiers = true)
            => claimValue(self, ClaimTypes.Surname, trimStringQualifiers);

        /// <summary>
        ///   Gets the email claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsIdentity"/> instance.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The email claim when supported.
        /// </returns>
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