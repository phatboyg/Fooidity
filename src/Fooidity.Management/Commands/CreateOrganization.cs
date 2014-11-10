namespace Fooidity.Management.Commands
{
    using System;


    public class CreateOrganization :
        ICreateOrganization
    {
        public CreateOrganization(string userId, string organizationName)
        {
            CommandId = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;

            UserId = userId;
            OrganizationName = organizationName;
        }

        public Guid CommandId { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }
        public string OrganizationName { get; set; }
    }
}