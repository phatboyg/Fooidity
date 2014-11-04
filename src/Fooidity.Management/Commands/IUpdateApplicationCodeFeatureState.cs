namespace Fooidity.Management.Commands
{
    using System;


    public interface IUpdateApplicationCodeFeatureState
    {
        Guid CommandId { get; }

        DateTime Timestamp { get; }

        string ApplicationId { get; }

        Uri CodeFeatureId { get; }

        bool Enabled { get; }
    }
}