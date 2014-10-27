namespace Fooidity.Configuration
{
    using System;
    using System.Configuration;
    using Caching;
    using Caching.Internals;


    public class ConfigurationCodeFeatureStateCacheProvider :
        ICodeFeatureStateCacheProvider
    {
        public ICodeFeatureStateCacheInstance Load()
        {
            var cache = new InMemoryCache<string, CodeFeatureState>();
            ICacheIndex<Type, CodeFeatureState> index = cache.GetIndex(x => x.FeatureType);
            bool defaultState = false;

            var configuration = ConfigurationManager.GetSection("fooidity") as FooidityConfiguration;
            if (configuration != null)
            {
                defaultState = configuration.DefaultState;

                if (configuration.Features != null)
                {
                    for (int i = 0; i < configuration.Features.Count; i++)
                    {
                        FeatureStateElement feature = configuration.Features[i];

                        Type codeFeatureType = null;
                        if (!string.IsNullOrWhiteSpace(feature.Type))
                        {
                            codeFeatureType = Type.GetType(feature.Type);
                            if (codeFeatureType == null)
                                throw new ConfigurationErrorsException("The feature type is not valid: " + feature.Type);
                        }

                        var state = new FeatureState(feature.Id, codeFeatureType, feature.Enabled);

                        cache.TryAdd(state.Id, state);
                    }
                }
            }

            return new CodeFeatureStateCacheInstance(cache, index, defaultState);
        }


        class FeatureState :
            CodeFeatureState
        {
            readonly bool _enabled;
            readonly Type _featureType;
            readonly string _id;

            public FeatureState(string id, Type featureType, bool enabled)
            {
                _enabled = enabled;
                _featureType = featureType;
                _id = id;
            }

            public string Id
            {
                get { return _id; }
            }

            public Type FeatureType
            {
                get { return _featureType; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}