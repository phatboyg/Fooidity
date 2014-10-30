namespace Fooidity.Caching
{
    using System;
    using System.Threading;
    using Configuration;
    using Contracts;
    using Internals;
    using Metadata;


    /// <summary>
    /// Caches the switch states
    /// </summary>
    public class ContextFeatureStateCache<TContext> :
        IContextFeatureStateCache<TContext>,
        IReloadCache,
        IUpdateContextFeatureCache
    {
        readonly Connectable<IObserver<CodeFeatureStateCacheLoaded>> _cacheLoaded;
        readonly IContextFeatureStateCacheProvider<TContext> _cacheProvider;
        readonly ContextKeyProvider<TContext> _keyProvider;
        IContextFeatureStateCacheInstance<TContext> _cache;

        public ContextFeatureStateCache(IContextFeatureStateCacheProvider<TContext> cacheProvider,
            ContextKeyProvider<TContext> keyProvider)
        {
            _cacheProvider = cacheProvider;
            _keyProvider = keyProvider;

            _cacheLoaded = new Connectable<IObserver<CodeFeatureStateCacheLoaded>>();

            _cache = _cacheProvider.Load();
        }

        public bool TryGetContextFeatureState(TContext context, out ContextFeatureState featureState)
        {
            string key = _keyProvider.GetKey(context);

            return _cache.TryGetContextFeatureState(key, out featureState);
        }

        public void ReloadCache()
        {
            DateTime startTime = DateTime.UtcNow;
            IContextFeatureStateCacheInstance<TContext> cache = _cacheProvider.Load();
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
        }

        public IDisposable Subscribe(IObserver<CodeFeatureStateCacheLoaded> observer)
        {
            return _cacheLoaded.Connect(observer);
        }


        class Loaded :
            CodeFeatureStateCacheLoaded
        {
            readonly int _codeFeatureCount;
            readonly TimeSpan _duration;
            readonly Guid _eventId;
            readonly Host _host;
            readonly DateTime _timestamp;

            public Loaded(DateTime timestamp, TimeSpan duration, int codeFeatureCount)
            {
                _eventId = Guid.NewGuid();
                _timestamp = timestamp;
                _duration = duration;
                _codeFeatureCount = codeFeatureCount;
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

            public int CodeFeatureCount
            {
                get { return _codeFeatureCount; }
            }
        }
    }
}