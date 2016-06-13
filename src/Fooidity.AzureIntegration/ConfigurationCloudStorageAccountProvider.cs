namespace Fooidity.AzureIntegration
{
    using System;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Storage;


    public class ConfigurationCloudStorageAccountProvider :
        ICloudStorageAccountProvider
    {
        readonly string _connectionName;
        readonly Lazy<CloudStorageAccount> _value;

        public ConfigurationCloudStorageAccountProvider(string connectionName)
        {
            _connectionName = connectionName;
            _value = new Lazy<CloudStorageAccount>(GetConfiguredStorageAccount);
        }

        public CloudStorageAccount GetStorageAccount()
        {
            return _value.Value;
        }

        CloudStorageAccount GetConfiguredStorageAccount()
        {
            string connectionString = CloudConfigurationManager.GetSetting(_connectionName);

            return CloudStorageAccount.Parse(connectionString);
        }
    }
}