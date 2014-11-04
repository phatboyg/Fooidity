namespace Fooidity.Management.Models
{
    using System;


    public interface ICodeFeatureState
    {
        CodeFeatureId CodeFeatureId { get; }

        DateTime LastUpdated { get; }

        bool Enabled { get; }
    }
}