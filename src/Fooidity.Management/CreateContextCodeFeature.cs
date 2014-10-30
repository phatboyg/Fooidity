namespace Fooidity.Management
{
    using System;


    public interface CreateContextCodeFeature
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        Uri CodeFeatureId { get; }

        /// <summary>
        /// Identifies the context in which this code feature is being created
        /// </summary>
        Uri ContextId { get; }

        /// <summary>
        /// The key for the context
        /// </summary>
        string Key { get; }
    }
}