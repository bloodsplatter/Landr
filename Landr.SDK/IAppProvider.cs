using System.Collections.Generic;

namespace Landr.SDK
{
    public interface IAppProvider
    {
        //getting apps
        IEnumerable<IApp> GetApps();
        IEnumerable<BasicApp> GetBasicApps();
    }
}