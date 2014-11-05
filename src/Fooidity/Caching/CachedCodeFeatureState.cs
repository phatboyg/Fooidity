namespace Fooidity.Caching
{
    using System;


    public class CachedCodeFeatureState :
        ICachedCodeFeatureState
    {
        readonly bool _enabled;
        readonly CodeFeatureId _id;

        public CachedCodeFeatureState(CodeFeatureId id, bool enabled)
        {
            _id = id;
            _enabled = enabled;
        }

        public CachedCodeFeatureState(Uri id, bool enabled)
        {
            _id = new CodeFeatureId(id);
            _enabled = enabled;
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