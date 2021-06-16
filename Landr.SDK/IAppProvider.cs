using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Landr.SDK
{
    public interface IAppProvider
    {
        //getting apps
        Task<IReadOnlyCollection<IApp>> GetAppsAsync();
        Task<IReadOnlyCollection<TAppType>> GetAppsOfTypeAsync<TAppType>() where TAppType : IApp;

        //status
        public bool IsLoading { get; }

        // load the apps
        Task LoadAsync(params object[] environment);
    }
}