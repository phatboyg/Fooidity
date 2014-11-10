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
    using Management.Queries;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class GetApplicationQueryHandler :
        IQueryHandler<IGetApplication, IUserOrganizationApplication>
    {
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public GetApplicationQueryHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task<IUserOrganizationApplication> Execute(IGetApplication query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.UserId))
                throw new ArgumentException("UserId is required");
            if (string.IsNullOrWhiteSpace(query.ApplicationId))
                throw new ArgumentException("ApplicationId is required");

            CloudTable userAppIndexTable = _tableProvider.GetTable(_settings.UserApplicationIndexTableName);

            TableQuery<UserApplicationIndexEntity> userAppQuery = new TableQuery<UserApplicationIndexEntity>()
                .Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.UserId),
                    TableOperators.And, TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, query.ApplicationId))).Take(1);

            IEnumerable<UserApplicationIndexEntity> userApps = await userAppIndexTable.ExecuteQueryAsync(userAppQuery, cancellationToken);
            UserApplicationIndexEntity userApp = userApps.SingleOrDefault();
            if (userApp == null)
                throw new ApplicationNotFoundException(query.UserId, query.ApplicationId);

            return userApp;
        }
    }
}