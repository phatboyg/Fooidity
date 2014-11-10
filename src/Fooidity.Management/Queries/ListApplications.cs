namespace Fooidity.Management.Queries
{
    public class ListApplications :
        IListApplications
    {
        public ListApplications(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}