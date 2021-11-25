using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api
{
    class TetraPakGrantTypeResolver : IGrantTypeResolver
    {
        public async Task<Outcome<GrantType>> ResolveAutomaticGrantType(HttpContext context)
        {
            var tokenOutcome = await context.GetAccessTokenAsync();
            if (!tokenOutcome)
                return Outcome<GrantType>.Success(GrantType.ClientCredentials);

            var token = tokenOutcome.Value!;
            return Outcome<GrantType>.Success(
                token.IsSystemIdentityToken()
                    ? GrantType.ClientCredentials
                    : GrantType.TokenExchange);
        }
    }
}