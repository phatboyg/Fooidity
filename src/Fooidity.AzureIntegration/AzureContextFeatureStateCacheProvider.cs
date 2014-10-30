namespace Fooidity.AzureIntegration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Caching;
    using Microsoft.WindowsAzure.Storage.Table;


    public class AzureContextFeatureStateCacheProvider<TContext> :
        IContextFeatureStateCacheProvider<TContext>
    {
        readonly ICloudTableProvider _tableProvider;

        public AzureContextFeatureStateCacheProvider(ICloudTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public async Task<IEnumerable<Tuple<string, CodeFeatureState>>> Load()
        {
            CloudTable cloudTable = _tableProvider.GetTable("contextFeatureState");

            return await GetContextFeatureStates(cloudTable);
        }

        public async Task<bool> GetDefaultState()
        {
            return false;
        }

        async Task<IEnumerable<Tuple<string, CodeFeatureState>>> GetContextFeatureStates(CloudTable cloudTable,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            TableQuery<ContextFeatureStateEntity> query = new TableQuery<ContextFeatureStateEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Current"));

            var featureStates = new List<Tuple<string, CodeFeatureState>>();

            TableContinuationToken token = null;

            do
            {
                TableQuerySegment<ContextFeatureStateEntity> result =
                    await cloudTable.ExecuteQuerySegmentedAsync(query, token, cancellationToken);

                featureStates.AddRange(result.Select(entity =>
                    Tuple.Create(entity.ContextKey,
                        (CodeFeatureState)new CodeFeatureStateImpl(new CodeFeatureId(entity.CodeFeatureId), entity.Enabled))));

                token = result.ContinuationToken;
            }
            while (token != null);

            return featureStates;
        }
    }
}