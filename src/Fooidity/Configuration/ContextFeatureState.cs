namespace Fooidity.Configuration
{
    public interface ContextFeatureState
    {
        string Key { get; }

        bool TryGetCodeFeatureState(CodeFeatureId codeFeatureId, out CodeFeatureState featureState);

        /// <summary>
        /// Attempt to update the code feature state to the new value
        /// </summary>
        /// <param name="codeFeatureId"></param>
        /// <param name="updated"></param>
        /// <param name="existing"></param>
        /// <returns></returns>
        bool TryUpdate(CodeFeatureId codeFeatureId, CodeFeatureState updated, CodeFeatureState existing);

        /// <summary>
        /// Try to add a new code feature state to the context
        /// </summary>
        /// <param name="codeFeatureId"></param>
        /// <param name="featureState"></param>
        /// <returns></returns>
        bool TryAdd(CodeFeatureId codeFeatureId, CodeFeatureState featureState);
    }
}