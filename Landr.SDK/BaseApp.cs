using System;

namespace Landr.SDK
{
    /// <inheritdoc />
    public abstract class BaseApp : IApp
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public abstract string GetContent();

        /// <summary>
        /// Returns the string representation of the current object
        /// </summary>
        /// <returns>a string representation of the current object</returns>
        public override string ToString()
        {
            return GetContent();
        }
    }
}
