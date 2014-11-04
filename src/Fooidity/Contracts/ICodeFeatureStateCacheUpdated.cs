namespace Fooidity.Contracts
{
    using System;


    /// <summary>
    /// Observable when the state cache is loaded
    /// </summary>
    public interface ICodeFeatureStateCacheUpdated
    {
        Guid EventId { get; }

        /// <summary>
        /// The time the cache update started
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The time taken to update the cache
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// The command identifier that triggered the update
        /// </summary>
        Guid? CommandId { get; }

        /// <summary>
        /// The FeatureId that was updated
        /// </summary>
        Uri CodeFeatureId { get; }

        /// <summary>
        /// The updated state of the feature
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// The host that loaded the cache
        /// </summary>
        IHost Host { get; }
    }
}