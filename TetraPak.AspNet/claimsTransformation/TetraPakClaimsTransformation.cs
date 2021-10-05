using System.Security.Claims;
using System.Threading.Tasks;

namespace TetraPak.AspNet
{
    public abstract class TetraPakClaimsTransformation : ITetraPakClaimsTransformation
    {
        /// <inheritdoc />
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var clone = principal.Clone();
            return OnTransformAsync(clone);
        }

        protected abstract Task<ClaimsPrincipal> OnTransformAsync(ClaimsPrincipal principal);
    }
}