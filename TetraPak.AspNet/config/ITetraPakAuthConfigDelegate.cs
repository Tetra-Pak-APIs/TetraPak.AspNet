using Microsoft.Extensions.DependencyInjection;
using TetraPak.AspNet.Auth;
using TetraPak.SecretsManagement;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Classes implementing this contract can be passed as a delegate to customize several aspects
    ///   of Tetra Pak related configuration. 
    /// </summary>
    /// <seealso cref="TetraPakAuthConfig"/>
    public interface ITetraPakAuthConfigDelegate : IClientConfigDelegate 
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

    public static class TetraPakAuthConfigHelper
    {
        static readonly object s_syncRoot = new object();
        static bool s_isTetraPakAuthConfigDelegateConfigured;
        
        public static IServiceCollection AddTetraPakAuthConfigDelegate<TDelegate>(this IServiceCollection self) 
        where TDelegate : class, ITetraPakAuthConfigDelegate 
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPakAuthConfigDelegateConfigured)
                    return self;

                self.AddSingleton<ITetraPakAuthConfigDelegate, TDelegate>();
                s_isTetraPakAuthConfigDelegateConfigured = true;
                return self;
            }
        }

        public static IServiceCollection AddTetraPakAuthConfigServices<TDelegate,TSecretsProvider>(this IServiceCollection self) 
            where TDelegate : class, ITetraPakAuthConfigDelegate 
            where TSecretsProvider : class, ITetraPakSecretsProvider
        {
            lock (s_syncRoot)
            {
                if (s_isTetraPakAuthConfigDelegateConfigured)
                    return self;

                self.AddTetraPakAuthConfigDelegate<TDelegate>();
                self.AddSecretsProvider<TSecretsProvider>();
                s_isTetraPakAuthConfigDelegateConfigured = true;
                return self;
            }
        }

    }
}