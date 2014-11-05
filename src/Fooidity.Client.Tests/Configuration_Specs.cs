namespace Fooidity.Client.Tests
{
    using Autofac;
    using AutofacIntegration;
    using ClientSwitches;
    using NUnit.Framework;

    namespace ClientSwitches
    {
        public struct Feature_SupportSSL :
            ICodeFeature
        {
        }
    }


    [TestFixture, Explicit]
    public class Configuring_the_fooidity_client
    {
        [Test]
        public void Should_have_a_factory_syntax()
        {
            ICodeSwitch<Feature_SupportSSL> codeSwitch;
            Assert.IsTrue(_container.TryResolve(out codeSwitch));

            Assert.IsFalse(codeSwitch.Enabled);
        }

        IContainer _container;

        [TestFixtureSetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.ConfigureFoodityClient(x =>
            {
                x.Host("http://api.fooidity.com/");
                x.ApplicationKey("[need application id]");
            });

            builder.RegisterCodeSwitch<Feature_SupportSSL>();

            _container = builder.Build();
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}