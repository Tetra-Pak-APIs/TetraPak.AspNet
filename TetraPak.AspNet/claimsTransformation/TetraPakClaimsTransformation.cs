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
        readonly IClientCredentialsProvider _clientCredentialsProvider;

        /// <summary>
        ///   Gets a logger provider.
        /// </summary>
        protected ILogger Logger => AuthConfig.Logger;

        /// <summary>
        ///   Gets an ambient data provider.
        /// </summary>
        protected AmbientData AmbientData => _userInformation.AmbientData;

        /// <summary>
        ///   Gets the Tetra Pak configuration object. 
        /// </summary>
        protected TetraPakAuthConfig AuthConfig => AmbientData.AuthConfig;

        /// <summary>
        ///   Gets the current <see cref="HttpContext"/> instance.
        /// </summary>
        protected HttpContext HttpContext => AmbientData.HttpContext;

        internal static OAuthTokenResponse TokenResponse
        {
            get => s_tokenResponse.Value;
            set => s_tokenResponse.Value = value;
        }

        /// <inheritdoc />
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            Logger.TraceAsync(AuthConfig);
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
            
                    case TetraPakIdentitySource.RemoteService:
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

            ClaimsPrincipal mapFromIdToken(ActorToken token)
            {
                var clone = principal.Clone();
                var identity = (ClaimsIdentity) clone.Identity;
                if (identity is null)
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
            => await AmbientData.GetAccessTokenAsync();

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
            => await AmbientData.GetIdTokenAsync();
        
        /// <summary>
        ///   Call this method to obtain client credentials.
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="Credentials"/> object or, on failure, an <see cref="Exception"/>.
        /// </returns>
        protected virtual async Task<Outcome<Credentials>> OnGetClientCredentials()
        {
            if (_clientCredentialsProvider is { })
                return await _clientCredentialsProvider.GetClientCredentialsAsync();

            return AuthConfig.ClientSecret is { } 
                ? Outcome<Credentials>.Success(new Credentials(AuthConfig.ClientId, AuthConfig.ClientSecret)) 
                : Outcome<Credentials>.Fail(new InvalidOperationException("Failed obtaining client id from configuration"));
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
        /// <param name="userInformation">
        ///   Used internally to obtain user information.
        /// </param>
        /// <param name="clientCredentialsProvider">
        ///   Used internally to obtain client credentials.
        /// </param>
        public TetraPakClaimsTransformation(
            TetraPakUserInformation userInformation,
            IClientCredentialsProvider clientCredentialsProvider = null)
        {
            _userInformation = userInformation;
            _clientCredentialsProvider = clientCredentialsProvider;
        }
    }
}