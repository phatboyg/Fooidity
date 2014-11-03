namespace Fooidity.Management.AzureIntegration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;


    public static class TableQueryExtensions
    {
        public static Task<IEnumerable<TQuery>> ExecuteQueryAsync<TQuery>(this CloudTable table, TableQuery<TQuery> query,
            CancellationToken cancellationToken = default(CancellationToken))
            where TQuery : class, ITableEntity, new()
        {
            return ExecuteQueryAsync(table, query, x => x, cancellationToken);
        }

        public static async Task<IEnumerable<TResult>> ExecuteQueryAsync<TQuery, TResult>(this CloudTable table, TableQuery<TQuery> query,
            Func<TQuery, TResult> selector, CancellationToken cancellationToken = default(CancellationToken))
            where TQuery : class, ITableEntity, new()
        {
            var results = new List<TResult>();

            TableContinuationToken token = null;
            var options = new TableRequestOptions();
            var context = new OperationContext
            {
                ClientRequestID = Guid.NewGuid().ToString(),
            };
            do
            {
                TableQuerySegment<TQuery> result = await table.ExecuteQuerySegmentedAsync(query, token, options, context, cancellationToken);

                results.AddRange(result.Select(selector));

                token = result.ContinuationToken;
            }
            while (token != null);

            return results;
        }
    }
}