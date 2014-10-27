namespace Fooidity.Caching
{
    using System;
    using System.Threading;
    using Configuration;
    using Events;


    /// <summary>
    /// Caches the switch states
    /// </summary>
    public class ContextFeatureStateCache<TContext> :
        IContextFeatureStateCache<TContext>,
        IReloadCache
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

        public bool TryGetState(TContext context, out ContextFeatureState featureState)
        {
            string key = _keyProvider.GetKey(context);

            return _cache.Cache.TryGet(key, out featureState);
        }

        public void ReloadCache()
        {
            DateTime startTime = DateTime.UtcNow;
            IContextFeatureStateCacheInstance<TContext> cache = _cacheProvider.Load();
            DateTime endTime = DateTime.UtcNow;

            Interlocked.Exchange(ref _cache, cache);

            var loaded = new Loaded(startTime, endTime - startTime, cache.Cache.Values.Count);

            _cacheLoaded.ForEach(x => x.OnNext(loaded));
        }

        public IDisposable Subscribe(IObserver<CodeFeatureStateCacheLoaded> observer)
        {
            return _cacheLoaded.Connect(observer);
        }

        public void UpdateCache(CodeFeatureStateUpdated value)
        {
            throw new NotImplementedException("The update hasn't been built yet but it's coming");
        }


        class Loaded :
            CodeFeatureStateCacheLoaded
        {
            readonly int _count;
            readonly TimeSpan _duration;
            readonly DateTime _timestamp;

            public Loaded(DateTime timestamp, TimeSpan duration, int count)
            {
                _timestamp = timestamp;
                _duration = duration;
                _count = count;
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public TimeSpan Duration
            {
                get { return _duration; }
            }

            public int Count
            {
                get { return _count; }
            }
        }
    }
}