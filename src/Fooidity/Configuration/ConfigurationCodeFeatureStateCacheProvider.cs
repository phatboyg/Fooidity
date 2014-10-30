namespace Fooidity.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading.Tasks;
    using Caching;


    public class ConfigurationCodeFeatureStateCacheProvider :
        ICodeFeatureStateCacheProvider
    {
        public async Task<IEnumerable<CodeFeatureState>> Load()
        {
            var codeFeatureStates = new List<CodeFeatureState>();

            var configuration = ConfigurationManager.GetSection("fooidity") as FooidityConfiguration;
            if (configuration != null)
            {
                if (configuration.Features != null)
                {
                    for (int i = 0; i < configuration.Features.Count; i++)
                    {
                        FeatureStateElement feature = configuration.Features[i];

                        var featureId = new CodeFeatureId(feature.Id);

                        Type codeFeatureType = featureId.GetType(false);
                        if (codeFeatureType == null)
                            throw new ConfigurationErrorsException("The feature type is not valid: " + feature.Id);

                        var state = new FeatureState(featureId, feature.Enabled);

                        codeFeatureStates.Add(state);
                    }
                }
            }

            return codeFeatureStates;
        }

        public async Task<bool> GetDefaultState()
        {
            bool defaultState = false;

            var configuration = ConfigurationManager.GetSection("fooidity") as FooidityConfiguration;
            if (configuration != null)
                defaultState = configuration.DefaultState;

            return defaultState;
        }


        class FeatureState :
            CodeFeatureState
        {
            readonly bool _enabled;
            readonly CodeFeatureId _id;

            public FeatureState(CodeFeatureId id, bool enabled)
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