namespace Fooidity.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IContextFeatureStateCacheProvider<in TContext>
    {
        Task<IEnumerable<Tuple<string, ICachedCodeFeatureState>>> Load();
    }
}