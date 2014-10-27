namespace Fooidity.Caching
{
    using Configuration;


    public interface ICodeFeatureStateCacheInstance
    {
        /// <summary>
        /// The default state for a feature if the feature is not explicitly configured
        /// </summary>
        bool DefaultState { get; }

        /// <summary>
        /// The number of feature states in the cache
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Return the feature state from the cache if present
        /// </summary>
        /// <param name="id"></param>
        /// <param name="featureState"></param>
        /// <returns></returns>
        bool TryGetState(string id, out CodeFeatureState featureState);
    }
}