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
        readonly IContextKeyProvider<TContext> _keyProvider;
        IContextFeatureStateCacheInstance<TContext> _cache;

        public ContextFeatureStateCache(IContextFeatureStateCacheProvider<TContext> cacheProvider,
            IContextKeyProvider<TContext> keyProvider)
        {
            _cacheProvider = cacheProvider;
            _keyProvider = keyProvider;

            _cacheLoaded = new Connectable<IObserver<IContextCodeFeatureStateCacheLoaded>>();
            _cacheUpdated = new Connectable<IObserver<IContextCodeFeatureStateCacheUpdated>>();

            _cache = Task.Run(async () => await LoadCache()).Result;
        }

        public bool TryGetContextFeatureState(TContext context, out ICachedContextFeatureState featureState)
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

            ICachedContextFeatureState existingContext;
            if (_cache.TryGetContextFeatureState(update.ContextKey, out existingContext))
            {
                ICachedCodeFeatureState existingCode;
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
            IEnumerable<Tuple<string, ICachedCodeFeatureState>> states = await _cacheProvider.Load();

            var contextCache = new InMemoryCache<string, ICachedContextFeatureState>();
            foreach (var context in states.GroupBy(x => x.Item1))
                contextCache.TryAdd(context.Key, new CachedContextFeatureState(context.Select(x => x.Item2), context.Key));

            return new ContextFeatureStateCacheInstance<TContext>(contextCache);
        }

        void UpdateExistingCodeFeature(IUpdateContextCodeFeature update, CodeFeatureId codeFeatureId,
            ICachedContextFeatureState existingContext,
            ICachedCodeFeatureState existingCode)
        {
            var featureState = new CachedCodeFeatureState(codeFeatureId, update.Enabled);

            bool updated = existingContext.TryUpdate(codeFeatureId, featureState, existingCode);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void AddCodeFeatureState(IUpdateContextCodeFeature update, CodeFeatureId codeFeatureId, ICachedContextFeatureState existingContext)
        {
            var featureState = new CachedCodeFeatureState(codeFeatureId, update.Enabled);

            bool updated = existingContext.TryAdd(codeFeatureId, featureState);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void AddContextFeatureState(IUpdateContextCodeFeature update, CodeFeatureId codeFeatureId)
        {
            var featureState = new CachedCodeFeatureState(codeFeatureId, update.Enabled);
            var contextFeatureState = new CachedContextFeatureState(Enumerable.Repeat(featureState, 1), update.ContextKey);

            bool updated = _cache.TryAdd(update.ContextKey, contextFeatureState);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void NotifyUpdated(IUpdateContextCodeFeature update, ICachedCodeFeatureState updatedFeatureState)
        {
            var updatedEvent = new ContextCodeFeatureStateCacheUpdated(update.ContextId, update.ContextKey, updatedFeatureState.Id,
                updatedFeatureState.Enabled, update.CommandId);

            _cacheUpdated.ForEach(x => x.OnNext(updatedEvent));
        }
    }
}