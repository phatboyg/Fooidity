namespace Fooidity.Management.Models
{
    /// <summary>
    /// An application created within an organization
    /// </summary>
    public interface UserOrganizationApplication
    {
        string UserId { get; }
        string OrganizationId { get; }
        string OrganizationName { get; }
        string ApplicationId { get; }
        string ApplicationName { get; }
    }
}