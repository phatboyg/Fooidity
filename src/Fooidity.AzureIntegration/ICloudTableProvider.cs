namespace Fooidity.AzureIntegration
{
    using Microsoft.WindowsAzure.Storage.Table;


    /// <summary>
    /// Returns a cloud table, given the table name, configured for the entity type
    /// </summary>
    public interface ICloudTableProvider
    {
        CloudTable GetTable(string tableName);
    }
}