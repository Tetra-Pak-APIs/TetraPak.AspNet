using System;
using System.Security.Claims;
using System.Threading;
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

        /// <summary>
        ///   NOT SUPPORTED! DO NOT INVOKE!
        /// </summary>
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal, CancellationToken? cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}