using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landr.Web.ViewModels
{
    public sealed class SettingsViewModel : IViewModel
    {
        public const string EMPTY_EMAIL = @"empty@example.com";

        /// <summary>
        /// The normalized email address of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A boolean that shows if the email address was confirmed
        /// </summary>
        public bool EmailConfirmed { get; set; } = false;

        /// <summary>
        /// A boolean that shows if two factor authentication is enabled
        /// </summary>
        public bool TwoFactorEnabled { get; set; } = false;

        public bool IsEmpty
        {
            get
            {
                return Email.Equals(EMPTY_EMAIL, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public SettingsViewModel()
        {
            Email = EMPTY_EMAIL;
        }
    }
}
