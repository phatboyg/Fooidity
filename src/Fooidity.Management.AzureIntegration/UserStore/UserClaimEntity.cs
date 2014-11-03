namespace Fooidity.Management.AzureIntegration.UserStore
{
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserClaimEntity :
        TableEntity
    {
        public UserClaimEntity()
        {
        }

        public UserClaimEntity(string userId, string claimType, string claimValue)
        {
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;

            PartitionKey = UserId;
            RowKey = ClaimType.ToSha256();
        }

        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}