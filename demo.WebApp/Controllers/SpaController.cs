using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.WebApp.Controllers
{
    public class SpaController : Controller
    {
        // GET
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}