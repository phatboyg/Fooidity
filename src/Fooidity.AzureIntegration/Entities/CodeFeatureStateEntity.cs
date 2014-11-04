namespace Fooidity.AzureIntegration.Entities
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;


    public class CodeFeatureStateEntity :
        TableEntity
    {
        public CodeFeatureStateEntity()
        {
        }

        public CodeFeatureStateEntity(Uri codeFeatureId, DateTime timestamp, bool enabled, Guid? commandId = null)
        {
            if (codeFeatureId == null)
                throw new ArgumentNullException("codeFeatureId");

            CodeFeatureId = codeFeatureId.ToString();
            Enabled = enabled;

            CommandId = commandId;

            PartitionKey = CodeFeatureId;
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;
        }

        /// <summary>
        /// The CodeFeatureId for this entity
        /// </summary>
        public string CodeFeatureId { get; set; }

        /// <summary>
        /// If the state is enabled or disabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The command-id associated with this state change
        /// </summary>
        public Guid? CommandId { get; set; }
    }
}