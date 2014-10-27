namespace Fooidity.Caching
{
    public interface IContextFeatureStateCacheProvider<in TContext>
    {
        IContextFeatureStateCacheInstance<TContext> Load();
    }
}