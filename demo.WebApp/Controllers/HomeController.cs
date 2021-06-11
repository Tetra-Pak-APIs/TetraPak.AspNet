using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using demo.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using TetraPak.AspNet;
using TetraPak.AspNet.Auth;

namespace demo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly TetraPakAuthConfig _authConfig;

        [Authorize]
        public IActionResult Index()
        {
            
            return View(new MainModel(User.Identity));
        }

        [Authorize]
        public async Task<IActionResult> Details()
        {
            var token = await Request.HttpContext.GetAccessTokenAsync(_authConfig);
            return View(new DetailsModel(User.Identity, token));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        public HomeController(ILogger<HomeController> logger, TetraPakAuthConfig authConfig)
        {
            _logger = logger;
            _authConfig = authConfig;
        }
    }
}