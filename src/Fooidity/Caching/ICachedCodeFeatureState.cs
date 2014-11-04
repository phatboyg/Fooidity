namespace Fooidity.Caching
{
    /// <summary>
    /// The state of a code feature, typically loaded from a configuration source
    /// </summary>
    public interface ICachedCodeFeatureState
    {
        /// <summary>
        /// The switch Id, which is a URN formatted string based on the feature type
        /// </summary>
        CodeFeatureId Id { get; }

        /// <summary>
        /// The state of the switch
        /// </summary>
        bool Enabled { get; }
    }
}