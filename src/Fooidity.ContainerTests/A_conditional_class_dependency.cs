namespace Fooidity.ContainerTests
{
    using Autofac;
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

            builder.CodeSwitchesDisabledByDefault();

            builder.RegisterType<ConditionalClass>();

            var container = builder.Build();

            var conditionalClass = container.Resolve<ConditionalClass>();

            Assert.AreEqual("Old: 42, Test", conditionalClass.FunctionCall(42, "Test"));
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
    }
}
