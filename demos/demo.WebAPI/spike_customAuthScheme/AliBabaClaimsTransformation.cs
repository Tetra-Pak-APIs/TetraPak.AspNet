using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TetraPak;
using TetraPak.AspNet;

namespace WebAPI.spike_customAuthScheme
{
    class AliBabaClaimsTransformation : TetraPakClaimsTransformation
    {
        public bool IsSecretRevealedAsClaim { get; }

        protected override async Task<ClaimsPrincipal> OnTransformAsync(
            ClaimsPrincipal principal,
            CancellationToken? cancellationToken)
        {
            if (!IsSecretRevealedAsClaim)
                return principal;
            
            // get the token and try parsing it as Basic Auth Credentials ...
            var tokenOutcome = await HttpContext.GetAccessTokenAsync(/*TetraPakConfig obsolete */);
            if (!tokenOutcome)
                return principal;

            var token = tokenOutcome.Value!;
            var basicAuthCredentials =  BasicAuthCredentials.Parse(token);
            if (basicAuthCredentials is null)
                return principal;

            // add the secret to the "AliBaba" identity ...  
            foreach (var identity in principal.Identities)
            {
                if (identity is not { AuthenticationType: "AliBaba" } claimsIdentity)
                    return principal; // not the "AliBaba" identity

                var secret = basicAuthCredentials.Secret;
                claimsIdentity.BootstrapContext = token;
                claimsIdentity.AddClaim(
                    new Claim("secret", $"The secret used was: '{secret}'"));
            }
            return principal;
        }

        public AliBabaClaimsTransformation(TetraPakConfig tetraPakConfig)
        {
            var aliBabaConfig = tetraPakConfig.Section?.GetSection("AliBaba");
            IsSecretRevealedAsClaim = aliBabaConfig.GetBool(nameof(IsSecretRevealedAsClaim), false);
        }
    }
}