using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using demo.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using TetraPak.AspNet;

namespace demo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly IConfiguration _configuration;

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(new MainModel(User.Identity, await Request.HttpContext.GetAccessTokenAsync()));
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
        
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
    }
}