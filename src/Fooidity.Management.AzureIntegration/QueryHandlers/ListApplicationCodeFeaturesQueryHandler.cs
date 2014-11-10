namespace Fooidity.Management.AzureIntegration.QueryHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Fooidity.Contracts;
    using Management.Queries;
    using Microsoft.WindowsAzure.Storage.Table;


    public class ListApplicationCodeFeaturesQueryHandler :
        IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>>
    {
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public ListApplicationCodeFeaturesQueryHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task<IEnumerable<ICodeFeatureState>> Execute(IListApplicationCodeFeatures query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            CloudTable featureStateTable = _tableProvider.GetTable(_settings.ApplicationCodeFeatureStateTableName);

            TableQuery<ApplicationCodeFeatureStateEntity> featureStateQuery = new TableQuery<ApplicationCodeFeatureStateEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,
                    ApplicationCodeFeatureStateEntity.GetCurrentPartitionKey(query.ApplicationId)));

            IEnumerable<CodeFeatureState> featureStates = await featureStateTable.ExecuteQueryAsync(featureStateQuery,
                entity => new CodeFeatureState(new CodeFeatureId(entity.CodeFeatureId), entity.Timestamp.UtcDateTime, entity.Enabled),
                cancellationToken);

            CloudTable featureTable = _tableProvider.GetTable(_settings.ApplicationCodeFeatureTableName);

            TableQuery<ApplicationCodeFeatureEntity> featureQuery = new TableQuery<ApplicationCodeFeatureEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.ApplicationId));

            IEnumerable<CodeFeatureState> features = await featureTable.ExecuteQueryAsync(featureQuery,
                entity => new CodeFeatureState(new CodeFeatureId(entity.CodeFeatureId), entity.Timestamp.UtcDateTime, false),
                cancellationToken);

            // include the default (not-enabled) feature states for features which have not been initialized
            return featureStates.Union(features);
        }
    }
}