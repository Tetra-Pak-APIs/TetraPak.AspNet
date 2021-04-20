using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using demo.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using TetraPak.AspNet;

namespace demo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [Authorize]
        public IActionResult Index()
        {
            return View(new UserModel(User.Identity));
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    }

    public class UserModel
    {
        readonly IIdentity _identity;
        
        ClaimsIdentity ClaimsIdentity => _identity as ClaimsIdentity;
        
        public string UserName => _identity.Name;

        public string FirstName => ClaimsIdentity?.FirstName();

        public string LastName => ClaimsIdentity?.LastName();

        public UserModel(IIdentity identity)
        {
            _identity = identity;
        }
    }
}