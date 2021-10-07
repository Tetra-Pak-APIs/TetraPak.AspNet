using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Classes implementing this contract can be passed as a delegate to customize several aspects
    ///   of Tetra Pak related configuration. 
    /// </summary>
    /// <seealso cref="TetraPakConfig"/>
    public interface ITetraPakConfigDelegate : IClientConfigDelegate 
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

    // public static class TetraPakAuthConfigHelper obsolete
    // {
    //     static readonly object s_syncRoot = new object();
    //     static bool s_isTetraPakAuthConfigDelegateConfigured;
    //     
    //     public static IServiceCollection AddTetraPakConfigDelegate<TDelegate>(this IServiceCollection self) 
    //     where TDelegate : class, ITetraPakConfigDelegate 
    //     {
    //         lock (s_syncRoot)
    //         {
    //             if (s_isTetraPakAuthConfigDelegateConfigured)
    //                 return self;
    //
    //             self.AddSingleton<ITetraPakConfigDelegate, TDelegate>();
    //             s_isTetraPakAuthConfigDelegateConfigured = true;
    //             return self;
    //         }
    //     }
    //
    //     public static IServiceCollection AddTetraPakAuthConfigServices<TDelegate,TSecretsProvider>(this IServiceCollection self) 
    //         where TDelegate : class, ITetraPakConfigDelegate 
    //         where TSecretsProvider : class, ITetraPakSecretsProvider
    //     {
    //         lock (s_syncRoot)
    //         {
    //             if (s_isTetraPakAuthConfigDelegateConfigured)
    //                 return self;
    //
    //             self.AddTetraPakConfigDelegate<TDelegate>();
    //             self.AddSecretsProvider<TSecretsProvider>();
    //             s_isTetraPakAuthConfigDelegateConfigured = true;
    //             return self;
    //         }
    //     }
    //
    // }
}