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
        IObservable<ContextCodeFeatureStateCacheLoaded>,
        IObservable<ContextCodeFeatureStateCacheUpdated>
    {
        readonly Connectable<IObserver<ContextCodeFeatureStateCacheLoaded>> _cacheLoaded;
        readonly IContextFeatureStateCacheProvider<TContext> _cacheProvider;
        readonly Connectable<IObserver<ContextCodeFeatureStateCacheUpdated>> _cacheUpdated;
        readonly ContextKeyProvider<TContext> _keyProvider;
        IContextFeatureStateCacheInstance<TContext> _cache;

        public ContextFeatureStateCache(IContextFeatureStateCacheProvider<TContext> cacheProvider,
            ContextKeyProvider<TContext> keyProvider)
        {
            _cacheProvider = cacheProvider;
            _keyProvider = keyProvider;

            _cacheLoaded = new Connectable<IObserver<ContextCodeFeatureStateCacheLoaded>>();
            _cacheUpdated = new Connectable<IObserver<ContextCodeFeatureStateCacheUpdated>>();

            _cache = LoadCache().Result;
        }

        public bool TryGetContextFeatureState(TContext context, out ContextFeatureState featureState)
        {
            string key = _keyProvider.GetKey(context);

            return _cache.TryGetContextFeatureState(key, out featureState);
        }

        public IDisposable Subscribe(IObserver<ContextCodeFeatureStateCacheLoaded> observer)
        {
            return _cacheLoaded.Connect(observer);
        }

        public IDisposable Subscribe(IObserver<ContextCodeFeatureStateCacheUpdated> observer)
        {
            return _cacheUpdated.Connect(observer);
        }

        public async Task ReloadCache()
        {
            DateTime startTime = DateTime.UtcNow;
            IContextFeatureStateCacheInstance<TContext> cache = await LoadCache();
            DateTime endTime = DateTime.UtcNow;

            Interlocked.Exchange(ref _cache, cache);

            var loaded = new Loaded(startTime, endTime - startTime, cache.Count);

            _cacheLoaded.ForEach(x => x.OnNext(loaded));
        }

        public void UpdateCache(UpdateContextCodeFeature update)
        {
            // ignore updates that aren't for this cache instance
            if (update.ContextId != ContextMetadata<TContext>.Id)
                return;

            CodeFeatureId codeFeatureId = update.CodeFeatureId;

            ContextFeatureState existingContext;
            if (_cache.TryGetContextFeatureState(update.Key, out existingContext))
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

        void UpdateExistingCodeFeature(UpdateContextCodeFeature update, CodeFeatureId codeFeatureId, ContextFeatureState existingContext,
            CodeFeatureState existingCode)
        {
            var featureState = new CodeFeatureStateImpl(codeFeatureId, update.Enabled);

            bool updated = existingContext.TryUpdate(codeFeatureId, featureState, existingCode);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void AddCodeFeatureState(UpdateContextCodeFeature update, CodeFeatureId codeFeatureId, ContextFeatureState existingContext)
        {
            var featureState = new CodeFeatureStateImpl(codeFeatureId, update.Enabled);

            bool updated = existingContext.TryAdd(codeFeatureId, featureState);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void AddContextFeatureState(UpdateContextCodeFeature update, CodeFeatureId codeFeatureId)
        {
            var featureState = new CodeFeatureStateImpl(codeFeatureId, update.Enabled);
            var cache = new InMemoryCache<CodeFeatureId, CodeFeatureState>();
            cache.TryAdd(codeFeatureId, featureState);
            var contextFeatureState = new ContextFeatureStateImpl(cache, update.Key);

            bool updated = _cache.TryAdd(update.Key, contextFeatureState);
            if (updated)
                NotifyUpdated(update, featureState);
        }

        void NotifyUpdated(UpdateContextCodeFeature update, CodeFeatureStateImpl updatedFeatureState)
        {
            var updatedEvent = new Updated(update.CommandId, update.ContextId, update.Key,
                updatedFeatureState.Id, updatedFeatureState.Enabled);

            _cacheUpdated.ForEach(x => x.OnNext(updatedEvent));
        }


        class Loaded :
            ContextCodeFeatureStateCacheLoaded
        {
            readonly int _contextCount;
            readonly TimeSpan _duration;
            readonly Guid _eventId;
            readonly Host _host;
            readonly DateTime _timestamp;

            public Loaded(DateTime timestamp, TimeSpan duration, int contextCount)
            {
                _eventId = Guid.NewGuid();
                _timestamp = timestamp;
                _duration = duration;
                _contextCount = contextCount;
                _host = HostMetadata.Host;
            }

            public Host Host
            {
                get { return _host; }
            }

            public Guid EventId
            {
                get { return _eventId; }
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public TimeSpan Duration
            {
                get { return _duration; }
            }

            public int ContextCount
            {
                get { return _contextCount; }
            }
        }


        class Updated :
            ContextCodeFeatureStateCacheUpdated
        {
            readonly Uri _codeFeatureId;
            readonly Guid? _commandId;
            readonly Uri _contextId;
            readonly string _contextKey;
            readonly TimeSpan _duration;
            readonly bool _enabled;
            readonly Guid _eventId;
            readonly Host _host;
            readonly DateTime _timestamp;

            public Updated(Guid? commandId, Uri contextId, string contextKey, Uri codeFeatureId,
                bool enabled)
            {
                _eventId = Guid.NewGuid();
                _timestamp = DateTime.UtcNow;
                _duration = TimeSpan.Zero;
                _commandId = commandId;
                _contextId = contextId;
                _contextKey = contextKey;
                _codeFeatureId = codeFeatureId;
                _enabled = enabled;
                _host = HostMetadata.Host;
            }

            public bool Enabled
            {
                get { return _enabled; }
            }

            public Host Host
            {
                get { return _host; }
            }

            public Guid EventId
            {
                get { return _eventId; }
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public TimeSpan Duration
            {
                get { return _duration; }
            }

            public Guid? CommandId
            {
                get { return _commandId; }
            }

            public Uri ContextId
            {
                get { return _contextId; }
            }

            public string ContextKey
            {
                get { return _contextKey; }
            }

            public Uri CodeFeatureId
            {
                get { return _codeFeatureId; }
            }
        }
    }
}