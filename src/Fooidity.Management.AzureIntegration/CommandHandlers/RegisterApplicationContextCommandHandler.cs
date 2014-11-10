namespace Fooidity.Management.AzureIntegration.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Entities;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;


    public class RegisterApplicationContextCommandHandler :
        ICommandHandler<IRegisterApplicationContext>
    {
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public RegisterApplicationContextCommandHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task Execute(IRegisterApplicationContext command, CancellationToken cancellationToken = new CancellationToken())
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (string.IsNullOrWhiteSpace(command.ApplicationId))
                throw new ArgumentException("The ApplicationId is required");
            if (string.IsNullOrWhiteSpace(command.ContextId))
                throw new ArgumentException("The ContextId is required");

            CloudTable table = _tableProvider.GetTable(_settings.ApplicationContextTableName);

            var entity = new ApplicationContextEntity(command.ApplicationId, command.ContextId);

            await table.ExecuteAsync(TableOperation.InsertOrMerge(entity), cancellationToken);
        }
    }
}