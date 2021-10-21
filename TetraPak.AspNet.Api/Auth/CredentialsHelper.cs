using TetraPak.AspNet.Auth;

#nullable enable

namespace TetraPak.AspNet.Api.Auth
{
    public static class CredentialsHelper
    {
        /// <summary>
        ///   Examines <see cref="Credentials"/> and returns a value indicating whether they can be
        ///   used for a specified <see cref="GrantType"/>.
        /// </summary>
        /// <param name="credentials">
        ///   The extended <see cref="Credentials"/>.
        /// </param>
        /// <param name="grantType">
        ///   The specified grant type.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the credentials are valid for the specified grant type;
        ///   otherwise <c>false</c>.
        /// </returns>
        public static bool IsValidFor(this Credentials? credentials, GrantType grantType)
        {
            var id = credentials?.Identity?.Trim();
            var pw = credentials?.Secret?.Trim();

            return grantType switch
            {
                GrantType.CC => !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(pw),
                GrantType.TX => !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(pw),
                _ => false
            };
        }
    }
}