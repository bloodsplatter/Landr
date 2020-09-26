using Landr.SDK;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Landr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppProvider appProvider;

        public HomeController(IAppProvider appProvider)
        {
            this.appProvider = appProvider;
        }

        public IActionResult Index()
        {
            return View(appProvider.GetApps());
        }
    }
}