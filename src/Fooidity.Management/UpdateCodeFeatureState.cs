namespace Fooidity.Management
{
    using System;


    public interface UpdateCodeFeatureState
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }



        CodeFeatureId CodeFeatureId { get; }

        bool Enabled { get; }
    }
}