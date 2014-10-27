namespace Fooidity.Events
{
    using System;


    /// <summary>
    /// Observable when the state cache is loaded
    /// </summary>
    public interface CodeFeatureStateCacheLoaded
    {
        /// <summary>
        /// The time the cache load started
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The time taken to load the cache
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// The number of code features loaded
        /// </summary>
        int Count { get; }
    }
}