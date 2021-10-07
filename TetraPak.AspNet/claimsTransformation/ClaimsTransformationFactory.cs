using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TetraPak.AspNet
{
    public abstract class ClaimsTransformationFactory : ITetraPakClaimsTransformation
    {
        internal ITetraPakClaimsTransformation GetClaimsTransformation(IServiceProvider serviceProvider)
        {
            return OnGetClaimsTransformation(serviceProvider);
        }

        protected abstract ITetraPakClaimsTransformation OnGetClaimsTransformation(IServiceProvider serviceProvider);

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }
    }
}