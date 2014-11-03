namespace Fooidity.Management.AzureIntegration.UserStore
{
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserEmailIndexEntity :
        TableEntity
    {
        public UserEmailIndexEntity()
        {
        }

        public UserEmailIndexEntity(string hashedEmail, string userId)
        {
            PartitionKey = hashedEmail;
            RowKey = "";

            UserId = userId;
        }

        public string UserId { get; set; }
    }
}