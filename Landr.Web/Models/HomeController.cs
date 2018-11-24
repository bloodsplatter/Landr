using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Landr.Web.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new OkResult();
        }
    }
}