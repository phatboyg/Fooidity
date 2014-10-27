namespace Fooidity.Configuration
{
    using System;
    using System.Configuration;
    using Caching;
    using Metadata;


    public class ConfigurationContextFeatureStateCacheProvider<TContext> :
        IContextFeatureStateCacheProvider<TContext>
    {
        public IContextFeatureStateCacheInstance<TContext> Load()
        {
            var cache = new InMemoryCache<string, ContextFeatureState>();

            var configuration = ConfigurationManager.GetSection("fooidity") as FooidityConfiguration;
            if (configuration != null)
            {
                if (configuration.Contexts != null)
                {
                    for (int i = 0; i < configuration.Contexts.Count; i++)
                    {
                        ContextElement context = configuration.Contexts[i];

                        if (string.IsNullOrWhiteSpace(context.Type))
                            continue;

                        Type contextType = Type.GetType(context.Type);
                        if (contextType == null)
                            throw new ConfigurationErrorsException("The context type is not valid: " + context.Type);

                        if (contextType != typeof(TContext))
                            continue;

                        if (context.Instances != null)
                        {
                            for (int instanceIndex = 0; instanceIndex < context.Instances.Count; instanceIndex++)
                            {
                                ContextInstanceElement instance = context.Instances[instanceIndex];

                                var featureCache = new InMemoryCache<string, CodeFeatureState>();

                                if (instance.Features != null)
                                {
                                    for (int j = 0; j < instance.Features.Count; j++)
                                    {
                                        FeatureStateElement feature = instance.Features[j];

                                        Type codeFeatureType = null;
                                        if (!string.IsNullOrWhiteSpace(feature.Type))
                                        {
                                            codeFeatureType = Type.GetType(feature.Type);
                                            if (codeFeatureType == null)
                                            {
                                                throw new ConfigurationErrorsException("The feature type is not valid: "
                                                                                       + feature.Type);
                                            }
                                        }

                                        var codeState = new CodeFeatureStateImpl(feature.Id, codeFeatureType,
                                            feature.Enabled);

                                        featureCache.TryAdd(codeState.Id, codeState);
                                    }
                                }

                                var state = new ContextFeatureStateImpl(instance.Key, featureCache);

                                cache.TryAdd(state.Key, state);
                            }
                        }
                    }
                }
            }

            return new ContextFeatureStateCacheInstance<TContext>(cache);
        }


        class CodeFeatureStateImpl :
            CodeFeatureState
        {
            readonly bool _enabled;
            readonly Type _featureType;
            readonly string _id;

            public CodeFeatureStateImpl(string id, Type featureType, bool enabled)
            {
                _enabled = enabled;
                _featureType = featureType;
                _id = id;
            }

            public Type FeatureType
            {
                get { return _featureType; }
            }

            public string Id
            {
                get { return _id; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }


        class ContextFeatureStateImpl :
            ContextFeatureState
        {
            readonly IReadOnlyCache<string, CodeFeatureState> _cache;
            readonly string _key;

            public ContextFeatureStateImpl(string key, IReadOnlyCache<string, CodeFeatureState> cache)
            {
                _key = key;
                _cache = cache;
            }

            public string Key
            {
                get { return _key; }
            }

            public bool TryGetFeature<TFeature>(out CodeFeatureState featureState)
            {
                return _cache.TryGet(CodeFeatureMetadata<TFeature>.Id, out featureState);
            }
        }
    }
}