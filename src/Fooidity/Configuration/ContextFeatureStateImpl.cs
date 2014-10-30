namespace Fooidity.Configuration
{
    using Caching.Internals;


    class ContextFeatureStateImpl :
        ContextFeatureState
    {
        readonly ICache<CodeFeatureId, CodeFeatureState> _cache;
        readonly string _key;

        public ContextFeatureStateImpl(ICache<CodeFeatureId, CodeFeatureState> cache, string key)
        {
            _cache = cache;
            _key = key;
        }

        public string Key
        {
            get { return _key; }
        }

        public bool TryGetCodeFeatureState(CodeFeatureId codeFeatureId, out CodeFeatureState featureState)
        {
            return _cache.TryGet(codeFeatureId, out featureState);
        }

        public bool TryUpdate(CodeFeatureId codeFeatureId, CodeFeatureState updated, CodeFeatureState existing)
        {
            return _cache.TryUpdate(codeFeatureId, updated, existing);
        }

        public bool TryAdd(CodeFeatureId codeFeatureId, CodeFeatureState featureState)
        {
            return _cache.TryAdd(codeFeatureId, featureState);
        }
    }
}