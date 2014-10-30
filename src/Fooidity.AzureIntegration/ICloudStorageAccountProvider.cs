namespace Fooidity.AzureIntegration
{
    using Microsoft.WindowsAzure.Storage;


    public interface ICloudStorageAccountProvider
    {
        CloudStorageAccount GetStorageAccount();
    }
}