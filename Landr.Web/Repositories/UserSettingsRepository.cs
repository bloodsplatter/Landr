using Landr.Data;
using Landr.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Landr.Web.Repositories
{
    public class UserSettingsRepository
    {
        private readonly LandrContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserSettingsRepository(LandrContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets the SettingsViewModel for the specified user
        /// </summary>
        /// <param name="email">the user's email</param>
        /// <returns>A SettingsViewModel object</returns>
        public async Task<SettingsViewModel> Get(string email)
        {
            var viewModel = new SettingsViewModel();

            var user = await GetIdentityUserBy(email: email);

            viewModel.Email = user.NormalizedEmail;
            viewModel.EmailConfirmed = user.EmailConfirmed;
            viewModel.TwoFactorEnabled = user.TwoFactorEnabled;

            return viewModel;
        }

        private async Task<IdentityUser> GetIdentityUserBy(string email)
        {
            return await _userManager.FindByEmailAsync(email.ToLower());
        }
    }
}
