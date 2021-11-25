using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api
{
    public interface IGrantTypeResolver
    {
        Task<Outcome<GrantType>> ResolveAutomaticGrantType(HttpContext context);
    }
}