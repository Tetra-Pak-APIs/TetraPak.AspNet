using TetraPak.AspNet.Documentations;

namespace TetraPak.AspNet.Api.Auth
{
    public static class AuthExceptionsExceptionHelper
    {
        public static ServerException TokenExchangeNotSupportedForSystemIdentity(this ITokenExchangeGrantService _)
        {
            return ServerException.BadRequest(
                "Token exchange is not supported for system identities"+
                Docs.PleaseSee(Docs.DevPortal.TokenExchangeSubjectTokenTypes));
        }
    }
}