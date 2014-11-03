namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class OrganizationApplicationIndexEntity :
        TableEntity,
        OrganizationApplication
    {
        public OrganizationApplicationIndexEntity()
        {
        }

        public OrganizationApplicationIndexEntity(string organizationId, string organizationName, string applicationId, string applicationName, DateTime timestamp)
        {
            OrganizationId = organizationId;
            OrganizationName = organizationName;
            ApplicationId = applicationId;
            ApplicationName = applicationName;
            Timestamp = timestamp;

            PartitionKey = OrganizationId;
            RowKey = ApplicationId;
        }

        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
    }
}