using System.Security.Claims;
using System.Security.Principal;
using TetraPak.AspNet;

namespace demo.WebApp.Models
{
    public abstract class AuthorizedModel : ViewModel
    {
        readonly IIdentity _identity;
        
        ClaimsIdentity ClaimsIdentity => _identity as ClaimsIdentity;
        
        public string UserName => _identity.Name;

        public string FirstName => ClaimsIdentity?.FirstName();

        public string LastName => ClaimsIdentity?.LastName();

        public AuthorizedModel(IIdentity identity, string title = null) 
        : base(title)
        {
            _identity = identity;
        }
    }
}