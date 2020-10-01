using Landr.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landr.Web.BuiltInApps
{
    public sealed class BuiltInAppProvider : IAppProvider
    {
        public bool IsLoading { get; private set; }

        public BuiltInAppProvider()
        {
            //TODO: Expand constructor to have access to the builtin apps
        }

        public IReadOnlyList<IApp> GetApps()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TAppType> GetAppsOfType<TAppType>() where TAppType : IApp
        {
            return GetApps().Where(a => a is TAppType).Select(a => (TAppType)a).ToArray();
        }

        public void Load(params object[] environment)
        {
            throw new NotImplementedException();
        }
    }
}
