namespace Fooidity.AzureIntegration
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caching;
    using Entities;
    using Microsoft.WindowsAzure.Storage.Table;


    public class CloudContextFeatureStateCacheProvider<TContext> :
        IContextFeatureStateCacheProvider<TContext>
    {
        readonly ICloudTableProvider _tableProvider;

        public CloudContextFeatureStateCacheProvider(ICloudTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public async Task<IEnumerable<Tuple<string, ICachedCodeFeatureState>>> Load()
        {
            CloudTable table = _tableProvider.GetTable("contextFeatureState");

            TableQuery<ContextFeatureStateEntity> query = new TableQuery<ContextFeatureStateEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Current"));

            return await table.ExecuteQueryAsync(query,
                entity => Tuple.Create(entity.ContextKey,
                    (ICachedCodeFeatureState)new CachedCodeFeatureState(new CodeFeatureId(entity.CodeFeatureId), entity.Enabled)));
        }
    }
}