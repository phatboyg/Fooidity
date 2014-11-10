namespace Fooidity.Management.AzureIntegration.Entities
{
    using System;
    using Fooidity.AzureIntegration;
    using Microsoft.WindowsAzure.Storage.Table;


    /// <summary>
    /// The state of a code feature wthin an application
    /// </summary>
    public class ApplicationCodeFeatureStateEntity :
        TableEntity
    {
        const string SeparatorString = "'\u3000";

        public ApplicationCodeFeatureStateEntity()
        {
        }

        public ApplicationCodeFeatureStateEntity(string applicationId, Uri codeFeatureId, DateTime timestamp, bool enabled,
            Guid? commandId = null)
        {
            if (applicationId == null)
                throw new ArgumentNullException("applicationId");
            if (codeFeatureId == null)
                throw new ArgumentNullException("codeFeatureId");

            ApplicationId = applicationId;
            CodeFeatureId = codeFeatureId.ToString();
            Enabled = enabled;

            CommandId = commandId;

            PartitionKey = FormatPartitionKey(ApplicationId, CodeFeatureId);
            RowKey = timestamp.ToDescendingTimestamp();
            Timestamp = timestamp;
        }

        /// <summary>
        /// The application for this code feature state
        /// </summary>
        public string ApplicationId { get; set; }

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

        public static string FormatPartitionKey(string applicationId, string codeFeatureId)
        {
            return string.Join(SeparatorString,
                applicationId,
                codeFeatureId);
        }

        public void SetCurrent()
        {
            PartitionKey = GetCurrentPartitionKey(ApplicationId);
            RowKey = CodeFeatureId;
        }

        public static string GetCurrentPartitionKey(string applicationId)
        {
            return string.Join(SeparatorString,
                applicationId,
                "Current");
        }
    }
}