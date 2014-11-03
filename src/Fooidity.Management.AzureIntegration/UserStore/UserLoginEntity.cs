namespace Fooidity.Management.AzureIntegration.UserStore
{
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserLoginEntity :
        TableEntity
    {
        public UserLoginEntity()
        {
        }

        public UserLoginEntity(string userId, string loginProvider, string providerKey)
        {
            UserId = userId;
            LoginProvider = loginProvider;
            ProviderKey = providerKey;

            SetPartitionKeyRowKey();
        }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public string UserId { get; set; }

        public void SetPartitionKeyRowKey()
        {
            PartitionKey = UserId;
            RowKey = "";
        }
    }
}