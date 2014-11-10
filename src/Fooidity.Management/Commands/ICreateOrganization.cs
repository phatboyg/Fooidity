namespace Fooidity.Management.Commands
{
    using System;


    public interface ICreateOrganization
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        /// <summary>
        /// The user creating the application
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// The organization in which the application is being created
        /// </summary>
        string OrganizationName { get; }
    }
}