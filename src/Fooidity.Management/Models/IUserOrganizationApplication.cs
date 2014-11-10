namespace Fooidity.Management.Models
{
    /// <summary>
    /// An application created within an organization
    /// </summary>
    public interface IUserOrganizationApplication :
        IOrganizationApplication
    {
        string UserId { get; }
    }
}