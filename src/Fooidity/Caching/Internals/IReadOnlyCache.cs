namespace Fooidity.Caching.Internals
{
    using System;
    using System.Collections.Generic;


    interface IReadOnlyCache<in TKey, TValue> :
        IObservable<CacheItemAdded<TValue>>,
        IObservable<CacheItemRemoved<TValue>>,
        IObservable<CacheItemUpdated<TValue>>
    {
        ICollection<TValue> Values { get; }
        bool Contains(TKey key);
        bool ContainsValue(TValue value);

        bool Exists(Func<TValue, bool> predicate);

        bool Find(Func<TValue, bool> predicate, out TValue value);

        bool TryGet(TKey key, out TValue value);

        ICacheIndex<T, TValue> GetIndex<T>(Func<TValue, T> keyProvider);
    }
}