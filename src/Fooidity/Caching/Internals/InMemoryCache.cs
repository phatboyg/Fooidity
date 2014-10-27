namespace Fooidity.Caching.Internals
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;


    class InMemoryCache<TKey, TValue> :
        ICache<TKey, TValue>
    {
        readonly Connectable<IObserver<CacheItemAdded<TValue>>> _added;
        readonly object _mutateLock = new object();
        readonly Connectable<IObserver<CacheItemRemoved<TValue>>> _removed;
        readonly Connectable<IObserver<CacheItemUpdated<TValue>>> _updated;
        readonly ConcurrentDictionary<TKey, TValue> _values;

        public InMemoryCache()
        {
            _added = new Connectable<IObserver<CacheItemAdded<TValue>>>();
            _removed = new Connectable<IObserver<CacheItemRemoved<TValue>>>();
            _updated = new Connectable<IObserver<CacheItemUpdated<TValue>>>();

            _values = new ConcurrentDictionary<TKey, TValue>();
        }

        public ICollection<TValue> Values
        {
            get { return _values.Values; }
        }

        public IDisposable Subscribe(IObserver<CacheItemAdded<TValue>> observer)
        {
            return _added.Connect(observer);
        }

        public IDisposable Subscribe(IObserver<CacheItemRemoved<TValue>> observer)
        {
            return _removed.Connect(observer);
        }

        public IDisposable Subscribe(IObserver<CacheItemUpdated<TValue>> observer)
        {
            return _updated.Connect(observer);
        }

        public bool Contains(TKey key)
        {
            return _values.ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            return _values.Values.Any(x => x.Equals(value));
        }

        public bool Exists(Func<TValue, bool> predicate)
        {
            return _values.Values.Any(predicate);
        }

        public bool Find(Func<TValue, bool> predicate, out TValue value)
        {
            foreach (TValue candidate in _values.Values)
            {
                if (predicate(candidate))
                {
                    value = candidate;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        public bool TryGet(TKey key, out TValue value)
        {
            return _values.TryGetValue(key, out value);
        }

        public ICacheIndex<TIndex, TValue> GetIndex<TIndex>(Func<TValue, TIndex> keyProvider)
        {
            var indexCache = new InMemoryCache<TIndex, TValue>();

            lock (_mutateLock)
            {
                foreach (TValue value in _values.Values)
                    indexCache.TryAdd(keyProvider(value), value);

                return new InMemoryCacheIndex<TKey, TValue, TIndex>(this, indexCache, keyProvider);
            }
        }


        public bool TryAdd(TKey key, TValue value)
        {
            bool added;
            lock (_mutateLock)
            {
                added = _values.TryAdd(key, value);
            }

            if (added)
            {
                var itemAdded = new CacheItemAddedImpl(value);

                _added.ForEach(x => x.OnNext(itemAdded));
            }

            return added;
        }

        public bool TryRemove(TKey key)
        {
            TValue value;
            bool removed;
            lock (_mutateLock)
            {
                removed = _values.TryRemove(key, out value);
            }

            if (removed)
            {
                var itemRemoved = new CacheItemRemovedImpl(value);
                _removed.ForEach(x => x.OnNext(itemRemoved));
            }

            return removed;
        }

        public bool TryUpdate(TKey key, TValue value, TValue previousValue)
        {
            bool updated;
            lock (_mutateLock)
            {
                updated = _values.TryUpdate(key, value, previousValue);
            }

            if (updated)
            {
                var itemUpdated = new CacheItemUpdatedImpl(value);
                _updated.ForEach(x => x.OnNext(itemUpdated));
            }

            return updated;
        }


        class CacheItemAddedImpl :
            CacheItemAdded<TValue>
        {
            public CacheItemAddedImpl(TValue value)
            {
                Value = value;
            }

            public TValue Value { get; private set; }
        }


        class CacheItemRemovedImpl :
            CacheItemRemoved<TValue>
        {
            public CacheItemRemovedImpl(TValue value)
            {
                Value = value;
            }

            public TValue Value { get; private set; }
        }


        public class CacheItemUpdatedImpl :
            CacheItemUpdated<TValue>
        {
            public CacheItemUpdatedImpl(TValue value)
            {
                Value = value;
            }

            public TValue Value { get; private set; }
        }
    }
}