using Landr.SDK;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Landr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppProvider appProvider;

        public HomeController(IAppProvider appProvider)
        {
            this.appProvider = appProvider;
        }

        public async Task<IActionResult> Index()
        {
            return View(appProvider.GetApps().ToArray());
        }
    }
}