namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class Using_the_fooidity_api
    {
        [Test]
        public void Should_allow_simple_creation_of_dependent_fooids()
        {
            FooId<A> a = default(A).Enabled();
            FooId<B> b = default(B).Enabled();
            FooId<C> c = default(C).Enabled();

            FooId<ABC> abc = default(ABC).Dependent(a, b, c);
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
            When<A>,
            When<B>,
            When<C>
        {
        }
    }
}