using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Microsoft.Extensions.Localization;

namespace Landr.Web.Controllers
{
	public class AccountController : Controller
	{
        // reference material: https://www.blinkingcaret.com/2016/11/30/asp-net-identity-core-from-scratch/

		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IStringLocalizer<AccountController> l;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IStringLocalizer<AccountController> localizer)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			l = localizer;
		}

		[HttpPost]
		public async Task<IActionResult> Register(string email, string password, string repassword)
		{
			if (password != repassword)
				ModelState.AddModelError(string.Empty, l["Passwords don't match"]);

			var user = await _userManager.FindByEmailAsync(email);

			if (user != null)
				ModelState.AddModelError("email", l["A user has already registered with this e-mail address."]);

			if (ModelState.ErrorCount > 0)
				return View();

			var newUser = new IdentityUser { UserName = email, Email = email };
			var userCreationResult = await _userManager.CreateAsync(newUser, password);

			if (!userCreationResult.Succeeded)
			{
				ModelState.AddModelError(string.Empty, userCreationResult.Errors.Select(e => e.Description).Aggregate((allErrors, error) => $"{allErrors}, {error}"));

                return Json(ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)));
            }

			// TODO: add registration email stuff, then redirect to other page

			return RedirectToAction("VerifyEmail", new { id = (await _userManager.FindByEmailAsync(email)).Id, token = (await _userManager.GenerateEmailConfirmationTokenAsync(newUser)) });
		}

		public async Task<IActionResult> VerifyEmail(string id, string token)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
				return NotFound(id);

			var emailConfirmationResult = await _userManager.ConfirmEmailAsync(user, token);
			if (!emailConfirmationResult.Succeeded)
			{
                foreach (var error in emailConfirmationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View();
            }

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(string email, string password, bool rememberMe = true)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user == null)
				return NotFound(email);

            if (!user.EmailConfirmed)
            {
                return Unauthorized();
            }

            var passwordSignInResult =
                await _signInManager.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure: false);

            if (!passwordSignInResult.Succeeded)
                return Unauthorized();

            return RedirectToAction("Index", "Home");
        }
	}
}