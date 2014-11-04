namespace Fooidity.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Internals;
    using Metadata;


    /// <summary>
    /// Caches the switch states
    /// </summary>
    public class ContextFeatureStateCache<TContext> :
        IContextFeatureStateCache<TContext>,
        IReloadCache,
        IUpdateContextFeatureCache,
        IObservable<IContextCodeFeatureStateCacheLoaded>,
        IObservable<IContextCodeFeatureStateCacheUpdated>
    {
        readonly Connectable<IObserver<IContextCodeFeatureStateCacheLoaded>> _cacheLoaded;
        readonly IContextFeatureStateCacheProvider<TContext> _cacheProvider;
        readonly Connectable<IObserver<IContextCodeFeatureStateCacheUpdated>> _cacheUpdated;
        readonly ContextKeyProvider<TContext> _keyProvider;
        IContextFeatureStateCacheInstance<TContext> _cache;

        public ContextFeatureStateCache(IContextFeatureStateCacheProvider<TContext> cacheProvider,
            ContextKeyProvider<TContext> keyProvider)
        {
            _cacheProvider = cacheProvider;
            _keyProvider = keyProvider;

            _cacheLoaded = new Connectable<IObserver<IContextCodeFeatureStateCacheLoaded>>();
            _cacheUpdated = new Connectable<IObserver<IContextCodeFeatureStateCacheUpdated>>();

            _cache = LoadCache().Result;
        }

        public bool TryGetContextFeatureState(TContext context, out ContextFeatureState featureState)
        {
            string key = _keyProvider.GetKey(context);

            return _cache.TryGetContextFeatureState(key, out featureState);
        }

        public IDisposable Subscribe(IObserver<IContextCodeFeatureStateCacheLoaded> observer)
        {
            return _cacheLoaded.Connect(observer);
        }

        public IDisposable Subscribe(IObserver<IContextCodeFeatureStateCacheUpdated> observer)
        {
            return _cacheUpdated.Connect(observer);
        }

        public async Task ReloadCache()
        {
            DateTime startTime = DateTime.UtcNow;
            IContextFeatureStateCacheInstance<TContext> cache = await LoadCache();
            DateTime endTime = DateTime.UtcNow;

            Interlocked.Exchange(ref _cache, cache);

            var loaded = new ContextCodeFeatureStateCacheLoaded(startTime, endTime - startTime, cache.Count);

            _cacheLoaded.ForEach(x => x.OnNext(loaded));
        }

        public void UpdateCache(IUpdateContextCodeFeature update)
        {
            // ignore updates that aren't for this cache instance
            if (update.ContextId != ContextMetadata<TContext>.Id)
                return;

            CodeFeatureId codeFeatureId = update.CodeFeatureId;

            ContextFeatureState existingContext;
            if (_cache.TryGetContextFeatureState(update.ContextKey, out existingContext))
            {
                CodeFeatureState existingCode;
                if (existingContext.TryGetCodeFeatureState(codeFeatureId, out existingCode))
                {
                    if (existingCode.Enabled == update.Enabled)
                        return;

                    UpdateExistingCodeFeature(update, codeFeatureId, existingContext, existingCode);
                }
                else
                    AddCodeFeatureState(update, codeFeatureId, existingContext);
            }
            else
                AddContextFeatureState(update, codeFeatureId);
        }

        async Task<IContextFeatureStateCacheInstance<TContext>> LoadCache()
        {
            IEnumerable<Tuple<string, CodeFeatureState>> states = await _cacheProvider.Load();

            var contextCache = new InMemoryCache<string, ContextFeatureState>();
            foreach (var context in states.GroupBy(x => x.Item1))
            {
                var cache = new InMemoryCache<CodeFeatureId, CodeFeatureState>();
                foreach (CodeFeatureState state in context.Select(x => x.Item2))
                    cache.TryAdd(state.Id, state);

                contextCache.TryAdd(context.Key, new ContextFeatureStateImpl(cache, context.Key));
            }

            return new ContextFeatureStateCacheInstance<TContext>(contextCache);
        }

        void UpdateExistingCodeFeature(IUpdateContextCodeFeature update, CodeFeatureId codeFeatureId, ContextFeatureState existingContext,
            CodeFeatureState existingCode)
        {
            var featureState = new CodeFeatureStateImpl(codeFeatureId, update.Enabled);

            bool updated = existingContext.TryUpdate(codeFeatureId, featureState, existingCode);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void AddCodeFeatureState(IUpdateContextCodeFeature update, CodeFeatureId codeFeatureId, ContextFeatureState existingContext)
        {
            var featureState = new CodeFeatureStateImpl(codeFeatureId, update.Enabled);

            bool updated = existingContext.TryAdd(codeFeatureId, featureState);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void AddContextFeatureState(IUpdateContextCodeFeature update, CodeFeatureId codeFeatureId)
        {
            var featureState = new CodeFeatureStateImpl(codeFeatureId, update.Enabled);
            var cache = new InMemoryCache<CodeFeatureId, CodeFeatureState>();
            cache.TryAdd(codeFeatureId, featureState);
            var contextFeatureState = new ContextFeatureStateImpl(cache, update.ContextKey);

            bool updated = _cache.TryAdd(update.ContextKey, contextFeatureState);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void NotifyUpdated(IUpdateContextCodeFeature update, CodeFeatureStateImpl updatedFeatureState)
        {
            var updatedEvent = new ContextCodeFeatureStateCacheUpdated(update.ContextId, update.ContextKey, updatedFeatureState.Id,
                updatedFeatureState.Enabled, update.CommandId);

            _cacheUpdated.ForEach(x => x.OnNext(updatedEvent));
        }
    }
}