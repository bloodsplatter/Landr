using System.Collections.Generic;
using Landr.SDK;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Landr.SDK.Extensions;

namespace Landr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppProvider[] _appProviders;

        public HomeController(IEnumerable<IAppProvider> appProviders)
        {
            _appProviders = appProviders.ToArray();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _appProviders.GetAppsAsync());
        }

    }
}