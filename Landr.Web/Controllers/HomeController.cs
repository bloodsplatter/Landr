using Landr.SDK;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Landr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppProvider _appProvider;

        public HomeController(IAppProvider appProvider)
        {
            this._appProvider = appProvider;
        }

        public IActionResult Index()
        {
            return View(_appProvider.GetApps());
        }

        
    }
}