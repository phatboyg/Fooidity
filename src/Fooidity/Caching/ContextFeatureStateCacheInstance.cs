namespace Fooidity.Caching
{
    using Configuration;
    using Internals;


    class ContextFeatureStateCacheInstance<TContext> :
        IContextFeatureStateCacheInstance<TContext>
    {
        readonly ICache<string, ContextFeatureState> _cache;

        public ContextFeatureStateCacheInstance(ICache<string, ContextFeatureState> cache)
        {
            _cache = cache;
        }

        public bool TryGetContextFeatureState(string key, out ContextFeatureState featureState)
        {
            return _cache.TryGet(key, out featureState);
        }

        public bool TryAdd(string key, ContextFeatureState contextFeatureState)
        {
            return _cache.TryAdd(key, contextFeatureState);
        }

        public int Count
        {
            get { return _cache.Values.Count; }
        }
    }
}