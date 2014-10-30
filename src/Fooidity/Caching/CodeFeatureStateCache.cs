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
    public class CodeFeatureStateCache :
        ICodeFeatureStateCache,
        IReloadCache,
        IUpdateCodeFeatureCache,
        IObservable<CodeFeatureStateCacheLoaded>,
        IObservable<CodeFeatureStateCacheUpdated>
    {
        readonly Connectable<IObserver<CodeFeatureStateCacheLoaded>> _cacheLoaded;
        readonly ICodeFeatureStateCacheProvider _cacheProvider;
        readonly Connectable<IObserver<CodeFeatureStateCacheUpdated>> _cacheUpdated;
        ICodeFeatureStateCacheInstance _cache;

        public CodeFeatureStateCache(ICodeFeatureStateCacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;

            _cacheLoaded = new Connectable<IObserver<CodeFeatureStateCacheLoaded>>();
            _cacheUpdated = new Connectable<IObserver<CodeFeatureStateCacheUpdated>>();

            _cache = _cacheProvider.Load();
        }

        public bool TryGetState<TFeature>(out CodeFeatureState featureState)
        {
            if (_cache.TryGetState(CodeFeatureMetadata<TFeature>.Id, out featureState))
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

        public IDisposable Subscribe(IObserver<CodeFeatureStateCacheUpdated> observer)
        {
            return _cacheUpdated.Connect(observer);
        }

        public void ReloadCache()
        {
            DateTime startTime = DateTime.UtcNow;
            ICodeFeatureStateCacheInstance cache = _cacheProvider.Load();
            DateTime endTime = DateTime.UtcNow;

            Interlocked.Exchange(ref _cache, cache);

            var loaded = new Loaded(startTime, endTime - startTime, cache.Count);

            _cacheLoaded.ForEach(x => x.OnNext(loaded));
        }

        public void UpdateCache(UpdateCodeFeature update)
        {
            CodeFeatureId codeFeatureId = update.CodeFeatureId;

            CodeFeatureState existingFeatureState;
            if (_cache.TryGetState(codeFeatureId, out existingFeatureState))
            {
                if (existingFeatureState.Enabled == update.Enabled)
                    return;

                var updatedFeatureState = new UpdatedCodeFeatureState(codeFeatureId, update.Enabled);

                DateTime startTime = DateTime.UtcNow;
                bool updated = _cache.TryUpdate(codeFeatureId, updatedFeatureState, existingFeatureState);
                DateTime endTime = DateTime.UtcNow;

                if (updated)
                {
                    var updatedEvent = new Updated(startTime, endTime - startTime, updatedFeatureState.Id, updatedFeatureState.Enabled,
                        update.CommandId);

                    _cacheUpdated.ForEach(x => x.OnNext(updatedEvent));
                }
            }
            else
            {
                var featureState = new UpdatedCodeFeatureState(codeFeatureId, update.Enabled);

                DateTime startTime = DateTime.UtcNow;
                bool updated = _cache.TryAdd(codeFeatureId, featureState);
                DateTime endTime = DateTime.UtcNow;

                if (updated)
                {
                    var updatedEvent = new Updated(startTime, endTime - startTime, featureState.Id, featureState.Enabled, update.CommandId);

                    _cacheUpdated.ForEach(x => x.OnNext(updatedEvent));
                }
            }
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

            public Host Host
            {
                get { return _host; }
            }
        }


        class Updated :
            CodeFeatureStateCacheUpdated
        {
            readonly Uri _codeFeatureId;
            readonly Guid? _commandId;
            readonly TimeSpan _duration;
            readonly bool _enabled;
            readonly Guid _eventId;
            readonly Host _host;
            readonly DateTime _timestamp;

            public Updated(DateTime timestamp, TimeSpan duration, CodeFeatureId codeFeatureId, bool enabled, Guid? commandId = null)
            {
                _eventId = Guid.NewGuid();
                _timestamp = timestamp;
                _duration = duration;
                _codeFeatureId = codeFeatureId;
                _enabled = enabled;
                _commandId = commandId;
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

            public Guid? CommandId
            {
                get { return _commandId; }
            }

            public TimeSpan Duration
            {
                get { return _duration; }
            }

            public Uri CodeFeatureId
            {
                get { return _codeFeatureId; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }


        class UpdatedCodeFeatureState :
            CodeFeatureState
        {
            readonly bool _enabled;
            readonly CodeFeatureId _id;

            public UpdatedCodeFeatureState(CodeFeatureId id, bool enabled)
            {
                _id = id;
                _enabled = enabled;
            }

            public CodeFeatureId Id
            {
                get { return _id; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}