namespace Fooidity.Management.AzureIntegration.CommandHandlers
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
        ICommandHandler<ICreateApplication, IUserOrganizationApplication>
    {
        readonly IQueryHandler<IGetOrganization, IOrganization> _organizationQueryHandler;
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public CreateApplicationCommandHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings,
            IQueryHandler<IGetOrganization, IOrganization> organizationQueryHandler)
        {
            _tableProvider = tableProvider;
            _organizationQueryHandler = organizationQueryHandler;
            _settings = settings;
        }

        public async Task<IUserOrganizationApplication> Execute(ICreateApplication command,
            CancellationToken cancellationToken = new CancellationToken())
        {
            IOrganization organization = 
                await _organizationQueryHandler.Execute(new GetOrganization(command.UserId, command.OrganizationId), cancellationToken);

            CloudTable appTable = _tableProvider.GetTable(_settings.ApplicationTableName);

            var appEntity = new ApplicationEntity(command.ApplicationName, command.Timestamp);

            await appTable.ExecuteAsync(TableOperation.Insert(appEntity), cancellationToken);

            var indexEntity = new OrganizationApplicationIndexEntity(organization.OrganizationId, organization.OrganizationName, appEntity.Id, command.ApplicationName,
                command.Timestamp);

            CloudTable indexTable = _tableProvider.GetTable(_settings.OrganizationApplicationIndexTableName);

            await indexTable.ExecuteAsync(TableOperation.Insert(indexEntity), cancellationToken);

            var userIndexEntity = new UserApplicationIndexEntity(command.UserId, organization.OrganizationId, organization.OrganizationName, appEntity.Id, command.ApplicationName,
                command.Timestamp);

            CloudTable userIndexTable = _tableProvider.GetTable(_settings.UserApplicationIndexTableName);

            await userIndexTable.ExecuteAsync(TableOperation.Insert(userIndexEntity), cancellationToken);

            return userIndexEntity;
        }
    }
}