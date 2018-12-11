using System;
using System.Collections.Generic;
using System.Text;

namespace Landr.SDK
{
    public sealed class AdvancedAppContract : BaseApp, IAdvancedApp
    {
        public string Type { get; set; }

        public override string GetContent()
        {
            throw new NotImplementedException();
        }
    }
}
