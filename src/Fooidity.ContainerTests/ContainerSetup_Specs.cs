namespace Fooidity.ContainerTests
{
    using Autofac;
    using NUnit.Framework;


    [TestFixture]
    public class Setting_up_a_container
    {
        [Test]
        public void Should_support_delegate_registration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterEnabled<UseClassAV2>();

            builder.RegisterByFooId<UseClassAV2, A>(context => new ClassA_V2(), context => new ClassA())
                   .As<A>();

            IContainer container = builder.Build();

            var a = container.Resolve<A>();

            Assert.IsInstanceOf<ClassA_V2>(a);
        }

        [Test]
        public void Should_support_type_registration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterDisabled<UseClassAV2>();

            builder.RegisterByFooId<UseClassAV2, A, ClassA_V2, ClassA>();

            IContainer container = builder.Build();

            var a = container.Resolve<A>();

            Assert.IsInstanceOf<ClassA>(a);
        }


        interface A
        {
        }


        class ClassA :
            A
        {
        }


        class UseClassAV2 :
            FooId
        {
        }


        class ClassA_V2 :
            A
        {
        }
    }
}