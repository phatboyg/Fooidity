namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class Using_the_fooidity_api
    {
        [Test]
        public void Should_allow_simple_creation_of_dependent_fooids()
        {
            CodeSwitch<A> a = CodeSwitch.Enabled<A>();
            CodeSwitch<B> b = CodeSwitch.Enabled<B>();
            ToggleCodeSwitch<C> c = CodeSwitch.Toggle<C>();

            CodeSwitch<ABC> abc = CodeSwitch.Dependent<ABC>(x => x.Upon(a, b, c));
            Assert.IsFalse(abc.Enabled);

            c.Enable();
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