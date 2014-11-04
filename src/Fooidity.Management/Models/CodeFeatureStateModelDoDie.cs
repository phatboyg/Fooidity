namespace Fooidity.Management.Models
{
    using System;


    public interface CodeFeatureStateModelDoDie
    {
        CodeFeatureId CodeFeatureId { get; }

        DateTime LastUpdated { get; }

        bool Enabled { get; }
    }
}