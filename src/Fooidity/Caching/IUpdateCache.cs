namespace Fooidity.Caching
{
    public interface IUpdateCache<in TValue>
    {
        void UpdateCache(TValue value);
    }
}