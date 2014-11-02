namespace Fooidity.Management.AzureIntegration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;


    public class QueryCodeFeatureStateQueryHandler :
        IQueryHandler<QueryCodeFeatureState, IEnumerable<CodeFeatureStateModel>>
    {
        readonly ICloudTableProvider _tableProvider;

        public QueryCodeFeatureStateQueryHandler(ICloudTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public Task<IEnumerable<CodeFeatureStateModel>> Execute(QueryCodeFeatureState query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            CloudTable cloudTable = _tableProvider.GetTable("codeFeatureState");

            return GetCodeFeatureStates(cloudTable, cancellationToken);
        }

        async Task<IEnumerable<CodeFeatureStateModel>> GetCodeFeatureStates(CloudTable cloudTable,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                TableQuery<CodeFeatureStateEntity> query = new TableQuery<CodeFeatureStateEntity>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Current"));

                var codeFeatureStates = new List<CodeFeatureStateModel>();

                TableContinuationToken token = null;
                var options = new TableRequestOptions();
                var context = new OperationContext
                {
                    ClientRequestID = Guid.NewGuid().ToString(),
                };
                do
                {
                    TableQuerySegment<CodeFeatureStateEntity> result =
                        await cloudTable.ExecuteQuerySegmentedAsync(query, token, options, context, cancellationToken);

                    codeFeatureStates.AddRange(result.Select(
                        entity => new CodeFeatureStateImpl(new CodeFeatureId(entity.CodeFeatureId), entity.Timestamp.UtcDateTime,
                            entity.Enabled)));

                    token = result.ContinuationToken;
                }
                while (token != null);

                return codeFeatureStates;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);

                throw;
            }
        }


        class CodeFeatureStateImpl :
            CodeFeatureStateModel
        {
            readonly CodeFeatureId _codeFeatureId;
            readonly bool _enabled;
            readonly DateTime _lastUpdated;

            public CodeFeatureStateImpl(CodeFeatureId codeFeatureId, DateTime lastUpdated, bool enabled)
            {
                _enabled = enabled;
                _codeFeatureId = codeFeatureId;
                _lastUpdated = lastUpdated;
            }

            public DateTime LastUpdated
            {
                get { return _lastUpdated; }
            }

            public CodeFeatureId CodeFeatureId
            {
                get { return _codeFeatureId; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}