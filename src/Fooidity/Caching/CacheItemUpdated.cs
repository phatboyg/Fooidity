namespace Fooidity.Caching
{
    /// <summary>
    /// Signals an item in the cache was updated
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface CacheItemUpdated<out TValue>
    {
        TValue Value { get; }
    }
}