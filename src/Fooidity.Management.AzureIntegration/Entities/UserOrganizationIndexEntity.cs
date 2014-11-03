namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserOrganizationIndexEntity :
        TableEntity
    {
        public UserOrganizationIndexEntity()
        {
        }

        public UserOrganizationIndexEntity(DateTime timestamp, string userId, string organizationId, string organizationName, bool active)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (organizationId == null)
                throw new ArgumentNullException("organizationId");

            Active = active;
            OrganizationName = organizationName;
            OrganizationId = organizationId;
            UserId = userId;

            PartitionKey = userId;
            RowKey = organizationId;
            Timestamp = timestamp;
        }

        public string OrganizationId { get; set; }
        public string UserId { get; set; }
        public string OrganizationName { get; set; }
        public bool Active { get; set; }
    }
}