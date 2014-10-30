namespace Fooidity.Management.Contracts
{
    using System;


    public interface EnableCodeFeature
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        Uri CodeFeatureId { get; }
    }
}