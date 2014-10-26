namespace Fooidity.Caching
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    ///     Provides an index to items in a cache, using the key provider of the index
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TIndex"></typeparam>
    public class InMemoryCacheIndex<TKey, TValue, TIndex> :
        ICacheIndex<TIndex, TValue>,
        IObserver<CacheItemAdded<TValue>>,
        IObserver<CacheItemRemoved<TValue>>,
        IObserver<CacheItemUpdated<TValue>>
    {
        readonly IDisposable _added;
        readonly IReadOnlyCache<TKey, TValue> _cache;
        readonly ICache<TIndex, TValue> _index;
        readonly Func<TValue, TIndex> _keyProvider;
        readonly IDisposable _removed;
        readonly IDisposable _updated;

        public InMemoryCacheIndex(IReadOnlyCache<TKey, TValue> cache, ICache<TIndex, TValue> index,
            Func<TValue, TIndex> keyProvider)
        {
            _index = index;
            _keyProvider = keyProvider;

            _cache = cache;
            _added = _cache.Subscribe((IObserver<CacheItemAdded<TValue>>)this);
            _removed = _cache.Subscribe((IObserver<CacheItemRemoved<TValue>>)this);
            _updated = _cache.Subscribe((IObserver<CacheItemUpdated<TValue>>)this);
        }

        public ICollection<TValue> Values
        {
            get { return _index.Values; }
        }

        public bool Contains(TIndex key)
        {
            return _index.Contains(key);
        }

        public bool ContainsValue(TValue value)
        {
            return _index.ContainsValue(value);
        }

        public bool Exists(Func<TValue, bool> predicate)
        {
            return _index.Exists(predicate);
        }

        public bool Find(Func<TValue, bool> predicate, out TValue value)
        {
            return _index.Find(predicate, out value);
        }

        public bool TryGet(TIndex key, out TValue value)
        {
            return _index.TryGet(key, out value);
        }

        public ICacheIndex<T, TValue> GetIndex<T>(Func<TValue, T> keyProvider)
        {
            return _cache.GetIndex(keyProvider);
        }

        public IDisposable Subscribe(IObserver<CacheItemAdded<TValue>> observer)
        {
            return _index.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<CacheItemRemoved<TValue>> observer)
        {
            return _index.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<CacheItemUpdated<TValue>> observer)
        {
            return _index.Subscribe(observer);
        }

        public void Dispose()
        {
            _added.Dispose();
            _removed.Dispose();
            _updated.Dispose();
        }

        void IObserver<CacheItemAdded<TValue>>.OnNext(CacheItemAdded<TValue> value)
        {
            TIndex key = _keyProvider(value.Value);

            _index.TryAdd(key, value.Value);
        }

        void IObserver<CacheItemRemoved<TValue>>.OnNext(CacheItemRemoved<TValue> value)
        {
            TIndex key = _keyProvider(value.Value);

            _index.TryRemove(key);
        }

        void IObserver<CacheItemUpdated<TValue>>.OnNext(CacheItemUpdated<TValue> value)
        {
            TIndex key = _keyProvider(value.Value);

            TValue existing;
            if (_index.TryGet(key, out existing))
                _index.TryUpdate(key, value.Value, existing);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
    }
}