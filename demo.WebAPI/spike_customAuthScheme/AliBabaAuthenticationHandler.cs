using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TetraPak;

namespace WebAPI.spike_customAuthScheme
{
    /// <summary>
    ///   This is just a silly "authentication" handler that ensures the expected "token" is
    ///   always a basic auth credentials value with secret="Open Sesame!".
    ///   The class was part of a quick spike with custom authentication schemes.
    ///   --Jonas R. 2021-10-01
    /// </summary>
    class AliBabaAuthenticationHandler : AuthenticationHandler<AliBabaAuthenticationOptions>
    {
        const string AuthHeader = "Authorization";
        const string ExpectedSecret = "Open Sesame!";
        
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(AuthHeader))
                return Task.FromResult(AuthenticateResult.Fail("No authorization header found"));

            var encoded = Request.Headers[AuthHeader].ToString();
            var bac = BasicAuthCredentials.Parse(encoded);
            if (bac is null)
                return Task.FromResult(AuthenticateResult.Fail("Invalid token"));
            
            if (bac.Secret != ExpectedSecret)
                return Task.FromResult(AuthenticateResult.Fail("Invalid token"));

            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,  bac.Identity),
                new Claim(ClaimTypes.Email, $"{bac.Identity}@thieves.org")
            };
            var claimsIdentity = new ClaimsIdentity(claims, AliBabaAuthentication.Scheme);
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        
        public AliBabaAuthenticationHandler(IOptionsMonitor<AliBabaAuthenticationOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }
    }
    
    class AliBabaAuthenticationOptions : AuthenticationSchemeOptions
    {}

    public static class AliBabaAuthentication
    {
        public const string Scheme = "AliBaba";

        public static AuthenticationBuilder AddAliBabaAuthentication(this IServiceCollection services)
        {
            return services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = Scheme;
                })
                .AddScheme<AliBabaAuthenticationOptions,
                    AliBabaAuthenticationHandler>(Scheme, null);
        }
        
        public static AuthenticationBuilder AddAliBabaAuthentication(this AuthenticationBuilder auth)
        {
            return auth
                .AddScheme<AliBabaAuthenticationOptions,
                    AliBabaAuthenticationHandler>(Scheme, null);
        }

    }
}