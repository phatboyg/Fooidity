namespace Fooidity
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class FooidityException :
        Exception
    {
        public FooidityException()
        {
        }

        public FooidityException(string message)
            : base(message)
        {
        }

        public FooidityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected FooidityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}