namespace Fooidity.Contracts
{
    using System;


    public interface IContextCodeFeatureStateUpdated
    {
        /// <summary>
        /// Identifies the event uniquely
        /// </summary>
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

        /// <summary>
        /// The context in which the code feature was updated
        /// </summary>
        Uri ContextId { get; }

        /// <summary>
        /// The context instance in which the code feature was updated
        /// </summary>
        string ContextKey { get; }

        /// <summary>
        /// if the code feature was enabled
        /// </summary>
        bool Enabled { get; }
    }
}