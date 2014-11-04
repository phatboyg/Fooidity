namespace Fooidity.Management.AzureIntegration.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Management.Commands;
    using Microsoft.WindowsAzure.Storage.Table;


    public class UpdateApplicationCodeFeatureStateCommandHandler :
        ICommandHandler<IUpdateApplicationCodeFeatureState>
    {
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public UpdateApplicationCodeFeatureStateCommandHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings)
        {
            _tableProvider = tableProvider;
            _settings = settings;
        }

        public async Task Execute(IUpdateApplicationCodeFeatureState command,
            CancellationToken cancellationToken = new CancellationToken())
        {
            CloudTable cloudTable = _tableProvider.GetTable(_settings.ApplicationCodeFeatureStateTableName);

            var entity = new ApplicationCodeFeatureStateEntity(command.ApplicationId, command.CodeFeatureId, command.Timestamp,
                command.Enabled, command.CommandId);
            var current = new ApplicationCodeFeatureStateEntity(command.ApplicationId, command.CodeFeatureId, command.Timestamp,
                command.Enabled, command.CommandId);
            current.SetCurrent();

            IEnumerable<Task<TableResult>> writeTasks = new[] {entity, current}
                .Select(x => cloudTable.ExecuteAsync(TableOperation.InsertOrReplace(x), cancellationToken));

            await Task.WhenAll(writeTasks);
        }
    }
}