namespace Fooidity.Management.AzureIntegration.Entities
{
    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    /// A code feature reported by an application, purely for inventory purposes.
    /// The timestamp is the last time it was reported by an application
    /// </summary>
    public class ApplicationCodeFeatureEntity :
        TableEntity
    {
        public ApplicationCodeFeatureEntity()
        {
        }

        public ApplicationCodeFeatureEntity(string applicationId, string codeFeatureId)
        {
            CodeFeatureId = codeFeatureId;
            ApplicationId = applicationId;

            PartitionKey = ApplicationId;
            RowKey = CodeFeatureId;
        }

        /// <summary>
        /// The CodeFeatureId for this entity
        /// </summary>
        public string CodeFeatureId { get; set; }

        public string ApplicationId { get; set; }
    }
}