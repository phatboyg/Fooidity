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


    public class ListApplicationKeysQueryHandler :
        IQueryHandler<ListApplicationKeys, IEnumerable<OrganizationApplicationKey>>
    {
        readonly IQueryHandler<GetApplication, UserOrganizationApplication> _getApplication;
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public ListApplicationKeysQueryHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings,
            IQueryHandler<GetApplication, UserOrganizationApplication> getApplication)
        {
            _tableProvider = tableProvider;
            _settings = settings;
            _getApplication = getApplication;
        }

        public async Task<IEnumerable<OrganizationApplicationKey>> Execute(ListApplicationKeys query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.UserId))
                throw new AggregateException("UserId must be specified");
            if (string.IsNullOrWhiteSpace(query.ApplicationId))
                throw new AggregateException("ApplicationId must be specified");

            await _getApplication.Execute(new GetApplicationQuery(query.UserId, query.ApplicationId), cancellationToken);

            CloudTable appKeyTable = _tableProvider.GetTable(_settings.OrganizationApplicationKeyTableName);

            TableQuery<OrganizationApplicationKeyEntity> appKeyQuery = new TableQuery<OrganizationApplicationKeyEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.ApplicationId));

            return await appKeyTable.ExecuteQueryAsync(appKeyQuery, x => (OrganizationApplicationKey)x, cancellationToken);
        }


        class GetApplicationQuery :
            GetApplication
        {
            readonly string _applicationId;
            readonly string _userId;

            public GetApplicationQuery(string userId, string applicationId)
            {
                _userId = userId;
                _applicationId = applicationId;
            }

            public string UserId
            {
                get { return _userId; }
            }

            public string ApplicationId
            {
                get { return _applicationId; }
            }
        }
    }
}