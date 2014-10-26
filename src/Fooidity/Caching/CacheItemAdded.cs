namespace Fooidity.Caching
{
    /// <summary>
    /// Signals an item was added to the cache
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface CacheItemAdded<out TValue>
    {
        TValue Value { get; }
    }
}