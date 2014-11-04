namespace Fooidity.Configuration
{
    using Caching;
    using Metadata;


    public class DefaultCodeFeatureState<TFeature> :
        ICachedCodeFeatureState
    {
        readonly bool _enabled;

        public DefaultCodeFeatureState(bool enabled)
        {
            _enabled = enabled;
        }

        public CodeFeatureId Id
        {
            get { return CodeFeatureMetadata<TFeature>.Id; }
        }

        public bool Enabled
        {
            get { return _enabled; }
        }
    }
}