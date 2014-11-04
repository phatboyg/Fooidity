namespace Fooidity.Management.AzureIntegration.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Management.Queries;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class ListApplicationCodeFeaturesQueryHandler :
        IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>>
    {
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public ListApplicationCodeFeaturesQueryHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings)
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

            IEnumerable<CodeFeatureStateModel> featureStates = await featureStateTable.ExecuteQueryAsync(featureStateQuery,
                entity => new CodeFeatureStateModel(new CodeFeatureId(entity.CodeFeatureId), entity.Timestamp.UtcDateTime, entity.Enabled),
                cancellationToken);

            CloudTable featureTable = _tableProvider.GetTable(_settings.ApplicationCodeFeatureTableName);

            TableQuery<ApplicationCodeFeatureEntity> featureQuery = new TableQuery<ApplicationCodeFeatureEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.ApplicationId));

            IEnumerable<CodeFeatureStateModel> features = await featureTable.ExecuteQueryAsync(featureQuery,
                entity => new CodeFeatureStateModel(new CodeFeatureId(entity.CodeFeatureId), entity.Timestamp.UtcDateTime, false),
                cancellationToken);

            // include the default (not-enabled) feature states for features which have not been initialized
            return featureStates.Union(features);
        }
    }
}