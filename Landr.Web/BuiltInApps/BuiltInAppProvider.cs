using Landr.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landr.Web.BuiltInApps
{
    public sealed class BuiltInAppProvider : IAppProvider
    {
        private List<BaseApp> _apps = new();
        
        public bool IsLoading { get; private set; }

        public BuiltInAppProvider()
        {
        }

        public Task<IReadOnlyCollection<IApp>> GetAppsAsync()
        {
            return Task.FromResult<IReadOnlyCollection<IApp>>(_apps.Cast<IApp>().ToArray());
        }

        public async Task<IReadOnlyCollection<TAppType>> GetAppsOfTypeAsync<TAppType>() where TAppType : IApp
        {
            return (await GetAppsAsync()).OfType<TAppType>().ToArray();
        }

        public Task LoadAsync(params object[] environment)
        {
            if (IsLoading) return Task.CompletedTask;

            IsLoading = true;

            _apps = new List<BaseApp>(1);

            IsLoading = false;
            
            return Task.CompletedTask;
        }
    }
}
