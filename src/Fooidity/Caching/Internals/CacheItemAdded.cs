namespace Fooidity.Caching.Internals
{
    /// <summary>
    /// Signals an item was added to the cache
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    interface CacheItemAdded<out TValue>
    {
        TValue Value { get; }
    }
}