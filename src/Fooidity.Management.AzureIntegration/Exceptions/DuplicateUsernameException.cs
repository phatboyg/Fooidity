namespace Fooidity.Management.AzureIntegration.Exceptions
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class DuplicateUsernameException :
        Exception
    {
        public DuplicateUsernameException()
        {
        }

        public DuplicateUsernameException(string message)
            : base(message)
        {
        }

        public DuplicateUsernameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DuplicateUsernameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}