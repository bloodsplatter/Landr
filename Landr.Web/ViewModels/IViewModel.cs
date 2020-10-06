
namespace Landr.Web.ViewModels
{
    /// <summary>
    /// Interface that marks common methods and properties for all viewmodels
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Rather than using null values, can check if a viewmodel is empty
        /// </summary>
        public bool IsEmpty { get; }
    }
}
