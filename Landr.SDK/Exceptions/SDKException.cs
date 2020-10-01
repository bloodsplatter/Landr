using System;

namespace Landr.SDK.Exceptions
{

    [Serializable]
    public class SDKException : Exception
    {
        public SDKException() { }
        public SDKException(string message) : base(message) { }
        public SDKException(string message, Exception inner) : base(message, inner) { }
        protected SDKException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
