namespace Fooidity.Caching
{
    using Contracts;


    /// <summary>
    /// Update a cache using the supplied type argument
    /// </summary>
    public interface IUpdateContextFeatureCache
    {
        void UpdateCache(IUpdateContextCodeFeature update);
    }
}