namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;
    using UserStore;


    public class ApplicationEntity :
        TableEntity,
        Application
    {
        public ApplicationEntity()
        {
        }

        public ApplicationEntity(string applicationName, DateTime timestamp)
        {
            Id = Guid.NewGuid().ToByteArray().ToBase32();
            Name = applicationName;

            PartitionKey = Id;
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}