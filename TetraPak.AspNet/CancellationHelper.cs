using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Convenient methods for dealing with aborted/canceled HTTP requests.
    /// </summary>
    public static class CancellationHelper
    {
        /// <summary>
        ///   Returns a value indicating whether the current request/response roundtrip was aborted/cancelled. 
        /// </summary>
        public static bool IsRequestCancelled(this ControllerBase self) => self.HttpContext.IsRequestCancelled();

        /// <summary>
        ///   Returns a value indicating whether the current request/response roundtrip was aborted/cancelled. 
        /// </summary>
        public static bool IsRequestCancelled(this HttpContext? self) => self?.RequestAborted.IsCancellationRequested ?? false;

        /// <summary>
        ///   Returns a value indicating whether the current request/response roundtrip was aborted/cancelled. 
        /// </summary>
        public static bool IsRequestCancelled(this CancellationToken? self) => self is { IsCancellationRequested: true };

        /// <summary>
        ///   
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static ActionResult RespondCancelled(this ControllerBase self) => self.NoContent();
    }
}