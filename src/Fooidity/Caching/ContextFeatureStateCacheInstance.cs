namespace Fooidity.Caching
{
    using Internals;


    class ContextFeatureStateCacheInstance<TContext> :
        IContextFeatureStateCacheInstance<TContext>
    {
        readonly ICache<string, ICachedContextFeatureState> _cache;

        public ContextFeatureStateCacheInstance(ICache<string, ICachedContextFeatureState> cache)
        {
            _cache = cache;
        }

        public bool TryGetContextFeatureState(string key, out ICachedContextFeatureState featureState)
        {
            return _cache.TryGet(key, out featureState);
        }

        public bool TryAdd(string key, ICachedContextFeatureState contextFeatureState)
        {
            return _cache.TryAdd(key, contextFeatureState);
        }

        public int Count
        {
            get { return _cache.Values.Count; }
        }
    }
}