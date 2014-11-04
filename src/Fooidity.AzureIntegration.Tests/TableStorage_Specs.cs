namespace Fooidity.AzureIntegration.Tests
{
    using System;
    using Caching;
    using Management;
    using Management.AzureIntegration;
    using Metadata;
    using NUnit.Framework;
    using Shouldly;


    [TestFixture, Explicit]
    public class TableStorage_Specs
    {
        [Test]
        public void Should_be_able_to_load_the_cache()
        {
            var codeFeatureStateCacheProvider = new CloudCodeFeatureStateCacheProvider(_tableProvider);

            _codeFeatureStateCache = new CodeFeatureStateCache(codeFeatureStateCacheProvider);

            _codeFeatureStateCache.ShouldNotBe(null);

            ICachedCodeFeatureState featureState;
            _codeFeatureStateCache.TryGetState<Feature_CreateUser>(out featureState).ShouldBe(true);

            featureState.ShouldNotBe(null);
            featureState.Enabled.ShouldBe(true);
        }

        [Test]
        public void Should_be_able_to_load_the_context_cache()
        {
            var contextFeatureStateCacheProvider = new CloudContextFeatureStateCacheProvider<UserContext>(_tableProvider);

            _contextFeatureStateCache = new ContextFeatureStateCache<UserContext>(contextFeatureStateCacheProvider,
                new UserContextKeyProvider());

            _contextFeatureStateCache.ShouldNotBe(null);
        }

        [Test]
        public async void Should_write_an_updated_code_feature_state()
        {
            var writer = new UpdateCodeFeatureStateCommandHandler(_tableProvider);

            var disabled = new Update(CodeFeatureMetadata<Feature_CreateUser>.Id, DateTime.UtcNow, false);

            await writer.Execute(disabled);

            var enabled = new Update(CodeFeatureMetadata<Feature_CreateUser>.Id, DateTime.UtcNow, true);

            await writer.Execute(enabled);
        }

        CodeFeatureStateCache _codeFeatureStateCache;
        ContextFeatureStateCache<UserContext> _contextFeatureStateCache;
        CloudTableProvider _tableProvider;
        ConfigurationCloudStorageAccountProvider _storageAccountProvider;

        [TestFixtureSetUp]
        public void Setup()
        {
            _storageAccountProvider = new ConfigurationCloudStorageAccountProvider("fooidity:Storage");
            _tableProvider = new CloudTableProvider(_storageAccountProvider, "test");
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
        }


        class Update :
            UpdateCodeFeatureState
        {
            readonly CodeFeatureId _codeFeatureId;
            readonly Guid _commandId;
            readonly bool _enabled;
            readonly Uri _environmentId;
            readonly Uri _organizationId;
            readonly DateTime _timestamp;

            public Update(CodeFeatureId codeFeatureId, DateTime timestamp, bool enabled, Uri organizationId = null, Uri environmentId = null,
                Guid? commandId = null)
            {
                _codeFeatureId = codeFeatureId;
                _commandId = commandId ?? Guid.NewGuid();
                _enabled = enabled;
                _organizationId = organizationId;
                _environmentId = environmentId;
                _timestamp = timestamp;
            }

            public Guid CommandId
            {
                get { return _commandId; }
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public CodeFeatureId CodeFeatureId
            {
                get { return _codeFeatureId; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }

            public Uri OrganizationId
            {
                get { return _organizationId; }
            }

            public Uri EnvironmentId
            {
                get { return _environmentId; }
            }
        }
    }


    public struct Feature_CreateUser :
        ICodeFeature
    {
    }


    public class UserContext
    {
        public string Name { get; set; }
    }


    public class UserContextKeyProvider :
        IContextKeyProvider<UserContext>
    {
        public string GetKey(UserContext context)
        {
            return context.Name;
        }
    }
}