namespace Fooidity.Management.Models
{
    /// <summary>
    /// An organization connects users to applications
    /// </summary>
    public interface Organization
    {
        /// <summary>
        /// The identifier for the organization
        /// </summary>
        string Id { get; }

        /// <summary>
        /// The organization name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The user which created the organization
        /// </summary>
        string CreatedByUserId { get; }
    }
}