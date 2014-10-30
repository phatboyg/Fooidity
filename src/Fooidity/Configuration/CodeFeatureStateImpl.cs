namespace Fooidity.Configuration
{
    class CodeFeatureStateImpl :
        CodeFeatureState
    {
        readonly bool _enabled;
        readonly CodeFeatureId _id;

        public CodeFeatureStateImpl(CodeFeatureId id, bool enabled)
        {
            _enabled = enabled;
            _id = id;
        }

        public CodeFeatureId Id
        {
            get { return _id; }
        }

        public bool Enabled
        {
            get { return _enabled; }
        }
    }
}