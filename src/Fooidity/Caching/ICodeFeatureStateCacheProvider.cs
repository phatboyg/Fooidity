namespace Fooidity.Caching
{
    public interface ICodeFeatureStateCacheProvider
    {
        ICodeFeatureStateCacheInstance Load();
    }
}