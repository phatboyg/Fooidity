namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;
    using UserStore;


    public class OrganizationEntity :
        TableEntity,
        Organization
    {
        public OrganizationEntity()
        {
        }

        public OrganizationEntity(string createdByUserId, string organizationName, DateTime timestamp)
        {
            Id = Guid.NewGuid().ToByteArray().ToBase32();
            CreatedByUserId = createdByUserId;
            Name = organizationName;

            PartitionKey = Id;
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string CreatedByUserId { get; set; }
    }
}