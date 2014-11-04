namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class Using_the_fooidity_api
    {
        [Test]
        public void Should_allow_simple_creation_of_dependent_fooids()
        {
            ICodeSwitch<A> a = CodeSwitch.Factory.Enabled<A>();
            ICodeSwitch<B> b = CodeSwitch.Factory.Enabled<B>();
            IToggleCodeSwitch<C> c = CodeSwitch.Factory.Toggle<C>();

            ICodeSwitch<ABC> abc = CodeSwitch.Factory.Dependent<ABC>(x => x.Upon(a, b, c));
            Assert.IsFalse(abc.Enabled);
        }

        [Test]
        public void Should_allow_simple_creation_of_dependent_fooids_enabled()
        {
            ICodeSwitch<A> a = CodeSwitch.Factory.Enabled<A>();
            ICodeSwitch<B> b = CodeSwitch.Factory.Enabled<B>();
            IToggleCodeSwitch<C> c = CodeSwitch.Factory.Toggle<C>(true);

            ICodeSwitch<ABC> abc = CodeSwitch.Factory.Dependent<ABC>(x => x.Upon(a, b, c));
            Assert.IsTrue(abc.Enabled);
        }


        struct A :
            ICodeFeature
        {
        }


        struct B :
            ICodeFeature
        {
        }


        struct C :
            ICodeFeature
        {
        }


        struct ABC :
            ICodeFeature
        {
        }
    }
}