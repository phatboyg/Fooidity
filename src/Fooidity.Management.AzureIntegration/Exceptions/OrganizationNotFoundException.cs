namespace Fooidity.Management.AzureIntegration.Exceptions
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class OrganizationNotFoundException :
        Exception
    {
        public OrganizationNotFoundException(string userId, string organizationId)
            : this(string.Format("The organization {0} was not found for user {1}", organizationId, userId))
        {
            
        }
        public OrganizationNotFoundException()
        {
        }

        public OrganizationNotFoundException(string message)
            : base(message)
        {
        }

        public OrganizationNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected OrganizationNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}