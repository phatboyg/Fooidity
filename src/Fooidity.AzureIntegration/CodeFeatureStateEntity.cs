namespace Fooidity.AzureIntegration
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;


    public class CodeFeatureStateEntity :
        TableEntity
    {
        public CodeFeatureStateEntity()
        {
        }

        public CodeFeatureStateEntity(CodeFeatureId codeFeatureId, DateTime timestamp, bool enabled, Guid? commandId = null)
        {
            PartitionKey = codeFeatureId.ToString();
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;

            CodeFeatureId = codeFeatureId.ToString();
            CommandId = commandId;
            Enabled = enabled;
        }

        public string CodeFeatureId { get; set; }
        public bool Enabled { get; set; }
        public Guid? CommandId { get; set; }
    }
}