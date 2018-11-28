using System;
using System.Collections.Generic;
using System.Text;

namespace Landr.SDK
{
    public abstract class AdvancedAppBase : AppBase, IAdvancedApp
    {
        public string Type => GetType().FullName;
    }
}
