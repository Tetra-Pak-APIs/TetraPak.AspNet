using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Classes implementing this code contract can be used as (custom) "claims transformers".  
    /// </summary>
    /// <seealso cref="TetraPakClaimsTransformationHelper.AddTetraPakCustomClaimsTransformation{T}"/>
    public interface ITetraPakClaimsTransformation
    {
        /// <summary>
        ///   Provides a central transformation point to change the specified principal. 
        /// </summary>
        /// <param name="principal">
        ///   The <see cref="ClaimsPrincipal"/> to transform.
        /// </param>
        /// <param name="cancellationToken">
        ///   Allows cancelling the operation.
        /// </param>
        /// <returns>
        ///   The transformed principal.
        /// </returns>
        Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal, CancellationToken? cancellationToken);
    }
}