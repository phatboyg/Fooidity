namespace Fooidity.Management.Web.Models
{
    using System;


    /// <summary>
    /// A code feature is defined in the system by identifier and identifies
    /// a feature that can be switched.
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Identifies the CodeFeature, generated from the code feature's Type
        /// </summary>
        public Uri CodeFeatureId { get; set; }

        /// <summary>
        /// True if the feature is enabled, otherwise false.
        /// </summary>
        public bool Enabled { get; set; }
    }
}