using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Convenient extension methods for obtaining typical claims from a <see cref="ClaimsIdentity"/> value.
    /// </summary>
    public static class ClaimsIdentityExtensions
    {
        /// <summary>
        ///   Gets the user name, if present.
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
        public static string? Name(this ClaimsIdentity self, bool trimStringQualifiers = true)
            => claimValue(self.Claims, ClaimTypes.Name, "sub", trimStringQualifiers); 
        
        /// <summary>
        ///   Gets the user name, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsPrincipal"/> instance.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The first name claim when supported.
        /// </returns>
        public static string? Name(this ClaimsPrincipal? self, bool trimStringQualifiers = true)
            => claimValue(self?.Claims, ClaimTypes.Name, "sub", trimStringQualifiers); 
        
        /// <summary>
        ///   Gets the user name, if present
        ///   (this is the equivalence to calling <see cref="Name(System.Security.Claims.ClaimsIdentity,bool)"/>).
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
        public static string? Id(this ClaimsIdentity self, bool trimStringQualifiers = true)
            => self.Name(trimStringQualifiers); 
        
        /// <summary>
        ///   Gets the user name, if present
        ///   (this is the equivalence to calling <see cref="Name(System.Security.Claims.ClaimsIdentity,bool)"/>).
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsPrincipal"/> instance.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The first name claim when supported.
        /// </returns>
        public static string? Id(this ClaimsPrincipal? self, bool trimStringQualifiers = true)
            => self.Name(trimStringQualifiers); 
        
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
        public static string? FirstName(this ClaimsIdentity? self, bool trimStringQualifiers = true)
            => claimValue(self?.Claims, ClaimTypes.GivenName, "given_name", trimStringQualifiers);
       
        /// <summary>
        ///   Gets the first name claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsPrincipal"/>.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The first name claim when supported.
        /// </returns>
        public static string? FirstName(this ClaimsPrincipal? self, bool trimStringQualifiers = true)
            => claimValue(self?.Claims, ClaimTypes.GivenName, "given_name", trimStringQualifiers);
       
        /// <summary>
        ///   Gets the last name claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsIdentity"/>.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The last name claim when supported.
        /// </returns>
        public static string? LastName(this ClaimsIdentity? self, bool trimStringQualifiers = true)
            => claimValue(self?.Claims, ClaimTypes.Surname, "family_name", trimStringQualifiers);

        /// <summary>
        ///   Gets the last name claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsPrincipal"/>.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The last name claim when supported.
        /// </returns>
        public static string? LastName(this ClaimsPrincipal? self, bool trimStringQualifiers = true)
            => claimValue(self?.Claims, ClaimTypes.Surname, "family_name", trimStringQualifiers);

        /// <summary>
        ///   Gets the email claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsIdentity"/>.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The email claim when supported.
        /// </returns>
        public static string? Email(this ClaimsIdentity? self, bool trimStringQualifiers = true)
            => claimValue(self?.Claims, ClaimTypes.Email, null, trimStringQualifiers);

        /// <summary>
        ///   Gets the email claim, if present.
        /// </summary>
        /// <param name="self">
        ///   The extended <see cref="ClaimsPrincipal"/>.
        /// </param>
        /// <param name="trimStringQualifiers">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to trim the claim from any string qualifiers.
        /// </param>
        /// <returns>
        ///   The email claim when supported.
        /// </returns>
        public static string? Email(this ClaimsPrincipal? self, bool trimStringQualifiers = true)
            => claimValue(self?.Claims, ClaimTypes.Email, null, trimStringQualifiers: trimStringQualifiers);

        static string? claimValue(
            IEnumerable<Claim>? claims, 
            string key, 
            string? fallbackKey, 
            bool trimStringQualifiers = true)
        {
            if (claims is null)
                return null;
            
            var value = fallbackKey is {} 
                ? claims.FirstOrDefault(i => i.Type == key || i.Type == fallbackKey)?.Value
                : claims.FirstOrDefault(i => i.Type == key)?.Value;
            
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return trimStringQualifiers
                ? value.Trim('\"')
                : value;
        }
    }
}