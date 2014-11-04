namespace Fooidity.ContainerTests.Defaults
{
    using Autofac;
    using NUnit.Framework;


    [TestFixture]
    public class A_default_disabled_foodid
    {
        [Test]
        public void Should_return_as_default()
        {
            var builder = new ContainerBuilder();

            builder.CodeSwitchesDisabledbyDefault();

            IContainer container = builder.Build();

            var fooId = container.Resolve<ICodeSwitch<Active>>();

            Assert.IsFalse(fooId.Enabled);
        }

        [Test]
        public void Should_return_as_specific()
        {
            var builder = new ContainerBuilder();

            builder.CodeSwitchesDisabledbyDefault();

            builder.RegisterCodeSwitchEnabled<Active>();

            IContainer container = builder.Build();

            var fooId = container.Resolve<ICodeSwitch<Active>>();

            Assert.IsTrue(fooId.Enabled);
        }

        [Test]
        public void Should_convert_to_specific()
        {
            var builder = new ContainerBuilder();

            builder.CodeSwitchesDisabledbyDefault();

            IContainer container = builder.Build();

            var fooId = container.Resolve<ICodeSwitch<Active>>();

            Assert.IsFalse(fooId.Enabled);

            container.EnableCodeSwitch<Active>();

            fooId = container.Resolve<ICodeSwitch<Active>>();

            Assert.IsTrue(fooId.Enabled);
        }


        struct Active :
            ICodeFeature
        {
        }
    }
}