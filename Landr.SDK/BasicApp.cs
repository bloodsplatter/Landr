namespace Landr.SDK
{
    /// <inheritdoc />
    public class BasicApp : AppBase
    {
        public BasicApp()
        {
        }

        public string Content { get; set; }

        public override string GetContent()
        {
            return Content;
        }
    }
}