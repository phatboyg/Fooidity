namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;
    using UserStore;


    public class OrganizationEntity :
        TableEntity,
        IOrganization
    {
        public OrganizationEntity()
        {
        }

        public OrganizationEntity(string createdByUserId, string organizationName, DateTime timestamp)
        {
            OrganizationId = Guid.NewGuid().ToByteArray().ToBase32();
            CreatedByUserId = createdByUserId;
            OrganizationName = organizationName;

            PartitionKey = OrganizationId;
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;
        }

        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string CreatedByUserId { get; set; }
    }
}