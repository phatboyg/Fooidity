namespace Fooidity.Configuration
{
    public interface ContextFeatureState
    {
        string Key { get; }

        bool TryGetFeature<TFeature>(out CodeFeatureState featureState);
    }
}