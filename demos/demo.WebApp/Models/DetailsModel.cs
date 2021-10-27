using System.Security.Principal;
using TetraPak;

namespace demo.WebApp.Models
{
    public class DetailsModel : AuthorizedModel
    {
        public ActorToken AccessToken { get; }

        public DetailsModel(IIdentity identity, ActorToken accessToken) 
        : base(identity)
        {
            AccessToken = accessToken;
        }
    }
}