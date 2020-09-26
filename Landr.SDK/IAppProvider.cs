using System.Collections.Generic;

namespace Landr.SDK
{
    public interface IAppProvider
    {
        //getting apps
        IReadOnlyList<IApp> GetApps();
        IReadOnlyList<BasicApp> GetBasicApps();

        //status
        public bool IsLoading { get; }

        // load the apps
        void Load(params object[] environment);
    }
}