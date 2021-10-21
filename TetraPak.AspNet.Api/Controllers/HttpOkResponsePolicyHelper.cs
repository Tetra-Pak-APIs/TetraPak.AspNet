using Microsoft.Extensions.DependencyInjection;

namespace TetraPak.AspNet.Api.Controllers
{
    /// <summary>
    ///   Adds a convenient extension method for registering a custom <see cref="IHttpOkResponsePolicy"/>.
    /// </summary>
    public static class HttpOkResponsePolicyHelper
    {
        static readonly IHttpOkResponsePolicy s_default = new TetraPakHttpOkResponsePolicy();
        static IHttpOkResponsePolicy s_resolver;

        /// <summary>
        ///   Adds a custom <see cref="IHttpOkResponsePolicy"/>, to be used when automatically resolving a
        ///   successful response HTTP status code.
        ///   Pass <c>null</c> to restore the default resolution policy. 
        /// </summary>
        /// <param name="collection">
        ///   The DI service collection.
        /// </param>
        /// <param name="resolver">
        ///   The custom HTTP status code resolver.
        ///   Pass <c>null</c> to restore the default resolution policy.
        /// </param>
        /// <seealso cref="HttpOkStatusCode.Auto"/>
        public static void AddHttpOkResponsePolicy(this IServiceCollection collection, IHttpOkResponsePolicy resolver)
        {
            s_resolver = resolver;
        }

        internal static IHttpOkResponsePolicy GetHttpOkResponsePolicy() => s_resolver ?? s_default;
    }
}