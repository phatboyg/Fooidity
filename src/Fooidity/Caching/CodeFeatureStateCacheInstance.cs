namespace Fooidity.Caching
{
    using Internals;


    class CodeFeatureStateCacheInstance :
        ICodeFeatureStateCacheInstance
    {
        readonly ICache<CodeFeatureId, ICachedCodeFeatureState> _cache;
        readonly bool _defaultState;

        public CodeFeatureStateCacheInstance(ICache<CodeFeatureId, ICachedCodeFeatureState> cache, bool defaultState)
        {
            _cache = cache;
            _defaultState = defaultState;
        }

        public bool DefaultState
        {
            get { return _defaultState; }
        }

        public int Count
        {
            get { return _cache.Values.Count; }
        }

        public bool TryGetState(CodeFeatureId id, out ICachedCodeFeatureState featureState)
        {
            return _cache.TryGet(id, out featureState);
        }

        public bool TryUpdate(CodeFeatureId id, ICachedCodeFeatureState featureState, ICachedCodeFeatureState previousFeatureState)
        {
            return _cache.TryUpdate(id, featureState, previousFeatureState);
        }

        public bool TryAdd(CodeFeatureId id, ICachedCodeFeatureState featureState)
        {
            return _cache.TryAdd(id, featureState);
        }
    }
}