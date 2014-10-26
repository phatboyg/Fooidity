namespace Fooidity.Caching
{
    using System;


    public interface ICodeFeatureStateCacheInstance
    {
        IReadOnlyCache<string, CodeFeatureState> Cache { get; }
        ICacheIndex<Type, CodeFeatureState> TypeIndex { get; }

        /// <summary>
        /// The default state for a feature if the feature is not explicitly configured
        /// </summary>
        bool DefaultState { get; }
    }
}