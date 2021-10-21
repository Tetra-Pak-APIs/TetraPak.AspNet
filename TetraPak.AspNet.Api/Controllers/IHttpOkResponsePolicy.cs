using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TetraPak.AspNet.Api.Controllers
{
    /// <summary>
    ///   Classes implementing this interface can be used internally to enforce a custom policy
    ///   for successful HTTP response, such as setting the correct ("success") HTTP status code (200-299).  
    /// </summary>
    public interface IHttpOkResponsePolicy
    {
        /// <summary>
        ///   Invoked automatically to allow setting the correct HTTP status code for a response. 
        /// </summary>
        /// <param name="context">
        ///   The HTTP request/response context.
        /// </param>
        /// <param name="response">
        ///   The HTTP result whose <see cref="ObjectResult.StatusCode"/> should be set.
        /// </param>
        /// <returns>
        ///   An <see cref="ActionResult"/> (typically the <paramref name="response"/>).
        /// </returns>
        OkObjectResult ApplyHttpResponsePolicy(HttpContext context, OkObjectResult response);
    }
}