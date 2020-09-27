using System.Collections.Generic;

namespace Landr.SDK
{
    public interface IAppProvider
    {
        //getting apps
        IReadOnlyList<IApp> GetApps();
        IReadOnlyList<TAppType> GetAppsOfType<TAppType>() where TAppType : IApp;

        //status
        public bool IsLoading { get; }

        // load the apps
        void Load(params object[] environment);
    }
}