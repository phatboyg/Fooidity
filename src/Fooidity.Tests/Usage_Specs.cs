namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class Using_the_fooidity_api
    {
        [Test]
        public void Should_allow_simple_creation_of_dependent_fooids()
        {
            FooId<A> a = FooIds.Enabled<A>();
            FooId<B> b = FooIds.Enabled<B>();
            ToggleFooId<C> c = FooIds.Toggle<C>();

            FooId<ABC> abc = FooIds.Dependent<ABC>(x => x.Upon(a, b, c));
            Assert.IsFalse(abc.Enabled);

            c.Enable();
            Assert.IsTrue(abc.Enabled);
        }


        struct A :
            FooId
        {
        }


        struct B :
            FooId
        {
        }


        struct C :
            FooId
        {
        }


        struct ABC :
            FooId
        {
        }
    }
}