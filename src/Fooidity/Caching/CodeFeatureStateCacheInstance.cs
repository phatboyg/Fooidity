namespace Fooidity.Caching
{
    using System;
    using Configuration;


    public class CodeFeatureStateCacheInstance :
        ICodeFeatureStateCacheInstance
    {
        readonly IReadOnlyCache<string, CodeFeatureState> _cache;
        readonly bool _defaultState;
        readonly ICacheIndex<Type, CodeFeatureState> _typeIndex;

        public CodeFeatureStateCacheInstance(IReadOnlyCache<string, CodeFeatureState> cache,
            ICacheIndex<Type, CodeFeatureState> typeIndex, bool defaultState)
        {
            _cache = cache;
            _typeIndex = typeIndex;
            _defaultState = defaultState;
        }

        public IReadOnlyCache<string, CodeFeatureState> Cache
        {
            get { return _cache; }
        }

        public ICacheIndex<Type, CodeFeatureState> TypeIndex
        {
            get { return _typeIndex; }
        }

        public bool DefaultState
        {
            get { return _defaultState; }
        }
    }
}