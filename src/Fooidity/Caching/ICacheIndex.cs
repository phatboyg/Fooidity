namespace Fooidity.Caching
{
    using System;


    /// <summary>
    /// An index to a cache for quick access to items
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface ICacheIndex<in TKey, TValue> :
        IReadOnlyCache<TKey, TValue>,
        IDisposable
    {
    }
}