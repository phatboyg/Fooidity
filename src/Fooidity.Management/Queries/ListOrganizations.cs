namespace Fooidity.Management.Queries
{
    public class ListOrganizations :
        IListOrganizations
    {
        public ListOrganizations(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}