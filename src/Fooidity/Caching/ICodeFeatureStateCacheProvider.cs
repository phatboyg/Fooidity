namespace Fooidity.Caching
{
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface ICodeFeatureStateCacheProvider
    {
        /// <summary>
        /// Returns the default state for code features
        /// </summary>
        Task<bool> GetDefaultState();

        /// <summary>
        /// Loads an enumeration of code feature states
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ICachedCodeFeatureState>> Load();
    }
}