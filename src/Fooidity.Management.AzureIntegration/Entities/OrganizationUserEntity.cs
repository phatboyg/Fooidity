namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;


    public class OrganizationUserEntity :
        TableEntity
    {
        const string SeparatorString = "'\u3000";

        public OrganizationUserEntity()
        {
        }

        public OrganizationUserEntity(DateTime timestamp, string organizationId, string userId, bool active)
        {
            if (organizationId == null)
                throw new ArgumentNullException("organizationId");
            if (userId == null)
                throw new ArgumentNullException("userId");

            Active = active;
            OrganizationId = organizationId;
            UserId = userId;

            PartitionKey = FormatPartitionKey(organizationId, userId);
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;
        }

        public string OrganizationId { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }

        public static string FormatPartitionKey(string organizationId, string userId)
        {
            return string.Join(SeparatorString, organizationId, userId);
            ;
        }
    }
}