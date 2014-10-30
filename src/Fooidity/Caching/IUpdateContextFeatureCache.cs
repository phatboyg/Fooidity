namespace Fooidity.Caching
{
    /// <summary>
    /// Update a cache using the supplied type argument
    /// </summary>
    public interface IUpdateContextFeatureCache
    {
        void UpdateCache(UpdateContextCodeFeature update);
    }
}