namespace Fooidity.Management.AzureIntegration
{
    public interface AzureManagementSettings
    {
        string ApplicationTableName { get; }
        string OrganizationTableName { get; }
        string UserTableName { get; }
        string OrganizationUserTableName { get; }
        string UserOrganizationIndexTableName { get; }
        string OrganizationApplicationIndexTableName { get; }
        string UserApplicationIndexTableName { get; }
    }
}