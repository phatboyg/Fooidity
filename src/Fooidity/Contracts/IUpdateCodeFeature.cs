namespace Fooidity.Contracts
{
    using System;


    /// <summary>
    /// Sent to the cache when the state of code feature is updated, so that the cache can be updated
    /// </summary>
    public interface IUpdateCodeFeature
    {
        Guid CommandId { get; }

        /// <summary>
        /// When the feature state was updated
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The FeatureId that was updated
        /// </summary>
        CodeFeatureId CodeFeatureId { get; }

        /// <summary>
        /// The updated state of the feature
        /// </summary>
        bool Enabled { get; }
    }
}