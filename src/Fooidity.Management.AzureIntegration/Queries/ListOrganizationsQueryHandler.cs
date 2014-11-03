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


    public class ListOrganizationsQueryHandler :
        IQueryHandler<ListOrganizations, IEnumerable<Organization>>
    {
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public ListOrganizationsQueryHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public Task<IEnumerable<Organization>> Execute(ListOrganizations query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (string.IsNullOrWhiteSpace(query.UserId))
                throw new AggregateException("UserId must be specfiied");

            CloudTable cloudTable = _tableProvider.GetTable(_settings.UserOrganizationIndexTableName);

            TableQuery<UserOrganizationIndexEntity> indexQuery = new TableQuery<UserOrganizationIndexEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, query.UserId));

            return cloudTable.ExecuteQueryAsync(indexQuery, x => (Organization)new OrganizationResult(x.OrganizationId, x.OrganizationName),
                cancellationToken);
        }


        class OrganizationResult :
            Organization
        {
            readonly string _id;
            readonly string _name;
            string _createdByUserId;

            public OrganizationResult(string id, string name)
            {
                _id = id;
                _name = name;
            }

            public string Id
            {
                get { return _id; }
            }

            public string Name
            {
                get { return _name; }
            }

            public string CreatedByUserId
            {
                get { return _createdByUserId; }
            }
        }
    }
}