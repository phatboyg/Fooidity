namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class UserApplicationIndexEntity :
        TableEntity,
        UserOrganizationApplication
    {
        public UserApplicationIndexEntity()
        {
        }

        public UserApplicationIndexEntity(string userId, string organizationId, string organizationName, string applicationId,
            string applicationName, DateTime timestamp)
        {
            UserId = userId;
            OrganizationId = organizationId;
            OrganizationName = organizationName;
            ApplicationId = applicationId;
            ApplicationName = applicationName;
            Timestamp = timestamp;

            PartitionKey = UserId;
            RowKey = ApplicationId;
        }

        public string UserId { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
    }
}