using System.IdentityModel.Tokens.Jwt;

namespace TetraPak.AspNet.Api.Auth
{
    public static class TokenHelper
    {
        public static bool TryParseAsJwtToken(this string self, out JwtSecurityToken token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                token = handler.ReadJwtToken(self);
                return true;
            }
            catch
            {
                token = null;
                return false;
            }
        }
    }
}