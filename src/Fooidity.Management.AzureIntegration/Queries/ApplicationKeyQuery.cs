namespace Fooidity.Management.AzureIntegration.Queries
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


    public class GetApplicationKeyQueryHandler :
        IQueryHandler<GetApplicationKey, OrganizationApplicationKey>
    {
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public GetApplicationKeyQueryHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task<OrganizationApplicationKey> Execute(GetApplicationKey query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.Key))
                throw new ArgumentException("Key is required");

            CloudTable keyIndexTable = _tableProvider.GetTable(_settings.KeyOrganizationApplicationIndexTableName);

            TableQuery<KeyOrganizationApplicationIndexEntity> userAppQuery = new TableQuery<KeyOrganizationApplicationIndexEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.Key)).Take(1);

            IEnumerable<KeyOrganizationApplicationIndexEntity> keyApps =
                await keyIndexTable.ExecuteQueryAsync(userAppQuery, cancellationToken);
            KeyOrganizationApplicationIndexEntity keyApp = keyApps.SingleOrDefault();
            if (keyApp == null)
                throw new ApplicationNotFoundException(string.Format("The key was not found: {0}", query.Key));

            return keyApp;
        }
    }
}