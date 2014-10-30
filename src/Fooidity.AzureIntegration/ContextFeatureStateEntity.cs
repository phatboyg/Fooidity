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
                codeFeatureId.ToString(),
                contextId.ToString(),
                contextKey);
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;

            CodeFeatureId = codeFeatureId.ToString();
            ContextId = contextId.ToString();
            ContextKey = contextKey;
        }

        public ContextFeatureStateEntity(ContextCodeFeatureStateEnabled message)
            : this(message.CodeFeatureId, message.ContextId, message.ContextKey, message.Timestamp)
        {
            Enabled = true;

            EventId = message.EventId;
            CommandId = message.CommandId;
        }

        public ContextFeatureStateEntity(ContextCodeFeatureStateDisabled message)
            : this(message.CodeFeatureId, message.ContextId, message.ContextKey, message.Timestamp)
        {
            Enabled = false;

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