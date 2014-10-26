namespace Fooidity
{
    using System;


    /// <summary>
    /// The state of a switch in the switch cache
    /// </summary>
    public interface CodeFeatureState
    {
        /// <summary>
        /// The switch Id, which is a URN formatted string based on the feature type
        /// </summary>
        string Id { get; }

        /// <summary>
        /// The feature Type
        /// </summary>
        Type FeatureType { get; }

        /// <summary>
        /// The current state of the switch
        /// </summary>
        bool Enabled { get; }
    }
}