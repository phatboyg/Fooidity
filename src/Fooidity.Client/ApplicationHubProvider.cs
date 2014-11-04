namespace Fooidity.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Caching;
    using Contracts;
    using Microsoft.AspNet.SignalR.Client;


    public class ApplicationHubProvider :
        ICodeFeatureStateCacheProvider
    {
        readonly IHubProxy _applicationHub;

        public ApplicationHubProvider(IHubProxy applicationHub)
        {
            _applicationHub = applicationHub;
        }

        public async Task<bool> GetDefaultState()
        {
            return false;
        }

        public async Task<IEnumerable<Caching.ICachedCodeFeatureState>> Load()
        {
            Console.WriteLine("Getting code feature states");

            IEnumerable<CodeFeatureState> initialCodeFeatureStates =
                await _applicationHub.Invoke<IEnumerable<CodeFeatureState>>("GetCodeFeatureStates");

            Console.WriteLine("Got them!");

            return initialCodeFeatureStates.Select(x => new CodeFeatureStateImpl(new CodeFeatureId(x.CodeFeatureId), x.Enabled));
        }


        class CodeFeatureStateImpl :
            Caching.ICachedCodeFeatureState
        {
            readonly bool _enabled;
            readonly CodeFeatureId _id;

            public CodeFeatureStateImpl(CodeFeatureId id, bool enabled)
            {
                _enabled = enabled;
                _id = id;
            }

            public CodeFeatureId Id
            {
                get { return _id; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}