using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Landr.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Landr.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserSettingsRepository _repository;

        public SettingsController(UserSettingsRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUserEmail = User.FindFirst(c => c.Type == ClaimTypes.Email).Value;

            var viewModel = await _repository.Get(currentUserEmail);

            return View(viewModel);
        }
    }
}
