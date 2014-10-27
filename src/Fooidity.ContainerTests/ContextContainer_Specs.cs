namespace Fooidity.ContainerTests
{
    using System;
    using System.Collections.Generic;
    using Autofac;
    using Autofac.Core;
    using AutofacIntegration;
    using Contexts;
    using Events;
    using Features;
    using NUnit.Framework;


    [TestFixture]
    public class Configuring_the_container_for_user_contexts
    {
        [Test]
        public void No_context_should_throw_the_proper_exception()
        {
            var exception = Assert.Throws<DependencyResolutionException>(() =>
            {
                using (ILifetimeScope scope = _container.BeginLifetimeScope())
                {
                    var codeSwitch = scope.Resolve<CodeSwitch<UseNewCodePath>>();
                }
            });

            Assert.IsInstanceOf<ContextSwitchException>(exception.InnerException);
        }

        [Test]
        public void Should_be_enabled_for_specified_user()
        {
            using (
                ILifetimeScope scope =
                    _container.BeginLifetimeScope(x => x.RegisterInstance(new UserContext {Name = "Chris"})))
            {
                var codeSwitch = scope.Resolve<CodeSwitch<UseNewCodePath>>();

                Assert.IsTrue(codeSwitch.Enabled);

                var repository = scope.Resolve<Repository>();

                Assert.AreEqual("No", repository.IsDbEnabled);

                IEnumerable<CodeSwitchEvaluated> codeSwitchesEvaluated = scope.GetCodeSwitchesEvaluated();

                foreach (CodeSwitchEvaluated evaluated in codeSwitchesEvaluated)
                    Console.WriteLine("{0}: {1}", evaluated.Id, evaluated.Enabled);
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

                IEnumerable<CodeSwitchEvaluated> codeSwitchesEvaluated = scope.GetCodeSwitchesEvaluated();

                foreach (CodeSwitchEvaluated evaluated in codeSwitchesEvaluated)
                    Console.WriteLine("{0}: {1}", evaluated.Id, evaluated.Enabled);
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
            builder.RegisterModule<ConfigurationContextFeatureCacheModule<UserContext, UserContextKeyProvider>>();

            builder.RegisterCodeSwitch<DbEnabled>();
            builder.RegisterContextSwitch<UseNewCodePath, UserContext>();

            builder.EnableCodeSwitchTracking();

            builder.RegisterType<Repository>();

            _container = builder.Build();
        }


        class Repository
        {
            readonly CodeSwitch<DbEnabled> _dbEnabled;

            public Repository(CodeSwitch<DbEnabled> dbEnabled)
            {
                _dbEnabled = dbEnabled;
            }

            public string IsDbEnabled
            {
                get { return _dbEnabled.Enabled ? "Yes" : "No"; }
            }
        }
    }
}