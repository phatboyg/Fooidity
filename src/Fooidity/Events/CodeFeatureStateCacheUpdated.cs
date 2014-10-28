namespace Fooidity.Events
{
    using System;


    /// <summary>
    /// Observable when the state cache is loaded
    /// </summary>
    public interface CodeFeatureStateCacheUpdated
    {
        /// <summary>
        /// The time the cache update started
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The time taken to update the cache
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// The FeatureId that was updated
        /// </summary>
        Uri Id { get; }

        /// <summary>
        /// The updated state of the feature
        /// </summary>
        bool Enabled { get; }
    }
}