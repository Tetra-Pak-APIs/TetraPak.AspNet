using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet.Api.DevelopmentTools
{
    /// <summary>
    ///   Provides helper method for examining the web hosting environment. 
    /// </summary>
    public static class WebHostEnvironmentHelper
    {
        const string LocalHostPattern = "://localhost";

        /// <summary>
        ///   Examines the bound host(s) and returns a value indicating whether they represent
        ///   a local host (eg: https://localhost[:port]).
        /// </summary>
        /// <param name="self">
        ///   The hosting environment.
        /// </param>
        /// <param name="policy">
        ///   (optional; default=<see cref="CollectionMatchingPolicy.All"/>)
        ///   Specifies how to resolve the result (see remarks).
        /// </param>
        /// <param name="logger">
        ///   (optional)<br/>
        ///   A logger provider. When passed the method will log its operation.
        /// </param>
        /// <returns>
        ///   The result depends on the specified <paramref name="policy"/>:
        ///   <list type="table">
        ///     <listheader>
        ///       <term>term</term>
        ///       <description>description</description>
        ///     </listheader>
        ///     <item>
        ///       <term>Any</term>
        ///       <description>
        ///       <c>true</c> if any bound host URL contains the pattern "<c>://localhost</c>"; otherwise <c>false</c>.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <term>All</term>
        ///       <description>
        ///       <c>true</c> if all bound host URL contains the pattern "<c>://localhost</c>"; otherwise <c>false</c>.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static bool IsLocalHost(
            this IWebHostEnvironment self, 
            CollectionMatchingPolicy policy = CollectionMatchingPolicy.All,
            ILogger? logger = null)
        {
            var hostUrls = new MultiStringValue(Environment.GetEnvironmentVariable("ASPNETCORE_URLS"), ";");
            logger.Debug($"Checking bound URLs for local host \"{hostUrls}\" (policy: {policy})");
            const StringComparison Comparison = StringComparison.InvariantCultureIgnoreCase;
            return policy switch
            {
                CollectionMatchingPolicy.Any => hostUrls.Any(s => s.Contains(LocalHostPattern, Comparison)),
                CollectionMatchingPolicy.All => hostUrls.All(s => s.Contains(LocalHostPattern, Comparison)),
                _ => throw new ArgumentOutOfRangeException(nameof(policy), policy, null)
            };
        }

        /// <summary>
        ///   Examines the bound host(s) and returns a value indicating whether they represent
        ///   a local host (eg: https://localhost[:port]).
        /// </summary>
        /// <param name="self">
        ///   The hosting environment.
        /// </param>
        /// <param name="criteria">
        ///   A callback method that gets interrogated for all bound host URLs. If the method returns
        ///   a <c>false</c> value the bound hosts are not considered "local". 
        /// </param>
        /// <returns>
        ///   <c>true</c> if all bound host URLs are considered "local"; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="criteria"/> was unassigned (<c>null</c>).
        /// </exception>
        public static bool IsLocalHost(
            this IWebHostEnvironment self,
            Func<Uri, bool> criteria)
        {
            if (criteria is null) throw new ArgumentNullException(nameof(criteria));
            var hostUrls = new MultiStringValue(Environment.GetEnvironmentVariable("ASPNETCORE_URLS"), ";");
            return hostUrls.Select(item => new Uri(item)).All(criteria);
        }
    }
}