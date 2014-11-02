namespace Fooidity.Management.Models
{
    using System;


    public interface CodeFeatureStateModel
    {
        CodeFeatureId CodeFeatureId { get; }

        DateTime LastUpdated { get; }

        bool Enabled { get; }
    }
}