namespace Fooidity.Metadata
{
    using System;


    public interface ICodeFeatureMetadata<TFeature>
    {
        CodeFeatureId Id { get; }

        Type FeatureType { get; }
    }
}