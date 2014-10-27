namespace Fooidity.Caching
{
    using Configuration;


    public interface IContextFeatureStateCacheInstance<in TContext>
    {
        IReadOnlyCache<string, ContextFeatureState> Cache { get; }
    }
}