using System.Security.Claims;
using System.Security.Principal;
using TetraPak;
using TetraPak.AspNet;

namespace demo.WebApp.Models
{
    public class MainModel
    {
        readonly IIdentity _identity;

        ClaimsIdentity ClaimsIdentity => _identity as ClaimsIdentity;
        
        public string UserName => _identity.Name;

        public string FirstName => ClaimsIdentity?.FirstName();

        public string LastName => ClaimsIdentity?.LastName();

        public ActorToken AccessToken { get; }

        public MainModel(IIdentity identity, ActorToken accessToken)
        {
            _identity = identity;
            AccessToken = accessToken;
        }
    }
}