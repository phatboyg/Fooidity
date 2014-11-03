namespace Fooidity.Management.AzureIntegration.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Management.Queries;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class ListApplicationsQueryHandler :
        IQueryHandler<ListApplications, IEnumerable<UserOrganizationApplication>>
    {
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public ListApplicationsQueryHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public Task<IEnumerable<UserOrganizationApplication>> Execute(ListApplications query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.UserId))
                throw new AggregateException("UserId must be specfiied");

            CloudTable cloudTable = _tableProvider.GetTable(_settings.UserApplicationIndexTableName);

            TableQuery<UserApplicationIndexEntity> indexQuery = new TableQuery<UserApplicationIndexEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.UserId));

            return cloudTable.ExecuteQueryAsync(indexQuery, x => (UserOrganizationApplication)x, cancellationToken);
        }
    }
}