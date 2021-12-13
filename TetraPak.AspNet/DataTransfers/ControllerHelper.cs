using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace TetraPak.AspNet.DataTransfers
{
    /// <summary>
    ///   Convenient method to help out with typical controller-related scenarios.
    /// </summary>
    public static class ControllerHelper
    {
        /// <summary>
        ///   Resolves the a default action for a specified controller type.
        /// </summary>
        /// <typeparam name="TController">
        ///   The controller type.
        /// </typeparam>
        /// <returns>
        ///   A <see cref="MethodInfo"/> reflecting the default action method if one could be resolved;
        ///   otherwise <c>null</c>. 
        /// </returns>
        public static MethodInfo? DefaultGetAction<TController>()
        where TController : ControllerBase
        {
            MethodInfo? defaultMethod = null;
            foreach (var method in typeof(TController).GetMethods()
                .Where(i => i.GetCustomAttribute<HttpGetAttribute>() is {}))
            {
                var routeAttrib = method.GetCustomAttribute<RouteAttribute>();
                if (routeAttrib is null)
                    return method;

                // todo resolve default method with routing
            }
            throw new NotImplementedException(); // spike
        }

        /// <summary>
        ///   Resolves and returns the path identifier for a specified controller type, as per standard ASP.NET
        ///   controller naming conventions (ei. stripping away any "Controller" suffix from the type name).
        /// </summary>
        public static string GetControllerName(this Type controllerType)
        {
            const string Suffix = "Controller";
            
            var name = controllerType.Name;
            return name.EndsWith(Suffix) 
                ? name[..^Suffix.Length] 
                : name;
        }
    }
}