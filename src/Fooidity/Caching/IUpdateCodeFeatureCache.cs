namespace Fooidity.Caching
{
    using Contracts;


    /// <summary>
    /// Update a cache using the supplied type argument
    /// </summary>
    public interface IUpdateCodeFeatureCache
    {
        void UpdateCache(IUpdateCodeFeature update);
    }
}