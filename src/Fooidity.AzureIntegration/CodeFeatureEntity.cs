namespace Fooidity.AzureIntegration
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;


    /// <summary>
    /// Every known code feature is saved here
    /// </summary>
    public class CodeFeatureEntity :
        TableEntity
    {
        public CodeFeatureEntity()
        {
        }

        public CodeFeatureEntity(CodeFeatureId codeFeatureId)
        {
            PartitionKey = codeFeatureId.ToString();
            Created = DateTime.UtcNow;
            LastModified = Created;
        }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public CodeFeatureId CodeFeatureId
        {
            get { return new CodeFeatureId(PartitionKey); }
        }
    }
}