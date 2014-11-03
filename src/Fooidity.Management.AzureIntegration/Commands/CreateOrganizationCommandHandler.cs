namespace Fooidity.Management.AzureIntegration.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Management.Commands;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class CreateOrganizationCommandHandler :
        ICommandHandler<CreateOrganization, Organization>
    {
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public CreateOrganizationCommandHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task<Organization> Execute(CreateOrganization command, CancellationToken cancellationToken = new CancellationToken())
        {
            CloudTable organizationTable = _tableProvider.GetTable(_settings.OrganizationTableName);

            var entity = new OrganizationEntity(command.UserId, command.OrganizationName, command.Timestamp);

            await organizationTable.ExecuteAsync(TableOperation.Insert(entity), cancellationToken);

            var indexEntity = new UserOrganizationIndexEntity(command.Timestamp, command.UserId, entity.Id, entity.Name, true);

            CloudTable userOrganizationIndexTable = _tableProvider.GetTable(_settings.UserOrganizationIndexTableName);

            await userOrganizationIndexTable.ExecuteAsync(TableOperation.InsertOrReplace(indexEntity), cancellationToken);

            return entity;
        }
    }
}