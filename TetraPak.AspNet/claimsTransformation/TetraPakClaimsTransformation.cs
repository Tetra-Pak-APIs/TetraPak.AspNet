using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Debugging;
using TetraPak.AspNet.Identity;
using TetraPak.Caching;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Add this class to the DI configuration to automatically provide a Tetra Pak identity to any request.
    ///   The class constructor also needs <see cref="AmbientData"/> and 
    ///   Please note that this is automatically done by calling <see cref="Auth.TetraPakAuth.AddTetraPakWebClientAuthentication"/>.
    /// </summary>
    /// <example>
    ///   <code>
    ///   public void ConfigureServices(IServiceCollection services)
    ///   {
    ///       :
    ///       services.AddTetraPakWebClientClaimsTransformation();
    ///       :
    ///   }
    ///   </code>
    /// </example>
    public class TetraPakClaimsTransformation : IClaimsTransformation
    {
        static readonly AsyncLocal<OAuthTokenResponse> s_tokenResponse = new();
        static readonly IDictionary<string, string> s_claimsMap = makeClaimsMap();
        readonly TetraPakUserInformation _userInformation;
        readonly IClientCredentialsProvider? _clientCredentialsProvider;

        /// <summary>
        ///   Gets a logger provider.
        /// </summary>
        protected ILogger? Logger => AuthConfig.Logger;

        /// <summary>
        ///   Gets the Tetra Pak configuration object. 
        /// </summary>
        protected TetraPakAuthConfig AuthConfig { get; }

        ITimeLimitedRepositories? Cache => AuthConfig.Cache;

        internal static OAuthTokenResponse? TokenResponse
        {
            get => s_tokenResponse.Value;
            set => s_tokenResponse.Value = value!;
        }

        /// <inheritdoc />
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            Logger.TraceAsync(AuthConfig);
            Outcome<CachedClaimsPrincipal> cachedOutcome;

            using (Logger?.BeginScope("ClaimsPrincipal transformation"))
            {
                cachedOutcome = await tryGetCachedPrincipalAsync(principal);
                if (cachedOutcome)
                {
                    Logger.Debug($"Claims Principal with id '{cachedOutcome.Value!.Id}' was already resolved (cached)");
                    return cachedOutcome.Value.Principal;
                }

                var _ = new CancellationToken();
                switch (AuthConfig.IdentitySource)
                {
                    case TetraPakIdentitySource.IdToken:
                        Logger.Debug("Source = Id Token");
                        var idTokenOutcome = await OnGetIdTokenAsync(_);
                        if (idTokenOutcome)
                            return mapFromIdToken(idTokenOutcome.Value!);

                        Logger.Warning("Could not populate identity from id token. No id token was available");
                        break;
            
                    case TetraPakIdentitySource.RemoteService:
                        var accessTokenOutcome = await OnGetAccessTokenAsync(_);
                        if (accessTokenOutcome)
                            return await mapFromApiAsync(accessTokenOutcome.Value);
                        
                        Logger.Warning("Could not populate identity from API. No access token was available");
                        break;
            
                    default:
                        throw new NotSupportedException(
                            $"Cannot transform claims principal from unsupported source: '{AuthConfig.IdentitySource}'");
                }
            }
        
            return principal;

            ClaimsPrincipal mapFromIdToken(ActorToken token)
            {
                var clone = principal.Clone();
                if (clone.Identity is not ClaimsIdentity identity)
                    return clone;
                
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token.Identity);
                var claimsDictionary = new Dictionary<string, string>(jwt.Claims.Select(
                    claim => new KeyValuePair<string, string>(claim.Type, claim.Value)));

                var mappedClaims = claimsDictionary.MapTo(pair =>
                {
                    var (key, value) = pair;
                    var claimValue = value ?? string.Empty;
                    return !s_claimsMap.TryGetValue(key, out var toKey)
                        ? new Claim(key, claimValue)
                        : new Claim(toKey, claimValue);
                });
                
                identity.BootstrapContext = token;
                identity.AddClaims(mappedClaims);
                identity.AddClaim(new Claim(identity.NameClaimType, jwt.Subject));
                return clone;
            }
            
            async Task<ClaimsPrincipal> mapFromApiAsync(string accessToken)
            {
                Logger.Trace("Fetches identity from Tetra Pak User Information Service");
                var userInfoOutcome = await _userInformation.GetUserInformationAsync(accessToken);
                if (!userInfoOutcome)
                {
                    Logger.Error(
                        userInfoOutcome.Exception, 
                        $"Could not obtain identity claims from Tetra Pak's User Information services: {userInfoOutcome.Exception.Message}");
                    return principal;
                }

                var clone = principal.Clone();
                if (clone.Identity is not ClaimsIdentity identity)
                    return clone;

                identity.BootstrapContext = "(api)";
                var claims = userInfoOutcome.Value!.ToDictionary().MapTo(pair =>
                {
                    var (key, value) = pair;
                    var claimValue = value ?? string.Empty;
                    return !s_claimsMap.TryGetValue(key, out var toKey) 
                        ? new Claim(key, claimValue) 
                        : new Claim(toKey, claimValue);
                });
                identity.AddClaims(claims);
                return await cachePrincipalAsync(cachedOutcome.Value, clone);
            }
        }

        async Task<ClaimsPrincipal> cachePrincipalAsync(CachedClaimsPrincipal? cachedClaimsPrincipal, ClaimsPrincipal claimsPrincipal)
        {
            var cachedId = cachedClaimsPrincipal?.Id; 
            if (Cache is null || cachedId is null)
                return claimsPrincipal;

            await Cache.AddAsync(CacheRepositories.ClaimsPrincipals, cachedId, claimsPrincipal);
            return claimsPrincipal;
        }

        async Task<Outcome<CachedClaimsPrincipal>> tryGetCachedPrincipalAsync(ClaimsPrincipal principal)
        {
            if (!principal.TryResolveIdClaim(out var id,  new[] {"sub"}))
                return Outcome<CachedClaimsPrincipal>.Fail();

            if (Cache is null)
                return Outcome<CachedClaimsPrincipal>.Fail(new CachedClaimsPrincipal(id, null!));

            var cachedOutcome = await Cache.GetAsync<ClaimsPrincipal>(CacheRepositories.ClaimsPrincipals, id);
            return cachedOutcome
                ? Outcome<CachedClaimsPrincipal>.Success(new CachedClaimsPrincipal(id, cachedOutcome.Value!))
                : Outcome<CachedClaimsPrincipal>.Fail(new CachedClaimsPrincipal(id, null!)); 
        }

        class CachedClaimsPrincipal
        {
            public string Id { get; set; }

            public ClaimsPrincipal Principal { get; }
            
            public CachedClaimsPrincipal(string id, ClaimsPrincipal principal)
            {
                Id = id;
                Principal = principal;
            }
        }

        /// <summary>
        ///   Invoked from <see cref="TransformAsync"/> to acquire an access token.
        /// </summary>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/> object used to allow operation cancellation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken) 
            => await AuthConfig.AmbientData.GetAccessTokenAsync();

        /// <summary>
        ///   Invoked from <see cref="TransformAsync"/> to acquire an identity token.
        /// </summary>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/> object used to allow operation cancellation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual async Task<Outcome<ActorToken>> OnGetIdTokenAsync(CancellationToken cancellationToken)
            => await AuthConfig.AmbientData.GetIdTokenAsync();
        
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
            if (_clientCredentialsProvider is { })
                return await _clientCredentialsProvider.GetClientCredentialsAsync();

            if (string.IsNullOrWhiteSpace(AuthConfig.ClientId))
                return Outcome<Credentials>.Fail(
                    new ConfigurationException("Could not obtain client id from configuration"));

            return string.IsNullOrWhiteSpace(AuthConfig.ClientSecret)
                ? Outcome<Credentials>.Fail(
                    new ConfigurationException("Could not obtain client secret from configuration"))
                : Outcome<Credentials>.Success(
                    new Credentials(AuthConfig.ClientId, AuthConfig.ClientSecret));
        }

        static IDictionary<string,string> makeClaimsMap()
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var dictionary = jwtTokenHandler.OutboundClaimTypeMap.ToInverted();
            if (!dictionary.ContainsKey("sub"))
            {
                dictionary.Add("sub", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            }

            return dictionary;
        }

        /// <summary>
        ///   Initializes the <see cref="TetraPakClaimsTransformation"/> instance.
        /// </summary>
        /// <param name="authConfig">
        ///   The Tetra Pak integration configuration.
        /// </param>
        /// <param name="userInformation">
        ///   Used internally to obtain user information.
        /// </param>
        /// <param name="clientCredentialsProvider">
        ///   (optional)<br/>
        ///   Used internally to obtain client credentials.
        /// </param>
        public TetraPakClaimsTransformation(
            TetraPakAuthConfig authConfig,
            TetraPakUserInformation userInformation,
            IClientCredentialsProvider? clientCredentialsProvider = null)
        {
            AuthConfig = authConfig ?? throw new ArgumentNullException(nameof(authConfig));
            _userInformation = userInformation;
            _clientCredentialsProvider = clientCredentialsProvider;
        }
    }
}