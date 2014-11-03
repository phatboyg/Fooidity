namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class KeyOrganizationApplicationIndexEntity :
        TableEntity,
        OrganizationApplication
    {
        public KeyOrganizationApplicationIndexEntity()
        {
        }

        public KeyOrganizationApplicationIndexEntity(string key, string organizationId, string organizationName, string applicationId,
            string applicationName, DateTime timestamp)
        {
            Key = key;
            OrganizationId = organizationId;
            OrganizationName = organizationName;
            ApplicationId = applicationId;
            ApplicationName = applicationName;
            Timestamp = timestamp;

            PartitionKey = Key;
            RowKey = ApplicationId;
        }

        public string Key { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
    }
}