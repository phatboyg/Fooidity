namespace Fooidity.Caching
{
    /// <summary>
    /// A cache of objects with the primary index of type TKey
    /// </summary>
    /// <typeparam name="TKey">The primary index type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public interface ICache<in TKey, TValue> :
        IReadOnlyCache<TKey, TValue>
    {
        bool TryAdd(TKey key, TValue value);

        bool TryRemove(TKey key);

        bool TryUpdate(TKey key, TValue value, TValue previousValue);
    }
}