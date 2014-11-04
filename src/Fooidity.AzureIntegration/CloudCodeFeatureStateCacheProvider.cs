namespace Fooidity.AzureIntegration
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caching;
    using Entities;
    using Microsoft.WindowsAzure.Storage.Table;


    public class CloudCodeFeatureStateCacheProvider :
        ICodeFeatureStateCacheProvider
    {
        readonly ICloudTableProvider _tableProvider;

        public CloudCodeFeatureStateCacheProvider(ICloudTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public async Task<bool> GetDefaultState()
        {
            return false;
        }

        public async Task<IEnumerable<ICachedCodeFeatureState>> Load()
        {
            CloudTable table = _tableProvider.GetTable("codeFeatureState");

            TableQuery<CodeFeatureStateEntity> query = new TableQuery<CodeFeatureStateEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Current"));

            return await table.ExecuteQueryAsync(query,
                entity => (ICachedCodeFeatureState)new CachedCodeFeatureState(new CodeFeatureId(entity.CodeFeatureId), entity.Enabled));
        }
    }
}