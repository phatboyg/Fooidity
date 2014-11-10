namespace Fooidity.Management.Queries
{
    public class ListApplicationKeys :
        IListApplicationKeys
    {
        public ListApplicationKeys(string userId, string applicationId)
        {
            ApplicationId = applicationId;
            UserId = userId;
        }

        public string UserId { get; set; }
        public string ApplicationId { get; set; }
    }
}