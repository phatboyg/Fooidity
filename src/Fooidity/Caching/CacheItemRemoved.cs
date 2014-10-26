namespace Fooidity.Caching
{
    /// <summary>
    /// Signals an item was removed from the cache
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface CacheItemRemoved<out TValue>
    {
        TValue Value { get; }
    }
}