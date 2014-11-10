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


    public class ListApplicationKeysQueryHandler :
        IQueryHandler<IListApplicationKeys, IEnumerable<IOrganizationApplicationKey>>
    {
        readonly IQueryHandler<IGetApplication, IUserOrganizationApplication> _getApplication;
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public ListApplicationKeysQueryHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings,
            IQueryHandler<IGetApplication, IUserOrganizationApplication> getApplication)
        {
            _tableProvider = tableProvider;
            _settings = settings;
            _getApplication = getApplication;
        }

        public async Task<IEnumerable<IOrganizationApplicationKey>> Execute(IListApplicationKeys query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.UserId))
                throw new AggregateException("UserId must be specified");
            if (string.IsNullOrWhiteSpace(query.ApplicationId))
                throw new AggregateException("ApplicationId must be specified");

            await _getApplication.Execute(new GetApplication(query.UserId, query.ApplicationId), cancellationToken);

            CloudTable appKeyTable = _tableProvider.GetTable(_settings.OrganizationApplicationKeyTableName);

            return await appKeyTable.ExecutePartitionKeyQueryAsync<OrganizationApplicationKeyEntity>(query.ApplicationId, cancellationToken);
        }
    }
}