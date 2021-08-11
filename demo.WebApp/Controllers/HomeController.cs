using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demo.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using TetraPak.AspNet.Api.Controllers;

namespace demo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View(new MainModel(User.Identity));
        }

        [Authorize]
        public async Task<IActionResult> Details()
        {
            var token = await this.GetAccessTokenAsync();
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
    }
}