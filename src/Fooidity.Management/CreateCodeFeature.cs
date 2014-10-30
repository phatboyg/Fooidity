namespace Fooidity.Management
{
    using System;


    /// <summary>
    /// Create a code feature
    /// </summary>
    public interface CreateCodeFeature
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        Uri CodeFeatureId { get; }
    }
}