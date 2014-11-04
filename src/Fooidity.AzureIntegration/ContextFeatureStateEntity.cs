namespace Fooidity.AzureIntegration
{
    using System;
    using Contracts;
    using Microsoft.WindowsAzure.Storage.Table;


    public class ContextFeatureStateEntity :
        TableEntity
    {
        const string SeparatorString = "'\u3000";

        public ContextFeatureStateEntity()
        {
        }

        ContextFeatureStateEntity(Uri codeFeatureId, Uri contextId, string contextKey, DateTime timestamp)
        {
            PartitionKey = string.Join(SeparatorString,
                contextId.ToString(),
                contextKey,
                codeFeatureId.ToString());
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;

            CodeFeatureId = codeFeatureId.ToString();
            ContextId = contextId.ToString();
            ContextKey = contextKey;
        }

        public ContextFeatureStateEntity(IContextCodeFeatureStateUpdated message)
            : this(message.CodeFeatureId, message.ContextId, message.ContextKey, message.Timestamp)
        {
            Enabled = message.Enabled;

            EventId = message.EventId;
            CommandId = message.CommandId;
        }

        public string CodeFeatureId { get; set; }
        public string ContextId { get; set; }
        public string ContextKey { get; set; }
        public bool Enabled { get; set; }
        public Guid EventId { get; set; }
        public Guid? CommandId { get; set; }
    }
}