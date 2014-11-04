namespace Fooidity.ContainerTests.Defaults
{
    using Autofac;
    using NUnit.Framework;


    [TestFixture]
    public class When_creating_a_child_container_for_a_fooid
    {
        [Test]
        public void Should_keep_both_containers_separated_by_scope()
        {
            var builder = new ContainerBuilder();
            builder.RegisterSwitchedType<BigOn, A, BigA, LittleA>();
//            builder.RegisterType<DefaultDataProvider>()
//                .As<IDataProvider>()
//                .SingleInstance();
//
//            using (var container = builder.Build())
//            {
//                var provider = container.Resolve<IDataProvider>();
//                Assert.AreEqual("Default", provider.GetData());
//
//                var tenent = container.BeginLifetimeScope(x =>
//                    {
//                        x.RegisterType<UpperCaseDataTransformer>()
//                            .As<IDataTransformer>();
//                        x.RegisterType<CustomDataProvider>()
//                            .As<IDataProvider>()
//                            .SingleInstance();
//                    });
//
//                using(tenent)
//                {
//                    var custom = container.Resolve<IDataProvider>();
//                    Assert.AreEqual("Custom", custom.GetData());
//
//                    string upper = tenent.Resolve<IDataTransformer>().Transform("John");
//                    Assert.AreEqual("JOHN", upper);
//                }
//
//                string lower = container.Resolve<IDataTransformer>().Transform("John");
//                Assert.AreEqual("john", lower);
//            }
        }

        struct BigOn :
            ICodeFeature{}


        interface A
        {
        }


        class BigA : A
        {
        }

        class LittleA : A
        {
            
        }

    }
}
