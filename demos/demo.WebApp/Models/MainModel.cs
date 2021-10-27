using System.Security.Principal;

namespace demo.WebApp.Models
{
    public class MainModel : AuthorizedModel
    {
        public MainModel(IIdentity identity) 
        : base(identity)
        {
        }
    }
}