namespace Fooidity.Management.AzureIntegration.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Management.Commands;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class CreateOrganizationCommandHandler :
        ICommandHandler<ICreateOrganization, IOrganization>
    {
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public CreateOrganizationCommandHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task<IOrganization> Execute(ICreateOrganization command, CancellationToken cancellationToken = new CancellationToken())
        {
            CloudTable table = _tableProvider.GetTable(_settings.OrganizationTableName);

            var entity = new OrganizationEntity(command.UserId, command.OrganizationName, command.Timestamp);

            await table.ExecuteAsync(TableOperation.Insert(entity), cancellationToken);

            var indexEntity = new UserOrganizationIndexEntity(command.Timestamp, command.UserId, entity.OrganizationId,
                entity.OrganizationName, command.UserId, true);

            CloudTable indexTable = _tableProvider.GetTable(_settings.UserOrganizationIndexTableName);

            await indexTable.ExecuteAsync(TableOperation.InsertOrReplace(indexEntity), cancellationToken);

            return entity;
        }
    }
}