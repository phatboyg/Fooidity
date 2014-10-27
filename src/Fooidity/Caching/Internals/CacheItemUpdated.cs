namespace Fooidity.Caching.Internals
{
    /// <summary>
    /// Signals an item in the cache was updated
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    interface CacheItemUpdated<out TValue>
    {
        TValue Value { get; }
    }
}