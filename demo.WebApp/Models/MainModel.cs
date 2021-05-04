using System.Security.Claims;
using System.Security.Principal;
using TetraPak.AspNet;

namespace demo.WebApp.Controllers
{
    public class MainModel
    {
        readonly IIdentity _identity;
        
        ClaimsIdentity ClaimsIdentity => _identity as ClaimsIdentity;
        
        public string UserName => _identity.Name;

        public string FirstName => ClaimsIdentity?.FirstName();

        public string LastName => ClaimsIdentity?.LastName();

        public MainModel(IIdentity identity)
        {
            _identity = identity;
        }
    }
}