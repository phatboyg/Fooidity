namespace Fooidity.Management.Models
{
    /// <summary>
    /// An application created within an organization
    /// </summary>
    public interface UserOrganizationApplication :
        OrganizationApplication
    {
        string UserId { get; }
    }
}