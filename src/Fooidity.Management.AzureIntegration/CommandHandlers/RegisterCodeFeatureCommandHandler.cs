namespace Fooidity.Management.AzureIntegration.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Entities;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;


    public class RegisterCodeFeatureCommandHandler :
        ICommandHandler<IRegisterCodeFeature>
    {
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public RegisterCodeFeatureCommandHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task Execute(IRegisterCodeFeature command, CancellationToken cancellationToken = new CancellationToken())
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (string.IsNullOrWhiteSpace(command.ApplicationId))
                throw new ArgumentException("The ApplicationId is required");
            if (string.IsNullOrWhiteSpace(command.CodeFeatureId))
                throw new ArgumentException("The CodeFeatureId is required");

            CloudTable table = _tableProvider.GetTable(_settings.ApplicationCodeFeatureTableName);

            var entity = new ApplicationCodeFeatureEntity(command.ApplicationId, command.CodeFeatureId);

            await table.ExecuteAsync(TableOperation.InsertOrMerge(entity), cancellationToken);
        }
    }
}