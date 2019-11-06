using System;

namespace Landr.SDK
{
    public sealed class AdvancedApp : BaseApp, IAdvancedApp
    {
        public string Type { get; set; }

        public override string GetContent()
        {
            throw new NotImplementedException();
        }
    }
}
