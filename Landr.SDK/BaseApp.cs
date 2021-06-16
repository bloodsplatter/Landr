using System;

namespace Landr.SDK
{
    /// <inheritdoc />
    public class BaseApp : IApp
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public virtual string GetContent()
        {
            throw new NotImplementedException("Please implement this method in your own class");
        }

        /// <summary>
        /// Returns the string representation of the current object
        /// </summary>
        /// <returns>a string representation of the current object</returns>
        public override string ToString()
        {
            return GetContent();
        }

        public BaseApp()
        {
        }
    }
}
