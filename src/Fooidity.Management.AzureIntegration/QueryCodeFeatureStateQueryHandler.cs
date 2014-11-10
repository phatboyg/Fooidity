namespace Fooidity.Management.AzureIntegration
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Fooidity.AzureIntegration;
    using Fooidity.AzureIntegration.Entities;
    using Fooidity.Contracts;
    using Microsoft.WindowsAzure.Storage.Table;


    public class QueryCodeFeatureStateQueryHandler :
        IQueryHandler<QueryCodeFeatureState, IEnumerable<ICodeFeatureState>>
    {
        readonly ICloudTableProvider _tableProvider;

        public QueryCodeFeatureStateQueryHandler(ICloudTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public Task<IEnumerable<ICodeFeatureState>> Execute(QueryCodeFeatureState query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            CloudTable table = _tableProvider.GetTable("codeFeatureState");

            TableQuery<CodeFeatureStateEntity> tableQuery = new TableQuery<CodeFeatureStateEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Current"));

            return table.ExecuteQueryAsync(tableQuery,
                entity => (ICodeFeatureState)new CodeFeatureState(new CodeFeatureId(entity.CodeFeatureId),
                    entity.Timestamp.UtcDateTime, entity.Enabled),
                cancellationToken);
        }
    }
}