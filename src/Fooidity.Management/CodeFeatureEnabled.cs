namespace Fooidity.Management
{
    using System;


    public interface CodeFeatureEnabled
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        Uri CodeFeatureId { get; }

        Guid OriginatingCommandId { get; }
    }
}