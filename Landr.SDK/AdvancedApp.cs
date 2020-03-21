using Microsoft.AspNetCore.Http;
using System;

namespace Landr.SDK
{
    public class AdvancedApp : BaseApp, IAdvancedApp
    {
        public string Type { get; set; }

        public AdvancedApp(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {}

        public override string GetContent()
        {
            throw new NotImplementedException("Please override this method in your own App");
        }
    }
}
