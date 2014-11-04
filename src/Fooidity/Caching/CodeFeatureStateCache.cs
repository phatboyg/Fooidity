namespace Fooidity.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Configuration;
    using Contracts;
    using Internals;
    using Metadata;


    /// <summary>
    /// Caches the switch states
    /// </summary>
    public class CodeFeatureStateCache :
        ICodeFeatureStateCache,
        IReloadCache,
        IUpdateCodeFeatureCache,
        IObservable<ICodeFeatureStateCacheLoaded>,
        IObservable<ICodeFeatureStateCacheUpdated>
    {
        readonly Connectable<IObserver<ICodeFeatureStateCacheLoaded>> _cacheLoaded;
        readonly ICodeFeatureStateCacheProvider _cacheProvider;
        readonly Connectable<IObserver<ICodeFeatureStateCacheUpdated>> _cacheUpdated;
        ICodeFeatureStateCacheInstance _cache;

        public CodeFeatureStateCache(ICodeFeatureStateCacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;

            _cacheLoaded = new Connectable<IObserver<ICodeFeatureStateCacheLoaded>>();
            _cacheUpdated = new Connectable<IObserver<ICodeFeatureStateCacheUpdated>>();

            _cache = LoadCache().Result;
        }

        public bool TryGetState<TFeature>(out ICachedCodeFeatureState featureState)
        {
            if (_cache.TryGetState(CodeFeatureMetadata<TFeature>.Id, out featureState))
                return true;

            if (!_cache.DefaultState)
                return false;

            featureState = new DefaultCodeFeatureState<TFeature>(true);
            return true;
        }

        public IDisposable Subscribe(IObserver<ICodeFeatureStateCacheLoaded> observer)
        {
            return _cacheLoaded.Connect(observer);
        }

        public IDisposable Subscribe(IObserver<ICodeFeatureStateCacheUpdated> observer)
        {
            return _cacheUpdated.Connect(observer);
        }

        public async Task ReloadCache()
        {
            DateTime startTime = DateTime.UtcNow;
            ICodeFeatureStateCacheInstance cache = await LoadCache();
            DateTime endTime = DateTime.UtcNow;

            Interlocked.Exchange(ref _cache, cache);

            var loaded = new CodeFeatureStateCacheLoaded(startTime, endTime - startTime, cache.Count);

            _cacheLoaded.ForEach(x => x.OnNext(loaded));
        }

        public void UpdateCache(IUpdateCodeFeature update)
        {
            CodeFeatureId codeFeatureId = update.CodeFeatureId;

            ICachedCodeFeatureState existingFeatureState;
            if (_cache.TryGetState(codeFeatureId, out existingFeatureState))
            {
                if (existingFeatureState.Enabled == update.Enabled)
                    return;

                var updatedFeatureState = new CachedCodeFeatureState(codeFeatureId, update.Enabled);

                DateTime startTime = DateTime.UtcNow;
                bool updated = _cache.TryUpdate(codeFeatureId, updatedFeatureState, existingFeatureState);
                DateTime endTime = DateTime.UtcNow;

                if (updated)
                {
                    var updatedEvent = new CodeFeatureStateCacheUpdated(startTime, endTime - startTime, updatedFeatureState.Id,
                        updatedFeatureState.Enabled,
                        update.CommandId);

                    _cacheUpdated.ForEach(x => x.OnNext(updatedEvent));
                }
            }
            else
            {
                var featureState = new CachedCodeFeatureState(codeFeatureId, update.Enabled);

                DateTime startTime = DateTime.UtcNow;
                bool updated = _cache.TryAdd(codeFeatureId, featureState);
                DateTime endTime = DateTime.UtcNow;

                if (updated)
                {
                    var updatedEvent = new CodeFeatureStateCacheUpdated(startTime, endTime - startTime, featureState.Id,
                        featureState.Enabled, update.CommandId);

                    _cacheUpdated.ForEach(x => x.OnNext(updatedEvent));
                }
            }
        }

        async Task<ICodeFeatureStateCacheInstance> LoadCache()
        {
            IEnumerable<ICachedCodeFeatureState> states = await _cacheProvider.Load();

            var cache = new InMemoryCache<CodeFeatureId, ICachedCodeFeatureState>();
            foreach (ICachedCodeFeatureState state in states)
                cache.TryAdd(state.Id, state);

            return new CodeFeatureStateCacheInstance(cache, _cacheProvider.GetDefaultState().Result);
        }
    }
}