using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    public static class HttpClientExtensions
    {
        
    }

    public class RefreshTokenArgs
    {
        readonly TetraPakConfig _config;
        
        

        public RefreshTokenArgs(TetraPakConfig config)
        {
            _config = config;
        }
    }
}