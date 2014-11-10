namespace Fooidity.Management.Queries
{
    public class GetApplication :
        IGetApplication
    {
        public GetApplication(string userId, string applicationId)
        {
            ApplicationId = applicationId;
            UserId = userId;
        }

        public string UserId { get; set; }
        public string ApplicationId { get; set; }
    }
}