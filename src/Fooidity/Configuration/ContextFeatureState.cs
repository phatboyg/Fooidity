namespace Fooidity.Configuration
{
    public interface ContextFeatureState
    {
        string Key { get; }

        bool TryGetCodeFeatureState<TFeature>(out CodeFeatureState featureState);
    }
}