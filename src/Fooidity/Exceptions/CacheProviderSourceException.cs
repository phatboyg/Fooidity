namespace Fooidity
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class CacheProviderSourceException :
        FooidityException
    {
        public CacheProviderSourceException()
        {
        }

        public CacheProviderSourceException(string message)
            : base(message)
        {
        }

        public CacheProviderSourceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CacheProviderSourceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}