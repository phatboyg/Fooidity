namespace Fooidity.Configuration
{
    using System;
    using Metadata;


    public class DefaultCodeFeatureState<TFeature> :
        CodeFeatureState
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

        public Type FeatureType
        {
            get { return typeof(TFeature); }
        }

        public bool Enabled
        {
            get { return _enabled; }
        }
    }
}