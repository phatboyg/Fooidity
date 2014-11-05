namespace Fooidity.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Caching;
    using Contracts;


    public class ApplicationHubCodeFeatureStateCacheProvider :
        ICodeFeatureStateCacheProvider
    {
        readonly IApplicationHubProxy _proxy;

        public ApplicationHubCodeFeatureStateCacheProvider(IApplicationHubProxy proxy)
        {
            _proxy = proxy;
        }

        public async Task<bool> GetDefaultState()
        {
            return false;
        }

        public async Task<IEnumerable<ICachedCodeFeatureState>> Load()
        {
            try
            {
                IEnumerable<CodeFeatureState> states =
                    await _proxy.UseProxy(x => x.Invoke<IEnumerable<CodeFeatureState>>("GetCodeFeatureStates"));

                return states.Select(x => new CachedCodeFeatureState(x.CodeFeatureId, x.Enabled));
            }
            catch (Exception ex)
            {
                throw new CacheProviderSourceException("The code feature cache source was unavailable", ex);
            }
        }
    }
}