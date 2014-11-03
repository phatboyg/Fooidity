namespace Fooidity.Management.AzureIntegration.UserStore
{
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserLoginProviderKeyIndexEntity :
        TableEntity
    {
        public UserLoginProviderKeyIndexEntity()
        {
        }

        public UserLoginProviderKeyIndexEntity(string userId, string providerKey, string loginProvider)
        {
            PartitionKey = string.Format("{0}_{1}", loginProvider.ToSha256(), providerKey.ToSha256());
            RowKey = "";

            UserId = userId;
        }

        public string UserId { get; set; }
    }
}