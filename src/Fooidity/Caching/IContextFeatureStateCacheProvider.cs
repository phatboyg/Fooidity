namespace Fooidity.Caching
{
    public interface IContextFeatureStateCacheProvider<TContext>
    {
        IContextFeatureStateCacheInstance<TContext> Load();
    }
}