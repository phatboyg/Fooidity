namespace Fooidity.Contracts
{
    using System;


    public interface ICodeFeatureState
    {
        Uri CodeFeatureId { get; }

        DateTime LastUpdated { get; }

        bool Enabled { get; }
    }
}