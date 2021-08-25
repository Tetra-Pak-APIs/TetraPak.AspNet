using System.Threading.Tasks;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Classes implementing this contract can be passed as a delegate to customize several aspects
    ///   of Tetra Pak related configuration. 
    /// </summary>
    /// <seealso cref="TetraPakAuthConfig"/>
    public interface ITetraPakAuthConfigDelegate : IClientConfigProvider
    {
        /// <summary>
        ///   Called to resolve the configured (or null, when un-configured) runtime environment.
        /// </summary>
        /// <param name="configuredValue">The <see cref="string"/> representation of the configured value.</param>
        /// <returns>
        ///   A resolved <see cref="RuntimeEnvironment"/> value.
        /// </returns>
        RuntimeEnvironment ResolveConfiguredEnvironment(string configuredValue);
    }
}