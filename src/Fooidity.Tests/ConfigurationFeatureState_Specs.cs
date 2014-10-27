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


        interface UserContext
        {
            string Name { get; }
        }


        class TestUserContext : 
            UserContext
        {
            readonly string _name;

            public TestUserContext(string name)
            {
                _name = name;
            }

            public string Name
            {
                get { return _name; }
            }
        }


        class UserContextKeyProvider :
            ContextKeyProvider<UserContext>
        {
            public string GetKey(UserContext context)
            {
                if (context == null)
                    throw new ArgumentNullException("context");

                return context.Name;
            }
        }


        [TestFixture]
        public class Loading_the_configuration_state_from_the_app_config_file
        {
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

            CodeFeatureStateCache _featureCache;

            [TestFixtureSetUp]
            public void Setup()
            {
                var cacheProvider = new ConfigurationCodeFeatureStateCacheProvider();

                _featureCache = new CodeFeatureStateCache(cacheProvider);
            }
        }


        [TestFixture]
        public class Overriding_configuration_state_by_user_context
        {
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

            [Test]
            public void Should_override_based_on_user_context()
            {
                CodeFeatureState featureState;
                Assert.IsTrue(_featureCache.TryGetState<Off>(out featureState));

                Assert.IsFalse(featureState.Enabled);

                var userContext = new TestUserContext("Chris");

                var codeSwitch = new ContextFeatureStateCodeSwitch<On, UserContext>(_featureCache, _userCache, userContext);

                Assert.IsFalse(codeSwitch.Enabled);
            }

            CodeFeatureStateCache _featureCache;
            ContextFeatureStateCache<UserContext> _userCache;

            [TestFixtureSetUp]
            public void Setup()
            {
                var cacheProvider = new ConfigurationCodeFeatureStateCacheProvider();

                _featureCache = new CodeFeatureStateCache(cacheProvider);

                var userCacheProvider = new ConfigurationContextFeatureStateCacheProvider<UserContext>();

                _userCache = new ContextFeatureStateCache<UserContext>(userCacheProvider, new UserContextKeyProvider());
            }
        }
    }
}