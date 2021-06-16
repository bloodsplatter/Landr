using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landr.SDK.Extensions
{
    public static class AppProviderExtensions
    {
        /// <summary>
        /// Loops over all supplied providers and gets apps from the ready providers.
        /// </summary>
        /// <param name="appProviders">A collection of <see cref="IAppProvider"/>s</param>
        /// <returns>A collection of <see cref="IApp"/>s</returns>
        public static async Task<IReadOnlyCollection<IApp>> GetAppsAsync(this IEnumerable<IAppProvider> appProviders)
        {
            var loadedProviders = appProviders.Where(ap => ap.IsLoading == false).ToArray();
            var appList = new List<IApp>();

            foreach (var provider in loadedProviders)
            {
                appList.AddRange(await provider.GetAppsAsync());
            }

            return appList;
        }
    }
}