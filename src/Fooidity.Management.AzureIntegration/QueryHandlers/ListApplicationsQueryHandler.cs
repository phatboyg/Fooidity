namespace Fooidity.Management.AzureIntegration.QueryHandlers
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
        IQueryHandler<IListApplications, IEnumerable<IUserOrganizationApplication>>
    {
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public ListApplicationsQueryHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public Task<IEnumerable<IUserOrganizationApplication>> Execute(IListApplications query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.UserId))
                throw new AggregateException("UserId must be specfiied");

            CloudTable cloudTable = _tableProvider.GetTable(_settings.UserApplicationIndexTableName);

            TableQuery<UserApplicationIndexEntity> indexQuery = new TableQuery<UserApplicationIndexEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.UserId));

            return cloudTable.ExecuteQueryAsync(indexQuery, x => (IUserOrganizationApplication)x, cancellationToken);
        }
    }
}