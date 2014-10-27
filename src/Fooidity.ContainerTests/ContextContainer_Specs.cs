namespace Fooidity.ContainerTests
{
    using System;
    using Autofac;
    using Caching;
    using Configuration;
    using Contexts;
    using Features;
    using NUnit.Framework;


    [TestFixture]
    public class Configuring_the_container_for_user_contexts
    {
        [Test]
        public void Should_be_enabled_for_specified_user()
        {
            using (
                ILifetimeScope scope =
                    _container.BeginLifetimeScope(x => x.RegisterInstance(new UserContext {Name = "Chris"})))
            {
                var codeSwitch = scope.Resolve<CodeSwitch<UseNewCodePath>>();

                Assert.IsTrue(codeSwitch.Enabled);

                var tracker = scope.Resolve<CodeSwitchStateTracker>();

                foreach (var evaluated in tracker)
                {
                    Console.WriteLine("{0}: {1}", evaluated.Id, evaluated.Enabled);
                }
            }
        }

        [Test]
        public void Should_use_the_default_off_value()
        {
            using (
                ILifetimeScope scope =
                    _container.BeginLifetimeScope(x => x.RegisterInstance(new UserContext {Name = "David"})))
            {
                var codeSwitch = scope.Resolve<CodeSwitch<UseNewCodePath>>();

                Assert.IsFalse(codeSwitch.Enabled);

                var tracker = scope.Resolve<CodeSwitchStateTracker>();

                foreach (var evaluated in tracker)
                {
                    Console.WriteLine("{0}: {1}", evaluated.Id, evaluated.Enabled);
                }
            }
        }

        IContainer _container;

        [TestFixtureTearDown]
        public void Teardown()
        {
            _container.Dispose();
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ConfigurationCodeFeatureCacheModule>();

            builder.RegisterContextSwitch<UseNewCodePath, UserContext>();

            builder.EnableCodeSwitchTracker();

            _container = builder.Build();
        }


        class UserContextKeyProvider :
            ContextKeyProvider<UserContext>
        {
            public string GetKey(UserContext context)
            {
                return context.Name;
            }
        }


        class UseNewCodePathSwitch :
            ContextFeatureStateCodeSwitch<UseNewCodePath, UserContext>
        {
            public UseNewCodePathSwitch(ICodeFeatureStateCache cache,
                IContextFeatureStateCache<UserContext> contextCache, UserContext context)
                : base(cache, contextCache, context)
            {
            }
        }


        class ConfigurationCodeFeatureCacheModule :
            Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<CodeFeatureStateCache>()
                    .As<ICodeFeatureStateCache>()
                    .Named<IReloadCache>("codeFeatureCache")
                    .SingleInstance();

                builder.RegisterType<ConfigurationCodeFeatureStateCacheProvider>()
                    .As<ICodeFeatureStateCacheProvider>();

                builder.RegisterType<UserContextKeyProvider>()
                    .As<ContextKeyProvider<UserContext>>();


                builder.RegisterType<ContextFeatureStateCache<UserContext>>()
                    .As<IContextFeatureStateCache<UserContext>>()
                    .Named<IReloadCache>("contextFeatureCache")
                    .SingleInstance();

                builder.RegisterType<ConfigurationContextFeatureStateCacheProvider<UserContext>>()
                    .As<IContextFeatureStateCacheProvider<UserContext>>();
            }
        }
    }
}