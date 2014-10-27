namespace Fooidity.Caching.Internals
{
    /// <summary>
    /// Signals an item was removed from the cache
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    interface CacheItemRemoved<out TValue>
    {
        TValue Value { get; }
    }
}