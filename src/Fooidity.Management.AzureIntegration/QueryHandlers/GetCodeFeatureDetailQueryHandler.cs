namespace Fooidity.Management.AzureIntegration.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Exceptions;
    using Fooidity.AzureIntegration;
    using Fooidity.Contracts;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;
    using Queries;


    public class GetCodeFeatureDetailQueryHandler :
        IQueryHandler<IGetCodeFeatureDetail, ICodeFeatureDetail>
    {
        readonly IQueryHandler<IGetApplication, IUserOrganizationApplication> _getApplication;
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public GetCodeFeatureDetailQueryHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings,
            IQueryHandler<IGetApplication, IUserOrganizationApplication> getApplication)
        {
            _tableProvider = tableProvider;
            _settings = settings;
            _getApplication = getApplication;
        }

        public async Task<ICodeFeatureDetail> Execute(IGetCodeFeatureDetail query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.UserId))
                throw new ArgumentException("UserId is required");
            if (string.IsNullOrWhiteSpace(query.ApplicationId))
                throw new ArgumentException("ApplicationId is required");
            if (query.CodeFeatureId == null)
                throw new ArgumentException("CodeFeatureId is required");

            IUserOrganizationApplication application =
                await _getApplication.Execute(new GetApplication(query.UserId, query.ApplicationId), cancellationToken);


            CloudTable featureStateTable = _tableProvider.GetTable(_settings.ApplicationCodeFeatureStateTableName);

            TableQuery<ApplicationCodeFeatureStateEntity> currentStateQuery = new TableQuery<ApplicationCodeFeatureStateEntity>()
                .Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,
                    ApplicationCodeFeatureStateEntity.GetCurrentPartitionKey(query.ApplicationId)),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, query.CodeFeatureId.ToString()))).Take(1);

            CodeFeatureState currentState = (await featureStateTable.ExecuteQueryAsync(currentStateQuery,
                entity => new CodeFeatureState(new CodeFeatureId(entity.CodeFeatureId), entity.Timestamp.UtcDateTime, entity.Enabled),
                cancellationToken)).FirstOrDefault();
            if (currentState == null)
                throw new FeatureNotFoundException(query.UserId, query.ApplicationId, query.CodeFeatureId.ToString());

            TableQuery<ApplicationCodeFeatureStateEntity> stateHistoryQuery = new TableQuery<ApplicationCodeFeatureStateEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,
                    ApplicationCodeFeatureStateEntity.FormatPartitionKey(query.ApplicationId, query.CodeFeatureId.ToString())));

            IEnumerable<CodeFeatureState> stateHistory = (await featureStateTable.ExecuteQueryAsync(stateHistoryQuery,
                entity => new CodeFeatureState(new CodeFeatureId(entity.CodeFeatureId), entity.Timestamp.UtcDateTime, entity.Enabled),
                cancellationToken));
            if (currentState == null)
                throw new FeatureNotFoundException(query.UserId, query.ApplicationId, query.CodeFeatureId.ToString());


            return new CodeFeatureDetail(application.ApplicationId, application.ApplicationName, new CodeFeatureId(query.CodeFeatureId),
                currentState, stateHistory);
        }
    }
}