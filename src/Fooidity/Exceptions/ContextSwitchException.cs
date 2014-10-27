namespace Fooidity
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class ContextSwitchException :
        FooidityException
    {
        public ContextSwitchException()
        {
        }

        public ContextSwitchException(string message)
            : base(message)
        {
        }

        public ContextSwitchException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ContextSwitchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}