namespace Landr.SDK
{
    public interface IAdvancedApp : IApp
    {
        /// <summary>
        /// Gets the fully qualified type name of the type to instantiate
        /// </summary>
        string Type { get; }
    }
}