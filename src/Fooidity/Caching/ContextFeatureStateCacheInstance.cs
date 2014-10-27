namespace Fooidity.Caching
{
    using Configuration;


    public class ContextFeatureStateCacheInstance<TContext> :
        IContextFeatureStateCacheInstance<TContext>
    {
        readonly IReadOnlyCache<string, ContextFeatureState> _cache;

        public ContextFeatureStateCacheInstance(IReadOnlyCache<string, ContextFeatureState> cache)
        {
            _cache = cache;
        }

        public IReadOnlyCache<string, ContextFeatureState> Cache
        {
            get { return _cache; }
        }
    }
}