using System;

namespace Landr.SDK.Exceptions
{
    public class AppException<TAppType> : SDKException where TAppType : IApp
    {

        public AppException(string message) : 
            base($"An exception has occured in app {typeof(TAppType).Name}:\n{message}")
        {
        }

        public AppException(string message, Exception innerException) :
            base($"An exception has occured in app {typeof(TAppType).Name}:\n{message}", innerException)
        {

        }
    }
}
