namespace Fooidity.Contracts
{
    using System;


    /// <summary>
    /// Sent to the cache when the state of code feature is updated, so that the cache can be updated
    /// </summary>
    public interface CodeFeatureStateEnabled
    {
        Guid EventId { get; }

        /// <summary>
        /// When the feature state was updated
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The identifier of the command that enabled the context code feature
        /// </summary>
        Guid? CommandId { get; }

        /// <summary>
        /// The FeatureId that was updated
        /// </summary>
        Uri CodeFeatureId { get; }
    }
}