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

            builder.RegisterEnabled<UseClassAv2>();

            builder.RegisterByFooId<UseClassAv2, A>(context => new ClassA_V2(), context => new ClassA())
                   .As<A>();

            IContainer container = builder.Build();

            var a = container.Resolve<A>();

            Assert.IsInstanceOf<ClassA_V2>(a);
        }

        [Test]
        public void Should_support_type_registration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterDisabled<UseClassAv2>();

            builder.RegisterByFooId<UseClassAv2, A, ClassA_V2, ClassA>();

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


        struct UseClassAv2 :
            CodeFeature
        {
        }


        class ClassA_V2 :
            A
        {
        }
    }
}