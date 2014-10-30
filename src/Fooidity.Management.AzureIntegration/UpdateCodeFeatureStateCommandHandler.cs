namespace Fooidity.Management.AzureIntegration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;


    public class UpdateCodeFeatureStateCommandHandler :
        ICommandHandler<UpdateCodeFeatureState>
    {
        readonly ICloudTableProvider _tableProvider;

        public UpdateCodeFeatureStateCommandHandler(ICloudTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public async Task Execute(UpdateCodeFeatureState update, CancellationToken cancellationToken = default(CancellationToken))
        {
            CloudTable cloudTable = _tableProvider.GetTable("codeFeatureState");

            var entity = new CodeFeatureStateEntity(update.CodeFeatureId, update.Timestamp, update.Enabled, update.CommandId);
            var current = new CodeFeatureStateEntity(update.CodeFeatureId, update.Timestamp, update.Enabled, update.CommandId);
            current.RowKey = current.PartitionKey;
            current.PartitionKey = "Current";

            IEnumerable<Task<TableResult>> writeTasks = new[] {entity, current}
                .Select(x => cloudTable.ExecuteAsync(TableOperation.InsertOrReplace(x), cancellationToken));

            await Task.WhenAll(writeTasks);
        }
    }
}