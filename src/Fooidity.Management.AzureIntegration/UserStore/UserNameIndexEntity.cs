namespace Fooidity.Management.AzureIntegration.UserStore
{
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserNameIndexEntity :
        TableEntity
    {
        public UserNameIndexEntity()
        {
        }

        public UserNameIndexEntity(string hashedUserName, string userId)
        {
            PartitionKey = hashedUserName;
            RowKey = "";

            UserId = userId;
        }

        public string UserId { get; set; }
    }
}