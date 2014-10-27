namespace Fooidity.Caching
{
    using Configuration;
    using Internals;


    class ContextFeatureStateCacheInstance<TContext> :
        IContextFeatureStateCacheInstance<TContext>
    {
        readonly IReadOnlyCache<string, ContextFeatureState> _cache;

        public ContextFeatureStateCacheInstance(IReadOnlyCache<string, ContextFeatureState> cache)
        {
            _cache = cache;
        }

        public bool TryGetContextFeatureState(string key, out ContextFeatureState featureState)
        {
            return _cache.TryGet(key, out featureState);
        }

        public int Count
        {
            get { return _cache.Values.Count; }
        }
    }
}