namespace Fooidity.Management.AzureIntegration.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Management.Commands;
    using Management.Queries;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class CreateApplicationCommandHandler :
        ICommandHandler<CreateApplication, UserOrganizationApplication>
    {
        readonly IQueryHandler<GetOrganization, Organization> _organizationQueryHandler;
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public CreateApplicationCommandHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings,
            IQueryHandler<GetOrganization, Organization> organizationQueryHandler)
        {
            _tableProvider = tableProvider;
            _organizationQueryHandler = organizationQueryHandler;
            _settings = settings;
        }

        public async Task<UserOrganizationApplication> Execute(CreateApplication command,
            CancellationToken cancellationToken = new CancellationToken())
        {
            GetOrganization query = new GetOrganizationQuery(command.UserId, command.OrganizationId);

            Organization organization = await _organizationQueryHandler.Execute(query, cancellationToken);

            CloudTable appTable = _tableProvider.GetTable(_settings.ApplicationTableName);

            var appEntity = new ApplicationEntity(command.ApplicationName, command.Timestamp);

            await appTable.ExecuteAsync(TableOperation.Insert(appEntity), cancellationToken);

            var indexEntity = new OrganizationApplicationIndexEntity(organization.Id, organization.Name, appEntity.Id, command.ApplicationName,
                command.Timestamp);

            CloudTable indexTable = _tableProvider.GetTable(_settings.OrganizationApplicationIndexTableName);

            await indexTable.ExecuteAsync(TableOperation.Insert(indexEntity), cancellationToken);

            var userIndexEntity = new UserApplicationIndexEntity(command.UserId, organization.Id, organization.Name, appEntity.Id, command.ApplicationName,
                command.Timestamp);

            CloudTable userIndexTable = _tableProvider.GetTable(_settings.UserApplicationIndexTableName);

            await userIndexTable.ExecuteAsync(TableOperation.Insert(userIndexEntity), cancellationToken);

            return userIndexEntity;
        }


        class GetOrganizationQuery :
            GetOrganization
        {
            readonly string _organizationId;
            readonly string _userId;

            public GetOrganizationQuery(string userId, string organizationId)
            {
                _userId = userId;
                _organizationId = organizationId;
            }

            public string UserId
            {
                get { return _userId; }
            }

            public string OrganizationId
            {
                get { return _organizationId; }
            }
        }
    }
}