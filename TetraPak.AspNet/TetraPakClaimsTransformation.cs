using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.Debugging;
using TetraPak.AspNet.Identity;
using TetraPak.Logging;

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
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IClientCredentialsProvider _clientCredentialsProvider;

        protected ILogger Logger => AuthConfig.Logger;

        protected AmbientData AmbientData { get; }

        protected TetraPakAuthConfig AuthConfig { get; }

        protected HttpContext HttpContext => _httpContextAccessor.HttpContext;

        internal static OAuthTokenResponse TokenResponse
        {
            get => s_tokenResponse.Value;
            set => s_tokenResponse.Value = value;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            Logger.Debug(AuthConfig);
            using (Logger?.BeginScope("ClaimsPrincipal transformation"))
            {
                var _ = new CancellationToken();
                switch (AuthConfig.IdentitySource)
                {
                    case TetraPakIdentitySource.IdToken:
                        Logger?.Debug("Source = Id Token");
                        var idTokenOutcome = await OnGetIdTokenAsync(_);
                        if (idTokenOutcome)
                            return mapFromIdToken(idTokenOutcome.Value);

                        AuthConfig.Logger.Warning("Could not populate identity from id token. No id token was available");
                        break;
            
                    case TetraPakIdentitySource.Api:
                        var accessTokenOutcome = await OnGetAccessTokenAsync(_);
                        if (accessTokenOutcome)
                            return await mapFromApiAsync(accessTokenOutcome.Value);
                        
                        AuthConfig.Logger.Warning("Could not populate identity from API. No access token was available");
                        break;
            
                    default:
                        throw new NotSupportedException(
                            $"Cannot transform claims principal from unsupported source: '{AuthConfig.IdentitySource}'");
                }
            }
        
            return principal;

            ClaimsPrincipal mapFromIdToken(string idToken)
            {
                var clone = principal.Clone();
                var identity = (ClaimsIdentity) clone.Identity;
                if (identity is null)
                    return clone;
                
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
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
                
                identity.BootstrapContext = idToken;
                // identity.AddClaims(jwt.Claims); obsolete
                identity.AddClaims(mappedClaims);
                identity.AddClaim(new Claim(identity.NameClaimType, jwt.Subject));
                return clone;
            }
            
            async Task<ClaimsPrincipal> mapFromApiAsync(string accessToken)
            {
                Logger.Debug("Fetches identity from Tetra Pak User Information Service");
                var userInfoOutcome = await _userInformation.GetUserInformationAsync(accessToken);
                if (!userInfoOutcome)
                {
                    Logger.Error(
                        userInfoOutcome.Exception, 
                        $"Could not obtain identity claims from Tetra Pak's User Information services: {userInfoOutcome.Exception.Message}");
                    return principal;
                }

                var clone = principal.Clone();
                var identity = (ClaimsIdentity) clone.Identity;
                if (identity is null)
                    return clone;

                identity.BootstrapContext = "(api)";
                var claims = userInfoOutcome.Value.ToDictionary().MapTo(pair =>
                {
                    var (key, value) = pair;
                    var claimValue = value ?? string.Empty;
                    return !s_claimsMap.TryGetValue(key, out var toKey) 
                        ? new Claim(key, claimValue) 
                        : new Claim(toKey, claimValue);
                });
                identity.AddClaims(claims);
                return clone;
            }
        }

        protected virtual async Task<Outcome<ActorToken>> OnGetAccessTokenAsync(CancellationToken cancellationToken) 
            => await AmbientData.GetAccessTokenAsync(AuthConfig);

        protected virtual async Task<Outcome<ActorToken>> OnGetIdTokenAsync(CancellationToken cancellationToken)
            => await AmbientData.GetIdTokenAsync(AuthConfig);
        
        protected virtual async Task<Credentials> OnGetClientCredentials()
        {
            if (_clientCredentialsProvider is { })
                return await _clientCredentialsProvider.GetClientCredentialsAsync();

            if (AuthConfig.ClientId is null)
                throw new InvalidOperationException("Failed obtaining client id from configuration");
            
            return new Credentials(AuthConfig.ClientId, AuthConfig.ClientSecret);
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


        public TetraPakClaimsTransformation(
            AmbientData ambientData, 
            TetraPakAuthConfig authConfig, 
            TetraPakUserInformation userInformation,
            IHttpContextAccessor httpContextAccessor,
            IClientCredentialsProvider clientCredentialsProvider = null)
        {
            AmbientData = ambientData;
            AuthConfig = authConfig;
            _userInformation = userInformation;
            _httpContextAccessor = httpContextAccessor;
            _clientCredentialsProvider = clientCredentialsProvider;
        }
    }

    public static class TetraPakWebClientClaimsTransformationHelper
    {
        /// <summary>
        ///   Sets up DI correctly for claims transformation.
        /// </summary>
        public static void AddTetraPakWebClientClaimsTransformation(this IServiceCollection c)
        {
            c.AddHttpContextAccessor();
            c.TryAddTransient<AmbientData>();
            c.TryAddSingleton<TetraPakAuthConfig>();
            c.AddTransient<IClaimsTransformation, TetraPakClaimsTransformation>();
        }

        /// <summary>
        ///   Sets up DI for access to Tetra Pak's User Information services.
        /// </summary>
        public static void AddTetraPakUserInformation(this IServiceCollection c)
        {
            c.TryAddSingleton<TetraPakUserInformation>();
        }
    }
}