namespace Fooidity.Management.Models
{
    /// <summary>
    /// An organization connects users to applications
    /// </summary>
    public interface IOrganization
    {
        /// <summary>
        /// The identifier for the organization
        /// </summary>
        string OrganizationId { get; }

        /// <summary>
        /// The organization name
        /// </summary>
        string OrganizationName { get; }

        /// <summary>
        /// The user which created the organization
        /// </summary>
        string CreatedByUserId { get; }
    }
}