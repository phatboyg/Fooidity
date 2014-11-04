namespace Fooidity.Caching
{
    public interface ICachedContextFeatureState
    {
        string Key { get; }

        bool TryGetCodeFeatureState(CodeFeatureId codeFeatureId, out ICachedCodeFeatureState featureState);

        /// <summary>
        /// Attempt to update the code feature state to the new value
        /// </summary>
        /// <param name="codeFeatureId"></param>
        /// <param name="updated"></param>
        /// <param name="existing"></param>
        /// <returns></returns>
        bool TryUpdate(CodeFeatureId codeFeatureId, ICachedCodeFeatureState updated, ICachedCodeFeatureState existing);

        /// <summary>
        /// Try to add a new code feature state to the context
        /// </summary>
        /// <param name="codeFeatureId"></param>
        /// <param name="featureState"></param>
        /// <returns></returns>
        bool TryAdd(CodeFeatureId codeFeatureId, ICachedCodeFeatureState featureState);
    }
}