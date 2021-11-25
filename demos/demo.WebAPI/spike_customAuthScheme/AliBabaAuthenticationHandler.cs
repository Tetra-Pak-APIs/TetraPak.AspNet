using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TetraPak;
using TetraPak.AspNet;

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
        const string ExpectedSecret = "Open Sesame!";
        
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // get token from request and try parsing it as Basic Authentication credentials ...
            var tokenOutcome = await Context.GetAccessTokenAsync();
            if (!tokenOutcome)
                return AuthenticateResult.Fail("No authorization found");

            var token = tokenOutcome.Value!;
            var credentials = BasicAuthCredentials.Parse(token);
            if (credentials is null)
                return AuthenticateResult.Fail("Invalid token");
            
            // assert the secret is the expected one ...        
            if (credentials.Secret != ExpectedSecret)
                return AuthenticateResult.Fail("Invalid token");

            // construct a claims principal and return a successful authentication result...
            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,  credentials.Identity),
                new Claim(ClaimTypes.Email, $"{credentials.Identity}@thieves.org")
            };
            var claimsIdentity = new ClaimsIdentity(claims, AliBabaAuthentication.Scheme);
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
        
        public AliBabaAuthenticationHandler(IOptionsMonitor<AliBabaAuthenticationOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }
    }

    class AliBabaAuthenticationOptions : AuthenticationSchemeOptions
    {
        // add any options here
    }

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