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
        bool TryGetState(CodeFeatureId id, out CodeFeatureState featureState);

        /// <summary>
        /// Add/Update an existing feature state to the specified value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="featureState"></param>
        /// <param name="previousFeatureState"></param>
        bool TryUpdate(CodeFeatureId id, CodeFeatureState featureState, CodeFeatureState previousFeatureState);

        /// <summary>
        /// Add a new feature state
        /// </summary>
        /// <param name="id"></param>
        /// <param name="featureState"></param>
        /// <returns></returns>
        bool TryAdd(CodeFeatureId id, CodeFeatureState featureState);
    }
}