namespace Fooidity.Management.Commands
{
    using System;


    public class CreateApplicationKey :
        ICreateApplicationKey
    {
        public CreateApplicationKey(string userId, string organizationId, string applicationId, DateTime timestamp, Guid commandId)
        {
            UserId = userId;
            OrganizationId = organizationId;
            ApplicationId = applicationId;
            Timestamp = timestamp;
            CommandId = commandId;
        }

        public Guid CommandId { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }
        public string OrganizationId { get; set; }
        public string ApplicationId { get; set; }
    }
}