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
using TetraPak.AspNet.Identity;
using TetraPak.Logging;

namespace TetraPak.AspNet
{
    public class TetraPakClaimsTransformation : IClaimsTransformation
    {
        static readonly AsyncLocal<OAuthTokenResponse> s_tokenResponse = new();
        static readonly IDictionary<string, string> s_claimsMap = makeClaimsMap();
        readonly TetraPakAuthConfig _authConfig;
        readonly AmbientData _ambientData;
        readonly TetraPakUserInformation _userInformation;

        ILogger Logger => _authConfig.Logger;

        
        internal static OAuthTokenResponse TokenResponse
        {
            get => s_tokenResponse.Value;
            set => s_tokenResponse.Value = value;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            using (Logger?.BeginScope("ClaimsPrincipal transformation"))
            {
                switch (_authConfig.IdentitySource)
                {
                    case TetraPakIdentitySource.IdToken:
                        Logger?.Debug("Source = Id Token");
                        var idTokenOutcome = await _ambientData.GetIdTokenAsync();
                        if (idTokenOutcome)
                            return mapFromIdToken(idTokenOutcome.Value);

                        _authConfig.Logger.Warning("Could not populate identity from id token. No id token was available");
                        break;
            
                    case TetraPakIdentitySource.Api:
                        var accessTokenOutcome = await _ambientData.GetAccessTokenAsync();
                        if (accessTokenOutcome)
                            return await mapFromApiAsync(accessTokenOutcome.Value);
                        
                        _authConfig.Logger.Warning($"Could not populate identity from API. No access token was available");
                        break;
            
                    default:
                        throw new NotSupportedException(
                            $"Cannot transform claims principal from unsupported source: '{_authConfig.IdentitySource}'");
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
                var claimsDictionary = new Dictionary<string, string>(jwt.Claims.Select(claim => new KeyValuePair<string, string>(claim.Type, claim.Value)));
                var claims = claimsDictionary.MapTo(pair =>
                {
                    var (key, value) = pair;
                    var claimValue = value ?? string.Empty;
                    return !s_claimsMap.TryGetValue(key, out var toKey)
                        ? new Claim(key, claimValue)
                        : new Claim(toKey, claimValue);
                });
                
                identity.BootstrapContext = idToken;
                identity.AddClaims(jwt.Claims);
                identity.AddClaim(new Claim(identity.NameClaimType, jwt.Subject));
                return clone;
            }
            
            async Task<ClaimsPrincipal> mapFromApiAsync(string accessToken)
            {
                Logger?.Debug("Fetches identity from Tetra Pak User Information Service");
                var userInfoOutcome = await _userInformation.GetUserInformationAsync(accessToken);
                if (!userInfoOutcome)
                {
                    _authConfig.Logger?.Error(
                        userInfoOutcome.Exception, 
                        "Could not obtain identity claims from Tetra Pak's User Information services");
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
            IHttpContextAccessor httpContextAccessor)
        {
            _authConfig = authConfig;
            _ambientData = ambientData;
            _userInformation = userInformation;
        }
    }

    public static class TetraPakClaimsTransformationHelper
    {
        /// <summary>
        ///   Sets up DI correctly for claims transformation.
        /// </summary>
        public static void AddTetraPakClaimsTransformation(this IServiceCollection c)
        {
            c.AddHttpContextAccessor();
            c.TryAddTransient<AmbientData>();
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