using System.Security.Claims;
using System.Threading.Tasks;
using TetraPak.AspNet;

namespace WebAPI.spike_customAuthScheme
{
    public class AliBabaJwtClaimsTransformation : TetraPakJwtClaimsTransformation
    {
        protected override Task<ClaimsPrincipal> OnTransformAsync(ClaimsPrincipal principal)
        {
            foreach (var identity in principal.Identities)
            {
                if (identity.AuthenticationType != AliBabaAuthentication.Scheme)
                    continue;

                if (principal.TryResolveIdClaim(out var id, "sub"))
                    continue;
            }
            return Task.FromResult(principal);
        }
    }
}