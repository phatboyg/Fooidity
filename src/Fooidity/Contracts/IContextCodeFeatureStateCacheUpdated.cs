namespace Fooidity.Contracts
{
    using System;


    /// <summary>
    /// Observable when the state cache is loaded
    /// </summary>
    public interface IContextCodeFeatureStateCacheUpdated
    {
        Guid EventId { get; }

        /// <summary>
        /// The time the cache update started
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The command identifier that triggered the update
        /// </summary>
        Guid? CommandId { get; }

        /// <summary>
        /// The context that was updated
        /// </summary>
        Uri ContextId { get; }

        /// <summary>
        /// The key that was updated
        /// </summary>
        string ContextKey { get; }

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