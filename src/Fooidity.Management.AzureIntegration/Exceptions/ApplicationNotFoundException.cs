namespace Fooidity.Management.AzureIntegration.Exceptions
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class ApplicationNotFoundException :
        Exception
    {
        public ApplicationNotFoundException(string userId, string applicationId)
            : this(string.Format("The application {0} was not found for user {1}", applicationId, userId))
        {
        }

        public ApplicationNotFoundException()
        {
        }

        public ApplicationNotFoundException(string message)
            : base(message)
        {
        }

        public ApplicationNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ApplicationNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}