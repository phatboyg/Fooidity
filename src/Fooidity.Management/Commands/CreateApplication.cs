namespace Fooidity.Management.Commands
{
    using System;


    public class CreateApplication :
        ICreateApplication
    {
        public CreateApplication(string userId, string organizationId, string applicationName, DateTime timestamp, Guid commandId)
        {
            UserId = userId;
            OrganizationId = organizationId;
            ApplicationName = applicationName;
            Timestamp = timestamp;
            CommandId = commandId;
        }

        public Guid CommandId { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }
        public string OrganizationId { get; set; }
        public string ApplicationName { get; set; }
    }
}