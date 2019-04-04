using Microsoft.AspNetCore.Mvc;

namespace Landr.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}