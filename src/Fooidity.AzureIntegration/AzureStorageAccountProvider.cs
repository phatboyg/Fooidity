namespace Fooidity.AzureIntegration
{
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Storage;


    public class AzureStorageAccountProvider :
        ICloudStorageAccountProvider
    {
        readonly string _connectionName;

        public AzureStorageAccountProvider(string connectionName)
        {
            _connectionName = connectionName;
        }

        public CloudStorageAccount GetStorageAccount()
        {
            string connectionString = CloudConfigurationManager.GetSetting(_connectionName);

            return CloudStorageAccount.Parse(connectionString);
        }
    }
}