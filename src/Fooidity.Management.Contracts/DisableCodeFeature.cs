namespace Fooidity.Management.Contracts
{
    using System;


    public interface DisableCodeFeature
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        Uri CodeFeatureId { get; }
    }
}