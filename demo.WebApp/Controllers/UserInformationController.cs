using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TetraPak.AspNet;

namespace demo.WebApp.Controllers
{
    public class UserInformationController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity) User.Identity;
            var userInfo = new
            {
                userName = User.Identity.Name,
                firstName = identity.FirstName(),
                lastName = identity.LastName()
            }; 
            return Ok(userInfo);
        }
    }
}