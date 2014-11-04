namespace Fooidity.AzureIntegration.Entities
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;


    public class ContextFeatureStateEntity :
        TableEntity
    {
        const string SeparatorString = "'\u3000";

        public ContextFeatureStateEntity()
        {
        }

        public ContextFeatureStateEntity(Uri codeFeatureId, Uri contextId, string contextKey, bool enabled, DateTime timestamp,
            Guid? eventId = null, Guid? commandId = null)
        {
            PartitionKey = string.Join(SeparatorString,
                contextId.ToString(),
                contextKey,
                codeFeatureId.ToString());
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;

            EventId = eventId.HasValue ? eventId.Value : Guid.NewGuid();
            CommandId = commandId;

            CodeFeatureId = codeFeatureId.ToString();
            ContextId = contextId.ToString();
            ContextKey = contextKey;
            Enabled = enabled;
        }

        public string CodeFeatureId { get; set; }
        public string ContextId { get; set; }
        public string ContextKey { get; set; }
        public bool Enabled { get; set; }
        public Guid EventId { get; set; }
        public Guid? CommandId { get; set; }
    }
}