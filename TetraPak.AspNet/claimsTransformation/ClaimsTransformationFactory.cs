using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Represents a basic (<c>abstract</c>) factory to be used for constructing
    ///   implementations of the <see cref="ITetraPakClaimsTransformation"/> interface.
    /// </summary>
    public abstract class ClaimsTransformationFactory : ITetraPakClaimsTransformation
    {
        internal ITetraPakClaimsTransformation GetClaimsTransformation(IServiceProvider serviceProvider)
        {
            return OnGetClaimsTransformation(serviceProvider);
        }

        /// <summary>
        ///   Invoked to construct and return a <see cref="ITetraPakClaimsTransformation"/>.
        /// </summary>
        /// <param name="serviceProvider">
        ///   A service locator.
        /// </param>
        /// <returns>
        ///   A <see cref="ITetraPakClaimsTransformation"/>.
        /// </returns>
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