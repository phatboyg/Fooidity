namespace Fooidity.Management.AzureIntegration.Entities
{
    using Microsoft.WindowsAzure.Storage.Table;


    /// <summary>
    /// A code feature reported by an application, purely for inventory purposes.
    /// The timestamp is the last time it was reported by an application
    /// </summary>
    public class ApplicationContextEntity :
        TableEntity
    {
        public ApplicationContextEntity()
        {
        }

        public ApplicationContextEntity(string applicationId, string contextId)
        {
            ContextId = contextId;
            ApplicationId = applicationId;

            PartitionKey = ApplicationId;
            RowKey = ContextId;
        }

        /// <summary>
        /// The CodeFeatureId for this entity
        /// </summary>
        public string ContextId { get; set; }

        public string ApplicationId { get; set; }
    }
}