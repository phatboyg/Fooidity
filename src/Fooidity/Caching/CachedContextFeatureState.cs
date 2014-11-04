namespace Fooidity.Caching
{
    using System.Collections.Generic;
    using Internals;


    public class CachedContextFeatureState :
        ICachedContextFeatureState
    {
        readonly ICache<CodeFeatureId, ICachedCodeFeatureState> _cache;
        readonly string _key;

        public CachedContextFeatureState(IEnumerable<ICachedCodeFeatureState> codeFeatureStates, string key)
        {
            _cache = CreateInMemoryCache(codeFeatureStates);
            _key = key;
        }

        public string Key
        {
            get { return _key; }
        }

        public bool TryGetCodeFeatureState(CodeFeatureId codeFeatureId, out ICachedCodeFeatureState featureState)
        {
            return _cache.TryGet(codeFeatureId, out featureState);
        }

        public bool TryUpdate(CodeFeatureId codeFeatureId, ICachedCodeFeatureState updated, ICachedCodeFeatureState existing)
        {
            return _cache.TryUpdate(codeFeatureId, updated, existing);
        }

        public bool TryAdd(CodeFeatureId codeFeatureId, ICachedCodeFeatureState featureState)
        {
            return _cache.TryAdd(codeFeatureId, featureState);
        }

        static ICache<CodeFeatureId, ICachedCodeFeatureState> CreateInMemoryCache(IEnumerable<ICachedCodeFeatureState> codeFeatureStates)
        {
            var cache = new InMemoryCache<CodeFeatureId, ICachedCodeFeatureState>();

            foreach (ICachedCodeFeatureState featureState in codeFeatureStates)
                cache.TryAdd(featureState.Id, featureState);
            return cache;
        }
    }
}