using System.Threading.Tasks;
using TetraPak;
using TetraPak.AspNet;

#nullable enable

namespace WebAPI
{
    public class MyAuthConfigDelegate : TetraPakAuthConfigDelegate
    {
        protected override Task<Outcome<Credentials>> OnGetClientSecretsAsync(AuthContext authContext)
        {
            
            if (!TryGetConfiguredValue(nameof(TetraPakAuthConfig.ClientId), authContext, out var clientId, true))
            {
                clientId = "noI5fBHGFdy5HQIkzwxa6XI7Smg2Iyco";
            }
            if (!TryGetConfiguredValue(nameof(TetraPakAuthConfig.ClientSecret), authContext, out var clientSecret, true))
            {
                clientSecret = "H6WDbPSeIe2gigYF";
            }
            
            return Task.FromResult(Outcome<Credentials>.Success(
                new Credentials(clientId, clientSecret)));
        }
    }
}