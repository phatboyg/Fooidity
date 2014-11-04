namespace Fooidity.Caching
{
    public class CachedCodeFeatureState :
        ICachedCodeFeatureState
    {
        readonly bool _enabled;
        readonly CodeFeatureId _id;

        public CachedCodeFeatureState(CodeFeatureId id, bool enabled)
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