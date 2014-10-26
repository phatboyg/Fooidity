namespace Fooidity.Tests
{
    namespace ConfigurationFeatureState_Specs
    {
        using System;
        using Caching;
        using Configuration;
        using NUnit.Framework;


        struct Off :
            CodeFeature
        {            
        }


        struct On :
            CodeFeature
        {            
        }

        [TestFixture]
        public class Loading_the_configuration_state_from_the_app_config_file
        {
            CodeFeatureStateCache _featureCache;

            [TestFixtureSetUp]
            public void Setup()
            {
                var cacheProvider = new ConfigurationCodeFeatureStateCacheProvider();

                _featureCache = new CodeFeatureStateCache(cacheProvider);                
            }

            [Test]
            public void Should_read_the_default_feature_state()
            {
                CodeFeatureState featureState;
                Assert.IsTrue(_featureCache.TryGetState<On>(out featureState));

                Assert.IsTrue(featureState.Enabled);
            }

            [Test]
            public void Should_read_the_specified_feature_state()
            {

                CodeFeatureState featureState;
                Assert.IsTrue(_featureCache.TryGetState<Off>(out featureState));

                Assert.IsFalse(featureState.Enabled);
            }
        }
    }
}