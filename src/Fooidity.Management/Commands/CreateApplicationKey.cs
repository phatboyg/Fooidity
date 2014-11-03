namespace Fooidity.Management.Commands
{
    using System;


    public interface CreateApplicationKey
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        string UserId { get; }

        string OrganizationId { get; }

        string ApplicationId { get; }
    }
}