namespace Fooidity.Caching
{
    using System.Threading.Tasks;


    public interface IReloadCache
    {
        Task ReloadCache();
    }
}