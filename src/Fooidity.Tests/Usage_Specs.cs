namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class Using_the_fooidity_api
    {
        [Test]
        public void Should_allow_simple_creation_of_dependent_fooids()
        {
            CodeSwitch<A> a = CodeSwitch.Factory.Enabled<A>();
            CodeSwitch<B> b = CodeSwitch.Factory.Enabled<B>();
            IToggleCodeSwitch<C> c = CodeSwitch.Factory.Toggle<C>();

            CodeSwitch<ABC> abc = CodeSwitch.Factory.Dependent<ABC>(x => x.Upon(a, b, c));
            Assert.IsFalse(abc.Enabled);
        }

        [Test]
        public void Should_allow_simple_creation_of_dependent_fooids_enabled()
        {
            CodeSwitch<A> a = CodeSwitch.Factory.Enabled<A>();
            CodeSwitch<B> b = CodeSwitch.Factory.Enabled<B>();
            IToggleCodeSwitch<C> c = CodeSwitch.Factory.Toggle<C>(true);

            CodeSwitch<ABC> abc = CodeSwitch.Factory.Dependent<ABC>(x => x.Upon(a, b, c));
            Assert.IsTrue(abc.Enabled);
        }


        struct A :
            CodeFeature
        {
        }


        struct B :
            CodeFeature
        {
        }


        struct C :
            CodeFeature
        {
        }


        struct ABC :
            CodeFeature
        {
        }
    }
}