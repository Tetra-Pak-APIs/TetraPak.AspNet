using System.Security.Claims;
using System.Threading.Tasks;
using TetraPak.AspNet;

namespace WebAPI.spike_customAuthScheme
{
    public class AliBabaClaimsTransformation : TetraPakClaimsTransformation
    {
        protected override Task<ClaimsPrincipal> OnTransformAsync(ClaimsPrincipal principal)
        {
            
            return Task.FromResult(principal);
        }
    }
}