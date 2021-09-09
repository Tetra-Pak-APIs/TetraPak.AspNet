using System;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Convenient extension methods for working with controllers and endpoints. 
    /// </summary>
    public static class RoutingHelper
    {
        /// <summary>
        ///   Examines an endpoint and returns a value indicating whether it requires authorization.
        /// </summary>
        /// <param name="self">
        ///   The <see cref="Endpoint"/> (can be <c>null</c>).  
        /// </param>
        /// <returns>
        ///   <c>true</c> if the endpoint is assigned and requires authorization; otherwise <c>false</c>.
        /// </returns>
        public static bool IsAuthorizationRequired(this Endpoint? self)
        {
            if (self is null)
                return false;

            var action = self.Metadata.GetMetadata<ControllerActionDescriptor>();
            return action?.MethodInfo.IsAuthorizationRequired() ?? false;
        }

        /// <summary>
        ///   Examines a method and returns a value indicating whether it requires authorization.
        /// </summary>
        /// <param name="self">
        ///   The <see cref="MethodInfo"/> (can be <c>null</c>).  
        /// </param>
        /// <param name="fallbackToDeclaringType">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to automatically fall back to the method's declaring type
        ///   if the requested value cannot be resolved from the method itself. 
        /// </param>
        /// <returns>
        ///   <c>true</c> if the method is assigned and requires authorization; otherwise <c>false</c>.
        /// </returns>
        public static bool IsAuthorizationRequired(this MethodInfo? self, bool fallbackToDeclaringType = true)
        {
            if (self is null)
                return false;

            if (self.GetCustomAttribute<AuthorizeAttribute>() is not null)
                return true;
            
            if (self.GetCustomAttribute<AllowAnonymousAttribute>() is not null)
                return false;

            return fallbackToDeclaringType && self.DeclaringType.IsAuthorizationRequired();
        }

        /// <summary>
        ///   Examines a <see cref="Type"/> and returns a value indicating whether it requires authorization.
        /// </summary>
        /// <param name="self">
        ///   The <see cref="Type"/> (can be <c>null</c>).  
        /// </param>
        /// <param name="fallbackToDeclaringType">
        ///   (optional; default=<c>true</c>)<br/>
        ///   Specifies whether to automatically fall back to the type's declaring type
        ///   if the requested value cannot be resolved from the type itself. 
        /// </param>
        /// <returns>
        ///   <c>true</c> if the type is assigned and requires authorization; otherwise <c>false</c>.
        /// </returns>
        public static bool IsAuthorizationRequired(this Type? self, bool fallbackToDeclaringType = true)
        {
            if (self is null)
                return false;

            if (self.GetCustomAttribute<AuthorizeAttribute>() is not null)
                return true;
            
            if (self.GetCustomAttribute<AllowAnonymousAttribute>() is not null)
                return false;

            return fallbackToDeclaringType && self.DeclaringType.IsAuthorizationRequired();
        }
    }
}