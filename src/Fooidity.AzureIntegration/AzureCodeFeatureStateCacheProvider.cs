namespace Fooidity.AzureIntegration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Caching;
    using Microsoft.WindowsAzure.Storage.Table;


    public class AzureCodeFeatureStateCacheProvider :
        ICodeFeatureStateCacheProvider
    {
        readonly ICloudTableProvider _tableProvider;

        public AzureCodeFeatureStateCacheProvider(ICloudTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public async Task<bool> GetDefaultState()
        {
            return false;
        }

        public async Task<IEnumerable<CodeFeatureState>> Load()
        {
            CloudTable cloudTable = _tableProvider.GetTable("codeFeatureState");

            return await GetCodeFeatureStates(cloudTable);
        }

        async Task<IEnumerable<CodeFeatureState>> GetCodeFeatureStates(CloudTable cloudTable,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                TableQuery<CodeFeatureStateEntity> query = new TableQuery<CodeFeatureStateEntity>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Current"));

                var codeFeatureStates = new List<CodeFeatureState>();

                TableContinuationToken token = null;

                do
                {
                    TableQuerySegment<CodeFeatureStateEntity> result =
                        cloudTable.ExecuteQuerySegmented(query, token);

                    codeFeatureStates.AddRange(
                        result.Select(entity => new CodeFeatureStateImpl(new CodeFeatureId(entity.CodeFeatureId), entity.Enabled)));

                    token = result.ContinuationToken;
                }
                while (token != null);

                return codeFeatureStates;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);

                throw;
            }
        }
    }
}