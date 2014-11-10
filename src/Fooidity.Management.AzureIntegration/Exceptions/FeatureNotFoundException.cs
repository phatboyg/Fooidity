namespace Fooidity.Management.AzureIntegration.Exceptions
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class FeatureNotFoundException :
        Exception
    {
        public FeatureNotFoundException(string userId, string applicationId, string codeFeatureId)
            : this(string.Format("The code feature {2} in application {0} was not found for user {1}", applicationId, userId, codeFeatureId)
                )
        {
        }

        public FeatureNotFoundException()
        {
        }

        public FeatureNotFoundException(string message)
            : base(message)
        {
        }

        public FeatureNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected FeatureNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}