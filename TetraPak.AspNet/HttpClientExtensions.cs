using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    public static class HttpClientExtensions
    {
        
    }

    public class RefreshTokenArgs
    {
        readonly TetraPakAuthConfig _authConfig;
        
        

        public RefreshTokenArgs(TetraPakAuthConfig authConfig)
        {
            _authConfig = authConfig;
        }
    }
}