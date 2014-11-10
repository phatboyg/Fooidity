namespace Fooidity.Management.Queries
{
    public interface IListApplicationKeys
    {
        /// <summary>
        /// The userId making the request (only applications visible to the user can be displayed)
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// The applicationId to get the keys for (must be visible to the userId)
        /// </summary>
        string ApplicationId { get; }
    }
}