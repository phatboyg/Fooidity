namespace Fooidity.Management.Models
{
    /// <summary>
    /// An application created within an organization
    /// </summary>
    public interface IOrganizationApplication
    {
        string OrganizationId { get; }
        string OrganizationName { get; }
        string ApplicationId { get; }
        string ApplicationName { get; }
    }
}