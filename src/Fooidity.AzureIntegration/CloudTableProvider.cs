namespace Fooidity.AzureIntegration
{
    using System;
    using System.Collections.Concurrent;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Table;


    public class CloudTableProvider :
        ICloudTableProvider
    {
        readonly ICloudStorageAccountProvider _storageAccountProvider;
        readonly string _tablePrefix;
        readonly ConcurrentDictionary<string, CloudTable> _tables = new ConcurrentDictionary<string, CloudTable>();

        public CloudTableProvider(ICloudStorageAccountProvider storageAccountProvider)
        {
            _storageAccountProvider = storageAccountProvider;
            _tablePrefix = "";
        }

        public CloudTableProvider(ICloudStorageAccountProvider storageAccountProvider, string tablePrefix)
        {
            _storageAccountProvider = storageAccountProvider;
            _tablePrefix = tablePrefix;
        }

        public CloudTable GetTable(string tableName)
        {
            return _tables.GetOrAdd(string.Format("{0}{1}", _tablePrefix, tableName), CreateCloudTable);
        }

        CloudTable CreateCloudTable(string tableName)
        {
            CloudStorageAccount storageAccount = _storageAccountProvider.GetStorageAccount();
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);

            table.CreateIfNotExists(new TableRequestOptions
            {
                PayloadFormat = TablePayloadFormat.Json,
                RetryPolicy = new LinearRetry(TimeSpan.FromMilliseconds(100), 5),
                ServerTimeout = TimeSpan.FromSeconds(3),
            });

            return table;
        }
    }
}