namespace Fooidity.Management.Models
{
    public interface IOrganizationApplicationKey :
        IOrganizationApplication
    {
        string Key { get; }
    }
}