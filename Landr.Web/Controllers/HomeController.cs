using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Landr.SDK;

namespace Landr.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly IAppProvider appProvider;
        #endregion

        #region Constructor
        public HomeController(IAppProvider appProvider)
        {
            this.appProvider = appProvider;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            return View(appProvider.GetApps().ToArray());
        }

        #endregion
    }
}