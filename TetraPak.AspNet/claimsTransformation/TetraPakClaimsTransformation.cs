using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Identity;
using TetraPak.Caching;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   A basic (abstract) implementation of the <see cref="ITetraPakClaimsTransformation"/> interface.
    /// </summary>
    public abstract class TetraPakClaimsTransformation : ITetraPakClaimsTransformation
    {
        /// <summary>
        ///   Gets or sets the global (static) default service scope to be used for all
        ///   <see cref="ITetraPakClaimsTransformation"/> delegates as they are being registered
        ///   with the dependency injection service locator.
        /// </summary>
        public static ServiceScope DefaultServiceScope { get; set; } = ServiceScope.Scoped;

        /// <summary>
        ///   Gets a Tetra Pak User Information service. 
        /// </summary>
        protected TetraPakUserInformation? UserInformation { get; private set; }
        
        /// <summary>
        ///   Gets a Tetra Client Credentials flow service.  
        /// </summary>
        protected IClientCredentialsProvider? ClientCredentials { get; private set; }


        /// <summary>
        ///   Gets the current HTTP context.
        /// </summary>
        protected HttpContext? Context { get; private set; }

        /// <summary>
        ///   Gets a logger provider.
        /// </summary>
        protected ILogger? Logger => TetraPakConfig?.Logger;

        /// <summary>
        ///   Gets the Tetra Pak configuration object. 
        /// </summary>
        protected TetraPakAuthConfig? TetraPakConfig { get; private set; }

        /// <summary>
        ///   Gets the configured identity source (see: <see cref="TetraPakIdentitySource"/>).
        /// </summary>
        protected TetraPakIdentitySource IdentitySource { get; set; }

        /// <summary>
        ///   Gets the supported cache service (if any). 
        /// </summary>
        protected ITimeLimitedRepositories? Cache => TetraPakConfig?.Cache;
        
        /// <inheritdoc />
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var clone = principal.Clone();
            return OnTransformAsync(clone);
        }
        
                /// <summary>
        ///   Invoked from <see cref="OnTransformAsync"/> to acquire an identity token.
        /// </summary>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/> object used to allow operation cancellation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual async Task<Outcome<ActorToken>> OnGetIdTokenAsync(CancellationToken cancellationToken)
            => await TetraPakConfig!.AmbientData.GetIdTokenAsync();
        
        /// <summary>
        ///   Obtains and returns the client credentials, either from the Tetra Pak integration configuration
        ///   (<see cref="TetraPakAuthConfig"/> or from an injected delegate (<see cref="IClientCredentialsProvider"/>).
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="Credentials"/> object or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected async Task<Outcome<Credentials>> GetClientCredentials()
        {
            if (ClientCredentials is { })
                return await ClientCredentials.GetClientCredentialsAsync();

            if (string.IsNullOrWhiteSpace(TetraPakConfig!.ClientId))
                return Outcome<Credentials>.Fail(
                    new ConfigurationException("Could not obtain client id from configuration"));

            return string.IsNullOrWhiteSpace(TetraPakConfig.ClientSecret)
                ? Outcome<Credentials>.Fail(
                    new ConfigurationException("Could not obtain client secret from configuration"))
                : Outcome<Credentials>.Success(
                    new Credentials(TetraPakConfig.ClientId, TetraPakConfig.ClientSecret));
        }
        
        /// <summary>
        ///   (Must be overridden)<br/>
        ///   Invoked, internally, to decorate the context <see cref="ClaimsPrincipal"/>.
        ///   Please note that the <paramref name="principal"/> is a cloned instance of the
        ///   <see cref="ClaimsPrincipal"/> attached to <see cref="Context"/>
        ///   
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        protected abstract Task<ClaimsPrincipal> OnTransformAsync(ClaimsPrincipal principal);
        
        internal virtual void OnInitialize(IServiceProvider provider)
        {
            Context = provider.GetService<IHttpContextAccessor>()?.HttpContext; 
            TetraPakConfig = provider.GetRequiredService<TetraPakAuthConfig>();
            IdentitySource = TetraPakConfig.IdentitySource; 
            UserInformation = provider.GetRequiredService<TetraPakUserInformation>();
            ClientCredentials = provider.GetService<IClientCredentialsProvider>();
        }

    }
}