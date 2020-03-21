using Microsoft.AspNetCore.Http;

namespace Landr.SDK
{
    /// <inheritdoc />
    public class BasicApp : BaseApp
    { 
        public BasicApp(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
        }

        public string Content { get; set; }

        public override string GetContent()
        {
            return Content;
        }
    }
}