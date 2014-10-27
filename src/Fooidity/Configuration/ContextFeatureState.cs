namespace Fooidity.Configuration
{
    public interface ContextFeatureState
    {
        bool TryGetCodeFeatureState<TFeature>(out CodeFeatureState featureState);
    }
}