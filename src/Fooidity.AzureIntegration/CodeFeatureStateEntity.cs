namespace Fooidity.AzureIntegration
{
    using System;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Storage.Table;


    public class CodeFeatureStateEntity :
        TableEntity
    {
        const string SeparatorString = "'\u3000";

        public CodeFeatureStateEntity()
        {
        }

        public CodeFeatureStateEntity(CodeFeatureId codeFeatureId, DateTime timestamp, bool enabled, Uri organizationId = null,
            Uri environmentId = null, Guid? commandId = null)
        {
            if (codeFeatureId == null)
                throw new ArgumentNullException("codeFeatureId");

            CodeFeatureId = codeFeatureId.ToString();
            Enabled = enabled;

            CommandId = commandId;
            OrganizationId = organizationId != null ? organizationId.ToString() : null;
            EnvironmentId = environmentId != null ? environmentId.ToString() : null;

            PartitionKey = string.Join(SeparatorString, GetPartitionKeyIds());
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
        /// The organization associated with this feature
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// The environment associated with this feature
        /// </summary>
        public string EnvironmentId { get; set; }

        /// <summary>
        /// The command-id associated with this state change
        /// </summary>
        public Guid? CommandId { get; set; }

        IEnumerable<string> GetPartitionKeyIds()
        {
            if (!string.IsNullOrWhiteSpace(OrganizationId))
                yield return OrganizationId;

            if (!string.IsNullOrWhiteSpace(EnvironmentId))
                yield return EnvironmentId;

            yield return CodeFeatureId;
        }
    }
}