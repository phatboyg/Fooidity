namespace Fooidity.Caching
{
    using Configuration;


    public interface IContextFeatureStateCacheInstance<in TContext>
    {
        /// <summary>
        /// The number of context entries in the cache
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Return the context entry feature states if present
        /// </summary>
        /// <param name="key"></param>
        /// <param name="featureState"></param>
        /// <returns></returns>
        bool TryGetContextFeatureState(string key, out ContextFeatureState featureState);
    }
}