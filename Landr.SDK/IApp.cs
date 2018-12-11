using System;

namespace Landr.SDK
{
    /// <summary>
    /// Basic interface for apps
    /// </summary>
    public interface IApp
    {
        /// <summary>
        /// A unique ID
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The name of the app
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The url for the icon
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// The url the app redirects to
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Returns the content object
        /// </summary>
        /// <returns>content of the app button</returns>
        string GetContent();
    }
}