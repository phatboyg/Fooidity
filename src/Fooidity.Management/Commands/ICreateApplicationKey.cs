namespace Fooidity.Management.Commands
{
    using System;


    public interface ICreateApplicationKey
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        string UserId { get; }

        string OrganizationId { get; }

        string ApplicationId { get; }
    }
}