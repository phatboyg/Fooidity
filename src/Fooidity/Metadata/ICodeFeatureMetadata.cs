namespace Fooidity.Metadata
{
    using System;


    public interface ICodeFeatureMetadata<TFeature>
    {
        string Id { get; }

        Type FeatureType { get; }
    }
}