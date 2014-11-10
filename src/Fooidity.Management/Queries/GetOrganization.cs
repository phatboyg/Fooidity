namespace Fooidity.Management.Queries
{
    public class GetOrganization :
        IGetOrganization
    {
        public GetOrganization(string userId, string organizationId)
        {
            OrganizationId = organizationId;
            UserId = userId;
        }

        public string UserId { get; set; }
        public string OrganizationId { get; set; }
    }
}