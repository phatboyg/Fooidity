namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;


    /// <summary>
    /// The state of a code feature wthin an application
    /// </summary>
    public class ApplicationContextCodeFeatureStateEntity :
        TableEntity
    {
        const string SeparatorString = "'\u3000";

        public ApplicationContextCodeFeatureStateEntity()
        {
        }

        public ApplicationContextCodeFeatureStateEntity(string applicationId, Uri contextId, string contextKey, Uri codeFeatureId,
            DateTime timestamp, bool enabled, Guid? commandId = null)
        {
            if (applicationId == null)
                throw new ArgumentNullException("applicationId");
            if (contextId == null)
                throw new ArgumentNullException("contextId");
            if (contextKey == null)
                throw new ArgumentNullException("contextKey");
            if (codeFeatureId == null)
                throw new ArgumentNullException("codeFeatureId");

            ApplicationId = applicationId;
            ContextId = contextId.ToString();
            ContextKey = contextKey;
            CodeFeatureId = codeFeatureId.ToString();
            Enabled = enabled;

            CommandId = commandId;

            PartitionKey = string.Join(SeparatorString,
                ApplicationId,
                ContextId,
                ContextKey,
                CodeFeatureId);
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;
        }

        /// <summary>
        /// The application for this code feature state
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// The context of this code feature state
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The context key of this code feature state
        /// </summary>
        public string ContextKey { get; set; }

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

        public void SetCurrent()
        {
            PartitionKey = GetCurrentPartitionKey(ApplicationId);
            RowKey = GetCurrentRowKey(ContextId, ContextKey, CodeFeatureId);
        }

        public static string GetCurrentPartitionKey(string applicationId)
        {
            return string.Join(SeparatorString,
                applicationId,
                "Current");
        }

        public static string GetCurrentRowKey(string contextId, string contextKey, string codeFeatureId)
        {
            return string.Join(SeparatorString,
                contextId,
                contextKey,
                codeFeatureId);
        }
    }
}