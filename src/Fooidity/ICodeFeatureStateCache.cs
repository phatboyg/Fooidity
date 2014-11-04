namespace Fooidity
{
    using Caching;


    /// <summary>
    /// A cache of switches and their states
    /// </summary>
    public interface ICodeFeatureStateCache
    {
        /// <summary>
        /// Return the cached feature state, if available
        /// </summary>
        /// <typeparam name="TFeature"></typeparam>
        /// <param name="featureState"></param>
        /// <returns></returns>
        bool TryGetState<TFeature>(out ICachedCodeFeatureState featureState);
    }
}