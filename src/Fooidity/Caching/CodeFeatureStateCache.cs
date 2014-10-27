namespace Fooidity.Caching
{
    using System;
    using System.Threading;
    using Configuration;
    using Events;
    using Metadata;


    /// <summary>
    /// Caches the switch states
    /// </summary>
    public class CodeFeatureStateCache :
        ICodeFeatureStateCache,
        IReloadCache,
        IObservable<CodeFeatureStateCacheLoaded>,
        IUpdateCache<CodeFeatureStateUpdated>
    {
        readonly Connectable<IObserver<CodeFeatureStateCacheLoaded>> _cacheLoaded;
        readonly ICodeFeatureStateCacheProvider _cacheProvider;
        ICodeFeatureStateCacheInstance _cache;

        public CodeFeatureStateCache(ICodeFeatureStateCacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;

            _cacheLoaded = new Connectable<IObserver<CodeFeatureStateCacheLoaded>>();

            _cache = _cacheProvider.Load();
        }

        public bool TryGetState<TFeature>(out CodeFeatureState featureState)
        {
            if (_cache.Cache.TryGet(CodeFeatureMetadata<TFeature>.Id, out featureState))
                return true;

            if (_cache.DefaultState)
            {
                featureState = new DefaultCodeFeatureState<TFeature>(true);
                return true;
            }

            return false;
        }

        public IDisposable Subscribe(IObserver<CodeFeatureStateCacheLoaded> observer)
        {
            return _cacheLoaded.Connect(observer);
        }

        public void ReloadCache()
        {
            DateTime startTime = DateTime.UtcNow;
            ICodeFeatureStateCacheInstance cache = _cacheProvider.Load();
            DateTime endTime = DateTime.UtcNow;

            Interlocked.Exchange(ref _cache, cache);

            var loaded = new Loaded(startTime, endTime - startTime, cache.Cache.Values.Count);

            _cacheLoaded.ForEach(x => x.OnNext(loaded));
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