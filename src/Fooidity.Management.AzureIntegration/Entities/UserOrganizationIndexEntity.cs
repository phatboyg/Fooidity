namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class UserOrganizationIndexEntity :
        TableEntity,
        IOrganization
    {
        public UserOrganizationIndexEntity()
        {
        }

        public UserOrganizationIndexEntity(DateTime timestamp, string userId, string organizationId, string organizationName,
            string createdByUserId, bool active)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (organizationId == null)
                throw new ArgumentNullException("organizationId");

            Active = active;
            OrganizationName = organizationName;
            CreatedByUserId = createdByUserId;
            OrganizationId = organizationId;
            UserId = userId;

            PartitionKey = userId;
            RowKey = organizationId;
            Timestamp = timestamp;
        }

        public string UserId { get; set; }
        public bool Active { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string CreatedByUserId { get; set; }
    }
}