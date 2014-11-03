namespace Fooidity.Management.Models
{
    public interface OrganizationApplicationKey :
        OrganizationApplication
    {
        string Key { get; }
    }
}