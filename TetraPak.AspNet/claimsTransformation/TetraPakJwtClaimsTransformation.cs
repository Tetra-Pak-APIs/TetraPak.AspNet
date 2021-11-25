using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Documentations;
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
    public class TetraPakJwtClaimsTransformation : TetraPakClaimsTransformation
    {
        static readonly AsyncLocal<OAuthTokenResponse> s_tokenResponse = new();
        static readonly IDictionary<string, string> s_claimsMap = makeClaimsMap();

        internal static OAuthTokenResponse? TokenResponse
        {
            get => s_tokenResponse.Value;
            set => s_tokenResponse.Value = value!;
        }

        /// <inheritdoc />
        protected override async Task<ClaimsPrincipal> OnTransformAsync(
            ClaimsPrincipal principal, 
            CancellationToken? cancellationToken)
        {
            // Logger.TraceTetraPakConfigAsync(TetraPakConfig); obsolete
            Outcome<CachedClaimsPrincipal> cachedOutcome;

            using (Logger?.BeginScope("ClaimsPrincipal transformation"))
            {
                cachedOutcome = await tryGetCachedPrincipalAsync(principal);
                if (cachedOutcome)
                {
                    Logger.Debug(
                        $"Claims Principal with id '{cachedOutcome.Value!.Id}' was already resolved (cached)", 
                        GetMessageId());
                    return cachedOutcome.Value.Principal;
                }

                await getFromSource(IdentitySource);
            }
            
            return principal;

            async Task getFromSource(TetraPakIdentitySource identitySource)
            {
                var ct = cancellationToken ?? new CancellationToken();
                switch (identitySource)
                {
                    case TetraPakIdentitySource.IdToken:
                        Logger.Debug("Source = Id Token", GetMessageId());
                        var idTokenOutcome = await OnGetIdTokenAsync(ct);
                        if (idTokenOutcome)
                        {
                            mapFromIdToken(idTokenOutcome.Value!);
                            return;
                        }

                        Logger.Warning(
                            "Could not populate identity from id token. No id token was available",
                            GetMessageId());
                        break;
            
                    case TetraPakIdentitySource.RemoteService:
                        // first get the "raw" access token to check whether it's issued for a system identity ...
                        var accessTokenOutcome = await HttpContext.GetAccessTokenAsync();
                        if (!accessTokenOutcome)
                        {
                            Logger.Warning(
                                $"Could not construct identity from remote service. {accessTokenOutcome.Exception.Message}", 
                                GetMessageId());
                            break;
                        }
                        if (accessTokenOutcome.Value!.IsSystemIdentityToken())
                        {
                            Logger.Warning(
                                $"Automatically skips constructing identity from remote service for system identity ({Docs.PleaseSee(Docs.SdkRepo.ClaimsTransformationWithSystemIdentity)}).", 
                                GetMessageId());
                            await getFromSource(TetraPakIdentitySource.IdToken);
                            break;
                        }

                        // now get the "transformed" access token (allow token exchange/whatever) to be used for authorized access to user information ... 
                        accessTokenOutcome = await OnGetAccessTokenAsync(ct);
                        if (!accessTokenOutcome)
                        {
                            Logger.Warning(
                                $"Could not construct identity from remote service. {accessTokenOutcome.Exception.Message}", 
                                GetMessageId());
                            break;
                        }

                        await mapFromRemoteServiceAsync(accessTokenOutcome.Value!);
                        break;
            
                    default:
                        throw new NotSupportedException(
                            $"Cannot transform claims principal from unsupported source: '{TetraPakConfig!.IdentitySource}'");
                }
            }
            
            void mapFromIdToken(ActorToken token)
            {
                foreach (var identity in principal.Identities)
                {
                    if (identity is not { AuthenticationType: AuthenticationTypes.Federation } claimsIdentity)
                        return; // not the "Federation" identity 

                    var jwtHandler = new JwtSecurityTokenHandler(); 
                    if (!jwtHandler.CanReadToken(token.Identity))
                        return; // not a JWT token; skip transformation
                        
                    var jwt = jwtHandler.ReadJwtToken(token.Identity);
                    var mappedClaims = new List<Claim>();
                    foreach (var claim in jwt.Claims)
                    {
                        mappedClaims.Add(s_claimsMap.TryGetValue(claim.Type, out var toType)
                            ? new Claim(toType, claim.Value)
                            : new Claim(claim.Type, claim.Value));
                    }
                    
                    claimsIdentity.BootstrapContext = token;
                    claimsIdentity.AddClaims(mappedClaims);
                    claimsIdentity.AddClaim(new Claim(claimsIdentity.NameClaimType, jwt.Subject));
                }
            }
            
            async Task mapFromRemoteServiceAsync(string accessToken)
            {
                Logger.Trace("Fetches identity from Tetra Pak User Information Service");
                var userInfoOutcome = await UserInformation!.GetUserInformationAsync(accessToken);
                if (!userInfoOutcome)
                {
                    Logger.Error(
                        userInfoOutcome.Exception, 
                        $"Could not obtain identity claims from Tetra Pak's User Information services: {userInfoOutcome.Exception.Message}",
                        GetMessageId());
                    return ;
                }

                if (principal.Identity is not ClaimsIdentity identity)
                    return;

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
                await cachePrincipalAsync(cachedOutcome.Value, principal);
            }
        }

        async Task cachePrincipalAsync(CachedClaimsPrincipal? cachedClaimsPrincipal, ClaimsPrincipal claimsPrincipal)
        {
            var cachedId = cachedClaimsPrincipal?.Id; 
            if (Cache is null || cachedId is null) return;

            await Cache.AddAsync(CacheRepositories.ClaimsPrincipals, cachedId, claimsPrincipal);
        }

        async Task<Outcome<CachedClaimsPrincipal>> tryGetCachedPrincipalAsync(ClaimsPrincipal principal)
        {
            if (!principal.TryResolveClaim(out var id, "sub"))
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
        ///   Can be invoked to acquire an access token from the <see cref="TetraPakClaimsTransformation.HttpContext"/>.
        /// </summary>
        /// <param name="cancellationToken">
        ///   A <see cref="CancellationToken"/> object used to allow operation cancellation.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="ActorToken"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken) 
            => await TetraPakConfig!.AmbientData.GetAccessTokenAsync();

        static IDictionary<string,string> makeClaimsMap()
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var dictionary = jwtTokenHandler.OutboundClaimTypeMap.ToInverted<string,string>();
            if (!dictionary.ContainsKey("sub"))
            {
                dictionary.Add("sub", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            }

            return dictionary;
        }
    }
}