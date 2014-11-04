namespace Fooidity.Management.Queries
{
    public class ListApplicationCodeFeatures :
        IListApplicationCodeFeatures
    {
        public ListApplicationCodeFeatures(string userId, string applicationId)
        {
            UserId = userId;
            ApplicationId = applicationId;
        }

        public string UserId { get; set; }

        public string ApplicationId { get; set; }
    }
}