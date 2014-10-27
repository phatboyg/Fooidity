namespace Fooidity.ContainerTests
{
    using System.Linq;
    using Autofac;
    using Features;
    using NUnit.Framework;
    using Subjects;


    [TestFixture]
    public class A_conditional_class_dependency
    {
        [Test]
        public void Should_use_the_new_methods()
        {
            var builder = new ContainerBuilder();

            builder.RegisterEnabled<UseNewMethod>();

            builder.RegisterType<ConditionalClass>();

            var container = builder.Build();

            var conditionalClass = container.Resolve<ConditionalClass>();

            Assert.AreEqual("V2: 42, Test", conditionalClass.FunctionCall(42, "Test"));
        }

        [Test]
        public void Should_use_the_old_methods()
        {
            var builder = new ContainerBuilder();

            builder.RegisterDisabled<UseNewMethod>();

            builder.RegisterType<ConditionalClass>();

            var container = builder.Build();

            var conditionalClass = container.Resolve<ConditionalClass>();

            Assert.AreEqual("Old: 42, Test", conditionalClass.FunctionCall(42, "Test"));
        }

        [Test]
        public void Should_use_the_old_methods_by_default()
        {
            var builder = new ContainerBuilder();

            builder.DisableCodeSwitchesByDefault();

            builder.RegisterType<ConditionalClass>();

            var container = builder.Build();

            var conditionalClass = container.Resolve<ConditionalClass>();

            Assert.AreEqual("Old: 42, Test", conditionalClass.FunctionCall(42, "Test"));
        }

        [Test]
        public void Should_use_the_new_methods_by_default()
        {
            var builder = new ContainerBuilder();

            builder.EnableCodeSwitchesByDefault();

            builder.RegisterType<ConditionalClass>();

            var container = builder.Build();

            var conditionalClass = container.Resolve<ConditionalClass>();

            Assert.AreEqual("V2: 42, Test", conditionalClass.FunctionCall(42, "Test"));
        }

        [Test]
        public void Should_be_able_to_enable_a_fooid_after_creation()
        {
            var builder = new ContainerBuilder();

            builder.RegisterDisabled<UseNewMethod>();

            builder.RegisterType<ConditionalClass>();

            var container = builder.Build();

            var conditionalClass = container.Resolve<ConditionalClass>();

            Assert.AreEqual("Old: 42, Test", conditionalClass.FunctionCall(42, "Test"));

            container.Enable<UseNewMethod>();

            conditionalClass = container.Resolve<ConditionalClass>();

            Assert.AreEqual("V2: 42, Test", conditionalClass.FunctionCall(42, "Test"));

        }

        [Test]
        public void Should_be_able_to_toggle_a_switch()
        {
            var builder = new ContainerBuilder();

            builder.RegisterToggle<UseNewMethod>();
            builder.EnableCodeSwitchTracking();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                Assert.IsFalse(scope.Resolve<CodeSwitch<UseNewMethod>>().Enabled);

                Assert.AreEqual(1, scope.GetCodeSwitchesEvaluated().Count());
            }

            container.Resolve<IToggleCodeSwitch<UseNewMethod>>().Enable();

            using (var scope = container.BeginLifetimeScope())
            {
                Assert.IsTrue(scope.Resolve<CodeSwitch<UseNewMethod>>().Enabled);

                Assert.AreEqual(1, scope.GetCodeSwitchesEvaluated().Count());
            }

        }
    }
}
